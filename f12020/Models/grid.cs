//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace f12020.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class grid
    {
        public int sequencial { get; set; }
        public int piloto_id_piloto { get; set; }
        public int gp_id_gp { get; set; }
        public int posicao { get; set; }
    
        public virtual gp gp { get; set; }
        public virtual piloto piloto { get; set; }
    }
}
