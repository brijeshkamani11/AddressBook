using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Addressbook.BAL;


namespace Addressbook
{
    public class CommonFillMethods
    {
        CommonFillMethods()
        {

        }
        public static void FillDropDownListState(DropDownList ddl)
        {
            StatesBAL balState = new StatesBAL();
            ddl.DataSource = balState.SelectForDropdownList();
            ddl.DataValueField = "StateID";
            ddl.DataTextField = "StateName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select Item", "-1"));
        }
        public static void FillDropDownListCity(DropDownList ddl)
        {
            CitiesBAL balCity = new CitiesBAL();
            ddl.DataSource = balCity.SelectForDropdownList();
            ddl.DataValueField = "CityID";
            ddl.DataTextField = "CityName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select Item", "-1"));
        }
        public static void FillDropDownListCountry(DropDownList ddl)
        {
            CountryBAL balCountry = new CountryBAL();
            ddl.DataSource = balCountry.SelectForDropdownList();
            ddl.DataValueField = "CountryID";
            ddl.DataTextField = "CountryName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select Item", "-1"));
        }
        public static void FillDropDownListBloodGroup(DropDownList ddl)
        {
            BloodGroupBAL balBloodGroup = new BloodGroupBAL();
            ddl.DataSource = balBloodGroup.SelectForDropdownList();
            ddl.DataValueField = "BloodGroupID";
            ddl.DataTextField = "BloodGroupName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select Item", "-1"));
        }
        public static void FillDropDownListContactCategory(DropDownList ddl)
        {
            ContactCategoryBAL balContactCategory = new ContactCategoryBAL();
            ddl.DataSource = balContactCategory.SelectForDropdownList();
            ddl.DataValueField = "ContactCategoryID";
            ddl.DataTextField = "ContactCategoryName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select Item", "-1"));
        }
    }
}