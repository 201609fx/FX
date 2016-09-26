using System;
using System.Data;
using System.Web;
using System.Web.Caching;

namespace SZMA.Core
{
    class Online
    {
        /// <summary>
        /// 在线用户表
        /// </summary>
        public Online()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        /// <summary>
        /// update online user info
        /// </summary>
        /// <param name="sessionID"></param>
        /// <param name="username"></param>
        /// <param name="ip"></param>
        /// <param name="act"></param>
        /// <param name="url"></param>
        public void UpdateOnlineUser(string sessionID, string username, string ip, string act, string url)
        {
            DataTable tb;
            DataRow[] rows;
            DataRow row;

            tb = GetOnline();
            rows = tb.Select(string.Concat("#", DateTime.Now.AddMinutes(-20), "# > lasttime "));
            for (int i = 0; i < rows.Length; i++)
                tb.Rows.Remove(rows[i]);

            rows = tb.Select(String.Concat("username='", username, "' and ip = '", ip, "' or sessionid='", sessionID, "'"));
            if (0 == rows.Length)
            {
                row = tb.NewRow();
                row["sessionid"] = sessionID;
                row["username"] = username;
                row["ip"] = ip;
                row["starttime"] = DateTime.Now;
                row["lasttime"] = DateTime.Now;
                row["act"] = act;
                row["url"] = url;
                tb.Rows.Add(row);
            }
            else
            {
                rows[0]["lasttime"] = DateTime.Now;
                rows[0]["username"] = username;
                rows[0]["act"] = act;
                rows[0]["url"] = url;
            }
            HttpContext.Current.Items["Online"] = tb.Rows.Count;
        }

        /// <summary>
        /// check the user online
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool CheckOnline(string username)
        {
            DataTable tb;
            DataRow[] rows;

            tb = GetOnline();
            rows = tb.Select(String.Concat("username='", username, "'"));
            return rows.Length > 0;
        }

        /// <summary>
        /// return the online table
        /// </summary>
        /// <returns></returns>
        public DataTable GetOnlineTable()
        {
            return GetOnline();
        }

        private DataTable GetOnline()
        {
            if (null == HttpContext.Current.Cache["ForumOnline"])
                HttpContext.Current.Cache.Insert("ForumOnline", CreateOnline(), null, DateTime.MaxValue, TimeSpan.Zero, CacheItemPriority.High, null);
            return HttpContext.Current.Cache["ForumOnline"] as DataTable;
        }

        private DataTable CreateOnline()
        {
            DataTable tb;
            DataColumn col;
            tb = new DataTable();
            col = new DataColumn("sessionid", typeof(string));
            col.MaxLength = 50;
            tb.Columns.Add(col);
            col = new DataColumn("username", typeof(string));
            col.MaxLength = 250;
            tb.Columns.Add(col);
            col = new DataColumn("ip", typeof(string));
            col.MaxLength = 50;
            tb.Columns.Add(col);
            col = new DataColumn("starttime", typeof(DateTime));
            tb.Columns.Add(col);
            col = new DataColumn("lasttime", typeof(DateTime));
            tb.Columns.Add(col);
            col = new DataColumn("act", typeof(string));
            col.MaxLength = 50;
            tb.Columns.Add(col);
            col = new DataColumn("url", typeof(string));
            col.MaxLength = 255;
            tb.Columns.Add(col);
            tb.PrimaryKey = new DataColumn[] { tb.Columns["sessionid"] };
            return tb;
        }

    }
}
