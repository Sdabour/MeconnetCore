using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.GL.GLDataBase;
using System.Data;
using System.Collections;
namespace SharpVision.GL.GLBusiness
{
    public class CheckPeriodStatisticCol : CollectionBase
    {
        #region Private Data

        #endregion
        #region Constructors
        public CheckPeriodStatisticCol(bool blDirection)
        {
            CheckPeriodStatisticDb objDb = new CheckPeriodStatisticDb();
            objDb.Direction = blDirection;
            DataTable dtTemp = objDb.Search();
            Hashtable hsTemp = new Hashtable();
            CheckPeriodStatisticBiz objBiz;
            foreach (DataRow objDr in dtTemp.Rows)
            {
                objDb = new CheckPeriodStatisticDb(objDr);

                if (hsTemp[objDb.Place] != null)
                {
                    objBiz = (CheckPeriodStatisticBiz)hsTemp[objDb.Place];


                }
                else
                {
                    objBiz = new CheckPeriodStatisticBiz();
                    objBiz.Place = objDb.Place;
                    hsTemp.Add(objDb.Place, objBiz);
                    Add(objBiz);
                }

                switch (objDb.PeriodNo)
                {
                    case 1: objBiz.Period1Value = objDb.Value; break;
                    case 2: objBiz.Period2Value = objDb.Value; break;
                    case 3: objBiz.Period3Value = objDb.Value; break;
                    case 4: objBiz.Period4Value = objDb.Value; break;
                    case 5: objBiz.Period5Value = objDb.Value; break;
                    case 6: objBiz.Period6Value = objDb.Value; break;
                    case 7: objBiz.Period7Value = objDb.Value; break;
                    case 8: objBiz.Period8Value = objDb.Value; break;
                    case 9: objBiz.Period9Value = objDb.Value; break;
                    default: objBiz.Period10Value = objDb.Value; break;
                }

            }
          
        }
        #endregion
        #region Public Properties
        public CheckPeriodStatisticBiz this[int intIndex]
        {
            get
            {
                return (CheckPeriodStatisticBiz)List[intIndex];

            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add(CheckPeriodStatisticBiz objBiz)
        {
            List.Add(objBiz);
        }
        #endregion
    }
}
