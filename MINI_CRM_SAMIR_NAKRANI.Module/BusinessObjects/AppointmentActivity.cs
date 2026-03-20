using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using DevExpress.XtraScheduler;
using System;

namespace MINI_CRM_SAMIR_NAKRANI.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("Activity")]
    public class AppointmentActivity : Activity
    {
        public AppointmentActivity(Session session) : base(session) { }

        private AppointmentStatus statusReason = AppointmentStatus.Free;
        public AppointmentStatus StatusReason
        {
            get => statusReason;
            set => SetPropertyValue(nameof(StatusReason), ref statusReason, value);
        }

        private bool isAllDay;
        public bool IsAllDay
        {
            get => isAllDay;
            set => SetPropertyValue(nameof(IsAllDay), ref isAllDay, value);
        }

        private string location;

        [RuleRequiredField]
        public string Location
        {
            get => location;
            set => SetPropertyValue(nameof(Location), ref location, value);
        }

        private int durationMinutes;
        [RuleValueComparison(DefaultContexts.Save, ValueComparisonType.GreaterThan, 0)]
        [RuleValueComparison(DefaultContexts.Save, ValueComparisonType.LessThan, 1400)]
        public int DurationMinutes
        {
            get => durationMinutes;
            set => SetPropertyValue(nameof(DurationMinutes), ref durationMinutes, value);
        }
    }

    public enum AppointmentStatus
    {
        Free,
        Busy,
        Tentative,
        OutOfOffice
    }
}