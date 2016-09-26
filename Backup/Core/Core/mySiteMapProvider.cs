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
    /// mySiteMapProvider ��ժҪ˵��
    /// </summary>
    public class mySiteMapProvider : XmlSiteMapProvider
    {
        public mySiteMapProvider()
        {
            //
            // TODO: �ڴ˴���ӹ��캯���߼�
            //
        }

        public override SiteMapNode FindSiteMapNode(string rawUrl)
        {
            // ������ԭ�е�FindSiteMapNode()����,Ѱ�Ҵ������ַ,�Ƿ��иýڵ�
            SiteMapNode smn = base.FindSiteMapNode(rawUrl);
            if (smn == null)
            {
                string[] arrUrl = rawUrl.Split('?');
                string sPage = arrUrl[0];
                // ȡ����ҳ��ַ
                string sQuery = string.Empty;
                if (arrUrl.Length >= 2)
                {
                    sQuery = arrUrl[1];// ȡ��QueryString
                }
                string[] aQuery = sQuery.Split('&');// ��QueryString���
                for (int i = 0; i < aQuery.Length; i++)
                {// ��������ҳ��ַ�����QueryStringȥѰ�ҽڵ�
                    smn = base.FindSiteMapNode(sPage + "?" + aQuery[i]);
                    if (smn != null)
                    {// �ҵ��˾��뿪ѭ��
                        break;
                    }
                }
                if (smn == null)
                {// ��ͨ����ҳ��ַ����QueryString,�����Ҳ���,��ֱ�ӷ�����ҳ��ַ�Ľڵ�,ȥ��QueryString
                    smn = base.FindSiteMapNode(sPage);
                }
            }// ���ڵ�G��ȥ��SiteMapPath WebControl Or TreeView WebControl
            return smn;
        }
    }
}
