using Addressbook.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Addressbook.AdminPanel.Contact
{
    public partial class ContactList : System.Web.UI.Page
    {
        #region Load Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillGridViewContact();
            }
        }
        #endregion Load Event

        #region Fill Contact

        private void FillGridViewContact()
        {
            ContactsBAL balContact = new ContactsBAL();
            DataTable dtContact = new DataTable();
            dtContact = balContact.SelectAll();
            if (dtContact != null && dtContact.Rows.Count > 0)
            {
                gvContactList.DataSource = dtContact;
                gvContactList.DataBind();

            }

        }
        #endregion Fill Contact

        #region Delete Contact

        protected void gvContactList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandArgument != null)
            {
                ContactsBAL balContact = new ContactsBAL();
                if (balContact.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim())))
                {
                    Response.Redirect("~/Adminpanel/Contact/ContactList.aspx");
                    lblError.Text = "";
                }
                else
                {

                    lblError.Text = balContact.Message;
                }
            }
        }
        #endregion Delete Contact
    }
}