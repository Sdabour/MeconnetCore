using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharpVision.Base.BaseBusiness
{
    public class SerializableBiz
    {
       public int ID;
       public string Code;
        public string Name;
        public int ForeignKey;

        public SerializableBiz()
        { }

        public SerializableBiz(int intID, string strCode, string strName,int intForeignKey)
        {
            this.ID = intID;
            this.Code = strCode;
            this.Name = strName;
            ForeignKey = intForeignKey;
        }

       
        
    }
}