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
    
    public partial class tbltaxcofigdetail
    {
        public int Code { get; set; }
        public int TaxConfigHdCd { get; set; }
        public string Name { get; set; }
        public bool TaxYN { get; set; }
        public string AddSub { get; set; }
        public string CalOn { get; set; }
        public Nullable<decimal> CalPer { get; set; }
        public Nullable<decimal> CalVal { get; set; }
        public string TermsType { get; set; }
        public bool ActiveYN { get; set; }
        public System.DateTime EntryDate { get; set; }
        public int UserCode { get; set; }
    }
}