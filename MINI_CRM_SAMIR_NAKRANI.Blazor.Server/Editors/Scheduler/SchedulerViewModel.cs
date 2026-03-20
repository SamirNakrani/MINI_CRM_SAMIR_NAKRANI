using DevExpress.ExpressApp.Blazor.Components.Models;
using MINI_CRM_SAMIR_NAKRANI.Module.BusinessObjects;
using MINI_CRM_SAMIR_NAKRANI.Blazor.Server.Pages;

namespace MINI_CRM_SAMIR_NAKRANI.Blazor.Server.Editors.Scheduler
{
    public class SchedulerViewModel : ComponentModelBase
    {
        public IEnumerable<Activity> Data
        {
            get => GetPropertyValue<IEnumerable<Activity>>();
            set => SetPropertyValue(value);
        }

        public override Type ComponentType => typeof(AppointmentsScheduler);
    }
}