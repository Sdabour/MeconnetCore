using System;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
namespace SharpVision.UMS.UMSDataBase 
{
    /// <summary>
    /// Summary description for DbConnection.
    /// </summary>
    /// 
    public enum UmsApproximateType
    {
        Default,
        Up,
        Down
    }
    class BaseDb
    {
        static SharpVision.Base.BaseDataBase.BaseDb _UMSBaseDb;
        internal static SharpVision.Base.BaseDataBase.BaseDb UMSBaseDb 
        {
            set => _UMSBaseDb = value;
            get
            {
                if(_UMSBaseDb== null)
                {
                    var builder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json");

                    IConfigurationRoot Configuration = builder.Build();
                    var connectionString = Configuration["ConnectionStrings:SVDBCon"];
                    string strTemp = connectionString.ToString();
                    _UMSBaseDb = new Base.BaseDataBase.BaseDb(strTemp);
                }
                return _UMSBaseDb;
            }
        }
        internal static int SysID;
        internal static string UMSServiceUrl;

        internal static string ReplaceStringComp(string strName)
        {
            string Str = "";
            try
            {
                Str = strName;
                Str = Str.Trim();
                Str = Str.Replace("�", "�");
                Str = Str.Replace("�", "�");
                Str = Str.Replace("�", "�");
                Str = Str.Replace("�", "�");
                Str = Str.Replace("�", "�");
                Str = Str.Replace("��� ", "���");
                Str = Str.Replace("��� ", "���");
                Str = Str.Replace("��� ", "���");
                Str = Str.Replace("��� ", "���");
                Str = Str.Replace("��� ", "���");
                Str = Str.Replace("�� ", "��");
                Str = Str.Replace("��� ", "���");
                Str = Str.Replace("�� ", "��");
                Str = Str.Replace("���� ", "����");
                //Str = Str.Replace(Chr(13), " ");
                //Str = Str.Replace(Chr(10), "");
                Str = Str.Replace("  ", " ");
                Str = Str.Replace(" ", "");
                //Str = Str.Replace(vbTab, " ");

            }
            catch (Exception Ex)
            {
                //MessageBox.Show(Ex.Message);
            }
            return Str;
        }
        public static double Approximate(double dblValue, double dblApprox, UmsApproximateType objApproximateType)
        {
            double Returned = dblValue;
            if (dblApprox != 0)
            {
                Returned = dblValue % dblApprox;
                if (objApproximateType == UmsApproximateType.Default)
                {
                    if (dblApprox - Returned > Returned)
                        Returned = dblValue - Returned;
                    else
                        Returned = dblValue - Returned + dblApprox;
                }
                else
                {
                    if (objApproximateType == UmsApproximateType.Down)
                        Returned = dblValue - Returned;
                    else
                        Returned = dblValue - Returned + dblApprox;
                }
            }
            return Returned;
        }

    }
    
}
