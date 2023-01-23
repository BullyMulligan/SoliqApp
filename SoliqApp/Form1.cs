using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using MySql.Data.MySqlClient;
using NUnit.Framework.Internal;

namespace SoliqApp
{
    public partial class Form1 : Form
    {
        private DBpsic dataBase;
        private Soliq soliq = new Soliq();
        private JsonPsic jsonPsic;
        private Automatic testSoliq;
        private Automatic testTasnifBD;
        public Form1()
        {
            InitializeComponent();
            buttonConnect.BackColor = SystemColors.Info;
        }
        
        T OpenJsonFile<T>(T checks)
        {
            using (StreamReader r = new StreamReader(openFileJson.OpenFile()))//преобразуем его в стринг
            {
                string json = r.ReadToEnd();
                checks = JsonConvert.DeserializeObject<T>(json);//сериализация джейсона в массив чеков
                return checks;
            }
            
        }
        
        //метод для сохранения массива в джейсон
        private void SaveJsonFileSoliq<T>(T checks) 
        {
            saveDialogJson.ShowDialog();
            string json = JsonConvert.SerializeObject(checks);
            File.WriteAllText(saveDialogJson.FileName+".json", json);
        }

        //метод для сохранения бэкапа или пройденного файла
        private void SaveBackupOrDone<T>(T checks, string sername)
        {
            string json = JsonConvert.SerializeObject(checks);
            File.WriteAllText($"{openFileJson.FileName.Replace(".json","")}{sername}.json", json);
        }

        //метод заполнения таблицы
        void FillTable<T>(DataGridView table,List <T> checks)
        {
            table.Rows.Clear();
            table.Refresh();
            if (checks!=null)
            {
                for (int i = 0; i < checks.Count; i++)
                {
                    DataGridViewRow row = (DataGridViewRow)table.Rows[0].Clone();
                    if (table==tableSoliq)
                    {
                        row.Cells[0].Value = soliq.selectedList[i].id;
                        row.Cells[1].Value = soliq.selectedList[i].product[0].psic;
                        row.Cells[2].Value = soliq.selectedList[i].status;
                        labelCountChecksSoliq.Text = $"Количество чеков: {checks.Count}";
                    }

                    if (table==tableTasnifDataBase)
                    {
                        row.Cells[0].Value = dataBase.selectedChecks[i].id;
                        row.Cells[1].Value = dataBase.selectedChecks[i].psic_code;
                        row.Cells[2].Value = dataBase.selectedChecks[i].psic_text;
                        labelCheckCountTasnifDB.Text = $"Количество чеков: {checks.Count}";
                    }
                    table.Rows.Add(row);
                }
                
            }
            
            
            
        }

        //*********************************************Soliq********************************************
        
        //ивент включается при нажатии кнопки OpenJson
        private void buttonOpenJsonMySoliq_Click(object sender, EventArgs e)
        {
            soliq._checks = new List<Automatic.Check>();
            openFileJson.ShowDialog();
            soliq._checks = OpenJsonFile(soliq._checks);
            soliq.selectedList = soliq._checks;
            soliq.CheckCountingSoliq();
            FillTable(tableSoliq,soliq.selectedList);
        }

        //ивент включается при выборе ячйки внутри таблицы
        private void tableSoliq_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //если выбранная ячейка лежит внутри второй колонки, то выполняем API-запрос и выводим информацию о продукте
                if (e.ColumnIndex==1)
                {
                    var senderGrid = (DataGridView)sender;
                    WebRequest request = new WebRequest();
                    var cell = senderGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    request.GetPsicInfo(cell);
                    if (request._psicInfo.data.content.Length>0)
                    {
                        labelProductInfoSoliq.Text = $"Product: {request._psicInfo.data.content[0].attributeName}";
                    }
                    else
                    {
                        labelProductInfoSoliq.Text = "ИКПУ отсутствует в базе Tasnif";
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Сначала загрузите данные");
            }
        }

