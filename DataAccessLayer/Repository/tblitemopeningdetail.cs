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
    
    public partial class tblitemopeningdetail
    {
        public int Code { get; set; }
        public int ItemOpeningCd { get; set; }
        public int itemcd { get; set; }
        public int UnitCd { get; set; }
        public decimal Qty { get; set; }
        public decimal value { get; set; }
        public bool ActiveYN { get; set; }
        public Nullable<System.DateTime> ExpiryDt { get; set; }
        public Nullable<int> SubUnitCd { get; set; }
    }
}
