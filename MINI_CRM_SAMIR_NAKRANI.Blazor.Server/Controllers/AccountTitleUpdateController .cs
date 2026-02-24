using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Editors;
using MINI_CRM_SAMIR_NAKRANI.Module.BusinessObjects;

namespace MINI_CRM_SAMIR_NAKRANI.Blazor.Server.Controllers
{
    public class AccountTitleUpdateController : ObjectViewController<DetailView, Account>
    {
        protected override void OnActivated()
        {
            base.OnActivated();

            ObjectSpace.ObjectChanged += ObjectSpace_ObjectChanged;
            UpdateCaption();
        }

        private void ObjectSpace_ObjectChanged(object sender, ObjectChangedEventArgs e)
        {
            if (e.Object == View.CurrentObject &&
                e.PropertyName == nameof(Account.AccountName))
            {
                UpdateCaption();
            }
        }

        private void UpdateCaption()
        {
            if (View.CurrentObject is Account account &&
                !string.IsNullOrWhiteSpace(account.AccountName))
            {
                View.Caption = account.AccountName;
            }
        }

        protected override void OnDeactivated()
        {
            ObjectSpace.ObjectChanged -= ObjectSpace_ObjectChanged;
            base.OnDeactivated();
        }
    }
}