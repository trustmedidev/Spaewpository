using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class ClientEL
    {
        public int? ClientId { get; set; }
        public string ClientName { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public DateTime? VisitDate { get; set; }
        public string MaritalStatus { get; set; }
        public string Sex { get; set; }
        public string ReferralSource { get; set; }        
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public bool? IsActive { get; set; }
        public bool? SendEmail { get; set; }
        public bool? SendSMS { get; set; }
        public DateTime? AddedDate { get; set; }
        public string CaseHistory { get; set; }
        public int ServiceId { get; set; }
        public int ServiceName { get; set; }
        public string Age { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public decimal? Discount { get; set; }
        public decimal? Due { get; set; }
        public string ModeOfPayment { get; set; }
        public int? AppId { get; set; }
        public bool? ByPackage { get; set; }

        public int PaymentId { get; set; }
    }
}
