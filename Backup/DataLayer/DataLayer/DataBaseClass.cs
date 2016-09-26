using System;
using System.Configuration;
using System.Data;
using GotDotNet.ApplicationBlocks.Data;

namespace SZMA.DataLayer
{
    public class DataBaseClass
    {
        /// <summary>
        /// get the SqlHelper object
        /// </summary>
        public static AdoHelper dbHelper
        {
            get { return new SqlServer(); }
        }


        public  object DTCheck(DateTime DT)
        {
            if(DT.Ticks==0)
                return DBNull.Value;
            else 
                return DT;
        }
        public string ConnectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
    }
}
