using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onyx.Core
{
    public partial class ValidateUser
    {
        public bool IsValidated { get; set; }
        public string ErrorMessage { get; set; }
        public EnumRol Rol { get; set; }
        public int Status { get; set; }
    }
}
