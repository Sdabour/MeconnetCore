using AlgorithmatENM.ERP.ERPBusiness;

namespace AlgorithmatENM.ERP.ERPSimple
{
    public class MachineSimple
    {

        #region Properties
        public int ID
        {
            set;
            get;
        }
        
       
        public int Flow
        {
            set;
            get;
        }
        public string Code
        {
            set;
            get;
        }
        public string Desc
        {
            set;
            get;
        }
        public string NameA
        {
            set;
            get;
        }
        public string NameE
        {
            set;
            get;
        }
        public ProcessSimple Process { set; get; }
      
        public WorkCenterSimple Center
        {
            set;
            get;
        }
        #endregion
    }
}
