using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ContactCategoryENT
/// </summary>

namespace Addressbook.ENT
{
	public class ContactCategoryENT
	{
	
	#region Constructor 
	public ContactCategoryENT()
	{
		//
		// TODO: Add constructor logic here
		//
	}
	#endregion Constructor
	
	#region ContactCategoryID

	protected SqlInt32 _ContactCategoryID;

	public SqlInt32 ContactCategoryID
	{
		get
		{
			return _ContactCategoryID;
		}		
		set
		{
			_ContactCategoryID= value;
		}
	}

	#endregion ContactCategoryID

	#region ContactCategoryName

	protected SqlString _ContactCategoryName;

	public SqlString ContactCategoryName
	{
		get
		{
			return _ContactCategoryName;
		}		
		set
		{
			_ContactCategoryName= value;
		}
	}

	#endregion ContactCategoryName

	}
}
