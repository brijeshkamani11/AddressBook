using Addressbook.ENT;
using Addressbook.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StatesBAL
/// </summary>

namespace Addressbook.BAL
{
	public class StatesBAL
	{
	
		#region Constructor
		public StatesBAL()
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
		public Boolean Insert(StatesENT entStates)
		{
			StatesDAL dalStates = new StatesDAL();
			if (dalStates.Insert(entStates))
			{
				return true;
			}
			else
			{
				Message = dalStates.Message;
				return false;
			}
		}
		#endregion Insert Operation

		#region Update Operation
		public Boolean Update(StatesENT entStates)
		{
			StatesDAL dalStates = new StatesDAL();
			if (dalStates.Update(entStates))
			{
				return true;
			}
			else
			{
				Message = dalStates.Message;
				return false;
			}
		}
		#endregion Update Operation

		#region Delete Operation
		public Boolean Delete(SqlInt32 StatesID)
		{
			StatesDAL dalStates = new StatesDAL();
			if (dalStates.Delete(StatesID))
			{
				return true;
			}
			else
			{
				Message = dalStates.Message;
				return false;
			}
		}
		#endregion Delete Operation

		#region Select Operation

		#region Select All
		public DataTable SelectAll()
		{
			StatesDAL dalStates = new StatesDAL();
			return dalStates.SelectAll();
		}
		#endregion Select All

		#region SelectForDropdownList
		public DataTable SelectForDropdownList()
		{
			StatesDAL dalStates = new StatesDAL();
			return dalStates.SelectForDropdownList();
		}
		#endregion SelectForDropdownList

		#region SelectByPK
		public StatesENT SelectByPK(SqlInt32 StatesID)
		{
			StatesDAL dalStates = new StatesDAL();
			return dalStates.SelectByPK(StatesID);
		}
		#endregion SelectByPK

		#endregion Select Operation
	}
}