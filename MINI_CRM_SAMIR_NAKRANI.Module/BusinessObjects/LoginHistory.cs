using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;

namespace MINI_CRM_SAMIR_NAKRANI.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("Security")]
    [Persistent("LoginHistory")]
    public class LoginHistory : BaseObject
    {
        public LoginHistory(Session session) : base(session) { }

        private string userName;
        private string operation;
        private string ipAddress;
        private string hostName;
        private DateTime createdOn;

        [Size(100)]
        public string UserName
        {
            get => userName;
            set => SetPropertyValue(nameof(UserName), ref userName, value);
        }

        [Size(50)]
        public string Operation
        {
            get => operation;
            set => SetPropertyValue(nameof(Operation), ref operation, value);
        }

        [Size(50)]
        public string IpAddress
        {
            get => ipAddress;
            set => SetPropertyValue(nameof(IpAddress), ref ipAddress, value);
        }

        [Size(100)]
        public string HostName
        {
            get => hostName;
            set => SetPropertyValue(nameof(HostName), ref hostName, value);
        }

        [ModelDefault("AllowEdit", "False")]
        [ModelDefault("DisplayFormat", "G")]
        public DateTime CreatedOn
        {
            get => createdOn;
            set => SetPropertyValue(nameof(CreatedOn), ref createdOn, value);
        }
    }
}