using System.Collections;
using System.ComponentModel;
using System.Web.UI;

namespace SZMA.Core
{
    /// <summary>
    /// Summary description for MessageBox.
    /// </summary>
    [DefaultProperty("Text"),
        ToolboxData("<{0}:MessageBox runat=server></{0}:MessageBox>")]
    public class MessageBox : System.Web.UI.WebControls.WebControl
    {
        /// <summary>
        /// ���ð�ť
        /// </summary> 
        public enum MessageBoxButtons
        {
            /// <summary>
            /// �رհ�ť
            /// </summary>
            Close,
            /// <summary>
            /// ���ذ�ť
            /// </summary>
            Back,
            /// <summary>
            /// ��ҳ��ť
            /// </summary>
            Home,
            /// <summary>
            /// ע�ᰴť
            /// </summary>
            Register,
            /// <summary>
            /// ��½��ť
            /// </summary>
            Login
        }

        private string message = string.Empty;
        private string title = string.Empty;
        private string btStr = string.Empty;
        private int boxType = 0;
        /// <summary>
        /// Ҫ��ʾ�İ�ť
        /// </summary>
        public ArrayList Buttons;

        /// <summary>
        /// ��Ϣ��
        /// </summary>
        /// <param name="boxType">���ͣ�1Ϊ�ⲿ���棬2Ϊ�������</param>
        public MessageBox(int boxType)
        {
            this.boxType = boxType;
            Buttons = new ArrayList();
        }

        /// <summary>
        /// ��Ϣ��
        /// </summary>
        public MessageBox()
        {
            Buttons = new ArrayList();
        }

        /// <summary>
        /// Ҫ��ʾ����Ϣ
        /// </summary>
        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        /// <summary>
        /// ��Ϣ��ı���
        /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        /// <summary>
        /// ���ͣ�1Ϊ�ⲿ���棬2Ϊ�������
        /// </summary>
        public int BoxType
        {
            get { return boxType; }
            set { boxType = value; }
        }

        /// <summary> 
        /// Render this control to the output parameter specified.
        /// </summary>
        /// <param name="output"> The HTML writer to write out to </param>
        protected override void Render(HtmlTextWriter output)
        {
            RenderButtons();
            string str;
            str = string.Format("<table width=\"96%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\"> <tr bgcolor=\"#317DD3\"> <td bgcolor=\"#317DD3\" colspan=\"3\" height=\"5\"><img src=\"\" width=\"0\"></td> </tr> <tr> <td bgcolor=\"#317DD3\" width=\"1\"><img src=\"\" width=\"0\"></td> <td height=\"22\" bgcolor=\"#DAE8F8\" class=\"text-main\" align=\"left\">&nbsp;<b>{0}</b></td> <td bgcolor=\"#317DD3\" width=\"1\"><img src=\"\" width=\"0\"></td> </tr> <tr> <td bgcolor=\"#317DD3\" width=\"1\"><img src=\"\" width=\"0\"></td> <td><table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"10\"> <tr> <td width=\"0\" align=\"center\" height=\"160\">&nbsp;</td> <td><table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\"> <tr> <td class=\"text-main\">{1}</td> </tr> <tr> <td align=\"right\" class=\"text-main\"><br>{2}</td> </tr> </table> </td> </tr> </table></td> <td bgcolor=\"#317DD3\" width=\"1\"><img src=\"\" width=\"0\"></td> </tr> <tr> <td bgcolor=\"#317DD3\" colspan=\"3\" height=\"1\"><img src=\"\" width=\"0\"></td> </tr> </table>", title, message, btStr);
            output.Write(str);
        }

        private void RenderButtons()
        {
            for (int i = 0; i < Buttons.Count; i++)
            {
                switch (Buttons[i].ToString())
                {
                    case "Close":
                        btStr += "<input type=button onclick=\"javascript:window.opener=null;window.close();\" value=\"�ر�\" class=\"button\">��";
                        break;
                    case "Back":
                        btStr += "<input type=button onclick=\"javascript:history.go(-1);\" value=\"����\" class=\"button\">��";
                        break;
                    case "Home":
                        btStr += "<input type=button onclick=\"javascript:location.href='/'\" value=\"��ҳ\" class=\"button\">��";
                        break;
                    case "Login":
                        btStr += "<input type=button onclick=\"javascript:location.href='?m=Login'\" value=\"��½\" class=\"button\">��";
                        break;
                    case "Register":
                        btStr += "<input type=button onclick=\"javascript:location.href='?m=register';\" value=\"ע��\" class=\"button\">��";
                        break;
                    default:
                        btStr += Buttons[i].ToString() + "��";
                        break;
                }
            }
        }
    }

    /// <summary>
    /// �Զ��尴ť
    /// </summary>
    public class CustomButton
    {
        string _text, _action;

        /// <summary>
        /// �Զ��尴ť
        /// </summary>
        /// <param name="text"></param>
        /// <param name="action"></param>
        public CustomButton(string text, string action)
        {
            _text = text;
            _action = action;
        }

        /// <summary>
        /// ���ɰ�ťHTML
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("<input type=button onclick=\"{0}\" value=\"{1}\" class=\"button\">", _action, _text);
        }
    }
}
