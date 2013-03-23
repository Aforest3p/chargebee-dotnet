using System;
using System.IO;
using System.ComponentModel;
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using ChargeBee.Internal;
using ChargeBee.Api;
using ChargeBee.Models.Enums;

namespace ChargeBee.Models
{

    public class Estimate : Resource 
    {
    

        #region Methods
        public static CreateSubscriptionRequest CreateSubscription()
        {
            string url = ApiUtil.BuildUrl("estimates", "create_subscription");
            return new CreateSubscriptionRequest(url);
        }
        public static UpdateSubscriptionRequest UpdateSubscription()
        {
            string url = ApiUtil.BuildUrl("estimates", "update_subscription");
            return new UpdateSubscriptionRequest(url);
        }
        #endregion
        
        #region Properties
        public DateTime CreatedAt 
        {
            get { return (DateTime)GetDateTime("created_at", true); }
        }
        public bool Recurring 
        {
            get { return GetValue<bool>("recurring", true); }
        }
        public string SubscriptionId 
        {
            get { return GetValue<string>("subscription_id", false); }
        }
        public SubscriptionStatusEnum? SubscriptionStatus 
        {
            get { return GetEnum<SubscriptionStatusEnum>("subscription_status", false); }
        }
        public DateTime? TermEndsAt 
        {
            get { return GetDateTime("term_ends_at", false); }
        }
        public bool CollectNow 
        {
            get { return GetValue<bool>("collect_now", true); }
        }
        public int Amount 
        {
            get { return GetValue<int>("amount", true); }
        }
        public int SubTotal 
        {
            get { return GetValue<int>("sub_total", true); }
        }
        public List<EstimateLineItem> LineItems 
        {
            get { return GetResourceList<EstimateLineItem>("line_items"); }
        }
        public List<EstimateDiscount> Discounts 
        {
            get { return GetResourceList<EstimateDiscount>("discounts"); }
        }
        public List<EstimateTax> Taxes 
        {
            get { return GetResourceList<EstimateTax>("taxes"); }
        }

        #endregion
        
        #region Requests
        public class CreateSubscriptionRequest : EntityRequest 
        {

            public CreateSubscriptionRequest(string url) 
                    : base(url)
            {
                m_method = HttpMethod.POST;
            }

            public CreateSubscriptionRequest BillingCycles(int billingCycles) 
            {
                m_params.AddOpt("billing_cycles", billingCycles);
                return this;
            }
            public CreateSubscriptionRequest SubscriptionId(string subscriptionId) 
            {
                m_params.AddOpt("subscription[id]", subscriptionId);
                return this;
            }
            public CreateSubscriptionRequest SubscriptionPlanId(string subscriptionPlanId) 
            {
                m_params.Add("subscription[plan_id]", subscriptionPlanId);
                return this;
            }
            public CreateSubscriptionRequest SubscriptionPlanQuantity(int subscriptionPlanQuantity) 
            {
                m_params.AddOpt("subscription[plan_quantity]", subscriptionPlanQuantity);
                return this;
            }
            public CreateSubscriptionRequest SubscriptionTrialEnd(DateTime subscriptionTrialEnd) 
            {
                m_params.AddOpt("subscription[trial_end]", subscriptionTrialEnd);
                return this;
            }
            public CreateSubscriptionRequest SubscriptionCoupon(string subscriptionCoupon) 
            {
                m_params.AddOpt("subscription[coupon]", subscriptionCoupon);
                return this;
            }
            public CreateSubscriptionRequest AddonId(int index, string addonId) 
            {
                m_params.AddOpt("addons[id][" + index + "]", addonId);
                return this;
            }
            public CreateSubscriptionRequest AddonQuantity(int index, int addonQuantity) 
            {
                m_params.AddOpt("addons[quantity][" + index + "]", addonQuantity);
                return this;
            }
        }
        public class UpdateSubscriptionRequest : EntityRequest 
        {

            public UpdateSubscriptionRequest(string url) 
                    : base(url)
            {
                m_method = HttpMethod.POST;
            }

            public UpdateSubscriptionRequest BillingCycles(int billingCycles) 
            {
                m_params.AddOpt("billing_cycles", billingCycles);
                return this;
            }
            public UpdateSubscriptionRequest ReplaceAddonList(bool replaceAddonList) 
            {
                m_params.AddOpt("replace_addon_list", replaceAddonList);
                return this;
            }
            public UpdateSubscriptionRequest Prorate(bool prorate) 
            {
                m_params.AddOpt("prorate", prorate);
                return this;
            }
            public UpdateSubscriptionRequest EndOfTerm(bool endOfTerm) 
            {
                m_params.AddOpt("end_of_term", endOfTerm);
                return this;
            }
            public UpdateSubscriptionRequest SubscriptionId(string subscriptionId) 
            {
                m_params.Add("subscription[id]", subscriptionId);
                return this;
            }
            public UpdateSubscriptionRequest SubscriptionPlanId(string subscriptionPlanId) 
            {
                m_params.AddOpt("subscription[plan_id]", subscriptionPlanId);
                return this;
            }
            public UpdateSubscriptionRequest SubscriptionPlanQuantity(int subscriptionPlanQuantity) 
            {
                m_params.AddOpt("subscription[plan_quantity]", subscriptionPlanQuantity);
                return this;
            }
            public UpdateSubscriptionRequest SubscriptionTrialEnd(DateTime subscriptionTrialEnd) 
            {
                m_params.AddOpt("subscription[trial_end]", subscriptionTrialEnd);
                return this;
            }
            public UpdateSubscriptionRequest SubscriptionCoupon(string subscriptionCoupon) 
            {
                m_params.AddOpt("subscription[coupon]", subscriptionCoupon);
                return this;
            }
            public UpdateSubscriptionRequest AddonId(int index, string addonId) 
            {
                m_params.AddOpt("addons[id][" + index + "]", addonId);
                return this;
            }
            public UpdateSubscriptionRequest AddonQuantity(int index, int addonQuantity) 
            {
                m_params.AddOpt("addons[quantity][" + index + "]", addonQuantity);
                return this;
            }
        }
        #endregion


        #region Subclasses
        public class EstimateLineItem : Resource
        {

            public DateTime DateFrom() {
                return (DateTime)GetDateTime("date_from", true);
            }

            public DateTime DateTo() {
                return (DateTime)GetDateTime("date_to", true);
            }

            public int UnitAmount() {
                return GetValue<int>("unit_amount", true);
            }

            public int? Quantity() {
                return GetValue<int?>("quantity", false);
            }

            public int? Tax() {
                return GetValue<int?>("tax", false);
            }

            public double? TaxRate() {
                return GetValue<double?>("tax_rate", false);
            }

            public int Amount() {
                return GetValue<int>("amount", true);
            }

            public string Description() {
                return GetValue<string>("description", true);
            }

        }
        public class EstimateDiscount : Resource
        {

            public int Amount() {
                return GetValue<int>("amount", true);
            }

            public string Description() {
                return GetValue<string>("description", false);
            }

        }
        public class EstimateTax : Resource
        {

            public int Amount() {
                return GetValue<int>("amount", true);
            }

            public string Description() {
                return GetValue<string>("description", false);
            }

        }

        #endregion
    }
}
