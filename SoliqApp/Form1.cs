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
        private Category psicAdd;
        private Automatic testSoliq;
        private Automatic testTasnifBD;
        private Automatic testJsonTasnif;
        private Automatic testAddPsic;
        
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
                        row.Cells[0].Value = soliq.selectedCheckList[i].id;
                        row.Cells[1].Value = soliq.selectedCheckList[i].product[0].psic;
                        row.Cells[2].Value = soliq.selectedCheckList[i].status;
                        
                    }

                    if (table==tableTasnifDataBase)
                    {
                        row.Cells[0].Value = dataBase.selectedCheckList[i].id;
                        row.Cells[1].Value = dataBase.selectedCheckList[i].psic_code;
                        row.Cells[2].Value = dataBase.selectedCheckList[i].psic_text;
                        
                    }

                    if (table==tableJsonTasnif)
                    {
                        row.Cells[0].Value = i + 1;
                        row.Cells[1].Value = jsonPsic.selectedCheckList[i].psic_code;
                        row.Cells[2].Value = jsonPsic.selectedCheckList[i].status;
                        
                    }
                    if (table==tableAdd)
                    {
                        row.Cells[0].Value = i+1;
                        row.Cells[1].Value = psicAdd.selectedCheckList[i].psic_code;
                        row.Cells[2].Value = psicAdd.selectedCheckList[i].status;

                    }
                    table.Rows.Add(row);
                }

                if (table==tableSoliq){labelCountChecksSoliq.Text = $"Количество чеков: {checks.Count}";}
                if (table==tableTasnifDataBase){labelCheckCountTasnifDB.Text = $"Количество чеков: {checks.Count}";}
                if (table==tableJsonTasnif){labelCheckCountJsonTasnif.Text = $"Количество чеков: {checks.Count}";}
                if (table==tableAdd){labelCountListAdd.Text = $"Количество чеков: {checks.Count}";}
            }
        }

        //*********************************************Soliq********************************************
        
        //ивент включается при нажатии кнопки OpenJson
        private void buttonOpenJsonMySoliq_Click(object sender, EventArgs e)
        {
            soliq.сheckList = new List<Automatic.Check>();
            openFileJson.ShowDialog();
            soliq.сheckList = OpenJsonFile(soliq.сheckList);
            soliq.selectedCheckList = soliq.сheckList;
            soliq.CheckCounting();
            FillTable(tableSoliq,soliq.selectedCheckList);
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
                        switch (sender==tableSoliq)
                        {
                            case true:
                                labelProductInfoSoliq.Text = $"Product: {request._psicInfo.data.content[0].attributeName}";
                                break;
                            case false:
                                labelProductInfoJsonTasnif.Text = $"Product: {request._psicInfo.data.content[0].attributeName}";
                                break;
                        }
                    }
                    else
                    {
                        switch (sender==tableSoliq)
                        {
                            case true:
                                labelProductInfoSoliq.Text = "ИКПУ отсутствует в базе Tasnif";
                                break;
                            case false:
                                labelProductInfoJsonTasnif.Text = "ИКПУ отсутствует в базе Tasnif";
                                break;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Сначала загрузите данные");
            }
        }

        //при изменении значения в комбобоксе меняем выбранный лист чеков
        private void comboBoxChanged(object sender, EventArgs e)
        {
            ComboBox combobox = (ComboBox)sender;
            if (combobox == comboBoxCheckListSoliq)
            {
                soliq.SwitchSelectList(comboBoxCheckListSoliq.SelectedIndex);
                FillTable(tableSoliq,soliq.selectedCheckList);
            }
            if (combobox == comboBoxListChecksTasnifDB)
            {
                dataBase.SwitchSelectList(comboBoxListChecksTasnifDB.SelectedIndex);
                FillTable(tableTasnifDataBase,dataBase.selectedCheckList);
            }
            if (combobox == comboBoxSelectChecsJsonTasnif)
            {
                jsonPsic.SwitchSelectList(comboBoxSelectChecsJsonTasnif.SelectedIndex);
                FillTable(tableJsonTasnif,jsonPsic.selectedCheckList);
                
            }
            if (combobox == comboBoxAdd)
            {
                psicAdd.SwitchSelectList(comboBoxAdd.SelectedIndex);
                FillTable(tableAdd,psicAdd.selectedCheckList);
                
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
            if (checkedListSoliq.GetItemChecked(2)){SaveBackupOrDone(soliq.сheckList, "backup");}
            Automatic.InfoAboutMethod info = new Automatic.InfoAboutMethod(comboBoxCheckListSoliq.SelectedIndex,
                checkedListSoliq.GetItemChecked(1), openDialogPDF.FileName);
            testSoliq = new Automatic(soliq.сheckList, info);
            try
            {
                testSoliq.MySoligUniversal();
                soliq.сheckList = testSoliq.checks;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Ошибка при выполнении функций Selenium");
            }
            if(checkedListSoliq.GetItemChecked(1)){SaveBackupOrDone(testSoliq.checks, "");}
            if(checkedListSoliq.GetItemChecked(1)){SaveBackupOrDone(testSoliq.checks, "done");}
            //пересчитываем число пройденных чеков и обновляем их количество в лейбле
            soliq.CheckCounting();
            soliq.SwitchSelectList(comboBoxListChecksTasnifDB.SelectedIndex);
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
                dataBase = new DBpsic(fieldDataBase.Text, fieldLocalHost.Text, fieldUserID.Text, fieldPassword.Text);
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
                dataBase.CheckCounting();
                dataBase.CloseConection();
                CheckStatusConnection(); 
                FillTable(tableTasnifDataBase,dataBase.selectedCheckList);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Подключитесь к базе!");
                throw;
            }
            
        }

        private void buttonStartTasnifDB_Click(object sender, EventArgs e)
        {
            if (checkedListTasnifDataBase.GetItemChecked(1)){ SaveJsonFileSoliq(dataBase.checksList);}
            testTasnifBD = new Automatic(dataBase.checksList);
            try
            {
                testTasnifBD.TasnifChangePSIC();
                dataBase.checksList = testTasnifBD.psics;
            }
            catch (Exception exception)
            {
                
            }
            if (checkedListTasnifDataBase.GetItemChecked(0)){SaveJsonFileSoliq(dataBase.checksList);}
            dataBase.CheckCounting();
            dataBase.SwitchSelectList(comboBoxListChecksTasnifDB.SelectedIndex);
        }
        //******************************************TasnifJson*******************************************
        private void buttonOpenJson_Click(object sender, EventArgs e)
        {
            jsonPsic = new JsonPsic();
            openFileJson.ShowDialog();
            jsonPsic.сheckList = OpenJsonFile(jsonPsic.сheckList);
            jsonPsic.CheckCounting();
            jsonPsic.SwitchSelectList(comboBoxSelectChecsJsonTasnif.SelectedIndex);
            
            FillTable(tableJsonTasnif,jsonPsic.selectedCheckList);
        }

        //ивент вызывается при нажатии на кнопку Start
        private void buttonJsonTasnif_Click(object sender, EventArgs e)
        {
            if (checkedListJsonTasnif.GetItemChecked(1)){SaveBackupOrDone(jsonPsic.сheckList,"_backup");}
            testJsonTasnif = new Automatic(jsonPsic.сheckList);
            try
            {
                testJsonTasnif.TasnifChangePSIC();
                jsonPsic.сheckList = testJsonTasnif.psics;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            if (checkedListJsonTasnif.GetItemChecked(0)){SaveBackupOrDone(jsonPsic.сheckList,"");}
            if (checkedListJsonTasnif.GetItemChecked(2)){SaveBackupOrDone(jsonPsic.сheckList,"_done");}
            jsonPsic.CheckCounting();
            jsonPsic.SwitchSelectList(comboBoxSelectChecsJsonTasnif.SelectedIndex);
        }

        private void buttonOpenJsonAddCategory_Click(object sender, EventArgs e)
        {
            psicAdd = new Category();
            openFileJson.ShowDialog();
            psicAdd.checkList = OpenJsonFile(psicAdd.checkList);
            psicAdd.CheckCounting();
            psicAdd.SwitchSelectList(comboBoxAdd.SelectedIndex);
            FillTable(tableAdd,psicAdd.selectedCheckList);
        }
        
        private void buttonStartAdd_Click(object sender, EventArgs e)
        {
            if (checkedListAdd.GetItemChecked(1)){SaveBackupOrDone(psicAdd.checkList,"_backup");}
            testAddPsic = new Automatic(psicAdd.checkList);
            try
            {
                testAddPsic.Tasnif();
                psicAdd.checkList=testAddPsic.psics;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }

            if (checkedListAdd.GetItemChecked(0)){SaveBackupOrDone(psicAdd.checkList,"");}
            if (checkedListAdd.GetItemChecked(2)){SaveBackupOrDone(psicAdd.checkList,"_done");}
        }
    }
}