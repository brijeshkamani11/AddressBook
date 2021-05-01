using Addressbook.ENT;
using Addressbook.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ContactCategoryBAL
/// </summary>

namespace Addressbook.BAL
{
	public class ContactCategoryBAL
	{
	
		#region Constructor
		public ContactCategoryBAL()
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
		public Boolean Insert(ContactCategoryENT entContactCategory)
		{
			ContactCategoryDAL dalContactCategory = new ContactCategoryDAL();
			if (dalContactCategory.Insert(entContactCategory))
			{
				return true;
			}
			else
			{
				Message = dalContactCategory.Message;
				return false;
			}
		}
		#endregion Insert Operation

		#region Update Operation
		public Boolean Update(ContactCategoryENT entContactCategory)
		{
			ContactCategoryDAL dalContactCategory = new ContactCategoryDAL();
			if (dalContactCategory.Update(entContactCategory))
			{
				return true;
			}
			else
			{
				Message = dalContactCategory.Message;
				return false;
			}
		}
		#endregion Update Operation

		#region Delete Operation
		public Boolean Delete(SqlInt32 ContactCategoryID)
		{
			ContactCategoryDAL dalContactCategory = new ContactCategoryDAL();
			if (dalContactCategory.Delete(ContactCategoryID))
			{
				return true;
			}
			else
			{
				Message = dalContactCategory.Message;
				return false;
			}
		}
		#endregion Delete Operation

		#region Select Operation

		#region Select All
		public DataTable SelectAll()
		{
			ContactCategoryDAL dalContactCategory = new ContactCategoryDAL();
			return dalContactCategory.SelectAll();
		}
		#endregion Select All

		#region SelectForDropdownList
		public DataTable SelectForDropdownList()
		{
			ContactCategoryDAL dalContactCategory = new ContactCategoryDAL();
			return dalContactCategory.SelectForDropdownList();
		}
		#endregion SelectForDropdownList

		#region SelectByPK
		public ContactCategoryENT SelectByPK(SqlInt32 ContactCategoryID)
		{
			ContactCategoryDAL dalContactCategory = new ContactCategoryDAL();
			return dalContactCategory.SelectByPK(ContactCategoryID);
		}
		#endregion SelectByPK

		#endregion Select Operation
	}
}