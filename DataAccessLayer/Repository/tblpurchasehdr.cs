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
    
    public partial class tblpurchasehdr
    {
        public int Code { get; set; }
        public string PurchaseTranID { get; set; }
        public int BranchCd { get; set; }
        public int GodownCd { get; set; }
        public Nullable<bool> OrderYN { get; set; }
        public int OrderCd { get; set; }
        public int SupplierCd { get; set; }
        public string Description { get; set; }
        public System.DateTime TranDate { get; set; }
        public decimal TotVal { get; set; }
        public decimal TotDisc { get; set; }
        public decimal TotBasicValue { get; set; }
        public decimal TotValue { get; set; }
        public int FinYr { get; set; }
        public bool AcgtiveYN { get; set; }
        public System.DateTime EntryDate { get; set; }
        public int UserCode { get; set; }
        public int TaxConfigCd { get; set; }
    }
}
