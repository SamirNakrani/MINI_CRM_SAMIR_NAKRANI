using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace MINI_CRM_SAMIR_NAKRANI.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("Geography")]
    [Persistent("Country")]
    public class Country : BaseObject
    {
        public Country(Session session) : base(session) { }

        private string name;
        private string phoneCode;
        private DateTime createdOn;
        private DateTime modifiedOn;
        [Size(100)]
        public string Name
        {
            get => name;
            set => SetPropertyValue(nameof(Name), ref name, value);
        }

        [Size(10)]
        public string PhoneCode
        {
            get => phoneCode;
            set => SetPropertyValue(nameof(PhoneCode), ref phoneCode, value);
        }


        [ModelDefault("AllowEdit", "False")]
        public DateTime CreatedOn
        {
            get => createdOn;
            set => SetPropertyValue(nameof(CreatedOn), ref createdOn, value);
        }

        [ModelDefault("AllowEdit", "False")]
        public DateTime ModifiedOn
        {
            get => modifiedOn;
            set => SetPropertyValue(nameof(ModifiedOn), ref modifiedOn, value);
        }

        protected override void OnSaving()
        {
            base.OnSaving();

            if (Session.IsNewObject(this))
            {
                CreatedOn = DateTime.Now;
            }

            ModifiedOn = DateTime.Now;
        }
    }
}