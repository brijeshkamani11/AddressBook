using Addressbook.BAL;
using Addressbook.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Addressbook.AdminPanel.City
{
    public partial class CityAddEdit : System.Web.UI.Page
    {
        #region Load Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                fillDropDownList();
                if (Request.QueryString["CityID"] == null)
                    lblHeading.Text = "Add New City";
                else
                {
                    lblHeading.Text = "Edit City ";
                    fillControls(Convert.ToInt32(Request.QueryString["CityID"]));
                }
            }
        }

        #region fill dropndown
        private void fillDropDownList()
        {
            CommonFillMethods.FillDropDownListState(ddlState);
        }
        #endregion fill dropndown

        #endregion Load Event

        #region fill controls
        private void fillControls(SqlInt32 CityID)
        {
            CitiesENT entCity = new CitiesENT();
            CitiesBAL balCity = new CitiesBAL();

            entCity = balCity.SelectByPK(CityID);
            if (entCity != null)
            {
                if (!entCity.CityName.IsNull)
                    txtCityName.Text = entCity.CityName.Value.ToString();
                if (!entCity.Pincode.IsNull)
                    txtPincode.Text = entCity.Pincode.Value.ToString();
                if (!entCity.STDCode.IsNull)
                    txtSTDCode.Text = entCity.STDCode.Value.ToString();
                if (!entCity.StateID.IsNull)
                    ddlState.SelectedValue = entCity.StateID.Value.ToString();
            }
            else
                lblError.Text = balCity.Message;


        }
        #endregion fill Controls

        #region Bytton : Save

        protected void btnSave_Click(object sender, EventArgs e)
        {
            #region Server Side Validation
            lblError.Text = "";
            if (txtCityName.Text.Trim().ToUpper() == "")
                lblError.Text += "Enter City Name <br/>";

            if (ddlState.SelectedValue == "-1")
                lblError.Text += "Please Select State <br/>";

            if (lblError.Text != "")
                return;
            #endregion Server Side Validation

            #region Collecting Data
            CitiesENT entCity = new CitiesENT();
            if (ddlState.SelectedValue != "-1" && txtCityName.Text.Trim().ToUpper() != "")
            {
                entCity.CityName = txtCityName.Text.Trim().ToUpper();
                entCity.StateID = Convert.ToInt32(ddlState.SelectedValue);
                entCity.Pincode = txtPincode.Text.Trim();
                entCity.STDCode = txtSTDCode.Text.Trim();
            }
            CitiesBAL balCity = new CitiesBAL();
            #endregion Collecting Data
            if (Request.QueryString["CityID"] == null)
            {
                #region insertingData
                if (balCity.Insert(entCity))
                    Response.Redirect("~/AdminPanel/City/CityList.aspx");
                else
                    lblError.Text = balCity.Message;
                #endregion insertingData
            }
            else
            {
                #region updatingData
                entCity.CityID = Convert.ToInt32(Request.QueryString["CityID"]);
                if (balCity.Update(entCity))
                    Response.Redirect("~/AdminPanel/City/CityList.aspx");
                else
                    lblError.Text = balCity.Message;
                #endregion updatingData
            }


        }
        #endregion Button : Save

        #region Button : Cancle
        protected void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminPanel/City/CityList.aspx");
        }
        #endregion Button : Cancle
    }
}