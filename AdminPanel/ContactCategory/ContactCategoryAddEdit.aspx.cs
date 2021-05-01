using Addressbook.BAL;
using Addressbook.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Addressbook.AdminPanel.ContactCategory
{
    public partial class ContactCategoryAddEdit : System.Web.UI.Page
    {
        #region Load Event
        protected void Page_Load(object sender, EventArgs e)
        {
            #region Check Request
            if (!Page.IsPostBack)
            {

                if (Request.QueryString["ContactCategoryID"] == null)
                    lblHeading.Text = "Add New Contact Category";
                else
                {
                    lblHeading.Text = "Edit Contact Category";
                    fillControls(Convert.ToInt32(Request.QueryString["ContactCategoryID"]));
                }
            }
            #endregion Check Request
        }
        #endregion Load Event

        #region fill controls
        private void fillControls(SqlInt32 ContactCategoryID)
        {
            ContactCategoryENT entContactCategory = new ContactCategoryENT();
            ContactCategoryBAL balContactCategory = new ContactCategoryBAL();

            entContactCategory = balContactCategory.SelectByPK(ContactCategoryID);
            if (entContactCategory != null)
            {
                if (!entContactCategory.ContactCategoryName.IsNull)
                    txtContactCategoryName.Text = entContactCategory.ContactCategoryName.Value.ToString();
            }
            else
                lblError.Text = balContactCategory.Message;


        }
        #endregion fill Controls

        #region Bytton : Save

        protected void btnSave_Click(object sender, EventArgs e)
        {
            #region Server Side Validation
            
            lblError.Text = "";
            if (txtContactCategoryName.Text.Trim().ToUpper() == "")
                lblError.Text += "Enter ContactCategory Name <br/>";

            if (lblError.Text != "")
                return;
            #endregion Server Side Validation

            #region Collecting Data
            ContactCategoryENT entContactCategory = new ContactCategoryENT();
            if (txtContactCategoryName.Text.Trim().ToUpper() != "")
            {
                entContactCategory.ContactCategoryName = txtContactCategoryName.Text.Trim().ToUpper();
            }
            ContactCategoryBAL balContactCategory = new ContactCategoryBAL();
            #endregion Collecting Data
            if (Request.QueryString["ContactCategoryID"] == null)
            {
                #region insertingData
                if (balContactCategory.Insert(entContactCategory))
                    Response.Redirect("~/AdminPanel/ContactCategory/ContactCategoryList.aspx");
                else
                    lblError.Text = balContactCategory.Message;
                #endregion insertingData
            }
            else
            {
                #region updatingData
                entContactCategory.ContactCategoryID = Convert.ToInt32(Request.QueryString["ContactCategoryID"]);
                if (balContactCategory.Update(entContactCategory))
                    Response.Redirect("~/AdminPanel/ContactCategory/ContactCategoryList.aspx");
                else
                    lblError.Text = balContactCategory.Message;
                #endregion updatingData
            }


        }
        #endregion Button : Save

        #region Button : Cancle
        protected void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminPanel/ContactCategory/ContactCategoryList.aspx");
        }
        #endregion Button : Cancle
    }
}