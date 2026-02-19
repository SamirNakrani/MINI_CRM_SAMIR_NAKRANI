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
    [Persistent("ContactMethod")]
    public class ContactMethod : BaseObject
    {
        public ContactMethod(Session session) : base(session) { }

        #region Contact Method

        private PreferredContactMethod preferredContactMethod;

        private bool doNotPostalMail;
        private bool doNotSendMM;
        private bool doNotPhone;
        private bool doNotFax;
        private bool doNotEmail;
        private bool followEmail;
        private bool doNotBulkEmail;

        public PreferredContactMethod PreferredContactMethod
        {
            get => preferredContactMethod;
            set => SetPropertyValue(nameof(PreferredContactMethod), ref preferredContactMethod, value);
        }

        public bool DoNotPostalMail
        {
            get => doNotPostalMail;
            set => SetPropertyValue(nameof(DoNotPostalMail), ref doNotPostalMail, value);
        }

        public bool DoNotSendMM
        {
            get => doNotSendMM;
            set => SetPropertyValue(nameof(DoNotSendMM), ref doNotSendMM, value);
        }

        public bool DoNotPhone
        {
            get => doNotPhone;
            set => SetPropertyValue(nameof(DoNotPhone), ref doNotPhone, value);
        }

        public bool DoNotFax
        {
            get => doNotFax;
            set => SetPropertyValue(nameof(DoNotFax), ref doNotFax, value);
        }

        public bool DoNotEmail
        {
            get => doNotEmail;
            set => SetPropertyValue(nameof(DoNotEmail), ref doNotEmail, value);
        }

        public bool FollowEmail
        {
            get => followEmail;
            set => SetPropertyValue(nameof(FollowEmail), ref followEmail, value);
        }

        public bool DoNotBulkEmail
        {
            get => doNotBulkEmail;
            set => SetPropertyValue(nameof(DoNotBulkEmail), ref doNotBulkEmail, value);
        }

        #endregion

        #region Defaults

        public override void AfterConstruction()
        {
            base.AfterConstruction();

            PreferredContactMethod = PreferredContactMethod.Any;

            DoNotPostalMail = false;   // Allow
            DoNotSendMM = false;       // Send
            DoNotPhone = false;        // Allow
            DoNotFax = false;          // Allow
            DoNotEmail = false;        // Allow
            FollowEmail = false;       // Allow
            DoNotBulkEmail = false;    // Allow
        }

        #endregion
    }

    public enum PreferredContactMethod
    {
        Any,
        Email,
        Phone,
        Mobile,
        PostalMail,
        Fax
    }
}
