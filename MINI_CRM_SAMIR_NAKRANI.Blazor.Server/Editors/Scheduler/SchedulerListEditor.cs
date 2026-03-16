using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Blazor;
using DevExpress.ExpressApp.Blazor.Components;
using DevExpress.ExpressApp.Blazor.Components.Models;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Utils;
using Microsoft.AspNetCore.Components;
using MINI_CRM_SAMIR_NAKRANI.Module.BusinessObjects;
using System.Collections;
using System.ComponentModel;

namespace MINI_CRM_SAMIR_NAKRANI.Blazor.Server.Editors.Scheduler
{
    [ListEditor(typeof(AppointmentActivity))]
    public class SchedulerListEditor : ListEditor, IComponentContentHolder
    {
        private RenderFragment _componentContent;

        public SchedulerViewModel ComponentModel { get; private set; }

        public RenderFragment ComponentContent
        {
            get
            {
                _componentContent ??=
                    ComponentModelObserver.Create(ComponentModel, ComponentModel.GetComponentContent());

                return _componentContent;
            }
        }

        public SchedulerListEditor(IModelListView model) : base(model) { }

        protected override object CreateControlsCore()
        {
            ComponentModel = new SchedulerViewModel();
            return ComponentModel;
        }

        protected override void AssignDataSourceToControl(object dataSource)
        {
            if (ComponentModel == null) return;

            ComponentModel.Data = (dataSource as IEnumerable)?
                .OfType<Activity>()
                .ToList();
        }

        public override void Refresh()
        {
            AssignDataSourceToControl(DataSource);
        }

        public override IList GetSelectedObjects()
        {
            return new List<Activity>();
        }

        public override SelectionType SelectionType => SelectionType.Full;
    }
}