using Employee_And_Company_Management.Helpers.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_And_Company_Management.Models
{
    public class LoginDTO
    {
        public int ProfileId { get; set; }
        public string UserName { get; set; }
        public string Role {  get; set; }
        public string Language {  get; set; }
        public string Theme { get; set; }
        public bool Success { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }

    }
}
