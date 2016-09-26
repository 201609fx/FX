using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SZMA.DataLayer
{
    public class AnswerDAL:DataBaseClass
    {
        public DataSet SelectByOption(string MainSCID, string ProblemID, string OptionID)
        {
            DataSet ds;
            IDataParameter[] paras = {
	            dbHelper.GetParameter("@MainSCID", MainSCID),
	            dbHelper.GetParameter("@ProblemID", ProblemID),
	            dbHelper.GetParameter("@OptionID", OptionID)
            };


            ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "answer_SelectByOption", paras);

            if (0 == ds.Tables.Count)
                ds.Tables.Add(new DataTable());
            return ds;
        }
        
         public DataSet SelectByProblem(string MainSCID, string ProblemID)
        {
            DataSet ds;
            IDataParameter[] paras = {
	            dbHelper.GetParameter("@MainSCID", MainSCID),
	            dbHelper.GetParameter("@ProblemID", ProblemID)
            };


            ds = dbHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "answer_SelectByProblem", paras);

            if (0 == ds.Tables.Count)
                ds.Tables.Add(new DataTable());
            return ds;
        }
        public int Insert(string MainSCID, string ProblemID, string OptionID, string OptionAnswer, string WriteAnswer, string remark, string UserName)
        {
            IDataParameter[] paras = {
                dbHelper.GetParameter("@MainSCID", MainSCID),
                dbHelper.GetParameter("@ProblemID", ProblemID),
                dbHelper.GetParameter("@OptionID", OptionID),
                dbHelper.GetParameter("@OptionAnswer", OptionAnswer),
                dbHelper.GetParameter("@WriteAnswer", WriteAnswer),
                dbHelper.GetParameter("@remark", remark),
                dbHelper.GetParameter("@UserName", UserName)
            };


            return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "answer_Insert", paras);
        }
        public int Update(string OptionID, string OptionAnswer, string WriteAnswer, string remark, string UserName, string MainSCID, string ProblemID)
        {
            IDataParameter[] paras = {
	            dbHelper.GetParameter("@OptionID", OptionID),
	            dbHelper.GetParameter("@OptionAnswer", OptionAnswer),
	            dbHelper.GetParameter("@WriteAnswer", WriteAnswer),
	            dbHelper.GetParameter("@remark", remark),
	            dbHelper.GetParameter("@UserName", UserName),
	            dbHelper.GetParameter("@MainSCID", MainSCID),
	            dbHelper.GetParameter("@ProblemID", ProblemID)
            };


            return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "answer_Update", paras);
        }

        public int Delete(string ProblemID, string MainSCID)
        {
            IDataParameter[] paras = {
	            dbHelper.GetParameter("@ProblemID", ProblemID),
	            dbHelper.GetParameter("@MainSCID", MainSCID)
            };

            return dbHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "answer_DeleteByPIDandMID", paras);
        }

    }
}
