using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.GL.GLDataBase;
using SharpVision.SystemBase;

namespace SharpVision.GL.GLBusiness
{
   public class JournalTypeCol : BaseCol
    {
       public JournalTypeCol()
       {
           JournalTypeDb objDb = new JournalTypeDb();
           DataTable dtTemp = objDb.Search();
           foreach (DataRow objDr in dtTemp.Rows)
           {
               Add(new JournalTypeBiz(objDr));
           }
       }
       public JournalTypeCol(bool blIsempty)
       {
           if (blIsempty)
               return;
           JournalTypeBiz objTypeBiz = new JournalTypeBiz();
           objTypeBiz.NameA = "€Ì— „Õœœ";
           Add(objTypeBiz);
           JournalTypeDb objDb = new JournalTypeDb();
           DataTable dtTemp = objDb.Search();
           foreach (DataRow objDr in dtTemp.Rows)
           {
               Add(new JournalTypeBiz(objDr));
           }
       }
       public JournalTypeCol(int intID)
        {
            JournalTypeDb objDb = new JournalTypeDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new JournalTypeBiz(objDr));
            }
        }

       public JournalTypeBiz this[int intIndex]
        {

            get
            {
                return (JournalTypeBiz)List[intIndex];
            }
        }
       public JournalTypeBiz GetJournalTypeByID(int intID)
       {
           JournalTypeBiz Returned = new JournalTypeBiz();
           foreach (JournalTypeBiz objBiz in this)
           {
               if (objBiz.ID == intID)
               {
                   Returned = objBiz;
                   break;
               }
 
           }
           return Returned;
       }
       public void Add(JournalTypeBiz objBiz)
        {
            List.Add(objBiz);

        }
       public JournalTypeCol GetColByCode(string strCode)
       {
           JournalTypeCol Returned = new JournalTypeCol(true);
           foreach (JournalTypeBiz objBiz in this)
           {
               if (objBiz.Code.IndexOf(strCode,StringComparison.OrdinalIgnoreCase) != -1)
                   Returned.Add(objBiz);
           }
           return Returned;
       }
    }
}
