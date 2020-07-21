using ShoppingCar.Enums;
using ShoppingCar.Models;
using ShoppingCar.Repository;
using ShoppingCar.Utility.Extensions;
using System;

namespace ShoppingCar.Service
{
    public class MemberService
    {
        

        private static string GetHashString(string account, string passWord, string salt)
        {
            //密碼加密儲存 格式為 account password + salt型態
            byte[] passwordAndSaltBytes = System.Text.Encoding.UTF8.GetBytes($"{account}{passWord}{salt}");
            byte[] hashBytes = new System.Security.Cryptography.SHA256Managed().ComputeHash(passwordAndSaltBytes);
            string hashString = Convert.ToBase64String(hashBytes);
            return hashString;
        }

        public MemberRespoistory MemberRespoistory = new MemberRespoistory();
        public ShoppingCarRepository ShoppingCarRepository = new ShoppingCarRepository();
        public ProductRespoistory ProductRespoistory = new ProductRespoistory();


        /// <summary>
        /// // 註冊 Member
        /// </summary>
        /// <param name="model"></param>
        public ResultModel<MemberModel> Create(MemberModel model)
        {
            
            if (MemberRespoistory.IsExistsByAccount(model.Account))
            {
                return new ResultModel<MemberModel> 
                {
                    IsSuccess = false,
                    Message = "使用者帳號重覆",
                    Model = model
                };
            }

            string salt = Guid.NewGuid().ToString();
            string hashString = GetHashString(model.Account,model.PassWord, salt);

            model.RegisterTime = DateTimeHelper.GetNowTime();
            model.Salt = salt;
            model.PassWord = hashString;
            model.MemberLevel = (int)MemberLevelEnum.Level1;
            MemberRespoistory.Create(model);

            return new ResultModel<MemberModel> 
            {
                IsSuccess = true,
                Message = "成功註冊",
                Model = model
            };
        }

        public ResultModel Login(MemberModel model)
        {
            var account = MemberRespoistory.GetAccount(model.Account);
            if (account == null)
            {
                return new ResultModel
                {
                    IsSuccess = false,
                    Message = "帳號或密碼錯誤，請重新輸入"
                };
            }
            
            var password = GetHashString(model.Account, model.PassWord, account.Salt);
            
            if (account.Account==model.Account & account.PassWord==password)
            {
                return new ResultModel
                {
                    IsSuccess = true,
                    Message = "成功登入"
                };
            }
            else
            {
                return new ResultModel
                {
                    IsSuccess = false,
                    Message = "帳號或密碼錯誤，請重新輸入"
                };
            }
        }
    }

}