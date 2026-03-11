using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using Microsoft.AspNetCore.Components;

namespace MINI_CRM_SAMIR_NAKRANI.Blazor.Server.Controllers
{
    public class SchedulerNavigationController : ViewController
    {
        public SchedulerNavigationController()
        {
            var action = new SimpleAction(this, "OpenScheduler", PredefinedCategory.View)
            {
                Caption = "Scheduler",
                ImageName = "BO_Task"
            };

            action.Execute += SchedulerAction_Execute;
        }

        private void SchedulerAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            try
            {
                if (Frame?.Application?.ServiceProvider != null)
                {
                    var navManager = Frame.Application.ServiceProvider.GetService(typeof(NavigationManager)) as NavigationManager;
                    navManager?.NavigateTo("/appointments-scheduler");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Navigation error: {ex.Message}");
            }
        }
    }
}