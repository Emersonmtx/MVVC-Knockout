//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblFilmes
    {
        public int cod_filme { get; set; }
        public string titulo_filme { get; set; }
        public Nullable<System.DateTime> lancamento { get; set; }
        public string genero { get; set; }
        public string produtora { get; set; }
    }
}