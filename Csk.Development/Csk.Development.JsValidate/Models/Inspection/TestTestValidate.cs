using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Csk.Development.JsValidate.Models.Inspection
{

    public class TestValidate
    {
        public int Id { get; set; }
        [Required]
        [StringLength(18)]
        [Display(Name = "姓名")]
        public string Names { get; set; }
        [Display(Name ="年龄")]
        [Required]
        [Range(0,150,ErrorMessage ="输入的年龄范围不正确")]
        public Nullable<int> Age { get; set; }
        [Display(Name ="手机号码")]
        [Required]
        [RegularExpression("^1[0-9]{10}$", ErrorMessage ="输入的手机号码不正确")]
        public string Phone { get; set; }
        [Display(Name ="备注")]
        [StringLength(200,ErrorMessage ="最大200字")]
        public string Reamrk { get; set; }
        [Display(Name = "邮箱")]
        [Required]
        [Remote("Remote", "Test",ErrorMessage ="邮箱已存在",HttpMethod ="POST")]
        public string Email { get; set; }
    }
}