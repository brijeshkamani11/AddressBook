using Addressbook.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ContactsDAL
/// </summary>

namespace Addressbook.DAL
{
	public class ContactsDAL : DatabaseConfig
	{
	
		#region Constructor 
		public ContactsDAL()
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
		public Boolean Insert(ContactsENT entContacts)
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
						objCmd.CommandText = "PR_Contacts_Insert";
						objCmd.Parameters.Add("@ContactsID", SqlDbType.Int).Direction = ParameterDirection.Output;
						objCmd.Parameters.AddWithValue("@PersonName", SqlDbType.VarChar).Value = entContacts.PersonName;
						objCmd.Parameters.AddWithValue("@Address", SqlDbType.VarChar).Value = entContacts.Address;
						objCmd.Parameters.AddWithValue("@CityID", SqlDbType.Int).Value = entContacts.CityID;
						objCmd.Parameters.AddWithValue("@StateID", SqlDbType.Int).Value = entContacts.StateID;
						objCmd.Parameters.AddWithValue("@CountryID", SqlDbType.Int).Value = entContacts.CountryID;
						objCmd.Parameters.AddWithValue("@Pincode", SqlDbType.VarChar).Value = entContacts.Pincode;
						objCmd.Parameters.AddWithValue("@MobileNo", SqlDbType.VarChar).Value = entContacts.MobileNo;
						objCmd.Parameters.AddWithValue("@PhoneNo", SqlDbType.VarChar).Value = entContacts.PhoneNo;
						objCmd.Parameters.AddWithValue("@Email", SqlDbType.VarChar).Value = entContacts.Email;
						objCmd.Parameters.AddWithValue("@Gender", SqlDbType.VarChar).Value = entContacts.Gender;
						objCmd.Parameters.AddWithValue("@Age", SqlDbType.Int).Value = entContacts.Age;
						objCmd.Parameters.AddWithValue("@BirthDate", SqlDbType.DateTime).Value = entContacts.BirthDate;
						objCmd.Parameters.AddWithValue("@BloodGroupID", SqlDbType.Int).Value = entContacts.BloodGroupID;
						objCmd.Parameters.AddWithValue("@Profession", SqlDbType.VarChar).Value = entContacts.Profession;
						objCmd.Parameters.AddWithValue("@ContactCategoryID", SqlDbType.Int).Value = entContacts.ContactCategoryID;
						#endregion Prepare Command

						objCmd.ExecuteNonQuery();

						if (objCmd.Parameters["@ContactsID"] != null)
							entContacts.ContactID = Convert.ToInt32(objCmd.Parameters["@ContactsID"].Value);

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
		public Boolean Delete(SqlInt32 ContactsID)
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
						objCmd.CommandText = "PR_Contacts_DeleteByPK";
						objCmd.Parameters.AddWithValue("@ContactsID", ContactsID);
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
		public Boolean Update(ContactsENT entContacts)
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
						objCmd.CommandText = "PR_Contacts_UpdateByPK";
						objCmd.Parameters.AddWithValue("@ContactID", entContacts.ContactID);
						objCmd.Parameters.AddWithValue("@PersonName", entContacts.PersonName);
						objCmd.Parameters.AddWithValue("@Address", entContacts.Address);
						objCmd.Parameters.AddWithValue("@CityID", entContacts.CityID);
						objCmd.Parameters.AddWithValue("@StateID", entContacts.StateID);
						objCmd.Parameters.AddWithValue("@CountryID", entContacts.CountryID);
						objCmd.Parameters.AddWithValue("@Pincode", entContacts.Pincode);
						objCmd.Parameters.AddWithValue("@MobileNo", entContacts.MobileNo);
						objCmd.Parameters.AddWithValue("@PhoneNo", entContacts.PhoneNo);
						objCmd.Parameters.AddWithValue("@Email", entContacts.Email);
						objCmd.Parameters.AddWithValue("@Gender", entContacts.Gender);
						objCmd.Parameters.AddWithValue("@Age", entContacts.Age);
						objCmd.Parameters.AddWithValue("@BirthDate", entContacts.BirthDate);
						objCmd.Parameters.AddWithValue("@BloodGroupID", entContacts.BloodGroupID);
						objCmd.Parameters.AddWithValue("@Profession", entContacts.Profession);
						objCmd.Parameters.AddWithValue("@ContactCategoryID", entContacts.ContactCategoryID);
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
						objCmd.CommandText = "PR_Contacts_SelectAll";
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
						objCmd.CommandText = "PR_Contacts_SelectForDropDownList";
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
		public ContactsENT SelectByPK(SqlInt32 ContactsID)
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
						objCmd.CommandText = "PR_Contacts_SelectByPK";
						objCmd.Parameters.AddWithValue("@ContactsID",ContactsID);
						#endregion Prepare Command

