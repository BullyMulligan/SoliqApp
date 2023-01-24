using System.Collections.Generic;
using System.Linq;

namespace SoliqApp
{
    public class Category
    {
        public List<Automatic.PsicCategory> checkList;

        private List<Automatic.PsicCategory> successCheckList;
        private List<Automatic.PsicCategory> notSuccessCheckList;
        public List<Automatic.PsicCategory> selectedCheckList;

        public void CheckCounting()
        {
            successCheckList=checkList.Where(i => i.status == 1).ToList();
            notSuccessCheckList = checkList.Where(i => i.status != 1).ToList();
        }
        public void SwitchSelectList(int index)
        {
            switch (index)
            {
                case 0:
                    selectedCheckList = checkList;
                    break;
                case 1:
                    selectedCheckList = successCheckList;
                    break;
                case 2:
                    selectedCheckList = notSuccessCheckList;
                    break;
            }
        }
    }
}