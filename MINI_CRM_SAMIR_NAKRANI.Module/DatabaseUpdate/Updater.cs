using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using Microsoft.Extensions.DependencyInjection;
using MINI_CRM_SAMIR_NAKRANI.Module.BusinessObjects;

namespace MINI_CRM_SAMIR_NAKRANI.Module.DatabaseUpdate
{
    // For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Updating.ModuleUpdater
    public class Updater : ModuleUpdater
    {
        public Updater(IObjectSpace objectSpace, Version currentDBVersion) :
            base(objectSpace, currentDBVersion)
        {
        }
        public override void UpdateDatabaseAfterUpdateSchema()
        {
            base.UpdateDatabaseAfterUpdateSchema();

            if (ObjectSpace.GetObjectsCount(typeof(Lead), null) > 0)
                return;
            CreateLead(
                "Website inquiry",
                "John",
                "Doe",
                "john.doe@google.com",
                "Google",
                "https://www.google.com",
                "Software Engineer",
                "+1 650 253 0000",
                "+1 650 555 0101",
                LeadStatus.Open
            );

            CreateLead(
                "Advertising campaign request",
                "Lisa",
                "Wong",
                "lisa.wong@google.com",
                "Google",
                "https://www.google.com",
                "Marketing Manager",
                "+1 650 253 1111",
                "+1 650 555 0102",
                LeadStatus.Qualified
            );

            CreateLead(
                "Product demo request",
                "Sarah",
                "Smith",
                "sarah.smith@microsoft.com",
                "Microsoft",
                "https://www.microsoft.com",
                "Product Manager",
                "+1 425 882 8080",
                "+1 425 555 0202",
                LeadStatus.Qualified
            );

            CreateLead(
                "Cloud migration inquiry",
                "Robert",
                "Johnson",
                "robert.johnson@microsoft.com",
                "Microsoft",
                "https://www.microsoft.com",
                "Cloud Architect",
                "+1 425 882 9090",
                "+1 425 555 0203",
                LeadStatus.Disqualified
            );

            CreateLead(
                "Partnership opportunity",
                "Amit",
                "Patel",
                "amit.patel@amazon.com",
                "Amazon",
                "https://www.amazon.com",
                "Business Analyst",
                "+1 206 266 1000",
                "+1 206 555 0303",
                LeadStatus.Open
            );

            ObjectSpace.CommitChanges();
        }
        //ObjectSpace.CommitChanges(); //Uncomment this line to persist created object(s).
        private void CreateLead(
        string subject,
        string firstName,
        string lastName,
        string email,
        string company,
        string website,
        string title,
        string phone,
        string mobile,
        LeadStatus leadStatus
        )
        {
            var lead = ObjectSpace.CreateObject<Lead>();

            lead.Subject = subject;
            lead.FirstName = firstName;
            lead.LastName = lastName;
            lead.Email = email;
            lead.Company = company;
            lead.ReadableCompanyName = company;
            lead.Website = website;
            lead.Title = title;
            lead.Phone = phone;
            lead.Mobile = mobile;
            lead.Status = LeadStatus.Qualified;
        }
        public override void UpdateDatabaseBeforeUpdateSchema()
        {
            base.UpdateDatabaseBeforeUpdateSchema();
            //if(CurrentDBVersion < new Version("1.1.0.0") && CurrentDBVersion > new Version("0.0.0.0")) {
            //    RenameColumn("DomainObject1Table", "OldColumnName", "NewColumnName");
            //}
        }
    }
}
