using Addressbook.ENT;
using Addressbook.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CountryBAL
/// </summary>

namespace Addressbook.BAL
{
	public class CountryBAL
	{
	
		#region Constructor
		public CountryBAL()
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
		public Boolean Insert(CountryENT entCountry)
		{
			CountryDAL dalCountry = new CountryDAL();
			if (dalCountry.Insert(entCountry))
			{
				return true;
			}
			else
			{
				Message = dalCountry.Message;
				return false;
			}
		}
		#endregion Insert Operation

		#region Update Operation
		public Boolean Update(CountryENT entCountry)
		{
			CountryDAL dalCountry = new CountryDAL();
			if (dalCountry.Update(entCountry))
			{
				return true;
			}
			else
			{
				Message = dalCountry.Message;
				return false;
			}
		}
		#endregion Update Operation

		#region Delete Operation
		public Boolean Delete(SqlInt32 CountryID)
		{
			CountryDAL dalCountry = new CountryDAL();
			if (dalCountry.Delete(CountryID))
			{
				return true;
			}
			else
			{
				Message = dalCountry.Message;
				return false;
			}
		}
		#endregion Delete Operation

		#region Select Operation

		#region Select All
		public DataTable SelectAll()
		{
			CountryDAL dalCountry = new CountryDAL();
			return dalCountry.SelectAll();
		}
		#endregion Select All

		#region SelectForDropdownList
		public DataTable SelectForDropdownList()
		{
			CountryDAL dalCountry = new CountryDAL();
			return dalCountry.SelectForDropdownList();
		}
		#endregion SelectForDropdownList

		#region SelectByPK
		public CountryENT SelectByPK(SqlInt32 CountryID)
		{
			CountryDAL dalCountry = new CountryDAL();
			return dalCountry.SelectByPK(CountryID);
		}
		#endregion SelectByPK

		#endregion Select Operation
	}
}