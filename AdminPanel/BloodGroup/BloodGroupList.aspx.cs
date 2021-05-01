using Addressbook.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Addressbook.AdminPanel.BloodGroup
{
    public partial class BloodGroup : System.Web.UI.Page
    {
        #region Load Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillGridViewBloodGroup();
            }
        }
        #endregion Load Event

        #region Fill BloodGroup

        private void FillGridViewBloodGroup()
        {
            BloodGroupBAL balBloodGroup = new BloodGroupBAL();
            DataTable dtBloodGroup = new DataTable();
            dtBloodGroup = balBloodGroup.SelectAll();
            if (dtBloodGroup != null && dtBloodGroup.Rows.Count > 0)
            {
                gvBloodGroupList.DataSource = dtBloodGroup;
                gvBloodGroupList.DataBind();

            }

        }
        #endregion Fill BloodGroup

        #region Delete BloodGroup

        protected void gvBloodGroupList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandArgument != null)
            {
                BloodGroupBAL balBloodGroup = new BloodGroupBAL();
                if (balBloodGroup.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim())))
                {
                    Response.Redirect("~/Adminpanel/BloodGroup/BloodGroupList.aspx");
                    lblError.Text = "";
                }
                else
                {
                    lblError.Text = balBloodGroup.Message;
                }
            }
        }
        #endregion Delete BloodGroup
    }
}