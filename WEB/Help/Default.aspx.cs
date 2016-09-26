﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class help_Default : SZMA.Core.Client.BasePageByPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        PageTitle = "联系我们";
        string m = "default";
        if (null != Request.QueryString["m"] && Request.QueryString["m"].Trim().Length > 0)
        {
            m = Request.QueryString["m"].Trim();
        }
        m = string.Format("{0}.ascx", m);
        phContent.Controls.Add(LoadControl(m));
    }
}
