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
    
    public partial class tblparameter
    {
        public bool MultipleBranch { get; set; }
        public string LocalorWeb { get; set; }
        public bool Reorderlevel { get; set; }
        public bool StopMovementonReorder { get; set; }
        public bool ItemWithBatch { get; set; }
        public bool PurchaseRequisition { get; set; }
        public bool IndentonRequisition { get; set; }
        public bool MovementfromMainGodown { get; set; }
        public int MainGodownCd { get; set; }
        public bool IntergodownRequisition { get; set; }
        public string OPeningstockTranType { get; set; }
        public string PurchaseRequisitionTranType { get; set; }
        public string PurchaseRequixitionPrefix { get; set; }
        public string PurchaseOrderTranType { get; set; }
        public string PurchaseOrderPrefix { get; set; }
        public string PurchaseBillTranType { get; set; }
        public string PurchaseBillTranPrefix { get; set; }
        public string IntergodownTranType { get; set; }
        public string InterGodownTranPrefix { get; set; }
        public bool GRN { get; set; }
        public string GRNTRanType { get; set; }
        public string GRNTranPrefix { get; set; }
        public bool AllowBackDateEntry { get; set; }
        public bool DayCloser { get; set; }
        public int ID { get; set; }
    }
}
