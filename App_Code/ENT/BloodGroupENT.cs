using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BloodGroupENT
/// </summary>

namespace Addressbook.ENT
{
	public class BloodGroupENT
	{
	
	#region Constructor 
	public BloodGroupENT()
	{
		//
		// TODO: Add constructor logic here
		//
	}
	#endregion Constructor
	
	#region BloodGroupID

	protected SqlInt32 _BloodGroupID;

	public SqlInt32 BloodGroupID
	{
		get
		{
			return _BloodGroupID;
		}		
		set
		{
			_BloodGroupID= value;
		}
	}

	#endregion BloodGroupID

	#region BloodGroupName

	protected SqlString _BloodGroupName;

	public SqlString BloodGroupName
	{
		get
		{
			return _BloodGroupName;
		}		
		set
		{
			_BloodGroupName= value;
		}
	}

	#endregion BloodGroupName

	}
}
