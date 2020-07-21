using ShoppingCar.Da.Repository;
using ShoppingCar.Models;
using System.Collections.Generic;

namespace ShoppingCar.Repository
{
    public class MemberRespoistory : BaseConnectRepository<MemberModel>
    {
        public bool IsExistsByAccount(string account)
        {
            string whereSQL = "Where Account = @Account";
            return IsExistsByWhereSQL(whereSQL, new { Account = account });
        }
        public MemberModel GetAccount(string account)
        {
            string whereSQL = "Where Account = @Account";
            return GetByWhereSQL(whereSQL, new { Account = account });
        }
    }
}