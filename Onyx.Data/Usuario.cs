//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Onyx.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Usuario
    {
        public int UsuarioID { get; set; }
        public int RolID { get; set; }
        public string Usuario1 { get; set; }
        public string Pasword { get; set; }
    
        public virtual Rol Rol { get; set; }
    }
}
