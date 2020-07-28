using ShoppingCar.Enums;
using ShoppingCar.Models;
using ShoppingCar.Repository;
using ShoppingCar.Utility.Extensions;
using System;
using System.Web.Http.Validation;

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

        public MemberViewModel GetAccount(string account)
        {
            var e = MemberRespoistory.GetAccount(account);
            MemberViewModel memberViewModel = new MemberViewModel
            {
                Account = e.Account,
                Email = e.Email,
                RealName = e.RealName
            };
            return memberViewModel;
        }

        /// <summary>
        /// // 註冊 Member
        /// </summary>
        /// <param name="model"></param>
        public ResultModel<MemberViewModel> Create(MemberViewModel model)
        {
            if (model.PassWord!=model.PassWord2)
            {
                return new ResultModel<MemberViewModel>
                {
                  IsSuccess = false,
                  Message = "密碼輸入兩次不一致",
                  Model = model
                };
            }

            MemberModel memberModel = new MemberModel
            {
               Account = model.Account,
               Email = model.Email,
               PassWord = model.PassWord,
               RealName = model.RealName
            };

            if (MemberRespoistory.IsExistsByAccount(memberModel.Account))
             {
                return new ResultModel<MemberViewModel>
                {
                  IsSuccess = false,
                  Message = "使用者帳號重覆",
                  Model = model
                 };
             }

                string salt = Guid.NewGuid().ToString();
                string hashString = GetHashString(memberModel.Account, memberModel.PassWord, salt);

                memberModel.RegisterTime = DateTimeHelper.GetNowTime();
                memberModel.Salt = salt;
                memberModel.PassWord = hashString;
                memberModel.MemberLevel = (int)MemberLevelEnum.Level1;
                MemberRespoistory.Create(memberModel);

                return new ResultModel<MemberViewModel>
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
        public ResultModel MemberEdit(MemberViewModel model)
        {
            var account = MemberRespoistory.GetAccount(model.Account);
            if (account == null)
            {
                return new ResultModel<MemberViewModel>
                {
                    IsSuccess = false,
                    Message = "密碼錯誤，請重新輸入"
                };
            }
            if (model.PassWord != model.PassWord2)
            {
                return new ResultModel<MemberViewModel>
                {
                    IsSuccess = false,
                    Message = "密碼輸入兩次不一致"
                };
            }
            var password = GetHashString(model.Account, model.OldPassWord, account.Salt);

            if (account.PassWord != password)
            {
                return new ResultModel<MemberViewModel>
                {
                    IsSuccess = false,
                    Message = "舊密碼錯誤請重新輸入"
                };
            }
            string hashString = GetHashString(model.Account, model.PassWord, account.Salt);
            account.PassWord = hashString;
            account.RealName = model.RealName;
            account.Email = model.Email;
            MemberRespoistory.Update(account);
            return new ResultModel<MemberViewModel>
            {
                IsSuccess = true,
                Message = "基本資料修改完成"
            };
        }
    }

}