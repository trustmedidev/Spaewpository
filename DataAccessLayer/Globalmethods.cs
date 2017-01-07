using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Repository;
using System.Data.Entity;
using System.Windows.Forms;
using EntityLayer;
namespace DataAccessLayer
{
    public static class Globalmethods 
    {
        public static int UserCD = 0;
        public static int BranchCD = 1;
        public static bool IsAdmin = true;
        public static int FinYr=20162017;
        public static int rollid = 1;
        
 
       public static string GetPrefixforTransaction(int id)
       {
           string prefix = "Y";
           try
           {
               SpaPracticeEntities db = new SpaPracticeEntities();
               var BNValue = db.tblparameters.Where(p => p.ID == id).ToList(); ;
         //  prefix = BNValue.ToString();
           foreach (var pr in BNValue)
           {
               prefix = pr.TranPrefixType.ToString();


           }
           }
           catch(Exception ex)
           {
           }

           return prefix;

       }

       public static string GetParameterValues()
       {
           string prefix = "Y";
           try
           {
               SpaPracticeEntities db = new SpaPracticeEntities();
              // var BNValue =db.tblspa;
               //  prefix = BNValue.ToString();
               foreach (var pr in BNValue)
               {
                   prefix = pr.TranPrefixType.ToString();


               }
           }
           catch (Exception ex)
           {
           }

           return prefix;

       }
        

    }
}
