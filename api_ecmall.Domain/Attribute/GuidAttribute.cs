using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace api_ecmall.Domain.Attribute
{
    public class GuidAttribute : ValidationAttribute
    {
        private string Message = "";
        public GuidAttribute(string message)
        {
            Message = message;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!string.IsNullOrEmpty(Message))
            {
                if (Message != (string)value)
                {
                    return new ValidationResult("默认值为:" + Message.ToString());
                }
            }
            //return base.IsValid(value, validationContext);
            return ValidationResult.Success;
        }
    }
}
