using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Blazor.Editors;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Persistent.Base;
using MINI_CRM_SAMIR_NAKRANI.Blazor.Server.Editors.CustomActivityList;
using MINI_CRM_SAMIR_NAKRANI.Module.BusinessObjects;
using System;
using System.Reflection;

namespace MINI_CRM_SAMIR_NAKRANI.Blazor.Server.Controllers
{
    public class CreateActivityController
        : ObjectViewController<ListView, Activity>
    {
        public SingleChoiceAction CreateActivityAction { get; }
        public SimpleAction DeleteActivityAction { get; }

        private bool _hasSelection = false;

        public CreateActivityController()
        {
            TargetViewType = ViewType.ListView;

            CreateActivityAction = new SingleChoiceAction(
                this,
                "CreateActivity",
                PredefinedCategory.ObjectsCreation
            )
            {
                Caption = "New Activity",
                ItemType = SingleChoiceActionItemType.ItemIsOperation
            };

            CreateActivityAction.Items.Add(
                new ChoiceActionItem("Phone", typeof(PhoneActivity)));

            CreateActivityAction.Items.Add(
                new ChoiceActionItem("Appointment", typeof(AppointmentActivity)));

            CreateActivityAction.Execute += CreateActivityAction_Execute;

            DeleteActivityAction = new SimpleAction(
                this,
                "DeleteActivity",
                PredefinedCategory.Edit
            )
            {
                Caption = "Delete Activity"
            };

            DeleteActivityAction.Execute += DeleteActivityAction_Execute;
        }
        private void Editor_SelectionStateChanged(object sender, bool hasSelection)
        {
            UpdateSelectionState(hasSelection);
        }
        protected override void OnActivated()
        {
            base.OnActivated();

            UpdateSelectionState(false);

            if (View.Editor is BlazorCustomActivityListEditor editor)
            {
                editor.SelectionStateChanged += Editor_SelectionStateChanged;
            }
            var newController = Frame.GetController<NewObjectViewController>();
            if (newController != null)
                newController.NewObjectAction.Active["Hidden"] = false;
            var deleteController = Frame.GetController<DeleteObjectsViewController>();
            if (deleteController != null)
                deleteController.DeleteAction.Active["Hidden"] = false;
            var linkController = Frame.GetController<LinkUnlinkController>();
            if (linkController != null)
            {
                linkController.LinkAction.Active["Hidden"] = false;
                linkController.UnlinkAction.Active["Hidden"] = false;
            }
        }
        public void UpdateSelectionState(bool hasSelection)
        {
            _hasSelection = hasSelection;

            CreateActivityAction.Active["SelectionToggle"] = !_hasSelection;
            DeleteActivityAction.Active["SelectionToggle"] = _hasSelection;
        }

        private void CreateActivityAction_Execute(
            object sender,
            SingleChoiceActionExecuteEventArgs e)
        {
            Type objectType = (Type)e.SelectedChoiceActionItem.Data;

            IObjectSpace objectSpace = Application.CreateObjectSpace(objectType);
            var newObject = (Activity)objectSpace.CreateObject(objectType);

            var master = GetMasterObject(View.CollectionSource);
            if (master is Lead currentLead)
            {
                newObject.Lead = objectSpace.GetObject(currentLead);
            }

            DetailView detailView =
                Application.CreateDetailView(objectSpace, newObject);

            detailView.ViewEditMode = ViewEditMode.Edit;

            if (master is Lead)
            {
                var leadEditor = detailView.FindItem(nameof(Activity.Lead)) as LookupPropertyEditor;
                if (leadEditor != null)
                {
                    leadEditor.AllowEdit["DisableLead"] = false;
                }
            }

            var svp = new ShowViewParameters
            {
                CreatedView = detailView,
                TargetWindow = TargetWindow.NewModalWindow,
                Context = TemplateContext.PopupWindow
            };

            Application.ShowViewStrategy.ShowView(
                svp,
                new ShowViewSource(Frame, null)
            );
        }

        private void DeleteActivityAction_Execute(
            object sender,
            SimpleActionExecuteEventArgs e)
        {
            foreach (var obj in e.SelectedObjects)
            {
                ObjectSpace.Delete(obj);
            }

            ObjectSpace.CommitChanges();
            ObjectSpace.Refresh();
        }

   
        private object GetMasterObject(CollectionSourceBase collectionSource)
        {
            if (collectionSource == null) return null;
            var prop = collectionSource.GetType().GetProperty("MasterObject", BindingFlags.Public | BindingFlags.Instance);
            return prop?.GetValue(collectionSource);
        }

        protected override void OnDeactivated()
        {
            if (View.Editor is BlazorCustomActivityListEditor editor)
            {
                editor.SelectionStateChanged -= Editor_SelectionStateChanged;
            }

            base.OnDeactivated();
        }
    }
}