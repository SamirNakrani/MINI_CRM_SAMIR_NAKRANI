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

        private string accountName;
        private string readableName;
        private string phone;
        private string fax;
        private string website;
        private string tickerSymbol;

        private Account parentAccount;
        private Contact primaryContact;

        private Address address1;
        private Address address2;

        [Size(200)]
        [RuleRequiredField("Account.AccountName.Required", DefaultContexts.Save)]
        public string AccountName
        {
            get => accountName;
            set => SetPropertyValue(nameof(AccountName), ref accountName, value);
        }

        [Size(200)]
        public string ReadableName
        {
            get => readableName;
            set => SetPropertyValue(nameof(ReadableName), ref readableName, value);
        }

        [Size(30)]
        public string Phone
        {
            get => phone;
            set => SetPropertyValue(nameof(Phone), ref phone, value);
        }

        [Size(30)]
        public string Fax
        {
            get => fax;
            set => SetPropertyValue(nameof(Fax), ref fax, value);
        }

        [Size(200)]
        [RuleRegularExpression(
            "Account.Website.Valid",
            DefaultContexts.Save,
            @"^(https?:\/\/)?([\w\-]+\.)+[\w\-]+(\/[\w\-._~:/?#[\]@!$&'()*+,;=]*)?$",
            CustomMessageTemplate = "Please enter a valid website URL"
        )]
        public string Website
        {
            get => website;
            set => SetPropertyValue(nameof(Website), ref website, value);
        }

        [Size(50)]
        public string TickerSymbol
        {
            get => tickerSymbol;
            set => SetPropertyValue(nameof(TickerSymbol), ref tickerSymbol, value);
        }

        #region References

        [Association("Account-Parent")]
        public Account ParentAccount
        {
            get => parentAccount;
            set => SetPropertyValue(nameof(ParentAccount), ref parentAccount, value);
        }

        public Contact PrimaryContact
        {
            get => primaryContact;
            set => SetPropertyValue(nameof(PrimaryContact), ref primaryContact, value);
        }

        #endregion

        #region Addresses

        [Aggregated]
        [ExpandObjectMembers(ExpandObjectMembers.Never)]
        public Address Address1
        {
            get => address1;
            set => SetPropertyValue(nameof(Address1), ref address1, value);
        }

        [Aggregated]
        [ExpandObjectMembers(ExpandObjectMembers.Never)]
        public Address Address2
        {
            get => address2;
            set => SetPropertyValue(nameof(Address2), ref address2, value);
        }

        #endregion

        #region Collections

        [Association("Account-Parent")]
        public XPCollection<Account> ChildAccounts =>
            GetCollection<Account>(nameof(ChildAccounts));

        [Association("Account-Leads")]
        public XPCollection<Lead> Leads =>
            GetCollection<Lead>(nameof(Leads));

        //[Association("Account-Activities")]
        //public XPCollection<Activity> Activities =>
        //    GetCollection<Activity>(nameof(Activities));

        #endregion

        #region Overrides

        protected override void OnSaving()
        {
            base.OnSaving();
            if (string.IsNullOrWhiteSpace(ReadableName))
                ReadableName = AccountName;
        }

        #endregion
    }
}