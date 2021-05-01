using Addressbook.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Addressbook.AdminPanel.Country
{
    public partial class CountryList : System.Web.UI.Page
    {
        #region Load Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillGridViewCountry();
            }
        }
        #endregion Load Event

        #region Fill Country

        private void FillGridViewCountry()
        {
            CountryBAL balCountry = new CountryBAL();
            DataTable dtCountry = new DataTable();
            dtCountry = balCountry.SelectAll();
            if (dtCountry != null && dtCountry.Rows.Count > 0)
            {
                gvCountryList.DataSource = dtCountry;
                gvCountryList.DataBind();

            }

        }
        #endregion Fill Country

        #region Delete Country

        protected void gvCountryList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandArgument != null)
            {
                CountryBAL balCountry = new CountryBAL();
                if (balCountry.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim())))
                {
                    Response.Redirect("~/Adminpanel/Country/CountryList.aspx");
                    lblError.Text = "";
                }
                else
                {
                    lblError.Text = balCountry.Message;
                }
            }
        }
        #endregion Delete Country
    }
}