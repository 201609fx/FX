using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SZMA.Core
{
    /// <summary>
    /// DatePicker ��ժҪ˵����
    /// </summary>
    [DefaultProperty("Date"),
        ToolboxData("<{0}:DatePicker1 runat=server></{0}:DatePicker1>")]
    public class DatePicker1 : WebControl, INamingContainer
    {
        private TextBox txtDate;

        /// <summary>
        /// ���ڿؼ�
        /// </summary>
        public DatePicker1()
        {
            txtDate = new TextBox();
            txtDate.ID = this.UniqueID;
            Controls.Add(txtDate);
        }

        /// <summary>
        /// ���û򷵻������ַ���
        /// </summary>
        [Bindable(true),
            Category("Default"),
            Description("���û򷵻������ַ���"),
            DefaultValue("")]
        public string Date
        {
            get
            {
                EnsureChildControls();
                return txtDate.Text;
            }

            set
            {
                EnsureChildControls();
                txtDate.Text = value;
            }
        }

        /// <summary>
        /// �ͻ��������ű���·����Ĭ��Ϊcalendar.js
        /// </summary>
        [Description("���ÿͻ��������ű���·����Ĭ��Ϊcalendar.js")]
        public string ClientScriptFile
        {
            get
            {
                return null == ViewState["DatePicker1.ClientScriptFile"] ? "../jscript/setday.js" : ViewState["DatePicker1.ClientScriptFile"].ToString();
            }

            set
            {
                ViewState["DatePicker1.ClientScriptFile"] = value;
            }
        }

        /// <summary>
        /// �Ƿ�����Ĭ��Ϊtrue
        /// </summary>
        [Description("���ô������Ƿ�Ϊ�����Ĭ��Ϊtrue")]
        public bool IsRequest
        {
            get
            {
                return null == ViewState["DatePicker1.IsRequest"] ? true : bool.Parse(ViewState["DatePicker1.IsRequest"].ToString());
            }

            set
            {
                ViewState["DatePicker1.IsRequest"] = value;
            }
        }

        /// <summary>
        /// �����ؼ�
        /// </summary>
        protected override void CreateChildControls()
        {
            RequiredFieldValidator reqVali;
            CompareValidator comVali;

            //			txtDate.Attributes["onClick"] = "event.cancelBubble=true";
            txtDate.Attributes["onFocus"] = "setday(this)";
            txtDate.Style.Add("width", "220");
            txtDate.Attributes["onClick"] = "setday(this)";
            txtDate.CssClass = CssClass;
            Controls.Add(txtDate);
            this.CssClass = string.Empty;

            comVali = new CompareValidator();
            comVali.ControlToValidate = txtDate.ID;
            comVali.Display = ValidatorDisplay.Dynamic;
            comVali.Type = ValidationDataType.Date;
            comVali.Operator = ValidationCompareOperator.DataTypeCheck;
            comVali.ErrorMessage = "������������.";
            Controls.Add(comVali);

            reqVali = new RequiredFieldValidator();
            reqVali.ControlToValidate = txtDate.ID;
            reqVali.Display = ValidatorDisplay.Dynamic;
            reqVali.ErrorMessage = "*";
            reqVali.Enabled = IsRequest;
            Controls.Add(reqVali);
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "DataPicker", string.Format("<script language=\"javascript\" src=\"{0}\"></script>", ClientScriptFile));

            //this.Page.RegisterClientScriptBlock("DatePicker", string.Format("<script language=\"javascript\" src=\"{0}\"></script>", ClientScriptFile));
            //2.0�еķ����Ѿ��ı䡣
        }
    }
}
