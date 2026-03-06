using DevExpress.ExpressApp.Blazor.Components.Models;
using Microsoft.AspNetCore.Components;
using MINI_CRM_SAMIR_NAKRANI.Blazor.Server.Controllers;
using MINI_CRM_SAMIR_NAKRANI.Module.BusinessObjects;

namespace MINI_CRM_SAMIR_NAKRANI.Blazor.Server.Editors.CustomActivityList
{
    public class ActivityListViewModel : ComponentModelBase
    {
        public IEnumerable<Activity> Data
        {
            get => GetPropertyValue<IEnumerable<Activity>>();
            set => SetPropertyValue(value);
        }

        public EventCallback<Activity> ItemClick
        {
            get => GetPropertyValue<EventCallback<Activity>>();
            set => SetPropertyValue(value);
        }

        public EventCallback<IEnumerable<Activity>> SelectionChanged
        {
            get => GetPropertyValue<EventCallback<IEnumerable<Activity>>>();
            set => SetPropertyValue(value);
        }

        public EventCallback<bool> HasSelectionChanged
        {
            get => GetPropertyValue<EventCallback<bool>>();
            set => SetPropertyValue(value);
        }

        public override Type ComponentType => typeof(ActivityList);
    }
}