        //при изменении значения в комбобоксе меняем выбранный лист чеков
        private void comboBoxCheckListSoliq_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combobox = (ComboBox)sender;
            if (combobox == comboBoxCheckListSoliq)
            {
                soliq.SwitchSelectList(comboBoxCheckListSoliq.SelectedIndex);
                FillTable(tableSoliq,soliq.selectedList);
            }

            if (combobox == comboBoxListChecksTasnifDB)
            {
                dataBase.SwitchSelectList(comboBoxListChecksTasnifDB.SelectedIndex);
                FillTable(tableTasnifDataBase,dataBase.selectedChecks);
            }
            
        }

        

        private void buttonLoadPDF_Click(object sender, EventArgs e)
        {
            DialogResult res = openDialogPDF.ShowDialog();
            if (res == DialogResult.OK)
            {
                buttonStartSoliq.Visible = true;
            }
        }

        //ивент вызывается при нажатии на кнопку "Start"
        private void buttonStartSoliq_Click(object sender, EventArgs e)
        {
            if (checkedListSoliq.GetItemChecked(2)){SaveBackupOrDone(soliq._checks, "backup");}
            Automatic.InfoAboutMethod info = new Automatic.InfoAboutMethod(comboBoxCheckListSoliq.SelectedIndex,
                checkedListSoliq.GetItemChecked(1), openDialogPDF.FileName);
            testSoliq = new Automatic(soliq._checks, info);
            try
            {
                testSoliq.MySoligUniversal();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Ошибка при выполнении функций Selenium");
            }
            if(checkedListSoliq.GetItemChecked(1)){SaveBackupOrDone(testSoliq.checks, "");}
            if(checkedListSoliq.GetItemChecked(1)){SaveBackupOrDone(testSoliq.checks, "done");}
        }

        //*********************************************TasnifDataBase********************************************

        void CheckStatusConnection()
        {
            if (dataBase._connection.Ping())
            {
                buttonOpenConnectDB.Text = $"Connected to {fieldLocalHost.Text}";
                buttonOpenConnectDB.BackColor = Color.Chartreuse;
                buttonResponse.BackColor=Color.Chartreuse;
            }
            else
            {
                buttonOpenConnectDB.Text = $"Connecte to DataBase";
                buttonOpenConnectDB.BackColor = Color.Salmon;
                buttonResponse.BackColor=Color.Salmon;
            }
        }
        //ивент вызывается при нажатии на кнопку "Connect"
        private void buttonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                dataBase = new DBpsic("10.20.33.5", "paym_eva", "dev-base", "Xe3nQx287");
                dataBase.AddMySQLConnection();
                dataBase.OpenConnection();
                CheckStatusConnection();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Ошибка!",exception.Message);
            }
        }

        //ивент запускается при клике кнопки "Response"
        private void buttonResponse_Click(object sender, EventArgs e)
        {
            try
            {
                dataBase.GetComand(fieldResponse.Text);
                dataBase.CreateListsOfCheck();
                dataBase.CloseConection();
                CheckStatusConnection();
                
                FillTable(tableTasnifDataBase,dataBase.selectedChecks);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Подключитесь к базе!");
                throw;
            }
            
        }

        private void buttonStartTasnifDB_Click(object sender, EventArgs e)
        {
            if (checkedListTasnifDataBase.GetItemChecked(1)){ SaveJsonFileSoliq(dataBase._checks);}
            testTasnifBD = new Automatic(dataBase._checks);
            try
            {
                testTasnifBD.TasnifChangePSIC();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            if (checkedListTasnifDataBase.GetItemChecked(0)){SaveJsonFileSoliq(dataBase._checks);}
        }
        //******************************************TasnifJson*******************************************
        private void buttonOpenJson_Click(object sender, EventArgs e)
        {
            jsonPsic = new JsonPsic();
            openFileJson.ShowDialog();
            jsonPsic._checks = OpenJsonFile(jsonPsic._checks);
            jsonPsic.CheckCountingSoliq();
            FillTable(tableJsonTasnif,dataBase.selectedChecks);
        }

        
    }
}