using DevExpress.ExpressApp.Blazor;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using Microsoft.AspNetCore.Components;
using MINI_CRM_SAMIR_NAKRANI.Module.BusinessObjects;
using MINI_CRM_SAMIR_NAKRANI.Blazor.Server.Pages;

namespace MINI_CRM_SAMIR_NAKRANI.Blazor.Server.Editors.ViewItems
{
    [ViewItem(typeof(IModelViewItem))]
    public class LeadStatusBarViewItem : ViewItem, IComponentContentHolder
    {
        public ProcessProgress ComponentInstance { get; private set; }

        public LeadStatusBarViewItem(IModelViewItem model, Type objectType) : base(objectType, model.Id) { }

        protected override object CreateControlCore() => this;

        public override void Refresh()
        {
            base.Refresh();
            ComponentInstance?.RefreshUI();
        }

        RenderFragment IComponentContentHolder.ComponentContent => builder =>
        {

            var currentObject = View?.CurrentObject;

            if (currentObject is Lead)
            {
                builder.OpenComponent<ProcessProgress>(0);
                builder.AddAttribute(1, nameof(ProcessProgress.ViewItem), this);

                builder.AddComponentReferenceCapture(2, inst => ComponentInstance = (ProcessProgress)inst);

                builder.CloseComponent();
            }
        };
    }
}
