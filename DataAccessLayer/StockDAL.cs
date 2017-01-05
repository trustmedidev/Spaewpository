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
  public  class StockDAL : SpaPracticeEntities
    {
       
                public void   InsertUpdateStock(int TranHdrCd,int TranDtlCd, tblstock objStock )
           {
               try
               {
                   int code;
                   var BNValue = tblstocks.Max(i => (int?)i.Code).GetValueOrDefault();
                   if (BNValue == 0)
                   {
                       code = 1;

                   }
                   else
                   {
                       code = Int32.Parse(BNValue.ToString());
                       code = code + 1;
                   }
                   if (objStock.Code == 0)
                   {
                       objStock.Code = code;

                       tblstocks.Add(objStock);
                       SaveChanges();
                       
                   }
                   else
                   {
                       var appOrg = tblstocks.SingleOrDefault(p => p.TransuctionHdCd==TranHdrCd && p.TransuctionDtlCd==TranDtlCd);
                       Entry(appOrg).CurrentValues.SetValues(tblstocks);
                       SaveChanges();
                       
                       
                   }

               }
               catch (Exception ex)
               {
                   
               }

                
            }
    }
}
