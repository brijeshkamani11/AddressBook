using Addressbook.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StatesDAL
/// </summary>

namespace Addressbook.DAL
{
    public class StatesDAL : DatabaseConfig
	{
	
		#region Constructor 
		public StatesDAL()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion Constructor
		
		#region Local Variables
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
		#endregion Local Variables

		#region Insert Operation
		public Boolean Insert(StatesENT entStates)
		{
			using (SqlConnection objConn = new SqlConnection(ConnectionString))
			{
				objConn.Open();
				using (SqlCommand objCmd = objConn.CreateCommand())
				{
					try
					{
						#region Prepare Command
						objCmd.CommandType = CommandType.StoredProcedure;
						objCmd.CommandText = "PR_States_Insert";
						objCmd.Parameters.Add("@StateID", SqlDbType.Int).Direction = ParameterDirection.Output;
						objCmd.Parameters.AddWithValue("@CountryID", SqlDbType.Int).Value = entStates.CountryID;
						objCmd.Parameters.AddWithValue("@StateName", SqlDbType.VarChar).Value = entStates.StateName;
						#endregion Prepare Command

						objCmd.ExecuteNonQuery();

						if (objCmd.Parameters["@StateID"] != null)
							entStates.StateID = Convert.ToInt32(objCmd.Parameters["@StateID"].Value);

						return true;
					}
					catch (SqlException sqlex)
					{
						Message = sqlex.Message.ToString();
						return false;
					}
					catch (Exception ex)
					{
						Message = ex.Message.ToString();
						return false;
					}
					finally
					{
						if (objConn.State == ConnectionState.Open)
							objConn.Close();
					}
				}
			}
		}
		#endregion Insert Operation

		#region Delete Operation
		public Boolean Delete(SqlInt32 StatesID)
		{
			using (SqlConnection objConn = new SqlConnection(ConnectionString))
			{
				objConn.Open();
				using (SqlCommand objCmd = objConn.CreateCommand())
				{
					try
					{
						#region Prepare Command
						objCmd.CommandType = CommandType.StoredProcedure;
						objCmd.CommandText = "PR_States_DeleteByPK";
						objCmd.Parameters.AddWithValue("@StateID", StatesID);
						#endregion Prepare Command

						objCmd.ExecuteNonQuery();

						return true;
					}
					catch (SqlException sqlex)
					{
						Message = sqlex.Message.ToString();
						return false;
					}
					catch (Exception ex)
					{
						Message = ex.Message.ToString();
						return false;
					}
					finally
					{
						if (objConn.State == ConnectionState.Open)
							objConn.Close();
					}
				}
			}
		}
		#endregion Delete Operation

		#region Update Operation
		public Boolean Update(StatesENT entStates)
		{
			using (SqlConnection objConn = new SqlConnection(ConnectionString))
			{
				objConn.Open();
				using (SqlCommand objCmd = objConn.CreateCommand())
				{
					try
					{
						#region Prepare Command
						objCmd.CommandType = CommandType.StoredProcedure;
						objCmd.CommandText = "PR_States_UpdateByPK";
						objCmd.Parameters.AddWithValue("@StateID", entStates.StateID);
						objCmd.Parameters.AddWithValue("@CountryID", entStates.CountryID);
						objCmd.Parameters.AddWithValue("@StateName", entStates.StateName);
						#endregion Prepare Command

						objCmd.ExecuteNonQuery();

						return true;
					}
					catch (SqlException sqlex)
					{
						Message = sqlex.Message.ToString();
						return false;
					}
					catch (Exception ex)
					{
						Message = ex.Message.ToString();
						return false;
					}
					finally
					{
						if (objConn.State == ConnectionState.Open)
							objConn.Close();
					}
				}
			}
		}
		#endregion Update Operation

		#region SelectAll
		public DataTable SelectAll()
		{
			using (SqlConnection objConn = new SqlConnection(ConnectionString))
			{
				objConn.Open();
				using (SqlCommand objCmd = objConn.CreateCommand())
				{
					try
					{
						#region Prepare Command
						objCmd.CommandType = CommandType.StoredProcedure;
						objCmd.CommandText = "PR_States_SelectAll";
						#endregion Prepare Command

						#region ReadData and Set Controls
						DataTable dt = new DataTable();
						using (SqlDataReader objSDR = objCmd.ExecuteReader())
						{
							dt.Load(objSDR);
						}
						return dt;
						#endregion ReadData and Set Controls
					}
					catch (SqlException sqlex)
					{
						Message = sqlex.Message.ToString();
						return null;
					}
					catch (Exception ex)
					{
						Message = ex.Message.ToString();
						return null;
					}
					finally
					{
						if (objConn.State == ConnectionState.Open)
							objConn.Close();
					}
				}
			}
		}
		#endregion SelectAll

		#region SelectForDropdown
		public DataTable SelectForDropdownList()
		{
			using (SqlConnection objConn = new SqlConnection(ConnectionString))
			{
				objConn.Open();
				using (SqlCommand objCmd = objConn.CreateCommand())
				{
					try
					{
						#region Prepare Command
						objCmd.CommandType = CommandType.StoredProcedure;
						objCmd.CommandText = "PR_States_SelectForDropDownList";
						#endregion Prepare Command

						#region ReadData and Set Controls
						DataTable dt = new DataTable();
						using (SqlDataReader objSDR = objCmd.ExecuteReader())
						{
							dt.Load(objSDR);
						}
						return dt;
						#endregion ReadData and Set Controls
					}
					catch (SqlException sqlex)
					{
						Message = sqlex.Message.ToString();
						return null;
					}
					catch (Exception ex)
					{
						Message = ex.Message.ToString();
						return null;
					}
					finally
					{
						if (objConn.State == ConnectionState.Open)
							objConn.Close();
					}
				}
			}
		}
		#endregion SelectForDropdown

		#region SelectBYPK
		public StatesENT SelectByPK(SqlInt32 StatesID)
		{
			using (SqlConnection objConn = new SqlConnection(ConnectionString))
			{
				objConn.Open();
				using (SqlCommand objCmd = objConn.CreateCommand())
				{
					try
					{
						#region Prepare Command
						objCmd.CommandType = CommandType.StoredProcedure;
						objCmd.CommandText = "PR_States_SelectByPK";
						objCmd.Parameters.AddWithValue("@StateID",StatesID);
						#endregion Prepare Command

						#region ReadData and Set Controls
						StatesENT entStates = new StatesENT();
						using(SqlDataReader objSDR = objCmd.ExecuteReader())
						{
							while (objSDR.Read())
							{
								if (!objSDR["StateID"].Equals(DBNull.Value))
								{
									entStates.StateID = Convert.ToInt32(objSDR["StateID"]);
								}
								if (!objSDR["CountryID"].Equals(DBNull.Value))
								{
									entStates.CountryID = Convert.ToInt32(objSDR["CountryID"]);
								}
								if (!objSDR["StateName"].Equals(DBNull.Value))
								{
									entStates.StateName = Convert.ToString(objSDR["StateName"]);
								}
							}
						}

						return entStates;
						#endregion ReadData and Set Controls
					}
					catch (SqlException sqlex)
					{
						Message = sqlex.Message.ToString();
						return null;
					}
					catch (Exception ex)
					{
						Message = ex.Message.ToString();
						return null;
					}
					finally
					{
						if (objConn.State == ConnectionState.Open)
							objConn.Close();
					}
				}
			}
		}
		#endregion SelectBYPK
	}
}