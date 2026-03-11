using DevExpress.ExpressApp.Blazor;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using Microsoft.AspNetCore.Components;
using MINI_CRM_SAMIR_NAKRANI.Blazor.Server.Pages;

namespace MINI_CRM_SAMIR_NAKRANI.Blazor.Server.Editors.ViewItems
{
    [ViewItem(typeof(IModelViewItem))]
    public class SchedulerViewItem : ViewItem, IComponentContentHolder
    {
        public SchedulerViewItem(IModelViewItem model, Type objectType)
            : base(objectType, model.Id) { }

        protected override object CreateControlCore() => this;

        RenderFragment IComponentContentHolder.ComponentContent => builder =>
        {
            builder.OpenComponent<AppointmentsScheduler>(0);
            builder.CloseComponent();
        };
    }
}
