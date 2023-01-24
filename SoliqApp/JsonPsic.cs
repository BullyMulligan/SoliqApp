using System.Collections.Generic;
using System.Linq;

namespace SoliqApp
{
    public class JsonPsic
    {
        public string nameJson;

        public List<Automatic.PsicCategory> сheckList = new List<Automatic.PsicCategory>();

        public List<Automatic.PsicCategory> selectedCheckList = new List<Automatic.PsicCategory>();
        //поля с сортированными чеками
        private List<Automatic.PsicCategory> nullCheckList = new List<Automatic.PsicCategory>();
        private List<Automatic.PsicCategory> successCheckList = new List<Automatic.PsicCategory>();
        private List<Automatic.PsicCategory> notSuccessCheckList = new List<Automatic.PsicCategory>();
        private List<Automatic.PsicCategory> notFoundPsicCheckList = new List<Automatic.PsicCategory>();
        
        public void CheckCounting()//Пересчет количества отображаемых чеков
        {
            //создаем списки с чеками разных статусов
            nullCheckList =сheckList.Where(i => i.status == 0).ToList();
            successCheckList = сheckList.Where(i => i.status == 1).ToList();
            notSuccessCheckList =сheckList.Where(i => i.status != 1).ToList();
            notFoundPsicCheckList = сheckList.Where(i => i.status == 2).ToList();
        }
        public void SwitchSelectList(int index)
        {
            switch (index)
            {
                case 0:
                    selectedCheckList = сheckList;
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