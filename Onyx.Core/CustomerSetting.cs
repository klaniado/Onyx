using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onyx.Core
{
    public partial class CustomerSetting
    {
       // [Key]
        public int CustomerSettingID { get; set; }
        public int KeyID { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}

