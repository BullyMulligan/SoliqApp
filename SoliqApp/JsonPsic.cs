using System.Collections.Generic;
using System.Linq;

namespace SoliqApp
{
    public class JsonPsic
    {
        public string nameJson;

        public List<Automatic.Check> _checks = new List<Automatic.Check>();
        
        //поля с сортированными чеками
        private List<Automatic.Check> _nullStatus = new List<Automatic.Check>();
        private List<Automatic.Check> _successStatus = new List<Automatic.Check>();
        private List<Automatic.Check> _notSuccessStatus = new List<Automatic.Check>();
        private List<Automatic.Check> _notFoundPsicStatus = new List<Automatic.Check>();
        
        private void CheckCountingSoliq()//Пересчет количества отображаемых чеков
        {
            //создаем списки с чеками разных статусов
            _nullStatus =_checks.Where(i => i.status == "").ToList();
            _successStatus = _checks.Where(i => i.status == "1").ToList();
            _notSuccessStatus =_checks.Where(i => i.status != "1").ToList();
            _notFoundPsicStatus = _checks.Where(i => i.status.Contains("2")).ToList();
        }
    }
}