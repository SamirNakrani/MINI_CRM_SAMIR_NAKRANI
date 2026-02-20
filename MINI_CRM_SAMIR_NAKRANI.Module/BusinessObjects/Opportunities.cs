using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;

namespace MINI_CRM_SAMIR_NAKRANI.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("Sales")]
    [ImageName("BO_Opportunity")]
    public class Opportunities : BaseObject
    {
        public Opportunities(Session session) : base(session) { }

        private string topic;
        [Size(200)]
        public string Topic
        {
            get => topic;
            set => SetPropertyValue(nameof(Topic), ref topic, value);
        }

        private string description;
        [Size(SizeAttribute.Unlimited)]
        public string Description
        {
            get => description;
            set => SetPropertyValue(nameof(Description), ref description, value);
        }

        private TimeFrame timeFrame;
        public TimeFrame TimeFrame
        {
            get => timeFrame;
            set => SetPropertyValue(nameof(TimeFrame), ref timeFrame, value);
        }

        private decimal budget;
        public decimal Budget
        {
            get => budget;
            set => SetPropertyValue(nameof(Budget), ref budget, value);
        }

        private BudgetStatus budgetStatus;
        public BudgetStatus BudgetStatus
        {
            get => budgetStatus;
            set => SetPropertyValue(nameof(BudgetStatus), ref budgetStatus, value);
        }

        private ForecastCategory forecastCategory;
        public ForecastCategory ForecastCategory
        {
            get => forecastCategory;
            set => SetPropertyValue(nameof(ForecastCategory), ref forecastCategory, value);
        }

        private DateTime estimatedCloseDate;
        public DateTime EstimatedCloseDate
        {
            get => estimatedCloseDate;
            set => SetPropertyValue(nameof(EstimatedCloseDate), ref estimatedCloseDate, value);
        }

    

        private Contact contact;
        public Contact Contact
        {
            get => contact;
            set => SetPropertyValue(nameof(Contact), ref contact, value);
        }
    }

    public enum TimeFrame
    {
        ThisMonth = 0,
        ThisQuarter = 1,
        ThisYear = 2,
        NextYear = 3
    }

    public enum BudgetStatus
    {
        WillBuy = 0,
        MayBuy = 1,
        NotBuying = 2
    }

    public enum ForecastCategory
    {
        BestCase = 0,
        Likely = 1,
        WorstCase = 2
    }
}
