using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
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
        [RuleRequiredField]
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

        private ActivityPriority priority = ActivityPriority.Normal;
        public ActivityPriority Priority
        {
            get => priority;
            set => SetPropertyValue(nameof(Priority), ref priority, value);
        }

        private ActivityState state = ActivityState.Open;
        public ActivityState State
        {
            get => state;
            set => SetPropertyValue(nameof(State), ref state, value);
        }

        private DateTime scheduledStart;
        [RuleRequiredField]
        public DateTime ScheduledStart
        {
            get => scheduledStart;
            set => SetPropertyValue(nameof(ScheduledStart), ref scheduledStart, value);
        }

        private DateTime scheduledEnd;
        [RuleRequiredField]
        public DateTime ScheduledEnd
        {
            get => scheduledEnd;
            set => SetPropertyValue(nameof(ScheduledEnd), ref scheduledEnd, value);
        }
    }

    public enum ActivityPriority
    {
        Low,
        Normal,
        High
    }

    public enum ActivityState
    {
        Open,
        Made,
        Canceled,
        Received
    }
}