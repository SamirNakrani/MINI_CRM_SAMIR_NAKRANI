using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System.ComponentModel;

namespace MINI_CRM_SAMIR_NAKRANI.Module.BusinessObjects
{
    [DefaultClassOptions]
    [DefaultProperty(nameof(FullAddress))]
    [Persistent("Address")]
    public class Address : BaseObject
    {
        public Address(Session session) : base(session) { }

        private Country country;
        private string zipCode;
        private string state;
        private string city;
        private string street;
        private string phone1;
        private string phone2;
        private AddressType addressType;

        public Country Country
        {
            get => country;
            set => SetPropertyValue(nameof(Country), ref country, value);
        }

        [Size(20)]
        public string ZipPostalCode
        {
            get => zipCode;
            set => SetPropertyValue(nameof(ZipPostalCode), ref zipCode, value);
        }

        [Size(100)]
        public string StateProvince
        {
            get => state;
            set => SetPropertyValue(nameof(StateProvince), ref state, value);
        }

        [Size(100)]
        public string City
        {
            get => city;
            set => SetPropertyValue(nameof(City), ref city, value);
        }

        [Size(200)]
        public string Street
        {
            get => street;
            set => SetPropertyValue(nameof(Street), ref street, value);
        }

        [Size(30)]
        public string Phone1
        {
            get => phone1;
            set => SetPropertyValue(nameof(Phone1), ref phone1, value);
        }

        [Size(30)]
        public string Phone2
        {
            get => phone2;
            set => SetPropertyValue(nameof(Phone2), ref phone2, value);
        }

        public AddressType AddressType
        {
            get => addressType;
            set => SetPropertyValue(nameof(AddressType), ref addressType, value);
        }

        [PersistentAlias(
            "Concat(" +
            "Iif(Country Is Null, '', Country.Name + ', ')," +
            "Iif(Street Is Null, '', Street + ', ')," +
            "Iif(City Is Null, '', City + ', ')," +
            "Iif(StateProvince Is Null, '', StateProvince + ' ')," +
            "Iif(ZipPostalCode Is Null, '', ZipPostalCode)" +
            ")")]
        public string FullAddress => (string)EvaluateAlias(nameof(FullAddress));
    }
}

public enum AddressType
{
    Home,
    Office,
    Billing,
    Shipping,
    Other
}