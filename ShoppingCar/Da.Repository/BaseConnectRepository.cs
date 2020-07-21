using ShoppingCar.Base.Repository;
using System.Configuration;

namespace ShoppingCar.Da.Repository
{
    public class BaseConnectRepository<T> : BaseRepository<T> where T : class
       
    {
        protected static string _DBConn = ConfigurationManager.ConnectionStrings["DBConn"]?.ConnectionString;

        public BaseConnectRepository() : base(_DBConn)
        {

        }
    }
}