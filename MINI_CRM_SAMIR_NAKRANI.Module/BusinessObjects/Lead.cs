using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.Persistent.Validation;
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
        private string firstName;
        private string middleName;
        private string lastName;
        private string readableFirstName;
        private string readableMiddleName;
        private string readableLastName;
        private string title;
        private string phone;
        private string mobile;
        private string email;
        private string company;
        private string readableCompanyName;
        private string website;
        private Address address1;
        private Address address2;
        private Account parentAccount;
        private Contact parentContact;

        [Size(500)]
        [RuleRequiredField("Lead.Subject.Required", DefaultContexts.Save)]
        public string Subject
        {
            get => subject;
            set => SetPropertyValue(nameof(Subject), ref subject, value);
        }

        [Size(100)]
        [RuleRequiredField("Lead.FirstName.Required", DefaultContexts.Save)]
        public string FirstName
        {
            get => firstName;
            set => SetPropertyValue(nameof(FirstName), ref firstName, value);
        }

        [Size(100)]
        public string MiddleName
        {
            get => middleName;
            set => SetPropertyValue(nameof(MiddleName), ref middleName, value);
        }

        [Size(100)]
        [RuleRequiredField("Lead.LastName.Required", DefaultContexts.Save)]
        public string LastName
        {
            get => lastName;
            set => SetPropertyValue(nameof(LastName), ref lastName, value);
        }

        [Size(100)]
        public string ReadableFirstName
        {
            get => readableFirstName;
            set => SetPropertyValue(nameof(ReadableFirstName), ref readableFirstName, value);
        }

        [Size(100)]
        public string ReadableMiddleName
        {
            get => readableMiddleName;
            set => SetPropertyValue(nameof(ReadableMiddleName), ref readableMiddleName, value);
        }

        [Size(100)]
        public string ReadableLastName
        {
            get => readableLastName;
            set => SetPropertyValue(nameof(ReadableLastName), ref readableLastName, value);
        }

        [Size(50)]
        public string Title
        {
            get => title;
            set => SetPropertyValue(nameof(Title), ref title, value);
        }

        [Size(30)]
        public string Phone
        {
            get => phone;
            set => SetPropertyValue(nameof(Phone), ref phone, value);
        }

        [Size(30)]
        [ModelDefault("EditMask", "+00 000 000 0000")]
        public string Mobile
        {
            get => mobile;
            set => SetPropertyValue(nameof(Mobile), ref mobile, value);
        }

        [Size(150)]
        [RuleRequiredField("Lead.Email.Required", DefaultContexts.Save)]
        [RuleRegularExpression(
            "Lead.Email.Valid",
            DefaultContexts.Save,
            @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
            CustomMessageTemplate = "Please enter a valid email address"
        )]
        public string Email
        {
            get => email;
            set => SetPropertyValue(nameof(Email), ref email, value);
        }

        [Size(200)]
        public string Company
        {
            get => company;
            set => SetPropertyValue(nameof(Company), ref company, value);
        }

        [Size(200)]
        public string ReadableCompanyName
        {
            get => readableCompanyName;
            set => SetPropertyValue(nameof(ReadableCompanyName), ref readableCompanyName, value);
        }

        [Size(200)]
        [RuleRegularExpression(
            "Lead.Website.Valid",
            DefaultContexts.Save,
            @"^(https?:\/\/)?([\w\-]+\.)+[\w\-]+(\/[\w\-._~:/?#[\]@!$&'()*+,;=]*)?$",
            CustomMessageTemplate = "Please enter a valid website URL"
        )]
        public string Website
        {
            get => website;
            set => SetPropertyValue(nameof(Website), ref website, value);
        }

        [DevExpress.ExpressApp.DC.Aggregated]
        [ExpandObjectMembers(ExpandObjectMembers.Never)]
        public Address Address1
        {
            get => address1;
            set => SetPropertyValue(nameof(Address1), ref address1, value);
        }

        [DevExpress.ExpressApp.DC.Aggregated]
        [ExpandObjectMembers(ExpandObjectMembers.Never)]
        public Address Address2
        {
            get => address2;
            set => SetPropertyValue(nameof(Address2), ref address2, value);
        }

        [PersistentAlias("Concat(FirstName, ' ', LastName)")]
        public string FullName => (string)EvaluateAlias(nameof(FullName));

        [Association("Account-Leads")]
        public Account ParentAccount
        {
            get => parentAccount;
            set => SetPropertyValue(nameof(ParentAccount), ref parentAccount, value);
        }

        [Association("Contact-Leads")]
        public Contact ParentContact
        {
            get => parentContact;
            set => SetPropertyValue(nameof(ParentContact), ref parentContact, value);
        }

        [Association("Lead-Activities")]
        public XPCollection<Activity> Activities =>
            GetCollection<Activity>(nameof(Activities));

        private LeadStatus status = LeadStatus.Open;

        [DisplayName("Status")]
        public LeadStatus Status
        {
            get => status;
            set => SetPropertyValue(nameof(Status), ref status, value);
        }

        protected override void OnSaved()
        {
            base.OnSaving();
            ModifiedOn = DateTime.Now;
        }
        private PermissionPolicyUser owner;

        [ModelDefault("AllowEdit", "False")] 
        public PermissionPolicyUser Owner
        {
            get => owner;
            set => SetPropertyValue(nameof(Owner), ref owner, value);
        }

        private DateTime? modifiedOn;
        [ModelDefault("AllowEdit", "False")] 
        [ModelDefault("EditMask", "G")]
        [ModelDefault("DisplayFormat", "G")]
        [ModelDefault("EditMaskType", "DateTime")]
        [XafDisplayName(nameof(ModifiedOn))]
        public DateTime? ModifiedOn
        {
            get => modifiedOn;
            set => SetPropertyValue(nameof(ModifiedOn), ref modifiedOn, value);
        }

        private PermissionPolicyUser createdBy;

        [ModelDefault("AllowEdit", "False")] 
        public PermissionPolicyUser CreatedBy
        {
            get => createdBy;
            set => SetPropertyValue(nameof(CreatedBy), ref createdBy, value);
        }

        private DateTime? createdOn;
        [ModelDefault("AllowEdit", "False")]  
        [ModelDefault("EditMask", "G")]
        [ModelDefault("DisplayFormat", "G")]
        [ModelDefault("EditMaskType", "DateTime")]
        [XafDisplayName(nameof(CreatedOn))]
        public DateTime? CreatedOn
        {
            get => createdOn;
            set => SetPropertyValue(nameof(CreatedOn), ref createdOn, value);
        }

        private PermissionPolicyUser modifiedBy;

        [ModelDefault("AllowEdit", "False")]  
        public PermissionPolicyUser ModifiedBy
        {
            get => modifiedBy;
            set => SetPropertyValue(nameof(ModifiedBy), ref modifiedBy, value);
        }
        private ProcessState state;
        public ProcessState State
        { 
            get => state;
            set => SetPropertyValue(nameof(state),ref state, value);
        }
        private bool isConverted;

        public bool IsConverted
        {
            get => isConverted;
            set => SetPropertyValue(nameof(IsConverted), ref isConverted, value);
        }
        private void ConvertLead()
        {
            var session = Session;

            Account account = new Account(session)
            {
                AccountName = Company,
                Phone = Phone,
                Website = Website
            };

            Contact contact = new Contact(session)
            {
                FirstName = FirstName,
                MiddleName = MiddleName,
                LastName = LastName,
                Email = Email,
                Phone = Phone,
                Mobile = Mobile,
                Title = Title
            };

            account.PrimaryContact = contact;

            Opportunities opportunity = new Opportunities(session)
            {
                Topic = Subject,
                Description = $"Opportunity created from Lead: {FullName}",
                Contact = contact,
                EstimatedCloseDate = DateTime.Now.AddMonths(1)
            };

            ParentAccount = account;
            ParentContact = contact;
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            if (SecuritySystem.CurrentUser is PermissionPolicyUser user)
            {
                var currentUser = Session.GetObjectByKey<PermissionPolicyUser>(user.Oid);
                Owner = currentUser;
                CreatedBy = currentUser;   
                ModifiedBy = currentUser;  
            }
            CreatedOn = DateTime.Now;
            ModifiedOn = DateTime.Now;     
        }
        protected override void OnLoaded()
        {
            base.OnLoaded();

            // Patch display only — doesn't dirty the object
            if (Owner == null || CreatedBy == null || CreatedOn == null)
            {
                if (SecuritySystem.CurrentUser is PermissionPolicyUser user)
                {
                    var currentUser = Session.GetObjectByKey<PermissionPolicyUser>(user.Oid);

                    if (Owner == null) Owner = currentUser;
                    if (CreatedBy == null) CreatedBy = currentUser;
                    if (CreatedOn == null) CreatedOn = DateTime.Now;
                }
            }
        }
        protected override void OnSaving()
        {
            base.OnSaving();

            if (SecuritySystem.CurrentUser is PermissionPolicyUser user)
            {
                var currentUser = Session.GetObjectByKey<PermissionPolicyUser>(user.Oid);

                if (Owner == null)
                    Owner = currentUser;

                if (CreatedBy == null)
                    CreatedBy = currentUser;

                if (CreatedOn == null)
                    CreatedOn = DateTime.Now;

                ModifiedOn = DateTime.Now;
                ModifiedBy = currentUser;
            }
            if (SecuritySystem.CurrentUser is PermissionPolicyUser permissionPolicyUser)
            {
                var currentUser = Session.GetObjectByKey<PermissionPolicyUser>(permissionPolicyUser.Oid);
                if (Session.IsNewObject(this))
                {
                    CreatedOn = DateTime.Now;
                    CreatedBy = currentUser;
                }

                ModifiedOn = DateTime.Now;
                ModifiedBy = currentUser;
            }
            if (!IsDeleted && Status == LeadStatus.Qualified && !IsConverted && Session.IsObjectToSave(this))
            {
                ConvertLead();
                IsConverted = true;
            }
        }
        private XPCollection<AuditDataItemPersistent> auditTrail;

        [DevExpress.ExpressApp.CollectionOperationSet(AllowAdd = false, AllowRemove = false)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public XPCollection<AuditDataItemPersistent> AuditTrail
        {
            get
            {
                if (auditTrail == null)
                {
                    auditTrail = AuditedObjectWeakReference.GetAuditTrail(Session, this);
                }
                return auditTrail;
            }
        }
    }
}

namespace MINI_CRM_SAMIR_NAKRANI.Module.BusinessObjects
{
    public enum LeadStatus
    {
        Open,
        Qualified,
        Disqualified
    }

    public enum ProcessState
    {
        Open = 0,
        Qualified = 1,
        Developed = 2,
        Propose = 3,
        Closed = 4
    }
}