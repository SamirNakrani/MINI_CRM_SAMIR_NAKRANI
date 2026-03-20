    using DevExpress.ExpressApp;
    using DevExpress.ExpressApp.Actions;
    using DevExpress.ExpressApp.SystemModule;
    using MINI_CRM_SAMIR_NAKRANI.Module.BusinessObjects;

namespace MINI_CRM_SAMIR_NAKRANI.Blazor.Server.Controllers
{
    public class LoginHistoryReadOnlyActionsController : ViewController<ListView>
    {
        protected override void OnActivated()
        {
            base.OnActivated();

            if (View.ObjectTypeInfo.Type == typeof(LoginHistory))
            {
                var newController = Frame.GetController<NewObjectViewController>();
                var deleteController = Frame.GetController<DeleteObjectsViewController>();
                var modController = Frame.GetController<ModificationsController>();

                if (newController != null)
                    newController.NewObjectAction.Active["ReadOnly"] = false;

                if (deleteController != null)
                    deleteController.DeleteAction.Active["ReadOnly"] = false;

                if (modController != null)
                    modController.SaveAction.Active["ReadOnly"] = false;
            }
        }
    }
}
