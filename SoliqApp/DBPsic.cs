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

        public List<DBCheck> selectedChecks;
        public List<DBCheck> _checks;
        public List<DBCheck> statusSuccess;
        public List<DBCheck> statusNotSuccess;
        public List<DBCheck> statusNull;

        public DBpsic(string database, string localhost, string userId, string password)
        {
            _database = database;
            _localhost = localhost;
            _userId = userId;
            _password = password;
        }
        public class DBCheck
        {
            public string id { get; set; }
            public string psic_code { get; set; }
            public string psic_text { get; set; }
            public int status { get; set; }
            public string new_psic { get; set; }
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
            _checks = new List<DBCheck>();
            while (reader.Read())
            {
                DBCheck check = new DBCheck();
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
                _checks.Add(check);
            }

            selectedChecks = _checks;
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
            statusSuccess = _checks.Where(i => i.status == 1).ToList();
            statusNull = _checks.Where(i => i.status == 0).ToList();
            statusNotSuccess = _checks.Where(i => i.status != 1).ToList();
        }

        public void SwitchSelectList(int index)
        {
            switch (index)
            {
                case 0:
                    selectedChecks = _checks;
                    break;
                case 1:
                    selectedChecks = statusSuccess;
                    break;
                case 2:
                    selectedChecks = statusNotSuccess;
                    break;
                case 3:
                    selectedChecks = statusNull;
                    break;
            }
        }
        
    }


    
    
    
}