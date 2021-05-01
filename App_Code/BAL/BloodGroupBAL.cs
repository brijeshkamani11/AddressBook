using Addressbook.ENT;
using Addressbook.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BloodGroupBAL
/// </summary>

namespace Addressbook.BAL
{
	public class BloodGroupBAL
	{
	
		#region Constructor
		public BloodGroupBAL()
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
		public Boolean Insert(BloodGroupENT entBloodGroup)
		{
			BloodGroupDAL dalBloodGroup = new BloodGroupDAL();
			if (dalBloodGroup.Insert(entBloodGroup))
			{
				return true;
			}
			else
			{
				Message = dalBloodGroup.Message;
				return false;
			}
		}
		#endregion Insert Operation

		#region Update Operation
		public Boolean Update(BloodGroupENT entBloodGroup)
		{
			BloodGroupDAL dalBloodGroup = new BloodGroupDAL();
			if (dalBloodGroup.Update(entBloodGroup))
			{
				return true;
			}
			else
			{
				Message = dalBloodGroup.Message;
				return false;
			}
		}
		#endregion Update Operation

		#region Delete Operation
		public Boolean Delete(SqlInt32 BloodGroupID)
		{
			BloodGroupDAL dalBloodGroup = new BloodGroupDAL();
			if (dalBloodGroup.Delete(BloodGroupID))
			{
				return true;
			}
			else
			{
				Message = dalBloodGroup.Message;
				return false;
			}
		}
		#endregion Delete Operation

		#region Select Operation

		#region Select All
		public DataTable SelectAll()
		{
			BloodGroupDAL dalBloodGroup = new BloodGroupDAL();
			return dalBloodGroup.SelectAll();
		}
		#endregion Select All

		#region SelectForDropdownList
		public DataTable SelectForDropdownList()
		{
			BloodGroupDAL dalBloodGroup = new BloodGroupDAL();
			return dalBloodGroup.SelectForDropdownList();
		}
		#endregion SelectForDropdownList

		#region SelectByPK
		public BloodGroupENT SelectByPK(SqlInt32 BloodGroupID)
		{
			BloodGroupDAL dalBloodGroup = new BloodGroupDAL();
			return dalBloodGroup.SelectByPK(BloodGroupID);
		}
		#endregion SelectByPK

		#endregion Select Operation
	}
}