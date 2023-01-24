using System.Collections.Generic;
using System.Linq;

namespace SoliqApp
{
    public class Soliq
    {
        public List<Automatic.Check> сheckList = new List<Automatic.Check>();

        public List<Automatic.Check> selectedCheckList = new List<Automatic.Check>();
        //поля с сортированными чеками
        public List<Automatic.Check> nullCheckList = new List<Automatic.Check>();
        public List<Automatic.Check> successCheckList = new List<Automatic.Check>();
        public List<Automatic.Check> notSuccessCheckList = new List<Automatic.Check>();
        public List<Automatic.Check> notFoundPsicCheckList = new List<Automatic.Check>();
        
        public void CheckCounting()//Пересчет количества отображаемых чеков
        {
            //создаем списки с чеками разных статусов
            nullCheckList =сheckList.Where(i => i.status == "").ToList();
            successCheckList = сheckList.Where(i => i.status == "Success").ToList();
            notSuccessCheckList =сheckList.Where(i => i.status != "Success").ToList();
            notFoundPsicCheckList = сheckList.Where(i => i.status.Contains("psic")).ToList();
        }
        public void SwitchSelectList(int index)
        {
            switch (index)
            {
                case 0:
                    selectedCheckList= сheckList;
                    break;
                case 1:
                    selectedCheckList = successCheckList;
                    break;
                case 2:
                    selectedCheckList = notFoundPsicCheckList;
                    break;
                case 3:
                    selectedCheckList = notSuccessCheckList;
                    break;
                case 4:
                    selectedCheckList = nullCheckList;
                    break;
            }
        }
    }
}