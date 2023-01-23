using System.Collections.Generic;
using System.Linq;

namespace SoliqApp
{
    public class Soliq
    {
        public string nameJson;

        public List<Automatic.Check> _checks = new List<Automatic.Check>();

        public List<Automatic.Check> selectedList = new List<Automatic.Check>();
        //поля с сортированными чеками
        public List<Automatic.Check> _nullStatus = new List<Automatic.Check>();
        public List<Automatic.Check> _successStatus = new List<Automatic.Check>();
        public List<Automatic.Check> _notSuccessStatus = new List<Automatic.Check>();
        public List<Automatic.Check> _notFoundPsicStatus = new List<Automatic.Check>();
        
        public void CheckCounting()//Пересчет количества отображаемых чеков
        {
            //создаем списки с чеками разных статусов
            _nullStatus =_checks.Where(i => i.status == "").ToList();
            _successStatus = _checks.Where(i => i.status == "1").ToList();
            _notSuccessStatus =_checks.Where(i => i.status != "1").ToList();
            _notFoundPsicStatus = _checks.Where(i => i.status =="2").ToList();
        }
        public void SwitchSelectList(int index)
        {
            switch (index)
            {
                case 0:
                    selectedList= _checks;
                    break;
                case 1:
                    selectedList = _successStatus;
                    break;
                case 2:
                    selectedList = _notFoundPsicStatus;
                    break;
                case 3:
                    selectedList = _notSuccessStatus;
                    break;
                case 4:
                    selectedList = _nullStatus;
                    break;
            }
        }
    }
}