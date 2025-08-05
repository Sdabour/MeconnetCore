namespace AlgorithmatENM.ERP.ERPBusiness
{
    public class MOComponentSimple
    {

        #region Properties
        public int MO
        {
            set;
            get;
        }

        public double Quantity
        {
            set;
            get;
        }
        public ProductSimple Product { set; get; }
        public int ProductRef { set; get; }
       
        public MeasurementUnitSimple MeasurementUnit{set;get;}
        #endregion
    }
}
