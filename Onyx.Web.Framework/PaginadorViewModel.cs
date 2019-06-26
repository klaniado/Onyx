using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Onyx.Core;

namespace Onyx.Web.Framework
{
    public partial class PaginadorViewModel
    {
        public IEnumerable<CustomerSetting> Items { get; set; }
        public Paginador Paginador { get; set; }
    }
}
