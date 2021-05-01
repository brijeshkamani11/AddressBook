using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CitiesENT
/// </summary>

namespace Addressbook.ENT
{
	public class CitiesENT
	{
	
	#region Constructor 
	public CitiesENT()
	{
		//
		// TODO: Add constructor logic here
		//
	}
	#endregion Constructor
	
	#region CityID

	protected SqlInt32 _CityID;

	public SqlInt32 CityID
	{
		get
		{
			return _CityID;
		}		
		set
		{
			_CityID= value;
		}
	}

	#endregion CityID

	#region CityName

	protected SqlString _CityName;

	public SqlString CityName
	{
		get
		{
			return _CityName;
		}		
		set
		{
			_CityName= value;
		}
	}

	#endregion CityName

	#region Pincode

	protected SqlString _Pincode;

	public SqlString Pincode
	{
		get
		{
			return _Pincode;
		}		
		set
		{
			_Pincode= value;
		}
	}

	#endregion Pincode

	#region STDCode

	protected SqlString _STDCode;

	public SqlString STDCode
	{
		get
		{
			return _STDCode;
		}		
		set
		{
			_STDCode= value;
		}
	}

	#endregion STDCode

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

	}
}
