using DevExpress.Persistent.Base.General;
using DevExpress.Xpo;
using System;

namespace MINI_CRM_SAMIR_NAKRANI.Module.BusinessObjects
{
    public class AppointmentActivity : Activity, IEvent
    {
        public AppointmentActivity(Session session) : base(session) { }

        public DateTime EndOn { get; set; }
        public bool AllDay { get; set; }

        public string Description { get; set; }
        public string Location { get; set; }
        public int Label { get; set; }
        public int Status { get; set; }
        public int Type { get; set; }
        public string ResourceId { get; set; }
        public object AppointmentId => Oid;
    }
}