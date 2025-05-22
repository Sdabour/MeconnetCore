using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.GL.GLDataBase;
using System.Collections;
namespace SharpVision.GL.GLBusiness
{
    public class DimensionCol : CollectionBase
    {
        public DimensionCol()
        {
            

        }
        public DimensionCol(bool blIsEmpty)
        {


        }
        public virtual DimensionBiz this[int intIndex]
        {
            get
            {

                return (DimensionBiz)this.List[intIndex];

            }
        }
       
        public virtual void Add(DimensionBiz objDimensionBiz)
        {
            
                this.List.Add(objDimensionBiz);
             

        }
        public virtual void Add(DimensionCol objDimensionCol)
        {
            foreach (DimensionBiz objDimensionBiz in objDimensionCol)
            {
                 
                    this.List.Add(objDimensionBiz);

            }
        }
        public DimensionCol Copy()
        {
            DimensionCol Returned = new DimensionCol();
            foreach (DimensionBiz objTemp in this)
            {
                Returned.Add(objTemp);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("ModelID"), 
                new DataColumn("DimensionFeildID"),new DataColumn("DimensionX"),new DataColumn("DimensionY"),
            new DataColumn("DimensionWidth"),new DataColumn("DimensionHeight")});
            DataRow objDr;
            foreach (DimensionBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["ModelID"] = objBiz.LayoutID;
                objDr["DimensionFeildID"] = objBiz.FieldID;
                objDr["DimensionX"] = objBiz.X;
                objDr["DimensionY"] = objBiz.Y;
                objDr["DimensionWidth"] = objBiz.Width;
                objDr["DimensionHeight"] = objBiz.Height;
                Returned.Rows.Add(objDr);


            }
            return Returned;
        }
        public void RotateDimention()
        {
            double dblTemp;
            foreach (DimensionBiz objDimension in this)
            {
                if (objDimension.FieldID != 17)
                    continue;
                dblTemp = objDimension.X;
                //objDimension.X += objDimension.Width;
                //objDimension.X = objDimension.Y;
                //objDimension.Y = dblTemp;
                //dblTemp = objDimension.Width;
                //objDimension.Width = objDimension.Height;
                //objDimension.Height = dblTemp;
            }
        }
    }
}
