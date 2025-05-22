using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpVision.HR.HRDataBase;
using SharpVision.Base.BaseBusiness;
using System.Data;
namespace SharpVision.HR.HRBusiness
{
    public class GroupElementBiz:BaseSingleBiz
    {

        #region Constructor
        public GroupElementBiz()
        {
            _BaseDb = new GroupElementDb();
        }
        public GroupElementBiz(DataRow objDr)
        {
            _BaseDb = new GroupElementDb(objDr);
        }

        #endregion
        #region Private Data
        
        #endregion
        #region Properties
    public double Perc
        {
            set => ((GroupElementDb)_BaseDb).Perc = value;
            get => ((GroupElementDb)_BaseDb).Perc;
        }
        public int Order
        {
            set => ((GroupElementDb)_BaseDb).Order = value;
            get => ((GroupElementDb)_BaseDb).Order;
        }
        double _Value;
        public double Value
        {
            get => _Value;
            set => _Value = value;
        }
        double _TotalValue;
        public double TotalValue
        {
            get => _TotalValue;
            set => _TotalValue = value;
        }
        
        public EstimationFuzzyValueBiz FuzzyValue
        {
            get
            {
                return EstimationFuzzyValueBiz.GetFuzzyValue(Value);
            }
        }

        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            ((GroupElementDb)_BaseDb).Add();
        }
        public void Edit()
        {
            ((GroupElementDb)_BaseDb).Edit();
        }
        public void Delete()
        {
            ((GroupElementDb)_BaseDb).Delete();
        }
        #endregion
    }
}
