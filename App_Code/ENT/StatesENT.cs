using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StatesENT
/// </summary>

namespace Addressbook.ENT
{
	public class StatesENT
	{
	
	#region Constructor 
	public StatesENT()
	{
		//
		// TODO: Add constructor logic here
		//
	}
	#endregion Constructor
	
	#region StateID

	protected SqlInt32 _StateID;

	public SqlInt32 StateID
	{
		get
		{
			return _StateID;
		}		
		set
		{
			_StateID= value;
		}
	}

	#endregion StateID

	#region CountryID

	protected SqlInt32 _CountryID;

	public SqlInt32 CountryID
	{
		get
		{
			return _CountryID;
		}		
		set
		{
			_CountryID= value;
		}
	}

	#endregion CountryID

	#region StateName

	protected SqlString _StateName;

	public SqlString StateName
	{
		get
		{
			return _StateName;
		}		
		set
		{
			_StateName= value;
		}
	}

	#endregion StateName

	}
}
