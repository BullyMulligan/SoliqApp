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
        private Automatic test;
        public Form1()
        {
            InitializeComponent();
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
        void FillTable(DataGridView table,List <Automatic.Check> checks)
        {
            table.Rows.Clear();
            table.Refresh();
            for (int i = 0; i < checks.Count; i++)
            {
                DataGridViewRow row = (DataGridViewRow)table.Rows[0].Clone();
                row.Cells[0].Value = checks[i].id;
                row.Cells[1].Value = checks[i].product[0].psic;
                row.Cells[2].Value = checks[i].status;
                table.Rows.Add(row);
            }
            
            labelCountChecksSoliq.Text = $"Количество чеков: {checks.Count}";
        }

        //*********************************************Soliq********************************************
        
        //ивент включается при нажатии кнопки OpenJson
        private void buttonOpenJsonMySoliq_Click(object sender, EventArgs e)
        {
            soliq._checks = new List<Automatic.Check>();
            openFileJson.ShowDialog();
            soliq._checks = OpenJsonFile(soliq._checks);
            soliq.CheckCountingSoliq();
            FillTable(tableSoliq,soliq._checks);
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
            switch (comboBoxCheckListSoliq.SelectedIndex)
            {
                case 0 :
                    soliq.selectedList = soliq._checks;
                    break;
                case 1 :
                    soliq.selectedList = soliq._successStatus;
                    break;
                case 2 :
                    soliq.selectedList = soliq._notFoundPsicStatus;
                    break;
                case 3 :
                    soliq.selectedList = soliq._notSuccessStatus;
                    break;
                case 4 :
                    soliq.selectedList = soliq._nullStatus;
                    break;
            }
            FillTable(tableSoliq,soliq.selectedList);
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
            test = new Automatic(soliq._checks, info);
            try
            {
                test.MySoligUniversal();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Ошибка при выполнении функций Selenium");
            }
            if(checkedListSoliq.GetItemChecked(1)){SaveBackupOrDone(test.checks, "");}
            if(checkedListSoliq.GetItemChecked(1)){SaveBackupOrDone(test.checks, "done");}
        }

        //*********************************************TasnifDataBase********************************************
        
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            dataBase = new DBpsic(fieldDataBase.Text, fieldLocalHost.Text, fieldUserID.Text, fieldPassword.Text);
            dataBase.AddMySQLConnection();
            
        }
    }
}