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
    /// Collection of payment response related fields returned from a payment request.
    /// </summary>
    public class ProcessorResponse : PayPalSerializableObject
    {
        /// <summary>
        /// Paypal normalized response code, generated from the processor's specific response code
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "response_code")]
        public string response_code { get; set; }

        /// <summary>
        /// Address Verification System response code. https://developer.paypal.com/webapps/developer/docs/classic/api/AVSResponseCodes/
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "avs_code")]
        public string avs_code { get; set; }

        /// <summary>
        /// CVV System response code. https://developer.paypal.com/webapps/developer/docs/classic/api/AVSResponseCodes/
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "cvv_code")]
        public string cvv_code { get; set; }

        /// <summary>
        /// Provides merchant advice on how to handle declines related to recurring payments
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "advice_code")]
        public string advice_code { get; set; }

        /// <summary>
        /// Response back from the authorization. Provided by the processor
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "eci_submitted")]
        public string eci_submitted { get; set; }

        /// <summary>
        /// PVisa Payer Authentication Service status. Will be return from processor
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "vpas")]
        public string vpas { get; set; }
    }
}
