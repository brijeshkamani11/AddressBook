using Addressbook.BAL;
using Addressbook.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Addressbook.AdminPanel.State
{
    public partial class StateAddEdit : System.Web.UI.Page
    {
        #region Load Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                fillDropDownList();
                if (Request.QueryString["StateID"] == null)
                    lblHeading.Text = "Add New State";
                else
                {
                    lblHeading.Text = "Edit State ";
                    fillControls(Convert.ToInt32(Request.QueryString["StateID"]));
                }
            }
        }

        #region fill dropndown
        private void fillDropDownList()
        {
            CommonFillMethods.FillDropDownListCountry(ddlCountry);
        }
        #endregion fill dropndown

        #endregion Load Event

        #region fill controls
        private void fillControls(SqlInt32 StateID)
        {
            StatesENT entState = new StatesENT();
            StatesBAL balState = new StatesBAL();

            entState = balState.SelectByPK(StateID);
            if (entState != null)
            {
                if (!entState.StateName.IsNull)
                    txtStateName.Text = entState.StateName.Value.ToString();
                if (!entState.CountryID.IsNull)
                    ddlCountry.SelectedValue = entState.CountryID.Value.ToString();
            }
            else
                lblError.Text = balState.Message;


        }
        #endregion fill Controls

        #region Bytton : Save

        protected void btnSave_Click(object sender, EventArgs e)
        {
            #region Server Side Validation
            
            lblError.Text = "";
            if (txtStateName.Text.Trim().ToUpper() == "")
                lblError.Text += "Enter State Name <br/>";

            if (ddlCountry.SelectedValue == "-1")
                lblError.Text += "Please Select Country <br/>";

            if (lblError.Text != "")
                return;
            #endregion Server Side Validation

            #region Collecting Data
            StatesENT entState = new StatesENT();
            if (ddlCountry.SelectedValue != "-1" && txtStateName.Text.Trim().ToUpper() != "")
            {
                entState.StateName = txtStateName.Text.Trim().ToUpper();
                entState.CountryID = Convert.ToInt32(ddlCountry.SelectedValue);

            }
            StatesBAL balState = new StatesBAL();
            #endregion Collecting Data
            if (Request.QueryString["StateID"] == null)
            {
                #region insertingData
                if (balState.Insert(entState))
                    Response.Redirect("~/AdminPanel/State/StateList.aspx");
                else
                    lblError.Text = balState.Message;
                #endregion insertingData
            }
            else
            {
                #region updatingData
                entState.StateID = Convert.ToInt32(Request.QueryString["StateID"]);
                if (balState.Update(entState))
                    Response.Redirect("~/AdminPanel/State/StateList.aspx");
                else
                    lblError.Text = balState.Message;
                #endregion updatingData
            }


        }
        #endregion Button : Save

        #region Button : Cancle
        protected void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminPanel/State/StateList.aspx");
        }
        #endregion Button : Cancle
    }
}