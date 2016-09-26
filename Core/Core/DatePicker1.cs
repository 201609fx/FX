using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SZMA.Core
{
    /// <summary>
    /// DatePicker 的摘要说明。
    /// </summary>
    [DefaultProperty("Date"),
        ToolboxData("<{0}:DatePicker1 runat=server></{0}:DatePicker1>")]
    public class DatePicker1 : WebControl, INamingContainer
    {
        private TextBox txtDate;

        /// <summary>
        /// 日期控件
        /// </summary>
        public DatePicker1()
        {
            txtDate = new TextBox();
            txtDate.ID = this.UniqueID;
            Controls.Add(txtDate);
        }

        /// <summary>
        /// 设置或返回日期字符串
        /// </summary>
        [Bindable(true),
            Category("Default"),
            Description("设置或返回日期字符串"),
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
        /// 客户端日历脚本的路径，默认为calendar.js
        /// </summary>
        [Description("设置客户端日历脚本的路径，默认为calendar.js")]
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
        /// 是否必填项，默认为true
        /// </summary>
        [Description("设置此日期是否为必填项，默认为true")]
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
        /// 创建控件
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
            comVali.ErrorMessage = "日期输入有误.";
            Controls.Add(comVali);

            reqVali = new RequiredFieldValidator();
            reqVali.ControlToValidate = txtDate.ID;
            reqVali.Display = ValidatorDisplay.Dynamic;
            reqVali.ErrorMessage = "*";
            reqVali.Enabled = IsRequest;
            Controls.Add(reqVali);
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "DataPicker", string.Format("<script language=\"javascript\" src=\"{0}\"></script>", ClientScriptFile));

            //this.Page.RegisterClientScriptBlock("DatePicker", string.Format("<script language=\"javascript\" src=\"{0}\"></script>", ClientScriptFile));
            //2.0中的方法已经改变。
        }
    }
}
