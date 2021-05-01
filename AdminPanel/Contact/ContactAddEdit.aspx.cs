using Addressbook.BAL;
using Addressbook.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Addressbook.AdminPanel.Contact
{
    public partial class ContactAddEdit : System.Web.UI.Page
    {
        #region Load Event
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                fillDropDownList();
                if (Request.QueryString["ContactID"] == null)
                    lblHeading.Text = "Add New Contact";
                else
                {
                    lblHeading.Text = "Edit Contact ";
                    fillControls(Convert.ToInt32(Request.QueryString["ContactID"]));
                }
                
            }
            
        }

        #region fill dropndown
        private void fillDropDownList()
        {
            CommonFillMethods.FillDropDownListBloodGroup(ddlBloodGroup);
            CommonFillMethods.FillDropDownListCity(ddlCity);
            CommonFillMethods.FillDropDownListContactCategory(ddlContactCategory);
            CommonFillMethods.FillDropDownListCountry(ddlCountry);
            CommonFillMethods.FillDropDownListState(ddlState);

        }
        #endregion fill dropndown

        #endregion Load Event

        #region fill controls
        private void fillControls(SqlInt32 ContactID)
        {
            ContactsENT entContact = new ContactsENT();
            ContactsBAL balContact = new ContactsBAL();

            entContact = balContact.SelectByPK(ContactID);
            if (entContact != null)
            {
                if (!entContact.PersonName.IsNull)
                    txtPersonName.Text = entContact.PersonName.Value.ToString();
                if (!entContact.Pincode.IsNull)
                    txtPincode.Text = entContact.Pincode.Value.ToString();
                if (!entContact.MobileNo.IsNull)
                    txtMobileNo.Text = entContact.MobileNo.Value.ToString();
                if (!entContact.Address.IsNull)
                    txtAddress.Text = entContact.Address.Value.ToString();
                if (!entContact.Email.IsNull)
                    txtEmail.Text = entContact.Email.Value.ToString();
                if (!entContact.PhoneNo.IsNull)
                    txtPhoneNo.Text = entContact.PhoneNo.Value.ToString();
                if (!entContact.Profession.IsNull)
                    txtProfession.Text = entContact.Profession.Value.ToString();
                if (!entContact.StateID.IsNull)
                    ddlState.SelectedValue = entContact.StateID.Value.ToString();
                if (!entContact.CityID.IsNull)
                    ddlCity.SelectedValue = entContact.CityID.Value.ToString();
                if (!entContact.CountryID.IsNull)
                    ddlCountry.SelectedValue = entContact.CountryID.Value.ToString();
                if (!entContact.ContactCategoryID.IsNull)
                    ddlContactCategory.SelectedValue = entContact.ContactCategoryID.Value.ToString();
                if (!entContact.BloodGroupID.IsNull)
                    ddlBloodGroup.SelectedValue = entContact.BloodGroupID.Value.ToString();
                if (!entContact.Gender.IsNull)
                    ddlGender.SelectedValue = entContact.Gender.Value.ToString();
                if (!entContact.BirthDate.IsNull)
                    txtBirthDate.Text = DateTime.Parse(entContact.BirthDate.ToString()).ToString("yyyy-MM-dd");
            }
            else
                lblError.Text = balContact.Message;


        }
        #endregion fill Controls

        #region Bytton : Save

        protected void btnSave_Click(object sender, EventArgs e)
        {
            #region Server Side Validation
            
            lblError.Text = "";
            if (txtPersonName.Text.Trim().ToUpper() == "")
                lblError.Text += "Enter Contact Name <br/>";

            if (txtMobileNo.Text.Trim() == "")
                lblError.Text += "Enter Mobile No <br/>";

            if (ddlBloodGroup.SelectedValue == "-1")
                lblError.Text += "Please Select Bloodgroup <br/>";

            if (ddlContactCategory.SelectedValue == "-1")
                lblError.Text += "Please Select Contact Category <br/>";


            if (lblError.Text != "")
                return;
            #endregion Server Side Validation

            #region Collecting Data
            ContactsENT entContact = new ContactsENT();
            if (ddlBloodGroup.SelectedValue != "-1" && ddlContactCategory.SelectedValue != "-1" && txtPersonName.Text.Trim().ToUpper() != "" && txtMobileNo.Text.Trim() != "")
            {
                entContact.PersonName = txtPersonName.Text.Trim().ToUpper();
                entContact.MobileNo = txtMobileNo.Text.Trim();
                entContact.BloodGroupID = Convert.ToInt32(ddlBloodGroup.SelectedValue);
                entContact.ContactCategoryID = Convert.ToInt32(ddlContactCategory.SelectedValue);
            }
            #region Reading Remaining Data

            if (txtAddress.Text.Trim().ToUpper() != "")
                entContact.Address = txtAddress.Text.Trim().ToUpper();

            if (txtPincode.Text.Trim() != "")
                entContact.Pincode = txtPincode.Text.Trim();

            if (txtEmail.Text.Trim().ToLower() != "")
                entContact.Email = txtEmail.Text.Trim().ToLower();

            if (txtPhoneNo.Text.Trim() != "")
                entContact.PhoneNo = txtPhoneNo.Text.Trim();

            if (txtProfession.Text.Trim().ToUpper() != "")
                entContact.Profession = txtProfession.Text.Trim().ToUpper();

            if (txtBirthDate.Text.Trim() != "")
                if (DateTime.Parse(txtBirthDate.Text.Trim()) <= DateTime.Now)
                    entContact.BirthDate = SqlDateTime.Parse(txtBirthDate.Text.Trim());
                else
                {
                    lblError.Text += "Invalid Birthdate";
                    return;
                }

            if (!entContact.BirthDate.IsNull)
                entContact.Age = (DateTime.Now.Subtract(DateTime.Parse(entContact.BirthDate.ToString())).Days / 365);

            if (ddlCity.SelectedValue != "-1")
                entContact.CityID = Convert.ToInt32(ddlCity.SelectedValue);

            if (ddlState.SelectedValue != "-1")
                entContact.StateID = Convert.ToInt32(ddlState.SelectedValue);

            if (ddlCountry.SelectedValue != "-1")
                entContact.CountryID = Convert.ToInt32(ddlCountry.SelectedValue);

            if (ddlGender.SelectedValue != "-1")
                entContact.Gender = ddlGender.SelectedValue;


            #endregion Reading Remaining Data

            #endregion Collecting Data
            ContactsBAL balContact = new ContactsBAL();
            if (Request.QueryString["ContactID"] == null)
            {
                #region insertingData
                if (balContact.Insert(entContact))
                    Response.Redirect("~/AdminPanel/Contact/ContactList.aspx");
                else
                    lblError.Text = balContact.Message;
                #endregion insertingData
            }
            else
            {
                #region updatingData
                entContact.ContactID = Convert.ToInt32(Request.QueryString["ContactID"]);
                if (balContact.Update(entContact))
                    Response.Redirect("~/AdminPanel/Contact/ContactList.aspx");
                else
                    lblError.Text = balContact.Message;
                #endregion updatingData
            }


        }
        #endregion Button : Save

        #region Button : Cancle
        protected void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminPanel/Contact/ContactList.aspx");
        }
        #endregion Button : Cancle


    }
}