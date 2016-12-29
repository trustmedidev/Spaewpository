using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class UserEL
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }         
        public int? BranchId { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; } 
        public string Password { get; set; }
        public string Mobile { get; set; }
        public int? RoleId { get; set; }
        public string RoleName { get; set; }
        public Decimal? Fees { get; set; }
        public string Status { get; set; }
        public string Specialization { get; set; }

        public List<CustomList> RoleList { get; set; }
        public List<UserList> UserList { get; set; }
    }

    public class CustomList
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UserList
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }

        public string RoleName { get; set; }

        public string Specialization { get; set; }
        public int FK_RoleId { get; set; }
        public Nullable<bool> Status { get; set; }
        public string Active { get; set; }
    }
}
