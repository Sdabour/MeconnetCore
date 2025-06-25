using CookComputing.XmlRpc;
using System.Xml.Linq;

namespace AlgorithmatENM.ERP.ERPBusiness
{
    public interface IOdooCommon : IXmlRpcProxy
    {
        [XmlRpcMethod("login")]
        int login(string dbName, string dbUser, string dbPwd);
    }

    public interface IOdooObject : IXmlRpcProxy
    {
        [XmlRpcMethod("execute")]
        int[] search(string dbName, int userId, string dbPwd, string model, string method, object[] filter);
        //changed ids type from int[] to object[]
        [XmlRpcMethod("execute")]
        object[] read(string dbName, int userId, string dbPwd, string model, string method, object[] ids, object[] fields);
        [XmlRpcMethod("execute")]
        object[] read(string dbName, int userId, string dbPwd, string model, string method, int[] ids, object[] fields);
    }
    public class OddoHelper
    {
        public OddoHelper()
        {
            try
            {
                //string url = "http://your-odoo-instance.com";
                //string dbName = "your_database_name";
                //string username = "your_username";
                //string password = "your_password";
                string url = "https://habib-trading-pre-production-20645535.dev.odoo.com";
                var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json");

                IConfigurationRoot Configuration = builder.Build();
           url = Configuration["ConnectionStrings:ODDOURL"];
                string username = Configuration["ConnectionStrings:ODDOUserName"];
                string password = Configuration["ConnectionStrings:ODDOPass"];
                string dbName = Configuration["ConnectionStrings:ODDODB"];
                // Create proxy instances
                IOdooCommon commonProxy = XmlRpcProxyGen.Create<IOdooCommon>();
                commonProxy.Url = $"{url}/xmlrpc/2/common";

                IOdooObject objectProxy = XmlRpcProxyGen.Create<IOdooObject>();
                objectProxy.Url = $"{url}/xmlrpc/2/object";

                int userId = commonProxy.login(dbName, username, password);

                // Get all work orders
                int[] allWorkOrderIds = objectProxy.search(dbName, userId, password, "mrp.workorder", "search", new object[] { new object[0] });

                // Get all MOs with their work orders
                object[] moFields = new object[] { "workorder_ids" };
                object[] moWithWorkOrders = objectProxy.read(dbName, userId, password, "mrp.production", "search_read",
                    new object[] { new object[] { "workorder_ids", "!=", false } }, moFields);

                // Collect all work order IDs that have MOs
                var linkedWoIds = new HashSet<int>();
                foreach (XmlRpcStruct mo in moWithWorkOrders)
                {
                    if (mo.ContainsKey("workorder_ids") && mo["workorder_ids"] is int[] workOrderIds)
                    {
                        foreach (int id in workOrderIds)
                        {
                            linkedWoIds.Add(id);
                        }
                    }
                }

                // Find work orders without MOs
                var woWithoutMo = allWorkOrderIds.Where(id => !linkedWoIds.Contains(id)).ToArray();

                // Get details of these work orders
                object[] woFields = new object[] { "name", "state", "product_id", "qty_produced", "production_id" };
                object[] result = objectProxy.read(dbName, userId, password, "mrp.workorder", "read", woWithoutMo, woFields);

                Console.WriteLine($"Found {result.Length} work orders without manufacturing orders");
                foreach (XmlRpcStruct wo in result)
                {
                    Console.WriteLine($"{wo["name"]} - {wo["state"]}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public static List<ODDOWorkOrder> GetODDOWorkOrderLst()
        {
            List<ODDOWorkOrder> Returned = new List<ODDOWorkOrder>();
            try
            {
                //string url = "http://your-odoo-instance.com";
                //string dbName = "your_database_name";
                //string username = "your_username";
                //string password = "your_password";
                string url = "https://habib-trading-pre-production-20645535.dev.odoo.com";
                var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json");

                IConfigurationRoot Configuration = builder.Build();
                url = Configuration["ConnectionStrings:ODDOURL"];
                string username = Configuration["ConnectionStrings:ODDOUserName"];
                string password = Configuration["ConnectionStrings:ODDOPass"];
                string dbName = Configuration["ConnectionStrings:ODDODB"];
                // Create proxy instances
                IOdooCommon commonProxy = XmlRpcProxyGen.Create<IOdooCommon>();
                commonProxy.Url = $"{url}/xmlrpc/2/common";

                IOdooObject objectProxy = XmlRpcProxyGen.Create<IOdooObject>();
                objectProxy.Url = $"{url}/xmlrpc/2/object";

                int userId = commonProxy.login(dbName, username, password);

                // Get all work orders
                int[] allWorkOrderIds = objectProxy.search(dbName, userId, password, "mrp.workorder", "search", new object[] { new object[0] });

                // Get all MOs with their work orders
                object[] moFields = new object[] { "workorder_ids" };
                object[] moWithWorkOrders = objectProxy.read(dbName, userId, password, "mrp.production", "search_read",
                    new object[] { new object[] { "workorder_ids", "!=", false } }, moFields);

                // Collect all work order IDs that have MOs
                var linkedWoIds = new HashSet<int>();
                foreach (XmlRpcStruct mo in moWithWorkOrders)
                {
                    if (mo.ContainsKey("workorder_ids") && mo["workorder_ids"] is int[] workOrderIds)
                    {
                        foreach (int id in workOrderIds)
                        {
                            linkedWoIds.Add(id);
                        }
                    }
                }

                // Find work orders without MOs
                var woWithoutMo = allWorkOrderIds.Where(id => !linkedWoIds.Contains(id)).ToArray();

                // Get details of these work orders
                object[] woFields = new object[] { "name", "state", "product_id", "qty_produced", "production_id" };
                object[] result = objectProxy.read(dbName, userId, password, "mrp.workorder", "read", woWithoutMo, woFields);

                Console.WriteLine($"Found {result.Length} work orders without manufacturing orders");
                foreach (XmlRpcStruct wo in result)
                {
                    Returned.Add(new ODDOWorkOrder() { name = wo["name"].ToString(), production_id = wo["production_id"].ToString(), product_id = wo["product_id"].ToString(), qty_produced = wo["qty_produced"].ToString(), state = wo["state"].ToString() });
                    //Console.WriteLine($"{wo["name"]} - {wo["state"]}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return Returned;
        }
    }
}
