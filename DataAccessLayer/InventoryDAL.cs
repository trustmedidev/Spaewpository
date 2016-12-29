using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using DataAccessLayer.Repository;

namespace DataAccessLayer
{
   public class InventoryDAL :SpaPracticeEntities
    {
       
        #region Inventory Management
        public int InsertUpdateInventory(InventoryEL objInventoryEL)
        {
            tblinventory objtblinventory = new tblinventory();
             
            try
            {
                if (objInventoryEL.Id == 0)
                {
                    objtblinventory.FK_BranchId = objInventoryEL.FK_BranchId;
                    objtblinventory.Inv_Image = objInventoryEL.Inv_Image;
                    objtblinventory.Quantity = objInventoryEL.Quantity;
                    objtblinventory.Price = objInventoryEL.Price;
                    objtblinventory.Inv_Location = objInventoryEL.Inv_Location;
                    objtblinventory.Inv_Name = objInventoryEL.Inv_Name;
                    objtblinventory.IsActive = objInventoryEL.IsActive;
                    tblinventories.Add(objtblinventory);
                    SaveChanges();
                    objInventoryEL.Id = objtblinventory.Id;
                }
                else
                {
                    var data = tblinventories.Where(p => p.Id == objInventoryEL.Id).FirstOrDefault();
                    if (data != null)
                    {
                        objtblinventory.Id = objInventoryEL.Id;
                        objtblinventory.FK_BranchId = objInventoryEL.FK_BranchId;
                        objtblinventory.Inv_Image = objInventoryEL.Inv_Image;
                        objtblinventory.Quantity = objInventoryEL.Quantity;
                        objtblinventory.Price = objInventoryEL.Price;
                        objtblinventory.Inv_Location = objInventoryEL.Inv_Location;
                        objtblinventory.Inv_Name = objInventoryEL.Inv_Name;
                        objtblinventory.IsActive = objInventoryEL.IsActive;
                        Entry(data).CurrentValues.SetValues(objtblinventory);
                        SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return objInventoryEL.Id;
        }


        public IEnumerable<InventoryEL> GetInventoryData(int? branchId)
        {
            var Query = tblinventories.Where(x => x.FK_BranchId == branchId).Select(x => new InventoryEL
            {
                Id = x.Id,
                Quantity = (int)x.Quantity,
                Price = (decimal)x.Price,
                Inv_Image = x.Inv_Image,
                Inv_Location = x.Inv_Location,
                Inv_Name = x.Inv_Name,
                IsActive = x.IsActive,
            });
            return Query;
        }

        public bool DeleteInventoryById(int Id = 0, int branchID = 0)
        {
            var DeleteResult = tblinventories.Where(x => x.Id == Id).FirstOrDefault();
            tblinventories.Remove(DeleteResult);
            if (SaveChanges() > 0) { return true; } else { return false; }
        }
        #endregion Inventory Management
    }
}
