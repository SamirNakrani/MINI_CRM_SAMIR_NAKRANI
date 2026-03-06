using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;

namespace MINI_CRM_SAMIR_NAKRANI.Module.BusinessObjects
{
    [DefaultClassOptions]
    [Persistent("Activity")]
    
    public abstract class Activity : BaseObject
    {
        public Activity(Session session) : base(session) { }

        private Lead lead;
        [Association("Lead-Activities")]
        public Lead Lead
        {
            get => lead;
            set => SetPropertyValue(nameof(Lead), ref lead, value);
        }

        private DateTime startOn;
        public DateTime StartOn
        {
            get => startOn;
            set => SetPropertyValue(nameof(StartOn), ref startOn, value);
        }

        private string subject;
        public string Subject
        {
            get => subject;
            set => SetPropertyValue(nameof(Subject), ref subject, value);
        }
    }
}