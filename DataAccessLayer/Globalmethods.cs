﻿using System;
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
       public static string GetPrefixforTransaction(int id)
       {
           string prefix = "Y";
           try
           {
               SpaPracticeEntities db = new SpaPracticeEntities();
           var BNValue =db.tblparameters.Where(p => p.ID ==id).ToList();
           prefix = BNValue.ToString();
           }
           catch(Exception ex)
           {
           }

           return prefix;

       }

    }
}