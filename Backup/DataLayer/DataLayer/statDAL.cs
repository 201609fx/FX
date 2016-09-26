using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SZMA.DataLayer
{
     public class statDAL : DataBaseClass
    {
         public DataSet selectCountMainSCTemp()
         {
             string sql = @"select count(*) as stat  from MainSCTemp where state not in(6) and InsertFlag not in(0,4) 
              select Count(*) as stat  from [Cert] where  CertNum is not null and CertState=1
              select Count(*) as stat  from [Cert] where  CertNum is not null and EndTime<getdate()+1 and CertState=1
              select Count(*) as stat  from [Cert] where  CertNum is not null and EndTime>getdate() and CertState=1
              select Count(*) as stat  from [Cert] where  CertNum is not null  and CertState=2
             ";
       
             DataSet ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.Text, sql);

             if (0 == ds.Tables.Count)
                 ds.Tables.Add(new DataTable());
             return ds;
         }
    }
}
