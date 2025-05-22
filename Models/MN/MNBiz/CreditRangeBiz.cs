using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmatMN.MN.MNBiz
{
    public class CreditRangeBiz
    {
        string _Desc;
        public string Desc
        { set => _Desc = value; get => _Desc; }
        double _StartValue;
        public double StartValue { set => _StartValue = value; get => _StartValue; }
        double _EndValue;
        public double EndValue { set => _EndValue = value; get => _EndValue; }
        ROCol _RoCol;
        public ROCol ROCol { set => _RoCol = value;
            get
            {
                if (_RoCol == null)
                {
                    _RoCol = new ROCol();
                }
                return _RoCol;
            } }
        
    }
}
