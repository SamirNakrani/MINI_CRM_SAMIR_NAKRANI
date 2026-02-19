using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MINI_CRM_SAMIR_NAKRANI.Module.BusinessObjects
{
    [DefaultClassOptions]
    [Persistent("Company")]
    public class Company : BaseObject
    {
        public Company(Session session) : base(session) { }

        private string companyName;
        private string readableCompanyName;
        private string website;
        private string address1;
        private string address2;

        [Size(200)]
        public string CompanyName
        {
            get => companyName;
            set => SetPropertyValue(nameof(CompanyName), ref companyName, value);
        }

        [Size(200)]
        public string ReadableCompanyName
        {
            get => readableCompanyName;
            set => SetPropertyValue(nameof(ReadableCompanyName), ref readableCompanyName, value);
        }

        [Size(200)]
        public string Website
        {
            get => website;
            set => SetPropertyValue(nameof(Website), ref website, value);
        }

        [Size(200)]
        public string Address1
        {
            get => address1;
            set => SetPropertyValue(nameof(Address1), ref address1, value);
        }

        [Size(200)]
        public string Address2
        {
            get => address2;
            set => SetPropertyValue(nameof(Address2), ref address2, value);
        }

        protected override void OnSaving()
        {
            base.OnSaving();

            // Auto-populate Readable Company Name if empty
            if (string.IsNullOrWhiteSpace(ReadableCompanyName))
            {
                ReadableCompanyName = CompanyName;
            }
        }

    }
}
