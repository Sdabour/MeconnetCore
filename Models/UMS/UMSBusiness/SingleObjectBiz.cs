using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace SharpVision.UMS.UMSBusiness
{
    public class SingleObjectBiz
    {
        public SingleObjectBiz()
        { }
        public SingleObjectBiz(DataRow objDr)
        {
            int intTemp = 0;
            if (objDr.Table.Columns["ID"] != null)
                int.TryParse(objDr["ID"].ToString(), out intTemp);
            _ID = intTemp;
            _NameA = "";
            if (objDr.Table.Columns["NameA"] != null)
                _NameA = objDr["NameA"].ToString();
            _NameE = "";
            if (objDr.Table.Columns["NameE"] != null)
                _NameE = objDr["NameE"].ToString();
        }
        int _ID;
        public int ID { set => _ID = value; get => _ID; }
        string _NameA;
        public string NameA { set => _NameA = value; get => _NameA; }
        string _NameE;
        public string NameE { set => _NameE = value; get => _NameE; }
        public virtual string Name
        {
            get
            {
                return _NameA;
            }
        }
    }
}
