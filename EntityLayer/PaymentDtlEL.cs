using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class PaymentDtlEL
    {
        public string ClientName { get; set; }
        public int? PaymentID { get; set; }

        public string ReferralSource { get; set; }


        public string Sex { get; set; }

        public string Mobile { get; set; }



        public Nullable<DateTime> dateofbirth { get; set; }
        public int? Fk_AppointmentId { get; set; }

        public Nullable<DateTime> appointmentdate { get; set; }
        public int? Fk_CouponID { get; set; }
        public string Payment_Type { get; set; }
        public string Payment_Mode { get; set; }
        public Nullable<decimal> Total_Amt { get; set; }

        public Nullable<decimal> Service_Amt { get; set; }

        public Nullable<decimal> Tax_Amt { get; set; }

        public Nullable<decimal> Discount_Amt { get; set; }

        public Nullable<decimal> Net_Amt { get; set; }

        public Nullable<decimal> Advance_Amt { get; set; }

        public Nullable<decimal> Due_Amt { get; set; }

        public Nullable<decimal> Received_Amt { get; set; }

        public Nullable<decimal> Balance_Amt { get; set; }

        public bool IsPaymentCompleted { get; set; }
    }


}
