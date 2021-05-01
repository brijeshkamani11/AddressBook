using Addressbook.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Addressbook.AdminPanel.City;



namespace Addressbook.AdminPanel.City
{
    public partial class CityList : System.Web.UI.Page
    {
        #region Load Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillGridViewCity();
            }
        }
        #endregion Load Event

        #region Fill City

        private void FillGridViewCity()
        {
            CitiesBAL balCity = new CitiesBAL();
            DataTable dtCity = new DataTable();
            dtCity = balCity.SelectAll();
            if (dtCity != null && dtCity.Rows.Count > 0)
            {
                gvCityList.DataSource = dtCity;
                gvCityList.DataBind();

            }

        }
        #endregion Fill City

        #region Delete City

        protected void gvCityList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandArgument != null)
            {
                CitiesBAL balCity = new CitiesBAL();
                if (balCity.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim())))
                {
                    Response.Redirect("~/Adminpanel/City/CityList.aspx");
                    lblError.Text = "";
                }
                else
                {

                    lblError.Text = balCity.Message;
                }
            }
        }
        #endregion Delete City
    }
}