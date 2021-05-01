using Addressbook.ENT;
using Addressbook.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CitiesBAL
/// </summary>

namespace Addressbook.BAL
{
	public class CitiesBAL
	{
	
		#region Constructor
		public CitiesBAL()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion Constructor

		#region Local Variable

		protected string _Message;

		public string Message
		{
			get
			{
				return _Message;
			}
			set
			{
				 _Message = value;
			}
		}
		#endregion Local Variable

		#region Insert Operation
		public Boolean Insert(CitiesENT entCities)
		{
			CitiesDAL dalCities = new CitiesDAL();
			if (dalCities.Insert(entCities))
			{
				return true;
			}
			else
			{
				Message = dalCities.Message;
				return false;
			}
		}
		#endregion Insert Operation

		#region Update Operation
		public Boolean Update(CitiesENT entCities)
		{
			CitiesDAL dalCities = new CitiesDAL();
			if (dalCities.Update(entCities))
			{
				return true;
			}
			else
			{
				Message = dalCities.Message;
				return false;
			}
		}
		#endregion Update Operation

		#region Delete Operation
		public Boolean Delete(SqlInt32 CityID)
		{
			CitiesDAL dalCities = new CitiesDAL();
			if (dalCities.Delete(CityID))
			{
				return true;
			}
			else
			{
				Message = dalCities.Message;
				return false;
			}
		}
		#endregion Delete Operation

		#region Select Operation

		#region Select All
		public DataTable SelectAll()
		{
			CitiesDAL dalCities = new CitiesDAL();
			return dalCities.SelectAll();
		}
		#endregion Select All

		#region SelectForDropdownList
		public DataTable SelectForDropdownList()
		{
			CitiesDAL dalCities = new CitiesDAL();
			return dalCities.SelectForDropdownList();
		}
		#endregion SelectForDropdownList

		#region SelectByPK
		public CitiesENT SelectByPK(SqlInt32 CitiesID)
		{
			CitiesDAL dalCities = new CitiesDAL();
			return dalCities.SelectByPK(CitiesID);
		}
		#endregion SelectByPK

		#endregion Select Operation
	}
}