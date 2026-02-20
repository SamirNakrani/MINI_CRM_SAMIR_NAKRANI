using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;

namespace MINI_CRM_SAMIR_NAKRANI.Module.BusinessObjects
{
    [DefaultClassOptions]
    [Persistent("Account")]
    [NavigationItem("Sales")]
    [ImageName("BO_Account")]
    public class Account : BaseObject
    {
        public Account(Session session) : base(session) { }

        #region Account Information

        private string accountName;
        [Size(200)]
        [RuleRequiredField]
        public string AccountName
        {
            get => accountName;
            set => SetPropertyValue(nameof(AccountName), ref accountName, value);
        }

        private string accountNumber;
        [Size(100)]
        public string AccountNumber
        {
            get => accountNumber;
            set => SetPropertyValue(nameof(AccountNumber), ref accountNumber, value);
        }

        private string website;
        [Size(200)]
        public string Website
        {
            get => website;
            set => SetPropertyValue(nameof(Website), ref website, value);
        }

        private string phone;
        [Size(50)]
        public string Phone
        {
            get => phone;
            set => SetPropertyValue(nameof(Phone), ref phone, value);
        }

        private string fax;
        [Size(50)]
        public string Fax
        {
            get => fax;
            set => SetPropertyValue(nameof(Fax), ref fax, value);
        }

        private string email;
        [Size(200)]
        public string Email
        {
            get => email;
            set => SetPropertyValue(nameof(Email), ref email, value);
        }

        #endregion

        #region Address Information

        private string address1;
        [Size(SizeAttribute.Unlimited)]
        public string Address1
        {
            get => address1;
            set => SetPropertyValue(nameof(Address1), ref address1, value);
        }

        private string address2;
        [Size(SizeAttribute.Unlimited)]
        public string Address2
        {
            get => address2;
            set => SetPropertyValue(nameof(Address2), ref address2, value);
        }

        private string address3;
        [Size(SizeAttribute.Unlimited)]
        public string Address3
        {
            get => address3;
            set => SetPropertyValue(nameof(Address3), ref address3, value);
        }

        private string city;
        [Size(100)]
        public string City
        {
            get => city;
            set => SetPropertyValue(nameof(City), ref city, value);
        }

        private string stateOrProvince;
        [Size(100)]
        public string StateOrProvince
        {
            get => stateOrProvince;
            set => SetPropertyValue(nameof(StateOrProvince), ref stateOrProvince, value);
        }

        private string postalCode;
        [Size(20)]
        public string PostalCode
        {
            get => postalCode;
            set => SetPropertyValue(nameof(PostalCode), ref postalCode, value);
        }

        private string country;
        [Size(100)]
        public string Country
        {
            get => country;
            set => SetPropertyValue(nameof(Country), ref country, value);
        }

        #endregion

        #region Related Entities

        private Contact primaryContact;
        public Contact PrimaryContact
        {
            get => primaryContact;
            set => SetPropertyValue(nameof(PrimaryContact), ref primaryContact, value);
        }

        #endregion

        #region Collections
 
      
 

        #endregion

        #region Overrides

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        #endregion
    }
}
