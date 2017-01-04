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
    class ItemOpeningstock : SpaPracticeEntities
    {
           public int InsertUpdateOpeningstockHdr(tblitemopeningheader objOpeningstockHdr, tblitemopeningdetail obopeningStockDtlj)
           {
              
               try
               {
                  
                   int code;
                   var BNValue = tblitemopeningheaders.Max(i => (int?)i.Code).GetValueOrDefault();
                   if (BNValue == 0)
                   {
                       code = 1;

                   }
                   else
                   {
                       code = Int32.Parse(BNValue.ToString());
                       code = code + 1;
                   }

                   //new insert 
                   if (objOpeningstockHdr.Code == 0)
                   {
                       objOpeningstockHdr.Code = code;
                       tblitemopeningheaders.Add(objOpeningstockHdr);
                       SaveChanges();
                   }
                   else
                   {
                       var appOrg = tblitemopeningheaders.Find(objOpeningstockHdr.Code);
                       Entry(appOrg).CurrentValues.SetValues(objOpeningstockHdr);
                       SaveChanges();
                       //make all inactive in detail
                       var objOpeningDtl = tblitemopeningdetails.Where(p => p.ItemOpeningCd == objOpeningstockHdr.Code).ToList();
                       objOpeningDtl.ForEach(a => a.ActiveYN = false);
                       SaveChanges();
                   }
               }
               catch (Exception ex)
               {

               }
               
               return 0;
           }
        
    }
}
