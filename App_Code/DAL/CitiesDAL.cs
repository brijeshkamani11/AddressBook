using Addressbook.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;


/// <summary>
/// Summary description for CitiesDAL
/// </summary>

namespace Addressbook.DAL
{
	public class CitiesDAL : DatabaseConfig
	{
	
		#region Constructor 
		public CitiesDAL()
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
		public Boolean Insert(CitiesENT entCities)
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
						objCmd.CommandText = "PR_Cities_Insert";
						objCmd.Parameters.Add("@CityID", SqlDbType.Int).Direction = ParameterDirection.Output;
						objCmd.Parameters.AddWithValue("@CityName", SqlDbType.VarChar).Value = entCities.CityName;
						objCmd.Parameters.AddWithValue("@Pincode", SqlDbType.VarChar).Value = entCities.Pincode;
						objCmd.Parameters.AddWithValue("@STDCode", SqlDbType.VarChar).Value = entCities.STDCode;
						objCmd.Parameters.AddWithValue("@StateID", SqlDbType.Int).Value = entCities.StateID;
						#endregion Prepare Command

						objCmd.ExecuteNonQuery();

						if (objCmd.Parameters["@CityID"] != null)
							entCities.CityID = Convert.ToInt32(objCmd.Parameters["@CityID"].Value);

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
		public Boolean Delete(SqlInt32 CitiesID)
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
						objCmd.CommandText = "PR_Cities_DeleteByPK";
						objCmd.Parameters.AddWithValue("@CityID", CitiesID);
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
		public Boolean Update(CitiesENT entCities)
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
						objCmd.CommandText = "PR_Cities_UpdateByPK";
						objCmd.Parameters.AddWithValue("@CityID", entCities.CityID);
						objCmd.Parameters.AddWithValue("@CityName", entCities.CityName);
						objCmd.Parameters.AddWithValue("@Pincode", entCities.Pincode);
						objCmd.Parameters.AddWithValue("@STDCode", entCities.STDCode);
						objCmd.Parameters.AddWithValue("@StateID", entCities.StateID);
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
						objCmd.CommandText = "PR_Cities_SelectAll";
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
						objCmd.CommandText = "PR_Cities_SelectForDropDownList";
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
		public CitiesENT SelectByPK(SqlInt32 CitiesID)
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
						objCmd.CommandText = "PR_Cities_SelectByPK";
						objCmd.Parameters.AddWithValue("@CityID",CitiesID);
						#endregion Prepare Command

						#region ReadData and Set Controls
						CitiesENT entCities = new CitiesENT();
						using(SqlDataReader objSDR = objCmd.ExecuteReader())
						{
							while (objSDR.Read())
							{
								if (!objSDR["CityID"].Equals(DBNull.Value))
								{
									entCities.CityID = Convert.ToInt32(objSDR["CityID"]);
								}
								if (!objSDR["CityName"].Equals(DBNull.Value))
								{
									entCities.CityName = Convert.ToString(objSDR["CityName"]);
								}
								if (!objSDR["Pincode"].Equals(DBNull.Value))
								{
									entCities.Pincode = Convert.ToString(objSDR["Pincode"]);
								}
								if (!objSDR["STDCode"].Equals(DBNull.Value))
								{
									entCities.STDCode = Convert.ToString(objSDR["STDCode"]);
								}
								if (!objSDR["StateID"].Equals(DBNull.Value))
								{
									entCities.StateID = Convert.ToInt32(objSDR["StateID"]);
								}
							}
						}

						return entCities;
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