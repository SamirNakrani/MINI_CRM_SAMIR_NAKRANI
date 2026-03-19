using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Security;
using MINI_CRM_SAMIR_NAKRANI.Blazor.Server.Services;
using MINI_CRM_SAMIR_NAKRANI.Module.BusinessObjects;

public class LoginTrackingController : WindowController
{
    // ✅ Simple instance-level flag, no static, no HashSet
    private bool _loginLogged = false;

    public LoginTrackingController()
    {
        TargetWindowType = WindowType.Main;
    }

    protected override void OnActivated()
    {
        base.OnActivated();

        var currentUser = SecuritySystem.CurrentUser?.ToString();

        // ✅ Only log once per controller instance lifetime (= one session)
        if (!_loginLogged && !string.IsNullOrEmpty(currentUser))
        {
            _loginLogged = true;

            var os = Application.CreateObjectSpace(typeof(LoginHistory));
            var service = Application.ServiceProvider
                .GetService(typeof(LoginHistoryService)) as LoginHistoryService;

            service?.LogLogin(os, currentUser);
        }
    }
}