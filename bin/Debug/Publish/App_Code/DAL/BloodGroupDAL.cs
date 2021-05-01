using Addressbook.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BloodGroupDAL
/// </summary>

namespace Addressbook.DAL
{
	public class BloodGroupDAL : DatabaseConfig
	{
	
		#region Constructor 
		public BloodGroupDAL()
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
		public Boolean Insert(BloodGroupENT entBloodGroup)
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
						objCmd.CommandText = "PR_BloodGroup_Insert";
						objCmd.Parameters.Add("@BloodGroupID", SqlDbType.Int).Direction = ParameterDirection.Output;
						objCmd.Parameters.AddWithValue("@BloodGroupName", SqlDbType.VarChar).Value = entBloodGroup.BloodGroupName;
						#endregion Prepare Command

						objCmd.ExecuteNonQuery();

						if (objCmd.Parameters["@BloodGroupID"] != null)
							entBloodGroup.BloodGroupID = Convert.ToInt32(objCmd.Parameters["@BloodGroupID"].Value);

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
		public Boolean Delete(SqlInt32 BloodGroupID)
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
						objCmd.CommandText = "PR_BloodGroup_DeleteByPK";
						objCmd.Parameters.AddWithValue("@BloodGroupID", BloodGroupID);
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
		public Boolean Update(BloodGroupENT entBloodGroup)
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
						objCmd.CommandText = "PR_BloodGroup_UpdateByPK";
						objCmd.Parameters.AddWithValue("@BloodGroupID", entBloodGroup.BloodGroupID);
						objCmd.Parameters.AddWithValue("@BloodGroupName", entBloodGroup.BloodGroupName);
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
						objCmd.CommandText = "PR_BloodGroup_SelectAll";
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
						objCmd.CommandText = "PR_BloodGroup_SelectForDropDownList";
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
		public BloodGroupENT SelectByPK(SqlInt32 BloodGroupID)
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
						objCmd.CommandText = "PR_BloodGroup_SelectByPK";
						objCmd.Parameters.AddWithValue("@BloodGroupID",BloodGroupID);
						#endregion Prepare Command

						#region ReadData and Set Controls
						BloodGroupENT entBloodGroup = new BloodGroupENT();
						using(SqlDataReader objSDR = objCmd.ExecuteReader())
						{
							while (objSDR.Read())
							{
								if (!objSDR["BloodGroupID"].Equals(DBNull.Value))
								{
									entBloodGroup.BloodGroupID = Convert.ToInt32(objSDR["BloodGroupID"]);
								}
								if (!objSDR["BloodGroupName"].Equals(DBNull.Value))
								{
									entBloodGroup.BloodGroupName = Convert.ToString(objSDR["BloodGroupName"]);
								}
							}
						}

						return entBloodGroup;
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