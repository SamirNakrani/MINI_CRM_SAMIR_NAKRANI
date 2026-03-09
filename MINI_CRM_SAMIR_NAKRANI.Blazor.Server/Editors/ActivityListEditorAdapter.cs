using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Blazor;
using DevExpress.ExpressApp.Blazor.Components;
using DevExpress.ExpressApp.Blazor.Components.Models;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Utils;
using Microsoft.AspNetCore.Components;
using MINI_CRM_SAMIR_NAKRANI.Module.BusinessObjects;
using System.Collections;
using System.ComponentModel;

namespace MINI_CRM_SAMIR_NAKRANI.Blazor.Server.Editors.CustomActivityList
{
    [ListEditor(typeof(Activity))]
    public class BlazorCustomActivityListEditor : ListEditor, IComponentContentHolder, IControlOrderProvider
    {
        private RenderFragment _componentContent;
        private Activity[] _selectedObjects = Array.Empty<Activity>();
        public event EventHandler<bool> SelectionStateChanged;

        public ActivityListViewModel ComponentModel { get; private set; }

        public RenderFragment ComponentContent
        {
            get
            {
                _componentContent ??= ComponentModelObserver.Create(ComponentModel, ComponentModel.GetComponentContent());
                return _componentContent;
            }
        }

        public BlazorCustomActivityListEditor(IModelListView model) : base(model) { }

        private void BindingList_ListChanged(object sender, ListChangedEventArgs e)
            => UpdateDataSource(DataSource);

        private void UpdateDataSource(object dataSource)
        {
            if (ComponentModel != null)
            {
                ComponentModel.Data = (dataSource as IEnumerable)?
                    .OfType<Activity>()
                    .OrderByDescending(a => a.ScheduledStart)
                    .ToList();
            }
        }

        protected override object CreateControlsCore()
        {
            ComponentModel = new ActivityListViewModel();

            ComponentModel.ItemClick = EventCallback.Factory.Create<Activity>(this, item =>
            {
                _selectedObjects = new[] { item };
                OnSelectionChanged();
                OnProcessSelectedItem();       
            });

            ComponentModel.SelectionChanged = EventCallback.Factory.Create<IEnumerable<Activity>>(this, items =>
            {
                _selectedObjects = items.ToArray();
                OnSelectionChanged();
            });

            ComponentModel.HasSelectionChanged = EventCallback.Factory.Create<bool>(this, hasSelection =>
            {
                SelectionStateChanged?.Invoke(this, hasSelection);
            });

            return ComponentModel;
        }

        protected override void AssignDataSourceToControl(object dataSource)
        {
            if (ComponentModel == null) return;

            if (ComponentModel.Data is IBindingList oldList)
                oldList.ListChanged -= BindingList_ListChanged;

            UpdateDataSource(dataSource);

            if (dataSource is IBindingList newList)
                newList.ListChanged += BindingList_ListChanged;
        }

        public override void BreakLinksToControls()
        {
            AssignDataSourceToControl(null);
            base.BreakLinksToControls();
        }

        public override void Refresh() => UpdateDataSource(DataSource);

        public override SelectionType SelectionType => SelectionType.Full;
        public override IList GetSelectedObjects() => _selectedObjects;

        public int GetIndexByObject(object obj)
        {
            var items = ListHelper.GetList(ComponentModel?.Data);
            return items.IndexOf(obj);
        }

        public object GetObjectByIndex(int index)
        {
            var items = ListHelper.GetList(ComponentModel?.Data);
            return index >= 0 && index < items.Count ? items[index] : null;
        }

        public IList GetOrderedObjects()
        {
            var list = new List<object>();
            var items = ListHelper.GetList(ComponentModel?.Data);
            for (int i = 0; i < items.Count; i++)
                if (items[i] != null) list.Add(items[i]);
            return list;
        }
    }
}