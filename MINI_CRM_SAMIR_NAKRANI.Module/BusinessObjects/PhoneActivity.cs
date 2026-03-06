using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;

namespace MINI_CRM_SAMIR_NAKRANI.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class PhoneActivity : Activity
    {
        public PhoneActivity(Session session) : base(session) { }

        private ActivityState state = ActivityState.Open;
        public ActivityState State
        {
            get => state;
            set => SetPropertyValue(nameof(State), ref state, value);
        }

        private ActivityPriority priority = ActivityPriority.Normal;
        public ActivityPriority Priority
        {
            get => priority;
            set => SetPropertyValue(nameof(Priority), ref priority, value);
        }

        private string summary;
        [Size(SizeAttribute.Unlimited)]
        public string Summary
        {
            get => summary;
            set => SetPropertyValue(nameof(Summary), ref summary, value);
        }

        private string description;
        [Size(SizeAttribute.Unlimited)]
        public string Description
        {
            get => description;
            set => SetPropertyValue(nameof(Description), ref description, value);
        }

        private string number;
        public string Number
        {
            get => number;
            set => SetPropertyValue(nameof(Number), ref number, value);
        }

        private PhoneDirection direction = PhoneDirection.Outgoing;
        public PhoneDirection Direction
        {
            get => direction;
            set => SetPropertyValue(nameof(Direction), ref direction, value);
        }

        private int actualDurationMinutes;
        public int ActualDurationMinutes
        {
            get => actualDurationMinutes;
            set => SetPropertyValue(nameof(ActualDurationMinutes), ref actualDurationMinutes, value);
        }

        private DateTime scheduledStart;
        public DateTime ScheduledStart
        {
            get => scheduledStart;
            set => SetPropertyValue(nameof(ScheduledStart), ref scheduledStart, value);
        }

        private DateTime scheduledEnd;
        public DateTime ScheduledEnd
        {
            get => scheduledEnd;
            set => SetPropertyValue(nameof(ScheduledEnd), ref scheduledEnd, value);
        }

        private Lead from;
        public Lead From
        {
            get => from;
            set => SetPropertyValue(nameof(From), ref from, value);
        }

        private Lead to;
        public Lead To
        {
            get => to;
            set => SetPropertyValue(nameof(To), ref to, value);
        }

        private Lead relatedTo;
        [Association("Lead-PhoneActivities")]
        public Lead RelatedTo
        {
            get => relatedTo;
            set => SetPropertyValue(nameof(RelatedTo), ref relatedTo, value);
        }
    }

    public enum ActivityState
    {
        Open,
        Made,
        Canceled,
        Received
    }

    public enum ActivityPriority
    {
        Low,
        Normal,
        High
    }

    public enum PhoneDirection
    {
        Incoming,
        Outgoing
    }
}