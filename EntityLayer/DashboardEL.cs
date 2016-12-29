using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class DashboardEL
    {

        public int TotalAppointment { get; set; }

        public decimal? TotalCollection { get; set; }
    }

    public class MonthPatientChartByService
    {
        public string ServiceName { get; set; }
        public int Month1 { get; set; }
        public int Month2 { get; set; }

        public int Month3 { get; set; }

       // public string MonthName { get; set; }
    }
    public class MonthPatientChartByCollection
    {
        public string ServiceName { get; set; }
        public decimal? Month1 { get; set; }
        public decimal? Month2 { get; set; }

        public decimal? Month3 { get; set; }

        // public string MonthName { get; set; }
    }
}
