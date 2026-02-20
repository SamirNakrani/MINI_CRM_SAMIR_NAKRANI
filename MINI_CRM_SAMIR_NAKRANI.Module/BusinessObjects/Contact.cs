using System.Linq;
using DevExpress.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;

namespace MINI_CRM_SAMIR_NAKRANI.Module.BusinessObjects
{
    [DefaultClassOptions]
    [Persistent("Contact")]
    public class Contact : BaseObject
    {
        public Contact(Session session) : base(session) { }

        #region Names

        private string fullName;
        private string firstName;
        private string middleName;
        private string lastName;
        private string readableFirstName;
        private string readableMiddleName;
        private string readableLastName;

        [Size(200)]
        public string FullName
        {
            get => fullName;
            set => SetPropertyValue(nameof(FullName), ref fullName, value);
        }

        [Size(100)]
        public string FirstName
        {
            get => firstName;
            set => SetPropertyValue(nameof(FirstName), ref firstName, value);
        }

        [Size(100)]
        public string MiddleName
        {
            get => middleName;
            set => SetPropertyValue(nameof(MiddleName), ref middleName, value);
        }

        [Size(100)]
        public string LastName
        {
            get => lastName;
            set => SetPropertyValue(nameof(LastName), ref lastName, value);
        }

        [Size(100)]
        public string ReadableFirstName
        {
            get => readableFirstName;
            set => SetPropertyValue(nameof(ReadableFirstName), ref readableFirstName, value);
        }

        [Size(100)]
        public string ReadableMiddleName
        {
            get => readableMiddleName;
            set => SetPropertyValue(nameof(ReadableMiddleName), ref readableMiddleName, value);
        }

        [Size(100)]
        public string ReadableLastName
        {
            get => readableLastName;
            set => SetPropertyValue(nameof(ReadableLastName), ref readableLastName, value);
        }

        #endregion

        #region Contact Info

        private string title;
        private string phone;
        private string mobile;
        private string email;

        [Size(100)]
        public string Title
        {
            get => title;
            set => SetPropertyValue(nameof(Title), ref title, value);
        }

        [Size(50)]
        public string Phone
        {
            get => phone;
            set => SetPropertyValue(nameof(Phone), ref phone, value);
        }

        [Size(50)]
        public string Mobile
        {
            get => mobile;
            set => SetPropertyValue(nameof(Mobile), ref mobile, value);
        }

        [Size(100)]
        public string Email
        {
            get => email;
            set => SetPropertyValue(nameof(Email), ref email, value);
        }

        #endregion
 

        #region Collections
 
        #endregion

        #region Overrides

        protected override void OnSaving()
        {
            base.OnSaving();
            if (string.IsNullOrWhiteSpace(FullName))
            {
                FullName = string.Join(" ",
                    new[] { FirstName, MiddleName, LastName }
                    .Where(x => !string.IsNullOrWhiteSpace(x)));
            }
        }

        #endregion
    }
}