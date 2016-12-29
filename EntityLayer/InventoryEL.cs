using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class InventoryEL
    {
        public int Id { get; set; }
        public string Inv_Id { get; set; }
        public string Inv_Name { get; set; }
        public string Inv_Image { get; set; }
        public string Inv_Location { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public bool IsActive { get; set; }
        public int FK_BranchId { get; set; }
    }
    public class NVP
    {
        public int? Value { get; set; }
        public string Text { get; set; }
        public decimal? Rate { get; set; }
        public DateTime? Date { get; set; }
             
    }
}
