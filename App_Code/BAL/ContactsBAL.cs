using Addressbook.ENT;
using Addressbook.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ContactsBAL
/// </summary>

namespace Addressbook.BAL
{
    public class ContactsBAL
    {

        #region Constructor
        public ContactsBAL()
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
        public Boolean Insert(ContactsENT entContacts)
        {
            ContactsDAL dalContacts = new ContactsDAL();
            if (dalContacts.Insert(entContacts))
            {
                return true;
            }
            else
            {
                Message = dalContacts.Message;
                return false;
            }
        }
        #endregion Insert Operation

        #region Update Operation
        public Boolean Update(ContactsENT entContacts)
        {
            ContactsDAL dalContacts = new ContactsDAL();
            if (dalContacts.Update(entContacts))
            {
                return true;
            }
            else
            {
                Message = dalContacts.Message;
                return false;
            }
        }
        #endregion Update Operation

        #region Delete Operation
        public Boolean Delete(SqlInt32 ContactID)
        {
            ContactsDAL dalContacts = new ContactsDAL();
            if (dalContacts.Delete(ContactID))
            {
                return true;
            }
            else
            {
                Message = dalContacts.Message;
                return false;
            }
        }
        #endregion Delete Operation

        #region Select Operation

        #region Select All
        public DataTable SelectAll()
        {
            ContactsDAL dalContacts = new ContactsDAL();
            return dalContacts.SelectAll();
        }
        #endregion Select All

        #region SelectForDropdownList
        public DataTable SelectForDropdownList()
        {
            ContactsDAL dalContacts = new ContactsDAL();
            return dalContacts.SelectForDropdownList();
        }
        #endregion SelectForDropdownList

        #region SelectByPK
        public ContactsENT SelectByPK(SqlInt32 ContactsID)
        {
            ContactsDAL dalContacts = new ContactsDAL();
            return dalContacts.SelectByPK(ContactsID);
        }
        #endregion SelectByPK

        #endregion Select Operation
    }
}