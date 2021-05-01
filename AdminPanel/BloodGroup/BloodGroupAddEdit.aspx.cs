using Addressbook.BAL;
using Addressbook.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Addressbook.AdminPanel.BloodGroup
{
    public partial class BloodGroupAddEdit : System.Web.UI.Page
    {
        #region Load Event
        protected void Page_Load(object sender, EventArgs e)
        {
            #region Check Request
            if (!Page.IsPostBack)
            {

                if (Request.QueryString["BloodGroupID"] == null)
                    lblHeading.Text = "Add New BloodGroup";
                else
                {
                    lblHeading.Text = "Edit BloodGroup";
                    fillControls(Convert.ToInt32(Request.QueryString["BloodGroupID"]));
                }
            }
            #endregion Check Request
        }
        #endregion Load Event

        #region fill controls
        private void fillControls(SqlInt32 BloodGroupID)
        {
            BloodGroupENT entBloodGroup = new BloodGroupENT();
            BloodGroupBAL balBloodGroup = new BloodGroupBAL();

            entBloodGroup = balBloodGroup.SelectByPK(BloodGroupID);
            if (entBloodGroup != null)
            {
                if (!entBloodGroup.BloodGroupName.IsNull)
                    txtBloodGroupName.Text = entBloodGroup.BloodGroupName.Value.ToString();
            }
            else
                lblError.Text = balBloodGroup.Message;


        }
        #endregion fill Controls

        #region Bytton : Save

        protected void btnSave_Click(object sender, EventArgs e)
        {
            #region Server Side Validation

            lblError.Text = "";
            if (txtBloodGroupName.Text.Trim().ToUpper() == "")
                lblError.Text += "Enter BloodGroup Name <br/>";

            if (lblError.Text != "")
                return;
            #endregion Server Side Validation

            #region Collecting Data
            BloodGroupENT entBloodGroup = new BloodGroupENT();
            if (txtBloodGroupName.Text.Trim().ToUpper() != "")
            {
                entBloodGroup.BloodGroupName = txtBloodGroupName.Text.Trim().ToUpper();
            }
            BloodGroupBAL balBloodGroup = new BloodGroupBAL();
            #endregion Collecting Data
            if (Request.QueryString["BloodGroupID"] == null)
            {
                #region insertingData
                if (balBloodGroup.Insert(entBloodGroup))
                    Response.Redirect("~/AdminPanel/BloodGroup/BloodGroupList.aspx");
                else
                    lblError.Text = balBloodGroup.Message;
                #endregion insertingData
            }
            else
            {
                #region updatingData
                entBloodGroup.BloodGroupID = Convert.ToInt32(Request.QueryString["BloodGroupID"]);
                if (balBloodGroup.Update(entBloodGroup))
                    Response.Redirect("~/AdminPanel/BloodGroup/BloodGroupList.aspx");
                else
                    lblError.Text = balBloodGroup.Message;
                #endregion updatingData
            }


        }
        #endregion Button : Save

        #region Button : Cancle
        protected void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminPanel/BloodGroup/BloodGroupList.aspx");
        }
        #endregion Button : Cancle
    }
}