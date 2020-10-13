using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using api_ecmall.Domain.Entities;

namespace api_ecmall.Domain.Entities
{
    /// <summary>
    /// 商品档案
    /// </summary>
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        public string ClientGuid { get; set; }
        public string ClientName { get; set; }
        public virtual List<ProductItem> ProductItems { get; set; }
    }
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class CheckAttribute:ValidationAttribute
    {
        private string Message = "";
        public CheckAttribute(string message)
        {
            Message = message;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(!string.IsNullOrEmpty(Message))
            {
                if(Message!=(string)value)
                {
                    return new ValidationResult("默认值为:"+Message.ToString());
                }
            }
            //return base.IsValid(value, validationContext);
            return ValidationResult.Success;
        }
    }
}
