using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;

namespace MINI_CRM_SAMIR_NAKRANI.Module.BusinessObjects
{
    [DefaultClassOptions]
    [Persistent("Lead")]
    [NavigationItem("Sales")]
    public class Lead : BaseObject
    {
        public Lead(Session session) : base(session) { }

        private string subject;
        [Size(500)]
        public string Subject
        {
            get => subject;
            set => SetPropertyValue(nameof(Subject), ref subject, value);
        }

        private Contact contact;
        [ExpandObjectMembers(ExpandObjectMembers.InDetailView)]
        [ModelDefault("Visibility", "Hide")]
        public Contact Contact
        {
            get => contact;
            set => SetPropertyValue(nameof(Contact), ref contact, value);
        }

        private Company company;
        [ExpandObjectMembers(ExpandObjectMembers.InDetailView)]
        [ModelDefault("Visibility", "Hide")]
        public Company Company
        {
            get => company;
            set => SetPropertyValue(nameof(Company), ref company, value);
        }

        private ContactMethod contactMethod;
        [ExpandObjectMembers(ExpandObjectMembers.InDetailView)]
        [ModelDefault("Visibility", "Hide")]
        public ContactMethod ContactMethod
        {
            get => contactMethod;
            set => SetPropertyValue(nameof(ContactMethod), ref contactMethod, value);
        }

        private string description;
        [Size(SizeAttribute.Unlimited)]
        [ModelDefault("Visibility", "Hide")]
        public string Description
        {
            get => description;
            set => SetPropertyValue(nameof(Description), ref description, value);
        }

        private string industry;
        [Size(100)]
        [ModelDefault("Visibility", "Hide")]
        public string Industry
        {
            get => industry;
            set => SetPropertyValue(nameof(Industry), ref industry, value);
        }

        private decimal revenue;
        [ModelDefault("DisplayFormat", "{0:c}")]
        [ModelDefault("EditMask", "c")]
        [ModelDefault("Visibility", "Hide")]
        public decimal Revenue
        {
            get => revenue;
            set => SetPropertyValue(nameof(Revenue), ref revenue, value);
        }

        private int numberOfEmployees;
        [ModelDefault("Visibility", "Hide")]
        public int NumberOfEmployees
        {
            get => numberOfEmployees;
            set => SetPropertyValue(nameof(NumberOfEmployees), ref numberOfEmployees, value);
        }

        private string sicCode;
        [Size(50)]
        [ModelDefault("Visibility", "Hide")]
        public string SicCode
        {
            get => sicCode;
            set => SetPropertyValue(nameof(SicCode), ref sicCode, value);
        }

        private string transactionCurrency;
        [Size(10)]
        [ModelDefault("Visibility", "Hide")]
        public string TransactionCurrency
        {
            get => transactionCurrency;
            set => SetPropertyValue(nameof(TransactionCurrency), ref transactionCurrency, value);
        }

        private string lastUsedInCampaign;
        [Size(200)]
        [ModelDefault("Visibility", "Hide")]
        public string LastUsedInCampaign
        {
            get => lastUsedInCampaign;
            set => SetPropertyValue(nameof(LastUsedInCampaign), ref lastUsedInCampaign, value);
        }

        [Association("Lead-Activities")]
        public XPCollection<Activity> Activities
        {
            get { return GetCollection<Activity>(nameof(Activities)); }
        }
    }
}
