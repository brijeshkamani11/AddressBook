using Addressbook.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CountryDAL
/// </summary>

namespace Addressbook.DAL
{
	public class CountryDAL : DatabaseConfig
	{
	
		#region Constructor 
		public CountryDAL()
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
		public Boolean Insert(CountryENT entCountry)
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
						objCmd.CommandText = "PR_Country_Insert";
						objCmd.Parameters.Add("@CountryID", SqlDbType.Int).Direction = ParameterDirection.Output;
						objCmd.Parameters.AddWithValue("@CountryName", SqlDbType.VarChar).Value = entCountry.CountryName;
						objCmd.Parameters.AddWithValue("@CountryCode", SqlDbType.VarChar).Value = entCountry.CountryCode;
						#endregion Prepare Command

						objCmd.ExecuteNonQuery();

						if (objCmd.Parameters["@CountryID"] != null)
							entCountry.CountryID = Convert.ToInt32(objCmd.Parameters["@CountryID"].Value);

						return true;
					}
					catch (SqlException sqlex)
					{
						Message = sqlex.InnerException.Message.ToString();
						return false;
					}
					catch (Exception ex)
					{
						Message = ex.InnerException.Message.ToString();
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
		public Boolean Delete(SqlInt32 CountryID)
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
						objCmd.CommandText = "PR_Country_DeleteByPK";
						objCmd.Parameters.AddWithValue("@CountryID", CountryID);
						#endregion Prepare Command

						objCmd.ExecuteNonQuery();

						return true;
					}
					catch (SqlException sqlex)
					{
						Message = sqlex.InnerException.Message.ToString();
						return false;
					}
					catch (Exception ex)
					{
						Message = ex.InnerException.Message.ToString();
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
		public Boolean Update(CountryENT entCountry)
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
						objCmd.CommandText = "PR_Country_UpdateByPK";
						objCmd.Parameters.AddWithValue("@CountryID", entCountry.CountryID);
						objCmd.Parameters.AddWithValue("@CountryName", entCountry.CountryName);
						objCmd.Parameters.AddWithValue("@CountryCode", entCountry.CountryCode);
						#endregion Prepare Command

						objCmd.ExecuteNonQuery();

						return true;
					}
					catch (SqlException sqlex)
					{
						Message = sqlex.InnerException.Message.ToString();
						return false;
					}
					catch (Exception ex)
					{
						Message = ex.InnerException.Message.ToString();
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
						objCmd.CommandText = "PR_Country_SelectAll";
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
						Message = sqlex.InnerException.Message.ToString();
						return null;
					}
					catch (Exception ex)
					{
						Message = ex.InnerException.Message.ToString();
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
						objCmd.CommandText = "PR_Country_SelectForDropDownList";
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
						Message = sqlex.InnerException.Message.ToString();
						return null;
					}
					catch (Exception ex)
					{
						Message = ex.InnerException.Message.ToString();
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
		public CountryENT SelectByPK(SqlInt32 CountryID)
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
						objCmd.CommandText = "PR_Country_SelectByPK";
						objCmd.Parameters.AddWithValue("@CountryID",CountryID);
						#endregion Prepare Command

						#region ReadData and Set Controls
						CountryENT entCountry = new CountryENT();
						using(SqlDataReader objSDR = objCmd.ExecuteReader())
						{
							while (objSDR.Read())
							{
								if (!objSDR["CountryID"].Equals(DBNull.Value))
								{
									entCountry.CountryID = Convert.ToInt32(objSDR["CountryID"]);
								}
								if (!objSDR["CountryName"].Equals(DBNull.Value))
								{
									entCountry.CountryName = Convert.ToString(objSDR["CountryName"]);
								}
								if (!objSDR["CountryCode"].Equals(DBNull.Value))
								{
									entCountry.CountryCode = Convert.ToString(objSDR["CountryCode"]);
								}
							}
						}

						return entCountry;
						#endregion ReadData and Set Controls
					}
					catch (SqlException sqlex)
					{
						Message = sqlex.InnerException.Message.ToString();
						return null;
					}
					catch (Exception ex)
					{
						Message = ex.InnerException.Message.ToString();
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