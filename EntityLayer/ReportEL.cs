using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class ReportEL
    {
        public int? ClientId { get; set; }

        public string ClientName { get; set; }

        public string ServiceName { get; set; }

        public DateTime? AppointmentDate { get; set; }

        public decimal? TotalAmount { get; set; }

        public decimal? Discount { get; set; }
    }

    public class ReportDataEL
    {

        public int ReportId { get; set; }
        public int clientId { get; set; }
        public string clientName { get; set; }
        public string ReportName { get; set; }
        public string ReportDescription { get; set; }
        public string ReportPath { get; set; }

    }
}
