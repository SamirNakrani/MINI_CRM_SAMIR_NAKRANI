using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;

namespace MINI_CRM_SAMIR_NAKRANI.Module.BusinessObjects
{
    [DefaultClassOptions]
    [Persistent("Activity")]
    [NavigationItem("Activities")]
    public class Activity : BaseObject
    {
        public Activity(Session session) : base(session) { }

        private string subject;
        [Size(500)]
        public string Subject
        {
            get => subject;
            set => SetPropertyValue(nameof(Subject), ref subject, value);
        }

        private string description;
        [Size(SizeAttribute.Unlimited)]
        public string Description
        {
            get => description;
            set => SetPropertyValue(nameof(Description), ref description, value);
        }

        private DateTime? startDate;
        public DateTime? StartDate
        {
            get => startDate;
            set => SetPropertyValue(nameof(StartDate), ref startDate, value);
        }

        private DateTime? dueDate;
        public DateTime? DueDate
        {
            get => dueDate;
            set => SetPropertyValue(nameof(DueDate), ref dueDate, value);
        }

        private bool completed;
        public bool Completed
        {
            get => completed;
            set => SetPropertyValue(nameof(Completed), ref completed, value);
        }

        // ✅ Many-side: Activity → Lead
        private Lead lead;
        [Association("Lead-Activities")]
        public Lead Lead
        {
            get => lead;
            set => SetPropertyValue(nameof(Lead), ref lead, value);
        }

     
  

        // ✅ Many-side: Activity → Contact
        // Property renamed to "ActivityContact" to avoid the name conflict
        // but Association string stays "Contact-Activities" to match Contact.cs
    
    }
}