using ShoppingCar.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingCar.Models
{

    
    public class MemberModel 
    {
        [AutoKey]
        public int Id { get; set; }

        [DisplayName("帳號")]
        [Required(ErrorMessage = "必填")]
        public string Account { get; set; }
        [DisplayName("密碼")]
        [Required(ErrorMessage = "必填")]
        public string PassWord { get; set; }
        [DisplayName("使用者名稱")]
        [Required(ErrorMessage = "必填")]
        public string RealName { get; set; }
        [DisplayName("電子郵件")]
        [Required(ErrorMessage = "必填")]
        [EmailAddress]
        public string Email { get; set; }

        public string Salt { get; set; }

        public int MemberLevel { get; set; }

        public DateTime RegisterTime { get; set; }
    }

}