using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Repository;
using System.Data.Entity;
using System.Windows.Forms;

namespace DataAccessLayer 
{
    public class ItemDAL : SpaPracticeEntities
    {
        #region === insert data in Item
        public int Insert(string description, string ShName, int ItemMainGrpCd, int ItemSubGrpCd,
            int PurUnit, int IssUnit, decimal Factor, decimal Reorder, decimal VatPer, decimal VatVal,
            decimal DiscPer, decimal DiscVal, decimal LastPerRate, int Supplior, bool PerishableYN, bool SaleableYN, int UserCode)
        {
         
            tblitem bt = new tblitem();
            try
            {
                int code;
                var BNValue = tblitems.Max(i => (int?)i.Code).GetValueOrDefault();
                if (BNValue == 0)
                {
                    code = 1;
                }
                else
                {
                    code = Int32.Parse(BNValue.ToString());
                    code = code + 1;
                }
                bt.Code = code;
                bt.Description = description;
                bt.ShortName = ShName;
                bt.MainGroupCd=ItemMainGrpCd;
                bt.SubGroupCd = ItemSubGrpCd;
                bt.PurchaseUnitCd = PurUnit;
                bt.IssueUnitCd = IssUnit;
                bt.UnitFactor = Factor;
                bt.ReorderLavel = Reorder;
                bt.ItemVatPer = VatPer;
                bt.ItemVatVal = VatVal;
                bt.ItemDiscPer = DiscPer;
                bt.ItemDiscVal = DiscVal;
                bt.LastPurchaseRate = LastPerRate;
                bt.LastPurchaseParty = Supplior;
                bt.PerishableYN = PerishableYN;
                bt.SaleableYN = SaleableYN;
                bt.ActiveYN = true;
                bt.EntryDate = DateTime.Now;
                bt.UserCode = UserCode;
                tblitems.Add(bt);
                SaveChanges();
                return code;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }

        }
        #endregion

        #region ===update Item
        public int Update(int ID, string description, string ShName, int ItemMainGrpCd
            , int ItemSubGrpCd, int PurUnit, int IssUnit, decimal Factor, decimal Reorder, 
            decimal VatPer, decimal VatVal, decimal DiscPer, decimal DiscVal, decimal LastPerRate, 
            int Supplior, bool PerishableYN, bool SaleableYN, bool ActiveYN)
        {
            tblitem bt = tblitems.SingleOrDefault(p => p.Code == ID);
            try
            {
                bt.Code = ID;
                bt.Description = description;
                bt.ShortName = ShName;
                bt.MainGroupCd = ItemMainGrpCd;
                bt.SubGroupCd = ItemSubGrpCd;
                bt.PurchaseUnitCd = PurUnit;
                bt.IssueUnitCd = IssUnit;
                bt.UnitFactor = Factor;
                bt.ReorderLavel = Reorder;
                bt.ItemVatPer = VatPer;
                bt.ItemVatVal = VatVal;
                bt.ItemDiscPer = DiscPer;
                bt.ItemDiscVal = DiscVal;
                bt.LastPurchaseRate = LastPerRate;
                bt.LastPurchaseParty = Supplior;
                bt.PerishableYN = PerishableYN;
                bt.SaleableYN = SaleableYN;
                bt.ActiveYN = ActiveYN;

                SaveChanges();

                return  ID;

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }

        }
        #endregion

        #region === bind Item in DataGridView

        // item bind

        public void BindList(DataGridView grd)
        {
            try
            {
                var data = (from p in tblitems
                            join mg in tblitemmaingroups on p.MainGroupCd equals mg.Code
                            join sg in tblitemsubgroups on p.SubGroupCd equals sg.Code
                            into t1 from sg in t1.DefaultIfEmpty()
                            join pu in tblunits  on p.PurchaseUnitCd equals pu.Code
                            into t2 from pu in t2.DefaultIfEmpty()
                            join Iu in tblunits on p.IssueUnitCd equals Iu.Code
                            into t3
                            from iu in t3.DefaultIfEmpty()
                            orderby mg.Description, p.Description
                            select new
                            {
                                code = p.Code,
                                MaingrpName = mg.Description,
                                SubgrpNAme = (sg.Description ?? string.Empty),
                                Name = p.Description,
                                ShName = (p.ShortName ?? string.Empty),
                                ItemMainGrpCd = p.MainGroupCd,
                                ItemSubGrpCd = p.SubGroupCd,
                                PurUnitCd = p.PurchaseUnitCd,
                                IssUnitCd = p.IssueUnitCd,
                                PurUnit = pu.Description,
                                IssUnit = iu.Description,
                                Factor = p.UnitFactor,
                                Reorder = p.ReorderLavel,
                                VatPer = p.ItemVatPer,
                                VatVal = p.ItemVatVal,
                                DiscPer = p.ItemDiscPer,
                                DiscVal = p.ItemDiscVal,
                                LastPerRate = p.LastPurchaseRate,
                                Supplior = p.LastPurchaseParty,
                                PerishableYN = p.PerishableYN,
                                SaleableYN = p.SaleableYN,
                                ActiveYN = p.ActiveYN
                            }
                            );
                var result = data.ToList();

                if (result != null)
                {
                    grd.DataSource = null;
                    grd.DataSource = result;
                }
            }
            catch (Exception ex)
            {

            }
        }

        //public void BindList(DataGridView grd)
        //{
        //    try
        //    {
        //        var data = (from p in tblitems 

        //                    orderby p.Description
        //                    select new
        //                    {
        //                        code = p.Code,
        //                        Name = p.Description,
        //                        ShName= p.ShortName, 
        //                        ItemMainGrpCd=p.MainGroupCd ,
        //                        ItemSubGrpCd= p.SubGroupCd ,
        //                        PurUnit= p.PurchaseUnitCd ,
        //                        IssUnit= p.IssueUnitCd,
        //                        Factor= p.UnitFactor,
        //                        Reorder= p.ReorderLavel,
        //                        VatPer= p.ItemVatPer,
        //                        VatVal= p.ItemVatVal,
        //                        DiscPer= p.ItemDiscPer,
        //                        DiscVal= p.ItemDiscVal,
        //                        LastPerRate= p.LastPurchaseRate ,
        //                        Supplior= p.LastPurchaseParty,
        //                        PerishableYN= p.PerishableYN,
        //                        SaleableYN= p.SaleableYN,
        //                        ActiveYN = p.ActiveYN
        //                    }
        //                    );
        //        var result = data.ToList();

        //        if (result != null)
        //        {
        //            grd.DataSource = null;
        //            grd.DataSource = result;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        #endregion

        #region === bind Item
        public void BindDdlItem(ComboBox ddl)
        {
            try
            {

                var data = (from p in tblitems
                            select new
                            {
                                Code = p.Code,
                                Name = p.Description


                            });
                var servicelist = data.ToList();
                if (servicelist != null)
                {
                    ddl.DataSource = null;
                    ddl.Items.Clear();

                    ddl.ValueMember = "Code";
                    ddl.DisplayMember = "Name";
                    ddl.DataSource = servicelist;
                    ddl.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


       

        
        #endregion

        #region ===Item exists down the line
        public int ChkItemInBOM(int ID)
        {
            try
            {
                var data = (from p in tblbomdetails
                            where p.ItemCd == ID && p.ActiveYN == true
                            select p).ToList();
                if (data != null || data.Count > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }

            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        #endregion
    }
}
