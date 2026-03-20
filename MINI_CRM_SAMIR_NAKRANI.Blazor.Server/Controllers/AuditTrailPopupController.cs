using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.BaseImpl;
    
namespace MINI_CRM_SAMIR_NAKRANI.Blazor.Server.Controllers
{
    public class AuditPopupController
        : ObjectViewController<ListView, AuditDataItemPersistent>
    {
        protected override void OnActivated()
        {
            base.OnActivated();

            View.SelectionChanged += View_SelectionChanged;
        }

        private void View_SelectionChanged(object sender, EventArgs e)
        {
            var audit = View.CurrentObject as AuditDataItemPersistent;
            if (audit == null) return;

            IObjectSpace os = Application.CreateObjectSpace(typeof(AuditDataItemPersistent));
            var obj = os.GetObject(audit);

            DetailView dv = Application.CreateDetailView(os, obj, true);

            dv.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.View;

            ShowViewParameters svp = new ShowViewParameters(dv);
            svp.TargetWindow = TargetWindow.NewModalWindow;

            Application.ShowViewStrategy.ShowView(svp, new ShowViewSource(null, null));
        }

        protected override void OnDeactivated()
        {
            View.SelectionChanged -= View_SelectionChanged;
            base.OnDeactivated();
        }
    }
}