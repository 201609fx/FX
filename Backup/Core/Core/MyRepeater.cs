using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SZMA.Core
{
    [ToolboxData("<{0}:MyRepeater runat=server></{0}:MyRepeater>")]
   public class MyRepeater:System.Web.UI.WebControls.Repeater
    {
       protected override void OnDataBinding(System.EventArgs e)
       {
           base.OnDataBinding(e);

           this.Controls.Clear();
           this.ClearChildViewState();

           this.CreateControlHierarchy(true);
           this.ChildControlsCreated = true;
       }
       //protected MyRepeaterItem[] MyItems;
       //public override RepeaterItemCollection Items
       //{
       //    get
       //    {
       //        return new RepeaterItemCollection(new ArrayList(MyItems));
       //    }
       //}


    }
}
