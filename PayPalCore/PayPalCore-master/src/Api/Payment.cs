//==============================================================================
//
//  This file was auto-generated by a tool using the PayPal REST API schema.
//  More information: https://developer.paypal.com/docs/api/
//
//==============================================================================
using Newtonsoft.Json;
using PayPal.Util;
using System.Collections.Generic;

namespace PayPal.Api
{
    /// <summary>
    /// A REST API payment resource.
    /// <para>
    /// See <a href="https://developer.paypal.com/docs/api/">PayPal Developer documentation</a> for more information.
    /// </para>
    /// </summary>
    public class Payment : PayPalRelationalObject
    {
        /// <summary>
        /// Identifier of the payment resource created.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "id")]
        public string id { get; set; }

        /// <summary>
        /// Intent of the payment - Sale or Authorization or Order.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "intent")]
        public string intent { get; set; }

        /// <summary>
        /// Source of the funds for this payment represented by a PayPal account or a direct credit card.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "payer")]
        public Payer payer { get; set; }

        /// <summary>
        /// .
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "payee")]
        public Payee payee { get; set; }

        /// <summary>
        /// ID of the cart to execute the payment.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "cart")]
        public string cart { get; set; }

        /// <summary>
        /// A payment can have more than one transaction, with each transaction establishing a contract between the payer and a payee
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "transactions")]
        public List<Transaction> transactions { get; set; }

        /// <summary>
        /// Applicable for advanced payments like multi seller payment (MSP) to support partial failures
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "failed_transactions")]
        public List<Error> failed_transactions { get; set; }

        /// <summary>
        /// A payment instruction resource
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "payment_instruction")]
        public PaymentInstruction payment_instruction { get; set; }

        /// <summary>
        /// state of the payment
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "state")]
        public string state { get; set; }

        /// <summary>
        /// Identifier for the payment experience.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "experience_profile_id")]
        public string experience_profile_id { get; set; }

        /// <summary>
        /// Redirect urls required only when using payment_method as PayPal - the only settings supported are return and cancel urls.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "redirect_urls")]
        public RedirectUrls redirect_urls { get; set; }

        /// <summary>
        /// Time the resource was created in UTC ISO8601 format.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "create_time")]
        public string create_time { get; set; }

        /// <summary>
        /// Time the resource was last updated in UTC ISO8601 format.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "update_time")]
        public string update_time { get; set; }

        /// <summary>
        /// Free-form field that allows clients to pass in a message to the payer.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "note_to_payer")]
        public string note_to_payer { get; set; }

        /// <summary>
        /// Collection of PayPal generated billing agreement tokens.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "billing_agreement_tokens")]
        public List<string> billing_agreement_tokens { get; set; }

        /// <summary>
        /// Get or sets the token found in the approval_url link returned from a call to create this resource.
        /// </summary>
        [JsonIgnore]
        public string token { get; set; }

        /// <summary>
        /// Creates (and processes) a new Payment Resource.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <returns>Payment</returns>
        public Payment Create(APIContext apiContext)
        {
            return Payment.Create(apiContext, this);
        }

        /// <summary>
        /// Creates (and processes) a new Payment Resource.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <param name="payment">Payment object to be used in creating the PayPal resource.</param>
        /// <returns>Payment</returns>
        public static Payment Create(APIContext apiContext, Payment payment)
        {
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);

            // Configure and send the request
            var resourcePath = "v1/payments/payment";
            var resource = PayPalResource.ConfigureAndExecute<Payment>(apiContext, HttpMethod.POST, resourcePath, payment.ConvertToJson());
            resource.token = resource.GetTokenFromApprovalUrl();
            return resource;
        }

        /// <summary>
        /// Obtain the Payment resource for the given identifier.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <param name="paymentId">Identifier of the Payment Resource to obtain the data for.</param>
        /// <returns>Payment</returns>
        public static Payment Get(APIContext apiContext, string paymentId)
        {
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);
            ArgumentValidator.Validate(paymentId, "paymentId");

            // Configure and send the request
            var pattern = "v1/payments/payment/{0}";
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] { paymentId });
            return PayPalResource.ConfigureAndExecute<Payment>(apiContext, HttpMethod.GET, resourcePath);
        }

        /// <summary>
        /// Partially update the Payment resource for the given identifier
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <param name="patchRequest">PatchRequest</param>
        public void Update(APIContext apiContext, PatchRequest patchRequest)
        {
            Payment.Update(apiContext, this.id, patchRequest);
        }

        /// <summary>
        /// Partially update the Payment resource for the given identifier
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <param name="paymentId">ID of the payment to update.</param>
        /// <param name="patchRequest">PatchRequest</param>
        public static void Update(APIContext apiContext, string paymentId, PatchRequest patchRequest)
        {
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);
            ArgumentValidator.Validate(paymentId, "paymentId");
            ArgumentValidator.Validate(patchRequest, "patchRequest");

            // Configure and send the request
            var pattern = "v1/payments/payment/{0}";
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] { paymentId });
            PayPalResource.ConfigureAndExecute(apiContext, HttpMethod.PATCH, resourcePath, patchRequest.ConvertToJson());
        }

        /// <summary>
        /// Executes the payment (after approved by the Payer) associated with this resource when the payment method is PayPal.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <param name="paymentExecution">PaymentExecution</param>
        /// <returns>Payment</returns>
        public Payment Execute(APIContext apiContext, PaymentExecution paymentExecution)
        {
            return Payment.Execute(apiContext, this.id, paymentExecution);
        }

        /// <summary>
        /// Executes the payment (after approved by the Payer) associated with this resource when the payment method is PayPal.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <param name="paymentId">ID of the payment to execute.</param>
        /// <param name="paymentExecution">PaymentExecution</param>
        /// <returns>Payment</returns>
        public static Payment Execute(APIContext apiContext, string paymentId, PaymentExecution paymentExecution)
        {
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);
            ArgumentValidator.Validate(paymentId, "paymentId");
            ArgumentValidator.Validate(paymentExecution, "paymentExecution");

            // Configure and send the request
            var pattern = "v1/payments/payment/{0}/execute";
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] { paymentId });
            return PayPalResource.ConfigureAndExecute<Payment>(apiContext, HttpMethod.POST, resourcePath, paymentExecution.ConvertToJson());
        }

        /// <summary>
        /// Retrieves a list of payments.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <param name="count">Number of items to be returned by a GET operation.</param>
        /// <param name="startId">A resource ID that indicates the starting resource in the returned results.</param>
        /// <param name="startIndex">Start index of the resources to be returned. Typically used to jump to a specific position in the resource history based on it's cart.</param>
        /// <param name="startTime">Resource creation time that indicates the start of a range of results.</param>
        /// <param name="endTime">Resource creation time that indicates the end of a range of results.</param>
        /// <param name="startDate">Resource creation date that indicates the start of results.</param>
        /// <param name="endDate">Resource creation date that indicates the end of a range of results.</param>
        /// <param name="payeeEmail">Payee identifier (email) to filter the search results in list operations.</param>
        /// <param name="payeeId">Payee identifier (merchant id) assigned by PayPal to filter the search results in list operations.</param>
        /// <param name="sortBy">Field name that determines sort order of results.</param>
        /// <param name="sortOrder">Specifies if order of results is ascending or descending.</param>
        /// <returns>PaymentHistory</returns>
        public static PaymentHistory List(APIContext apiContext, int? count = null, string startId = "", int? startIndex = null, string startTime = "", string endTime = "", string startDate = "", string endDate = "", string payeeEmail = "", string payeeId = "", string sortBy = "", string sortOrder = "")
        {
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);

            var queryParameters = new QueryParameters();
            queryParameters["count"] = count.ToString();
            queryParameters["start_id"] = startId;
            queryParameters["start_index"] = startIndex.ToString();
            queryParameters["start_time"] = startTime;
            queryParameters["end_time"] = endTime;
            queryParameters["start_date"] = startDate;
            queryParameters["end_date"] = endDate;
            queryParameters["payee_email"] = payeeEmail;
            queryParameters["payee_id"] = payeeId;
            queryParameters["sort_by"] = sortBy;
            queryParameters["sort_order"] = sortOrder;

            // Configure and send the request
            var resourcePath = "v1/payments/payment" + queryParameters.ToUrlFormattedString();
            return PayPalResource.ConfigureAndExecute<PaymentHistory>(apiContext, HttpMethod.GET, resourcePath);
        }
    }
}