//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer.Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblbomdetail
    {
        public int Code { get; set; }
        public int BOM_Cd { get; set; }
        public int ItemCd { get; set; }
        public Nullable<decimal> Qty { get; set; }
        public int UnitCd { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public Nullable<bool> ActiveYN { get; set; }
        public System.DateTime EntryDate { get; set; }
        public int UserCode { get; set; }
    }
}
