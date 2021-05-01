using Addressbook.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Addressbook.AdminPanel.State
{
    public partial class StateList : System.Web.UI.Page
    {
        #region Load Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillGridViewState();
            }
        }
        #endregion Load Event

        #region Fill State

        private void FillGridViewState()
        {
            StatesBAL balState = new StatesBAL();
            DataTable dtState = new DataTable();
            dtState = balState.SelectAll();
            if (dtState != null && dtState.Rows.Count > 0)
            {
                gvStateList.DataSource = dtState;
                gvStateList.DataBind();

            }

        }
        #endregion Fill State

        #region Delete State

        protected void gvStateList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandArgument != null)
            {
                StatesBAL balState = new StatesBAL();
                if (balState.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim())))
                {
                    Response.Redirect("~/Adminpanel/State/StateList.aspx");
                    lblError.Text = "";
                }
                else
                {

                    lblError.Text = balState.Message;
                }
            }
        }
        #endregion Delete State
    }
}