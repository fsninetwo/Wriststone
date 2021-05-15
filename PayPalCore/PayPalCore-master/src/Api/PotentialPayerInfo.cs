//==============================================================================
//
//  This file was auto-generated by a tool using the PayPal REST API schema.
//  More information: https://developer.paypal.com/docs/api/
//
//==============================================================================
using Newtonsoft.Json;

namespace PayPal.Api
{
    /// <summary>
    /// A resource representing a information about a potential payer.
    /// </summary>
    public class PotentialPayerInfo : PayPalSerializableObject
    {
        /// <summary>
        /// Email address representing the potential payer.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "email")]
        public string email { get; set; }

        /// <summary>
        /// xternalRememberMe id representing the potential payer.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "external_remember_me_id")]
        public string external_remember_me_id { get; set; }

        /// <summary>
        /// Billing address of the potential payer.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "billing_address")]
        public Address billing_address { get; set; }
    }
}