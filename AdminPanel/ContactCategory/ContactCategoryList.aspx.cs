using Addressbook.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Addressbook.AdminPanel.ContactCategory
{
    public partial class ContactCategory : System.Web.UI.Page
    {
        #region Load Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillGridViewContactCategory();
            }
        }
        #endregion Load Event

        #region Fill ContactCategory

        private void FillGridViewContactCategory()
        {
            ContactCategoryBAL balContactCategory = new ContactCategoryBAL();
            DataTable dtContactCategory = new DataTable();
            dtContactCategory = balContactCategory.SelectAll();
            if (dtContactCategory != null && dtContactCategory.Rows.Count > 0)
            {
                gvContactCategoryList.DataSource = dtContactCategory;
                gvContactCategoryList.DataBind();

            }

        }
        #endregion Fill ContactCategory

        #region Delete ContactCategory

        protected void gvContactCategoryList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandArgument != null)
            {
                ContactCategoryBAL balContactCategory = new ContactCategoryBAL();
                if (balContactCategory.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim())))
                {
                    Response.Redirect("~/Adminpanel/ContactCategory/ContactCategoryList.aspx");
                    lblError.Text = "";
                }
                else
                {
                    lblError.Text = balContactCategory.Message;
                }
            }
        }
        #endregion Delete ContactCategory
    }
}