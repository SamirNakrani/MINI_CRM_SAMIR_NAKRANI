using DevExpress.ExpressApp;
using DevExpress.ExpressApp.SystemModule;
using MINI_CRM_SAMIR_NAKRANI.Blazor.Server.Editors.CustomActivityList;
using MINI_CRM_SAMIR_NAKRANI.Module.BusinessObjects;

namespace MINI_CRM_SAMIR_NAKRANI.Blazor.Server.Controllers
{
    public class EditActivityPopupController : ViewController<ListView>
    {
        public EditActivityPopupController()
        {
            TargetObjectType = typeof(Activity);
        }

        protected override void OnActivated()
        {
            base.OnActivated();

            if (View.Editor is BlazorCustomActivityListEditor editor)
            {
                editor.EditActivityRequested += Editor_EditActivityRequested;
            }
        }

        private void Editor_EditActivityRequested(object sender, Activity activity)
        {
            if (activity == null) return;

            IObjectSpace objectSpace = Application.CreateObjectSpace(activity.GetType());
            var activityToEdit = objectSpace.GetObject(activity);

            DetailView detailView = Application.CreateDetailView(objectSpace, activityToEdit);
            detailView.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit;

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

        protected override void OnDeactivated()
        {
            if (View?.Editor is BlazorCustomActivityListEditor editor)
            {
                editor.EditActivityRequested -= Editor_EditActivityRequested;
            }
            base.OnDeactivated();
        }
    }
}