						#region ReadData and Set Controls
						ContactsENT entContacts = new ContactsENT();
						using(SqlDataReader objSDR = objCmd.ExecuteReader())
						{
							while (objSDR.Read())
							{
								if (!objSDR["ContactID"].Equals(DBNull.Value))
								{
									entContacts.ContactID = Convert.ToInt32(objSDR["ContactID"]);
								}
								if (!objSDR["PersonName"].Equals(DBNull.Value))
								{
									entContacts.PersonName = Convert.ToString(objSDR["PersonName"]);
								}
								if (!objSDR["Address"].Equals(DBNull.Value))
								{
									entContacts.Address = Convert.ToString(objSDR["Address"]);
								}
								if (!objSDR["CityID"].Equals(DBNull.Value))
								{
									entContacts.CityID = Convert.ToInt32(objSDR["CityID"]);
								}
								if (!objSDR["StateID"].Equals(DBNull.Value))
								{
									entContacts.StateID = Convert.ToInt32(objSDR["StateID"]);
								}
								if (!objSDR["CountryID"].Equals(DBNull.Value))
								{
									entContacts.CountryID = Convert.ToInt32(objSDR["CountryID"]);
								}
								if (!objSDR["Pincode"].Equals(DBNull.Value))
								{
									entContacts.Pincode = Convert.ToString(objSDR["Pincode"]);
								}
								if (!objSDR["MobileNo"].Equals(DBNull.Value))
								{
									entContacts.MobileNo = Convert.ToString(objSDR["MobileNo"]);
								}
								if (!objSDR["PhoneNo"].Equals(DBNull.Value))
								{
									entContacts.PhoneNo = Convert.ToString(objSDR["PhoneNo"]);
								}
								if (!objSDR["Email"].Equals(DBNull.Value))
								{
									entContacts.Email = Convert.ToString(objSDR["Email"]);
								}
								if (!objSDR["Gender"].Equals(DBNull.Value))
								{
									entContacts.Gender = Convert.ToString(objSDR["Gender"]);
								}
								if (!objSDR["Age"].Equals(DBNull.Value))
								{
									entContacts.Age = Convert.ToInt32(objSDR["Age"]);
								}
								if (!objSDR["BirthDate"].Equals(DBNull.Value))
								{
									entContacts.BirthDate = Convert.ToDateTime(objSDR["BirthDate"]);
								}
								if (!objSDR["BloodGroupID"].Equals(DBNull.Value))
								{
									entContacts.BloodGroupID = Convert.ToInt32(objSDR["BloodGroupID"]);
								}
								if (!objSDR["Profession"].Equals(DBNull.Value))
								{
									entContacts.Profession = Convert.ToString(objSDR["Profession"]);
								}
								if (!objSDR["ContactCategoryID"].Equals(DBNull.Value))
								{
									entContacts.ContactCategoryID = Convert.ToInt32(objSDR["ContactCategoryID"]);
								}
							}
						}

						return entContacts;
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