using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace SZMA.Core
{
    /// <summary>
    /// mySiteMapProvider 的摘要说明
    /// </summary>
    public class mySiteMapProvider : XmlSiteMapProvider
    {
        public mySiteMapProvider()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        public override SiteMapNode FindSiteMapNode(string rawUrl)
        {
            // 先利用原有的FindSiteMapNode()方法,寻找传入的网址,是否有该节点
            SiteMapNode smn = base.FindSiteMapNode(rawUrl);
            if (smn == null)
            {
                string[] arrUrl = rawUrl.Split('?');
                string sPage = arrUrl[0];
                // 取得网页地址
                string sQuery = string.Empty;
                if (arrUrl.Length >= 2)
                {
                    sQuery = arrUrl[1];// 取得QueryString
                }
                string[] aQuery = sQuery.Split('&');// 将QueryString拆解
                for (int i = 0; i < aQuery.Length; i++)
                {// 在利用网页地址与拆解的QueryString去寻找节点
                    smn = base.FindSiteMapNode(sPage + "?" + aQuery[i]);
                    if (smn != null)
                    {// 找到了就离开循环
                        break;
                    }
                }
                if (smn == null)
                {// 如通过网页地址加上QueryString,还是找不到,就直接返回网页地址的节点,去除QueryString
                    smn = base.FindSiteMapNode(sPage);
                }
            }// 将节点丟出去给SiteMapPath WebControl Or TreeView WebControl
            return smn;
        }
    }
}
