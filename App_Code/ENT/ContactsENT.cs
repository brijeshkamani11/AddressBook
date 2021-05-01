using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ContactsENT
/// </summary>

namespace Addressbook.ENT
{
    public class ContactsENT
    {

        #region Constructor 
        public ContactsENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region ContactID

        protected SqlInt32 _ContactID;

        public SqlInt32 ContactID
        {
            get
            {
                return _ContactID;
            }
            set
            {
                _ContactID = value;
            }
        }

        #endregion ContactID

        #region PersonName

        protected SqlString _PersonName;

        public SqlString PersonName
        {
            get
            {
                return _PersonName;
            }
            set
            {
                _PersonName = value;
            }
        }

        #endregion PersonName

        #region Address

        protected SqlString _Address;

        public SqlString Address
        {
            get
            {
                return _Address;
            }
            set
            {
                _Address = value;
            }
        }

        #endregion Address

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
                _CityID = value;
            }
        }

        #endregion CityID

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
                _StateID = value;
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
                _CountryID = value;
            }
        }

        #endregion CountryID

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
                _Pincode = value;
            }
        }

        #endregion Pincode

        #region MobileNo

        protected SqlString _MobileNo;

        public SqlString MobileNo
        {
            get
            {
                return _MobileNo;
            }
            set
            {
                _MobileNo = value;
            }
        }

        #endregion MobileNo

        #region PhoneNo

        protected SqlString _PhoneNo;

        public SqlString PhoneNo
        {
            get
            {
                return _PhoneNo;
            }
            set
            {
                _PhoneNo = value;
            }
        }

        #endregion PhoneNo

        #region Email

        protected SqlString _Email;

        public SqlString Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
            }
        }

        #endregion Email

        #region Gender

        protected SqlString _Gender;

        public SqlString Gender
        {
            get
            {
                return _Gender;
            }
            set
            {
                _Gender = value;
            }
        }

        #endregion Gender

        #region Age

        protected SqlInt32 _Age;

        public SqlInt32 Age
        {
            get
            {
                return _Age;
            }
            set
            {
                _Age = value;
            }
        }

        #endregion Age

        #region BirthDate

        protected SqlDateTime _BirthDate;

        public SqlDateTime BirthDate
        {
            get
            {
                return _BirthDate;
            }
            set
            {
                _BirthDate = value;
            }
        }

        #endregion BirthDate

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
                _BloodGroupID = value;
            }
        }

        #endregion BloodGroupID

        #region Profession

        protected SqlString _Profession;

        public SqlString Profession
        {
            get
            {
                return _Profession;
            }
            set
            {
                _Profession = value;
            }
        }

        #endregion Profession

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
                _ContactCategoryID = value;
            }
        }

        #endregion ContactCategoryID

    }
}
