using DevExpress.ExpressApp;
using MINI_CRM_SAMIR_NAKRANI.Module.BusinessObjects;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace MINI_CRM_SAMIR_NAKRANI.Blazor.Server.Services
{
    public class LoginHistoryService
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public LoginHistoryService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public void LogLogin(IObjectSpace objectSpace, string userName)
        {
            var history = objectSpace.CreateObject<LoginHistory>();
            history.UserName = userName;
            history.Operation = "Login";

            var httpContext = httpContextAccessor.HttpContext;

            var ip = httpContext?.Request?.Headers["X-Forwarded-For"]
                          .FirstOrDefault()?.Split(',').FirstOrDefault()?.Trim();

            if (string.IsNullOrEmpty(ip))
            {
                var remoteIp = httpContext?.Connection?.RemoteIpAddress;

                if (remoteIp != null)
                {
                    if (IPAddress.IsLoopback(remoteIp))
                    {
                        ip = "127.0.0.1 (localhost)";
                    }
                    else
                    {
                        ip = remoteIp.IsIPv4MappedToIPv6
                            ? remoteIp.MapToIPv4().ToString()
                            : remoteIp.ToString();
                    }
                }
            }

            history.IpAddress = ip ?? "Unknown";
            history.HostName = httpContext?.Request?.Host.Value;
            history.CreatedOn = DateTime.Now;

            objectSpace.CommitChanges();
        }
    }
}