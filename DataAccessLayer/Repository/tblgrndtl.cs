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
    
    public partial class tblgrndtl
    {
        public int Code { get; set; }
        public int GRNCd { get; set; }
        public int ItemCd { get; set; }
        public int BatchCd { get; set; }
        public decimal Qty { get; set; }
        public int UnitCd { get; set; }
        public System.DateTime ExpiryDt { get; set; }
        public bool ActiveYN { get; set; }
    }
}
