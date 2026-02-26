using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Blazor.Editors;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Persistent.Base;
using MINI_CRM_SAMIR_NAKRANI.Module.BusinessObjects;
using System;
using System.Linq;

namespace MINI_CRM_SAMIR_NAKRANI.Blazor.Server.Controllers
{
    public class LeadStatusFilterController : ViewController<ListView>
    {
        private SingleChoiceAction statusFilterAction;
        private SimpleAction toggleFilterRowAction;
        private SimpleAction resetViewAction;

        private bool isFilterRowVisible;

        public LeadStatusFilterController()
        {
            TargetObjectType = typeof(Lead);
            TargetViewId = "Lead_ListView";

            statusFilterAction = new SingleChoiceAction(
                this,
                "StatusFilter",
                PredefinedCategory.Filters)
            {
                Caption = "Status",
                ItemType = SingleChoiceActionItemType.ItemIsMode,
                SelectionDependencyType = SelectionDependencyType.Independent
            };
            statusFilterAction.Execute += StatusFilterAction_Execute;

            toggleFilterRowAction = new SimpleAction(
                this,
                "ToggleFilterRow",
                PredefinedCategory.Filters)
            {
                Caption = "Filter Switching",
                ImageName = "Action_Filter"
            };
            toggleFilterRowAction.Execute += ToggleFilterRowAction_Execute;

            resetViewAction = new SimpleAction(
                this,
                "ResetLeadView",
                PredefinedCategory.Filters)
            {
                Caption = "Reset View Settings",
                ImageName = "Action_ResetViewSettings"
            };
            resetViewAction.Execute += ResetViewAction_Execute;
        }

        protected override void OnActivated()
        {
            base.OnActivated();

            statusFilterAction.Items.Clear();
            statusFilterAction.Items.Add(new ChoiceActionItem("All", null));

            foreach (LeadStatus status in Enum.GetValues(typeof(LeadStatus)))
            {
                statusFilterAction.Items.Add(
                    new ChoiceActionItem(status.ToString(), status));
            }

            statusFilterAction.SelectedItem = statusFilterAction.Items.First();
        }

        private void ToggleFilterRowAction_Execute(
            object sender,
            SimpleActionExecuteEventArgs e)
        {
            if (View.Editor is not DxGridListEditor gridEditor)
                return;

            isFilterRowVisible = !isFilterRowVisible;
            gridEditor.GridModel.ShowFilterRow = isFilterRowVisible;
        }

        private void StatusFilterAction_Execute(
            object sender,
            SingleChoiceActionExecuteEventArgs e)
        {
            const string key = "StatusFilter";

            if (e.SelectedChoiceActionItem.Data == null)
            {
                View.CollectionSource.Criteria.Remove(key);
                return;
            }

            View.CollectionSource.Criteria[key] =
                CriteriaOperator.Parse(
                    "Status = ?",
                    e.SelectedChoiceActionItem.Data);
        }

        private void ResetViewAction_Execute(
            object sender,
            SimpleActionExecuteEventArgs e)
        {
            var resetController = Frame.GetController<ResetViewSettingsController>();
            resetController?.ResetViewSettingsAction.DoExecute();
            statusFilterAction.SelectedItem = statusFilterAction.Items.First();

            if (View.Editor is DxGridListEditor gridEditor)
            {
                isFilterRowVisible = false;
                gridEditor.GridModel.ShowFilterRow = false;
            }
        }

        protected override void OnDeactivated()
        {
            toggleFilterRowAction.Execute -= ToggleFilterRowAction_Execute;
            statusFilterAction.Execute -= StatusFilterAction_Execute;
            resetViewAction.Execute -= ResetViewAction_Execute;
            base.OnDeactivated();
        }
    }
}