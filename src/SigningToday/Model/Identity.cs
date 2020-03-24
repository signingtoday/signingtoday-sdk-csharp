/* 
 * Signing Today API
 *
 * *Signing Today* enables seamless integration of digital signatures into any website by the use of easy requests to our API. This is the smart way of adding digital signature support with a great user experience.   *Signing Today APIs* use HTTP methods and are RESTful based, moreover they are protected by a *server to server authentication* standard by the use of tokens.   *Signing Today APIs* can be used in these environments:   | Environment | Description | Endpoint | | - -- -- -- -- -- | - -- -- -- -- -- | - -- -- -- - | | Sandbox     | Test environment | `https://sandbox.signingtoday.com` | | Live        | Production environment | `https://api.signingtoday.com` |   For every single request to Signing Today has to be defined the following *HTTP* header: - `Authorization`, which contains the authentication token.  If the request has a body than another *HTTP* header is requested: - `Content-Type`, with `application/json` value.   Follows an example of usage to enumerate all the user of *my-org* organization.  **Example**  ```json $ curl https://sandbox.signingtoday.com/api/v1/my-org/users \\     -H 'Authorization: Token <access-token>' ```  ## HTTP methods used  APIs use the right HTTP verb in every situation.  | Method   | Description                    | | - -- -- -- - | - -- -- -- -- -- -- -- -- -- -- -- -- -- -- - | | `GET`    | Request data from a resource   | | `POST`   | Send data to create a resource | | `PUT`    | Update a resource              | | `PATCH`  | Partially update a resource    | | `DELETE` | Delete a resourse              |   ## Response definition  All the response are in JSON format. As response to a request of all users of an organization you will have a result like this:  ```json {     \"pagination\": {       \"count\": 75,       \"previous\": \"https://sandbox.signingtoday.com/api/v1/my-org/users?page=1\",       \"next\": \"https://sandbox.signingtoday.com/api/v1/my-org/users?page=3\",       \"pages\": 8,       \"page\": 2     },     \"meta\": {       \"code\": 200     },     \"data\": [       {         \"id\": \"jdo\",         \"status\": \"enabled\",         \"type\": \"Basic user account\",         \"email\": johndoe@dummyemail.com,         \"first_name\": \"John\",         \"last_name\": \"Doe\",         \"wallet\": [],         \"created_by\": \"system\",         \"owner\": false,         \"automatic\": false,         \"rao\": false       },       ...     ]   } ```  The JSON of the response is made of three parts: - Pagination - Meta - Data  ### Pagination  *Pagination* object allows to split the response into parts and then to rebuild it sequentially by the use of `next` and `previous` parameters, by which you get previous and following blocks. The *Pagination* is present only if the response is a list of objects.  The general structure of *Pagination* object is the following:  ```json {     \"pagination\": {       \"count\": 75,       \"previous\": \"https://sandbox.signingtoday.com/api/v1/my-org/users?page=1\",       \"next\": \"https://sandbox.signingtoday.com/api/v1/my-org/users?page=3\",       \"pages\": 8,       \"page\": 2     },     ...   } ```  ### Meta  *Meta* object is used to enrich the information about the response. In the previous example, a successful case of response, *Meta* will have value `status: 2XX`. In case of unsuccessful response, *Meta* will have further information, as follows:  ```json {     \"meta\": {       \"code\": <HTTP STATUS CODE>,       \"error_type\": <STATUS CODE DESCRIPTION>,       \"error_message\": <ERROR DESCRIPTION>     }   } ```  ### Data  *Data* object outputs as object or list of them. Contains the expected data as requested to the API.  ## Search filters  Search filters of the API have the following structure:  `where_ATTRIBUTENAME`=`VALUE`  In this way you make a case-sensitive search of *VALUE*. You can extend it through the Django lookup, obtaining more specific filters. For example:  `where_ATTRIBUTENAME__LOOKUP`=`VALUE`  where *LOOKUP* can be replaced with `icontains` to have a partial insensitive research, where  `where_first_name__icontains`=`CHa`  matches with every user that have the *cha* string in their name, with no differences between capital and lower cases.  [Here](https://docs.djangoproject.com/en/1.11/ref/models/querysets/#field-lookups) the list of the lookups.  ## Webhooks  Signing Today supports webhooks for the update of DSTs and identities status. You can choose if to use or not webhooks and if you want to receive updates about DSTs and/or identities. You can configurate it on application token level, in the *webhook* field, as follows:  ```json \"webhooks\": {   \"dst\": \"URL\",   \"identity\": \"URL\"   } ```  ### DSTs status update  DSTs send the following status updates: - **DST_STATUS_CHANGED**: whenever the DST changes its status - **SIGNATURE_STATUS_CHANGED**: whenever one of the signatures changes its status  #### DST_STATUS_CHANGED  Sends the following information:  ```json {     \"message\": \"DST_STATUS_CHANGED\",     \"data\": {       \"status\": \"<DST_STATUS>\",       \"dst\": \"<DST_ID>\",       \"reason\": \"<DST_REASON>\"     }   } ```  #### SIGNATURE_STATUS_CHANGED  Sends the following information:  ```json {     \"message\": \"SIGNATURE_STATUS_CHANGED\",     \"data\": {       \"status\": \"<SIGNATURE_STATUS>\",       \"group\": <MEMBERSHIP_GROUP_INDEX>,       \"dst\": {         \"id\": \"<DST_ID>\",         \"title\": \"<DST_TITLE>\"       },       \"signature\": \"<SIGNATURE_ID>\",       \"signer\": \"<SIGNER_USERNAME>\",       \"position\": \"<SIGNATURE_POSITION>\",       \"document\": {         \"display_name\": \"<DOCUMENT_TITLE>\",         \"id\": \"<DOCUMENT_ID>\",         \"order\": <DOCUMENT_INDEX>       },       \"automatic\": <DECLARES_IF_THE_SIGNER_IS_AUTOMATIC>,       \"page\": \"<SIGNATURE_PAGE>\"     }   } ```  ### Identities status update  Identities send the following status updates: - **IDENTITY_REQUEST_ENROLLED**: whenever an identity request is activated  #### IDENTITY_REQUEST_ENROLLED  Sends the following information:  ```json {     \"message\": \"IDENTITY_REQUEST_ENROLLED\",     \"data\": {       \"status\": \"<REQUEST_STATUS>\",       \"request\": \"<REQUEST_ID>\",       \"user\": \"<APPLICANT_USERNAME>\"     }   } ```  ### Urlback  Sometimes may be necessary to make a redirect after an user, from the signature tray, has completed his operations or activated a certificate.  If set, redirects could happen in 3 cases: - after a signature or decline - after a DST has been signed by all the signers or canceled - after the activation of a certificate  In the first two cases the urlback returns the following information through a data form: - **dst-id**: id of the DST - **dst-url**: signature_ticket of the signature - **dst-status**: current status of the DST - **dst-signature-id**: id of the signature - **dst-signature-status**: current status of the signature - **user**: username of the signer - **decline-reason**: in case of a refused DST contains the reason of the decline  In the last case the urlback returns the following information through a data form: - **user**: username of the user activated the certificate - **identity-provider**: the provider has been used to issue the certificate - **identity-request-id**: id of the enrollment request - **identity-id**: id of the new identity - **identity-label**: the label assigned to the identity - **identity-certificate**: public key of the certificate   
 *
 * The version of the OpenAPI document: 1.5.0
 * Contact: smartcloud@bit4id.com
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = SigningToday.Client.OpenAPIDateConverter;

namespace SigningToday.Model
{
    /// <summary>
    /// The Identity is the core object of SigningToday, because inside it there are all the information that allows an user to sign a digital signature transaction. Of course the most important information is the cerficate, which is a base64 string in PEM format. This allows to sign documents with a legal validity. The Identity has as well an expiration date, a status, which may be simply active, error, in case of problems during its emission either if the certificate has been somehow altered, or pending if the enrollment procedure has to be completed (the following steps are indicated in the &#39;next&#39; field as well). Also there are information about the provider issued the Identity and fields with an url value that allows to send one time passwords or to sign digital signature transactions. 
    /// </summary>
    [DataContract]
    public partial class Identity :  IEquatable<Identity>, IValidatableObject
    {
        /// <summary>
        /// Identity status which can be one of the following. When an identity request is send, the identity is created and the status is **pending** until the provider dont&#39;approve the request. Then status of the identity changes to **active**. If for some reason an error occurs during the process, or after that, the status will be **error** 
        /// </summary>
        /// <value>Identity status which can be one of the following. When an identity request is send, the identity is created and the status is **pending** until the provider dont&#39;approve the request. Then status of the identity changes to **active**. If for some reason an error occurs during the process, or after that, the status will be **error** </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusEnum
        {
            /// <summary>
            /// Enum Pending for value: pending
            /// </summary>
            [EnumMember(Value = "pending")]
            Pending = 1,

            /// <summary>
            /// Enum Active for value: active
            /// </summary>
            [EnumMember(Value = "active")]
            Active = 2,

            /// <summary>
            /// Enum Error for value: error
            /// </summary>
            [EnumMember(Value = "error")]
            Error = 3

        }

        /// <summary>
        /// Identity status which can be one of the following. When an identity request is send, the identity is created and the status is **pending** until the provider dont&#39;approve the request. Then status of the identity changes to **active**. If for some reason an error occurs during the process, or after that, the status will be **error** 
        /// </summary>
        /// <value>Identity status which can be one of the following. When an identity request is send, the identity is created and the status is **pending** until the provider dont&#39;approve the request. Then status of the identity changes to **active**. If for some reason an error occurs during the process, or after that, the status will be **error** </value>
        [DataMember(Name="status", EmitDefaultValue=false)]
        public StatusEnum? Status { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Identity" /> class.
        /// </summary>
        /// <param name="id">The uuid code that identifies the Identity.</param>
        /// <param name="certificate">The X.509 certificate in PEM format of the Identity.</param>
        /// <param name="notAfter">Deadline of the Identity, expressed in ISO format.</param>
        /// <param name="status">Identity status which can be one of the following. When an identity request is send, the identity is created and the status is **pending** until the provider dont&#39;approve the request. Then status of the identity changes to **active**. If for some reason an error occurs during the process, or after that, the status will be **error** .</param>
        /// <param name="next">The next step to complete the activation procedure.</param>
        /// <param name="actions">actions.</param>
        /// <param name="provider">The name of the provider that issued the certificate for the Identity.</param>
        /// <param name="label">The label is an arbitrary name is possible to associate to an idenity. Doing so allows to distinguish different identities issued from the same provider during the performance of the signature in the signature tray.</param>
        /// <param name="signatureAppearanceUri">This is the url to the image that will be impressed on the document after the performance of the signature .</param>
        /// <param name="providerId">_provider_id_ is the univocal name of the provider that issued the identity .</param>
        /// <param name="providerType">Type of the provider. The most usual type is **cloud** .</param>
        /// <param name="providerData">Data of the provider that issued the certificate, it is variable from provider to provider.</param>
        /// <param name="providerImage">This is the logo of the provider that issued the identity.</param>
        /// <param name="sendOtpUrl">The url to send a one time password to the user which the identity is associated.</param>
        /// <param name="signUrl">The url to sign a document of a digital signature transaction.</param>
        /// <param name="hasBeenImported">If the Identity has been imported from another pre-existing Identity the has_been_imported field is set to **true**.</param>
        public Identity(Guid id = default(Guid), string certificate = default(string), string notAfter = default(string), StatusEnum? status = default(StatusEnum?), string next = default(string), IdentityActions actions = default(IdentityActions), string provider = default(string), string label = default(string), string signatureAppearanceUri = default(string), Guid providerId = default(Guid), string providerType = default(string), Object providerData = default(Object), string providerImage = default(string), string sendOtpUrl = default(string), string signUrl = default(string), bool hasBeenImported = default(bool))
        {
            this.Id = id;
            this.Certificate = certificate;
            this.NotAfter = notAfter;
            this.Status = status;
            this.Next = next;
            this.Actions = actions;
            this.Provider = provider;
            this.Label = label;
            this.SignatureAppearanceUri = signatureAppearanceUri;
            this.ProviderId = providerId;
            this.ProviderType = providerType;
            this.ProviderData = providerData;
            this.ProviderImage = providerImage;
            this.SendOtpUrl = sendOtpUrl;
            this.SignUrl = signUrl;
            this.HasBeenImported = hasBeenImported;
        }
        
        /// <summary>
        /// The uuid code that identifies the Identity
        /// </summary>
        /// <value>The uuid code that identifies the Identity</value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public Guid Id { get; set; }

        /// <summary>
        /// The X.509 certificate in PEM format of the Identity
        /// </summary>
        /// <value>The X.509 certificate in PEM format of the Identity</value>
        [DataMember(Name="certificate", EmitDefaultValue=false)]
        public string Certificate { get; set; }

        /// <summary>
        /// Deadline of the Identity, expressed in ISO format
        /// </summary>
        /// <value>Deadline of the Identity, expressed in ISO format</value>
        [DataMember(Name="not_after", EmitDefaultValue=false)]
        public string NotAfter { get; set; }


        /// <summary>
        /// The next step to complete the activation procedure
        /// </summary>
        /// <value>The next step to complete the activation procedure</value>
        [DataMember(Name="next", EmitDefaultValue=false)]
        public string Next { get; set; }

        /// <summary>
        /// Gets or Sets Actions
        /// </summary>
        [DataMember(Name="actions", EmitDefaultValue=false)]
        public IdentityActions Actions { get; set; }

        /// <summary>
        /// The name of the provider that issued the certificate for the Identity
        /// </summary>
        /// <value>The name of the provider that issued the certificate for the Identity</value>
        [DataMember(Name="provider", EmitDefaultValue=false)]
        public string Provider { get; set; }

        /// <summary>
        /// The label is an arbitrary name is possible to associate to an idenity. Doing so allows to distinguish different identities issued from the same provider during the performance of the signature in the signature tray
        /// </summary>
        /// <value>The label is an arbitrary name is possible to associate to an idenity. Doing so allows to distinguish different identities issued from the same provider during the performance of the signature in the signature tray</value>
        [DataMember(Name="label", EmitDefaultValue=false)]
        public string Label { get; set; }

        /// <summary>
        /// This is the url to the image that will be impressed on the document after the performance of the signature 
        /// </summary>
        /// <value>This is the url to the image that will be impressed on the document after the performance of the signature </value>
        [DataMember(Name="signature_appearance_uri", EmitDefaultValue=false)]
        public string SignatureAppearanceUri { get; set; }

        /// <summary>
        /// _provider_id_ is the univocal name of the provider that issued the identity 
        /// </summary>
        /// <value>_provider_id_ is the univocal name of the provider that issued the identity </value>
        [DataMember(Name="provider_id", EmitDefaultValue=false)]
        public Guid ProviderId { get; set; }

        /// <summary>
        /// Type of the provider. The most usual type is **cloud** 
        /// </summary>
        /// <value>Type of the provider. The most usual type is **cloud** </value>
        [DataMember(Name="provider_type", EmitDefaultValue=false)]
        public string ProviderType { get; set; }

        /// <summary>
        /// Data of the provider that issued the certificate, it is variable from provider to provider
        /// </summary>
        /// <value>Data of the provider that issued the certificate, it is variable from provider to provider</value>
        [DataMember(Name="provider_data", EmitDefaultValue=false)]
        public Object ProviderData { get; set; }

        /// <summary>
        /// This is the logo of the provider that issued the identity
        /// </summary>
        /// <value>This is the logo of the provider that issued the identity</value>
        [DataMember(Name="provider_image", EmitDefaultValue=false)]
        public string ProviderImage { get; set; }

        /// <summary>
        /// The url to send a one time password to the user which the identity is associated
        /// </summary>
        /// <value>The url to send a one time password to the user which the identity is associated</value>
        [DataMember(Name="send_otp_url", EmitDefaultValue=false)]
        public string SendOtpUrl { get; set; }

        /// <summary>
        /// The url to sign a document of a digital signature transaction
        /// </summary>
        /// <value>The url to sign a document of a digital signature transaction</value>
        [DataMember(Name="sign_url", EmitDefaultValue=false)]
        public string SignUrl { get; set; }

        /// <summary>
        /// If the Identity has been imported from another pre-existing Identity the has_been_imported field is set to **true**
        /// </summary>
        /// <value>If the Identity has been imported from another pre-existing Identity the has_been_imported field is set to **true**</value>
        [DataMember(Name="has_been_imported", EmitDefaultValue=false)]
        public bool HasBeenImported { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Identity {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Certificate: ").Append(Certificate).Append("\n");
            sb.Append("  NotAfter: ").Append(NotAfter).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  Next: ").Append(Next).Append("\n");
            sb.Append("  Actions: ").Append(Actions).Append("\n");
            sb.Append("  Provider: ").Append(Provider).Append("\n");
            sb.Append("  Label: ").Append(Label).Append("\n");
            sb.Append("  SignatureAppearanceUri: ").Append(SignatureAppearanceUri).Append("\n");
            sb.Append("  ProviderId: ").Append(ProviderId).Append("\n");
            sb.Append("  ProviderType: ").Append(ProviderType).Append("\n");
            sb.Append("  ProviderData: ").Append(ProviderData).Append("\n");
            sb.Append("  ProviderImage: ").Append(ProviderImage).Append("\n");
            sb.Append("  SendOtpUrl: ").Append(SendOtpUrl).Append("\n");
            sb.Append("  SignUrl: ").Append(SignUrl).Append("\n");
            sb.Append("  HasBeenImported: ").Append(HasBeenImported).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as Identity);
        }

        /// <summary>
        /// Returns true if Identity instances are equal
        /// </summary>
        /// <param name="input">Instance of Identity to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Identity input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.Certificate == input.Certificate ||
                    (this.Certificate != null &&
                    this.Certificate.Equals(input.Certificate))
                ) && 
                (
                    this.NotAfter == input.NotAfter ||
                    (this.NotAfter != null &&
                    this.NotAfter.Equals(input.NotAfter))
                ) && 
                (
                    this.Status == input.Status ||
                    (this.Status != null &&
                    this.Status.Equals(input.Status))
                ) && 
                (
                    this.Next == input.Next ||
                    (this.Next != null &&
                    this.Next.Equals(input.Next))
                ) && 
                (
                    this.Actions == input.Actions ||
                    (this.Actions != null &&
                    this.Actions.Equals(input.Actions))
                ) && 
                (
                    this.Provider == input.Provider ||
                    (this.Provider != null &&
                    this.Provider.Equals(input.Provider))
                ) && 
                (
                    this.Label == input.Label ||
                    (this.Label != null &&
                    this.Label.Equals(input.Label))
                ) && 
                (
                    this.SignatureAppearanceUri == input.SignatureAppearanceUri ||
                    (this.SignatureAppearanceUri != null &&
                    this.SignatureAppearanceUri.Equals(input.SignatureAppearanceUri))
                ) && 
                (
                    this.ProviderId == input.ProviderId ||
                    (this.ProviderId != null &&
                    this.ProviderId.Equals(input.ProviderId))
                ) && 
                (
                    this.ProviderType == input.ProviderType ||
                    (this.ProviderType != null &&
                    this.ProviderType.Equals(input.ProviderType))
                ) && 
                (
                    this.ProviderData == input.ProviderData ||
                    (this.ProviderData != null &&
                    this.ProviderData.Equals(input.ProviderData))
                ) && 
                (
                    this.ProviderImage == input.ProviderImage ||
                    (this.ProviderImage != null &&
                    this.ProviderImage.Equals(input.ProviderImage))
                ) && 
                (
                    this.SendOtpUrl == input.SendOtpUrl ||
                    (this.SendOtpUrl != null &&
                    this.SendOtpUrl.Equals(input.SendOtpUrl))
                ) && 
                (
                    this.SignUrl == input.SignUrl ||
                    (this.SignUrl != null &&
                    this.SignUrl.Equals(input.SignUrl))
                ) && 
                (
                    this.HasBeenImported == input.HasBeenImported ||
                    (this.HasBeenImported != null &&
                    this.HasBeenImported.Equals(input.HasBeenImported))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
                if (this.Certificate != null)
                    hashCode = hashCode * 59 + this.Certificate.GetHashCode();
                if (this.NotAfter != null)
                    hashCode = hashCode * 59 + this.NotAfter.GetHashCode();
                if (this.Status != null)
                    hashCode = hashCode * 59 + this.Status.GetHashCode();
                if (this.Next != null)
                    hashCode = hashCode * 59 + this.Next.GetHashCode();
                if (this.Actions != null)
                    hashCode = hashCode * 59 + this.Actions.GetHashCode();
                if (this.Provider != null)
                    hashCode = hashCode * 59 + this.Provider.GetHashCode();
                if (this.Label != null)
                    hashCode = hashCode * 59 + this.Label.GetHashCode();
                if (this.SignatureAppearanceUri != null)
                    hashCode = hashCode * 59 + this.SignatureAppearanceUri.GetHashCode();
                if (this.ProviderId != null)
                    hashCode = hashCode * 59 + this.ProviderId.GetHashCode();
                if (this.ProviderType != null)
                    hashCode = hashCode * 59 + this.ProviderType.GetHashCode();
                if (this.ProviderData != null)
                    hashCode = hashCode * 59 + this.ProviderData.GetHashCode();
                if (this.ProviderImage != null)
                    hashCode = hashCode * 59 + this.ProviderImage.GetHashCode();
                if (this.SendOtpUrl != null)
                    hashCode = hashCode * 59 + this.SendOtpUrl.GetHashCode();
                if (this.SignUrl != null)
                    hashCode = hashCode * 59 + this.SignUrl.GetHashCode();
                if (this.HasBeenImported != null)
                    hashCode = hashCode * 59 + this.HasBeenImported.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
