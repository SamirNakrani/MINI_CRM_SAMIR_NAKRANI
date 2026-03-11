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

        private string number;
        [RuleRequiredField]
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
        [RuleValueComparison(DefaultContexts.Save, ValueComparisonType.GreaterThan, 0)]
        [RuleValueComparison(DefaultContexts.Save, ValueComparisonType.LessThan, 1400)]
        public int ActualDurationMinutes
        {
            get => actualDurationMinutes;
            set => SetPropertyValue(nameof(ActualDurationMinutes), ref actualDurationMinutes, value);
        }

        private Lead from;
        [RuleRequiredField]
        public Lead From
        {
            get => from;
            set => SetPropertyValue(nameof(From), ref from, value);
        }

        private Lead to;
        [RuleRequiredField]
        public Lead To
        {
            get => to;
            set => SetPropertyValue(nameof(To), ref to, value);
        }
    }

    public enum PhoneDirection
    {
        Incoming,
        Outgoing
    }
}