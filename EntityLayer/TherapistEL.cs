using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class TherapistEL
    {
        public int TherapistId { get; set; }
        public int ApptId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Specialist { get; set; }
        public string Email { get; set; }
        public string Days { get; set; }
        public Boolean? Leave { get; set; }
        public Nullable<decimal> Commission { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string Status { get; set; }
        public Nullable<int> FK_BranchId { get; set; }
        public string Availability { get; set; }
        public string Timings { get; set; }
        public string Leaves { get; set; }

        public Nullable<System.DateTime> AppointmentDate { get; set; }
        public string ServiceName { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? TherapistAmount { get; set; }

        public string ClientName { get; set; }

        public decimal? ServiceAmount { get; set; }
        public decimal? Discount { get; set; }

        public int? PaymentId { get; set; }

    }
}
