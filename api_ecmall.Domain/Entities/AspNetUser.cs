using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace api_ecmall.Domain.Entities
{
    public class AspNetUser
    {
        [Key]
        public string Id { get; set; }
        public string Email { get; set; }
        public int EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }

        public string PhoneNumber { get; set; }
        public int PhoneNumberConfirmed { get; set; }
        public int TwoFactorEnabled { get; set; }
        public DateTime LockoutEndDateUtc { get; set; }
        public int LockoutEnabled { get; set; }

        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }
    }
}
