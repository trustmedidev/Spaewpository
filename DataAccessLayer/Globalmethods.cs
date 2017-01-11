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
        public static int FinYr = 20162017;
        public static int rollid = 1;
        public static string openingtrantype;


        public static string GetPrefixforTransaction(int id)
        {
            string prefix = "Y";
            try
            {
                SpaPracticeEntities db = new SpaPracticeEntities();
                var BNValue = db.tblparameters.Where(p => p.ID == 1).ToList(); ;
                //  prefix = BNValue.ToString();
                foreach (var pr in BNValue)
                {
                    prefix = pr.OPeningstockTranType.ToString();


                }
            }
            catch (Exception ex)
            {
            }

            return prefix;

        }
        public static string GetPurchaseBillPrefixforTran(int id)
        {
            string prefix = "N";
            try
            {
                SpaPracticeEntities db = new SpaPracticeEntities();
                var BNValue = db.tblparameters.Where(p => p.ID == 1).ToList(); ;
                foreach (var pr in BNValue)
                {
                    prefix = pr.PurchaseBillTranPrefix.ToString();


                }
            }
            catch (Exception ex)
            {
            }

            return prefix;

        }

        public static void GetParameterValues()
        {
            string prefix = "Y";
            try
            {
                SpaPracticeEntities db = new SpaPracticeEntities();


                var BNValue = db.tblparameters.FirstOrDefault(a => a.ID == 1);
                //  prefix = BNValue.ToString();
                //foreach (var pr in BNValue)
                //{
                openingtrantype = BNValue.OPeningstockTranType.ToString();


                //}
            }
            catch (Exception ex)
            {
            }



        }


    }
}
