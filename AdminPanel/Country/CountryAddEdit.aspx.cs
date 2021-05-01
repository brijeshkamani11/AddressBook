using Addressbook.BAL;
using Addressbook.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Addressbook.AdminPanel.Country
{
    public partial class CountryAddEdit : System.Web.UI.Page
    {
        #region Load Event
        protected void Page_Load(object sender, EventArgs e)
        {
            #region Check Request
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["CountryID"] == null)
                    lblHeading.Text = "Add New Country";
                else
                {
                    lblHeading.Text = "Edit Country";
                    fillControls(Convert.ToInt32(Request.QueryString["CountryID"]));
                }
            }
            #endregion Check Request
        }
        #endregion Load Event

        #region fill controls
        private void fillControls(SqlInt32 CountryID)
        {
            CountryENT entCountry = new CountryENT();
            CountryBAL balCountry = new CountryBAL();

            entCountry = balCountry.SelectByPK(CountryID);
            if (entCountry != null)
            {
                if (!entCountry.CountryName.IsNull)
                    txtCountryName.Text = entCountry.CountryName.Value.ToString();
                if (!entCountry.CountryCode.IsNull)
                    txtCountryCode.Text = entCountry.CountryCode.Value.ToString();
            }
            else
                lblError.Text = balCountry.Message;


        }
        #endregion fill Controls

        #region Bytton : Save

        protected void btnSave_Click(object sender, EventArgs e)
        {
            #region Server Side Validation
            lblError.Text = "";
            if (txtCountryName.Text.Trim().ToUpper() == "")
                lblError.Text += "Enter Country Name <br/>";

            if (txtCountryCode.Text.Trim().ToUpper() == "")
                lblError.Text += "Enter Country Code <br/>";


            if (lblError.Text != "")
                return;
            #endregion Server Side Validation

            #region Collecting Data
            CountryENT entCountry = new CountryENT();
            if (txtCountryCode.Text.Trim().ToUpper() != "" && txtCountryName.Text.Trim().ToUpper() != "")
            {
                entCountry.CountryName = txtCountryName.Text.Trim().ToUpper();
                entCountry.CountryCode = txtCountryCode.Text.Trim().ToUpper();

            }
            CountryBAL balCountry = new CountryBAL();
            #endregion Collecting Data
            if (Request.QueryString["CountryID"] == null)
            {
                #region insertingData
                if (balCountry.Insert(entCountry))
                    Response.Redirect("~/AdminPanel/Country/CountryList.aspx");
                else
                    lblError.Text = balCountry.Message;
                #endregion insertingData
            }
            else
            {
                #region updatingData
                entCountry.CountryID = Convert.ToInt32(Request.QueryString["CountryID"]);
                if (balCountry.Update(entCountry))
                    Response.Redirect("~/AdminPanel/Country/CountryList.aspx");
                else
                    lblError.Text = balCountry.Message;
                #endregion updatingData
            }


        }
        #endregion Button : Save

        #region Button : Cancle
        protected void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminPanel/Country/CountryList.aspx");
        }
        #endregion Button : Cancle
    }
}