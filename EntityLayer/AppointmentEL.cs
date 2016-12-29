using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class AppointmentEL
    {
        public int AppointmentId { get; set; }
        public int FK_PatientId { get; set; }

        public Nullable<int> clientid { get; set; }
        public int thpid { get; set; }

        public string ClientName { get; set; }

        public string CaseHistory { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public string AppointmentTime { get; set; }
        public decimal? Discount { get; set; }
        public int? FK_TaxId { get; set; }
        public int? FK_ServiceId { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? TotalPaid { get; set; }
        public decimal? TotalTax { get; set; }
        public decimal? DueAmount { get; set; }
        public decimal? recievedamount { get; set; }
        public decimal? advanceamount { get; set; }
        public decimal? balanceamount { get; set; }
        public decimal? GrossAmount { get; set; }
        public List<ServiceCharges> ServiceList { get; set; }
        public decimal? NetTotal { get; set; }
        public string PackageName { get; set; }

        public Nullable<int> serviceid { get; set; }
        public string ServiceName { get; set; }
        public string Service { get; set; }
        public decimal? ServiceCharge { get; set; }
        public string TherapistName { get; set; }
        public Nullable<int> packageid { get; set; }

        public string paymenttype { get; set; }
        public string paymentmode { get; set; }

        public bool? IsActive { get; set; }
        public string Status { get; set; }

        public string DoctorName { get; set; }
        public string BankCardNum { get; set; }
        public string BankName { get; set; }
        public string Mobile { get; set; }



        public Nullable<decimal> TaxAmount { get; set; }
        public Nullable<decimal> CouponDiscountAmount { get; set; }
        public Nullable<decimal> ManualDiscountPercentage { get; set; }
        public Nullable<decimal> ManualDiscountAmount { get; set; }
        public Nullable<decimal> NetPayableAmount { get; set; }
        public Nullable<decimal> PaymentDoneAmount { get; set; }
        public Nullable<bool> IsPaymentComplete { get; set; }
        public Nullable<bool> IsPaymentProcessStarted { get; set; }
        public Nullable<int> FK_CouponId { get; set; }
    }

    public class ServiceCharges
    {

        public string ServiceName { get; set; }

        public decimal? Amount { get; set; }

    }
}
