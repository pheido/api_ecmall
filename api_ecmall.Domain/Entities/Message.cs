using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_ecmall.Domain.Entities
{
    public class API_Message
    {
        public string MessageCode { get; set; } = ((int)m_Code.Success).ToString();
        public string Method { get; set; }
        public string ErrorMsg { get; set; }
    }
    public enum m_Code
    {
        Success=1,
        Faile=2
    }
}
