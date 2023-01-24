using System.Collections.Generic;
using System.Data;
using System.Linq;
using MySql.Data.MySqlClient;

namespace SoliqApp
{
    public class DBpsic
    {
        private string _database;
        private string _localhost;
        private string _userId;
        private string _password;

        public MySqlConnection _connection;
        private MySqlDataReader reader;

        public List<Automatic.PsicCategory> selectedCheckList;
        public List<Automatic.PsicCategory> checksList;
        public List<Automatic.PsicCategory> successCheckList;
        public List<Automatic.PsicCategory> notSuccessCheckList;
        public List<Automatic.PsicCategory> nullCheckList;

        public DBpsic(string database, string localhost, string userId, string password)
        {
            _database = database;
            _localhost = localhost;
            _userId = userId;
            _password = password;
        }
        
        public void AddMySQLConnection()
        {
            MySqlConnectionStringBuilder connBuilder = new MySqlConnectionStringBuilder();
            connBuilder.Add("Server", _database);
            connBuilder.Add("DataBase", _localhost);
            connBuilder.Add("Uid", _userId);
            connBuilder.Add("pwd", _password);

            _connection = new MySqlConnection(connBuilder.ConnectionString);
        }

        public void GetComand(string comandText)
        {
            MySqlCommand cmd = _connection.CreateCommand();
            cmd.CommandText = comandText;
            cmd.CommandType = CommandType.Text;

            reader = cmd.ExecuteReader();
        }

        public void StringBDInArray()
        {
            checksList = new List<Automatic.PsicCategory>();
            while (reader.Read())
            {
                Automatic.PsicCategory check = new Automatic.PsicCategory();
                check.id = reader.GetString(0);
                check.psic_code = reader.GetString(1);
                if (reader.GetValue(2)!=null)//проверяем, если стринг пустой
                {
                    check.psic_text = reader.GetValue(2).ToString();
                }
                else
                {
                    check.psic_code = "";
                }
                checksList.Add(check);
            }

            selectedCheckList = checksList;
            reader.Close();
        }
        
        public void OpenConnection()
        {
            AddMySQLConnection();
            _connection.Open();
        }

        public void CloseConection()
        {
            _connection.Close();
        }
        //создаем листы чеков по статусам
        public void CheckCounting()
        {
            StringBDInArray();
            successCheckList = checksList.Where(i => i.status == 1).ToList();
            nullCheckList = checksList.Where(i => i.status == 0).ToList();
            notSuccessCheckList = checksList.Where(i => i.status != 1).ToList();
        }

        public void SwitchSelectList(int index)
        {
            switch (index)
            {
                case 0:
                    selectedCheckList = checksList;
                    break;
                case 1:
                    selectedCheckList = successCheckList;
                    break;
                case 2:
                    selectedCheckList = notSuccessCheckList;
                    break;
                case 3:
                    selectedCheckList = nullCheckList;
                    break;
            }
        }
        
    }


    
    
    
}