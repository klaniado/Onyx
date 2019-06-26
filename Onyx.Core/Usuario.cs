using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onyx.Core
{
    public partial class Usuario
    {
        public int UsuarioID { get; set; }
        public int RolID { get; set; }
        public string Usuario1 { get; set; }
        public string Pasword { get; set; }
        public virtual Rol Rol { get; set; }
    }
}