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
    /// The Digital Signature Transaction is the object that makes possible a flow of signatures of one or more documents happen. Once there is an organization with some users, it is possible to create a dst through the definition of the document or the documents have to be signed, the signer or, eventually, the signers, grouping them, in this way it is possible to decide the order of the signatories will be followed. The status of the DST is _pending_ until all the signers have signed. Once that happens the status will change to _performed_. 
    /// </summary>
    [DataContract]
    public partial class SignatureTransaction :  IEquatable<SignatureTransaction>, IValidatableObject
    {
        /// <summary>
        /// The Digital Signature Transaction may have the following statuses:   - &#x60;waiting&#x60;: Not all the documents has ben uploaded and validated yet   - &#x60;pending&#x60;: The DST is ready to be signed   - &#x60;performed&#x60;: The DST has been signed by all the signers   - &#x60;expired&#x60;: The DST expired before all the signers have signed it   - &#x60;cancelled&#x60;: The DST has been canceled; the motivation is in the reason 
        /// </summary>
        /// <value>The Digital Signature Transaction may have the following statuses:   - &#x60;waiting&#x60;: Not all the documents has ben uploaded and validated yet   - &#x60;pending&#x60;: The DST is ready to be signed   - &#x60;performed&#x60;: The DST has been signed by all the signers   - &#x60;expired&#x60;: The DST expired before all the signers have signed it   - &#x60;cancelled&#x60;: The DST has been canceled; the motivation is in the reason </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusEnum
        {
            /// <summary>
            /// Enum Waiting for value: waiting
            /// </summary>
            [EnumMember(Value = "waiting")]
            Waiting = 1,

            /// <summary>
            /// Enum Pending for value: pending
            /// </summary>
            [EnumMember(Value = "pending")]
            Pending = 2,

            /// <summary>
            /// Enum Performed for value: performed
            /// </summary>
            [EnumMember(Value = "performed")]
            Performed = 3,

            /// <summary>
            /// Enum Expired for value: expired
            /// </summary>
            [EnumMember(Value = "expired")]
            Expired = 4,

            /// <summary>
            /// Enum Cancelled for value: cancelled
            /// </summary>
            [EnumMember(Value = "cancelled")]
            Cancelled = 5

        }

        /// <summary>
        /// The Digital Signature Transaction may have the following statuses:   - &#x60;waiting&#x60;: Not all the documents has ben uploaded and validated yet   - &#x60;pending&#x60;: The DST is ready to be signed   - &#x60;performed&#x60;: The DST has been signed by all the signers   - &#x60;expired&#x60;: The DST expired before all the signers have signed it   - &#x60;cancelled&#x60;: The DST has been canceled; the motivation is in the reason 
        /// </summary>
        /// <value>The Digital Signature Transaction may have the following statuses:   - &#x60;waiting&#x60;: Not all the documents has ben uploaded and validated yet   - &#x60;pending&#x60;: The DST is ready to be signed   - &#x60;performed&#x60;: The DST has been signed by all the signers   - &#x60;expired&#x60;: The DST expired before all the signers have signed it   - &#x60;cancelled&#x60;: The DST has been canceled; the motivation is in the reason </value>
        [DataMember(Name="status", EmitDefaultValue=false)]
        public StatusEnum? Status { get; set; }
        /// <summary>
        /// The motivations for the cancellation may be:   - &#x60;CANNOT_DOWNLOAD_DOCUMENT&#x60;: Signing Today could not download the     document   - &#x60;INVALID_DOCUMENT&#x60;: The downloaded document is not valid   - &#x60;PROTECTED_DOCUMENT&#x60;: The document is protected by password   - &#x60;declined&#x60;: One of the documents has been refused   - &#x60;MOTIVAZIONE_ESPLICITA&#x60;: Rejected from the system with a custom     reason 
        /// </summary>
        /// <value>The motivations for the cancellation may be:   - &#x60;CANNOT_DOWNLOAD_DOCUMENT&#x60;: Signing Today could not download the     document   - &#x60;INVALID_DOCUMENT&#x60;: The downloaded document is not valid   - &#x60;PROTECTED_DOCUMENT&#x60;: The document is protected by password   - &#x60;declined&#x60;: One of the documents has been refused   - &#x60;MOTIVAZIONE_ESPLICITA&#x60;: Rejected from the system with a custom     reason </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ReasonEnum
        {
            /// <summary>
            /// Enum CANNOTDOWNLOADDOCUMENT for value: CANNOT_DOWNLOAD_DOCUMENT
            /// </summary>
            [EnumMember(Value = "CANNOT_DOWNLOAD_DOCUMENT")]
            CANNOTDOWNLOADDOCUMENT = 1,

            /// <summary>
            /// Enum INVALIDDOCUMENT for value: INVALID_DOCUMENT
            /// </summary>
            [EnumMember(Value = "INVALID_DOCUMENT")]
            INVALIDDOCUMENT = 2,

            /// <summary>
            /// Enum PROTECTEDDOCUMENT for value: PROTECTED_DOCUMENT
            /// </summary>
            [EnumMember(Value = "PROTECTED_DOCUMENT")]
            PROTECTEDDOCUMENT = 3,

            /// <summary>
            /// Enum Declined for value: declined
            /// </summary>
            [EnumMember(Value = "declined")]
            Declined = 4,

            /// <summary>
            /// Enum MOTIVAZIONEESPLICITA for value: MOTIVAZIONE_ESPLICITA
            /// </summary>
            [EnumMember(Value = "MOTIVAZIONE_ESPLICITA")]
            MOTIVAZIONEESPLICITA = 5

        }

        /// <summary>
        /// The motivations for the cancellation may be:   - &#x60;CANNOT_DOWNLOAD_DOCUMENT&#x60;: Signing Today could not download the     document   - &#x60;INVALID_DOCUMENT&#x60;: The downloaded document is not valid   - &#x60;PROTECTED_DOCUMENT&#x60;: The document is protected by password   - &#x60;declined&#x60;: One of the documents has been refused   - &#x60;MOTIVAZIONE_ESPLICITA&#x60;: Rejected from the system with a custom     reason 
        /// </summary>
        /// <value>The motivations for the cancellation may be:   - &#x60;CANNOT_DOWNLOAD_DOCUMENT&#x60;: Signing Today could not download the     document   - &#x60;INVALID_DOCUMENT&#x60;: The downloaded document is not valid   - &#x60;PROTECTED_DOCUMENT&#x60;: The document is protected by password   - &#x60;declined&#x60;: One of the documents has been refused   - &#x60;MOTIVAZIONE_ESPLICITA&#x60;: Rejected from the system with a custom     reason </value>
        [DataMember(Name="reason", EmitDefaultValue=false)]
        public ReasonEnum? Reason { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="SignatureTransaction" /> class.
        /// </summary>
        /// <param name="id">The uuid code that identifies the Digital Signature Transaction.</param>
        /// <param name="documents">The _documents_ field is an array containing document objects, where everyone of them is defined as follows .</param>
        /// <param name="archived">True if the DST&#39;s resources has been deleted (default to false).</param>
        /// <param name="createdBy">The user created the Digital Signature Transaction.</param>
        /// <param name="status">The Digital Signature Transaction may have the following statuses:   - &#x60;waiting&#x60;: Not all the documents has ben uploaded and validated yet   - &#x60;pending&#x60;: The DST is ready to be signed   - &#x60;performed&#x60;: The DST has been signed by all the signers   - &#x60;expired&#x60;: The DST expired before all the signers have signed it   - &#x60;cancelled&#x60;: The DST has been canceled; the motivation is in the reason .</param>
        /// <param name="created">Date of creation of the Digital Signature Transaction.</param>
        /// <param name="reason">The motivations for the cancellation may be:   - &#x60;CANNOT_DOWNLOAD_DOCUMENT&#x60;: Signing Today could not download the     document   - &#x60;INVALID_DOCUMENT&#x60;: The downloaded document is not valid   - &#x60;PROTECTED_DOCUMENT&#x60;: The document is protected by password   - &#x60;declined&#x60;: One of the documents has been refused   - &#x60;MOTIVAZIONE_ESPLICITA&#x60;: Rejected from the system with a custom     reason .</param>
        /// <param name="title">Title of the Digital Signature Transaction.</param>
        /// <param name="notAfter">Deadline of the Digital Signature Transaction, expressed in ISO format.</param>
        /// <param name="urlback">The url for the redirection from signature tray when the Digital Signature Transaction is completed or refused.</param>
        /// <param name="cancelback">If set, in the signature tray will be displayed a button that needs to go back to a third part application.</param>
        /// <param name="templateName">A label to indicate the template used to create the Digital Signature Transaction.</param>
        public SignatureTransaction(Guid id = default(Guid), List<Document> documents = default(List<Document>), bool archived = false, string createdBy = default(string), StatusEnum? status = default(StatusEnum?), string created = default(string), ReasonEnum? reason = default(ReasonEnum?), string title = default(string), string notAfter = default(string), string urlback = default(string), string cancelback = default(string), string templateName = default(string))
        {
            this.Id = id;
            this.Documents = documents;
            // use default value if no "archived" provided
            if (archived == null)
            {
                this.Archived = false;
            }
            else
            {
                this.Archived = archived;
            }
            this.CreatedBy = createdBy;
            this.Status = status;
            this.Created = created;
            this.Reason = reason;
            this.Title = title;
            this.NotAfter = notAfter;
            this.Urlback = urlback;
            this.Cancelback = cancelback;
            this.TemplateName = templateName;
        }
        
        /// <summary>
        /// The uuid code that identifies the Digital Signature Transaction
        /// </summary>
        /// <value>The uuid code that identifies the Digital Signature Transaction</value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public Guid Id { get; set; }

        /// <summary>
        /// The _documents_ field is an array containing document objects, where everyone of them is defined as follows 
        /// </summary>
        /// <value>The _documents_ field is an array containing document objects, where everyone of them is defined as follows </value>
        [DataMember(Name="documents", EmitDefaultValue=false)]
        public List<Document> Documents { get; set; }

        /// <summary>
        /// True if the DST&#39;s resources has been deleted
        /// </summary>
        /// <value>True if the DST&#39;s resources has been deleted</value>
        [DataMember(Name="archived", EmitDefaultValue=false)]
        public bool Archived { get; set; }

        /// <summary>
        /// The user created the Digital Signature Transaction
        /// </summary>
        /// <value>The user created the Digital Signature Transaction</value>
        [DataMember(Name="created_by", EmitDefaultValue=false)]
        public string CreatedBy { get; set; }


        /// <summary>
        /// Date of creation of the Digital Signature Transaction
        /// </summary>
        /// <value>Date of creation of the Digital Signature Transaction</value>
        [DataMember(Name="created", EmitDefaultValue=false)]
        public string Created { get; set; }


        /// <summary>
        /// Title of the Digital Signature Transaction
        /// </summary>
        /// <value>Title of the Digital Signature Transaction</value>
        [DataMember(Name="title", EmitDefaultValue=false)]
        public string Title { get; set; }

        /// <summary>
        /// Deadline of the Digital Signature Transaction, expressed in ISO format
        /// </summary>
        /// <value>Deadline of the Digital Signature Transaction, expressed in ISO format</value>
        [DataMember(Name="not_after", EmitDefaultValue=false)]
        public string NotAfter { get; set; }

        /// <summary>
        /// The url for the redirection from signature tray when the Digital Signature Transaction is completed or refused
        /// </summary>
        /// <value>The url for the redirection from signature tray when the Digital Signature Transaction is completed or refused</value>
        [DataMember(Name="urlback", EmitDefaultValue=false)]
        public string Urlback { get; set; }

        /// <summary>
        /// If set, in the signature tray will be displayed a button that needs to go back to a third part application
        /// </summary>
        /// <value>If set, in the signature tray will be displayed a button that needs to go back to a third part application</value>
        [DataMember(Name="cancelback", EmitDefaultValue=false)]
        public string Cancelback { get; set; }

        /// <summary>
        /// A label to indicate the template used to create the Digital Signature Transaction
        /// </summary>
        /// <value>A label to indicate the template used to create the Digital Signature Transaction</value>
        [DataMember(Name="template_name", EmitDefaultValue=false)]
        public string TemplateName { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SignatureTransaction {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Documents: ").Append(Documents).Append("\n");
            sb.Append("  Archived: ").Append(Archived).Append("\n");
            sb.Append("  CreatedBy: ").Append(CreatedBy).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  Created: ").Append(Created).Append("\n");
            sb.Append("  Reason: ").Append(Reason).Append("\n");
            sb.Append("  Title: ").Append(Title).Append("\n");
            sb.Append("  NotAfter: ").Append(NotAfter).Append("\n");
            sb.Append("  Urlback: ").Append(Urlback).Append("\n");
            sb.Append("  Cancelback: ").Append(Cancelback).Append("\n");
            sb.Append("  TemplateName: ").Append(TemplateName).Append("\n");
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
            return this.Equals(input as SignatureTransaction);
        }

        /// <summary>
        /// Returns true if SignatureTransaction instances are equal
        /// </summary>
        /// <param name="input">Instance of SignatureTransaction to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SignatureTransaction input)
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
                    this.Documents == input.Documents ||
                    this.Documents != null &&
                    input.Documents != null &&
                    this.Documents.SequenceEqual(input.Documents)
                ) && 
                (
                    this.Archived == input.Archived ||
                    (this.Archived != null &&
                    this.Archived.Equals(input.Archived))
                ) && 
                (
                    this.CreatedBy == input.CreatedBy ||
                    (this.CreatedBy != null &&
                    this.CreatedBy.Equals(input.CreatedBy))
                ) && 
                (
                    this.Status == input.Status ||
                    (this.Status != null &&
                    this.Status.Equals(input.Status))
                ) && 
                (
                    this.Created == input.Created ||
                    (this.Created != null &&
                    this.Created.Equals(input.Created))
                ) && 
                (
                    this.Reason == input.Reason ||
                    (this.Reason != null &&
                    this.Reason.Equals(input.Reason))
                ) && 
                (
                    this.Title == input.Title ||
                    (this.Title != null &&
                    this.Title.Equals(input.Title))
                ) && 
                (
                    this.NotAfter == input.NotAfter ||
                    (this.NotAfter != null &&
                    this.NotAfter.Equals(input.NotAfter))
                ) && 
                (
                    this.Urlback == input.Urlback ||
                    (this.Urlback != null &&
                    this.Urlback.Equals(input.Urlback))
                ) && 
                (
                    this.Cancelback == input.Cancelback ||
                    (this.Cancelback != null &&
                    this.Cancelback.Equals(input.Cancelback))
                ) && 
                (
                    this.TemplateName == input.TemplateName ||
                    (this.TemplateName != null &&
                    this.TemplateName.Equals(input.TemplateName))
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
                if (this.Documents != null)
                    hashCode = hashCode * 59 + this.Documents.GetHashCode();
                if (this.Archived != null)
                    hashCode = hashCode * 59 + this.Archived.GetHashCode();
                if (this.CreatedBy != null)
                    hashCode = hashCode * 59 + this.CreatedBy.GetHashCode();
                if (this.Status != null)
                    hashCode = hashCode * 59 + this.Status.GetHashCode();
                if (this.Created != null)
                    hashCode = hashCode * 59 + this.Created.GetHashCode();
                if (this.Reason != null)
                    hashCode = hashCode * 59 + this.Reason.GetHashCode();
                if (this.Title != null)
                    hashCode = hashCode * 59 + this.Title.GetHashCode();
                if (this.NotAfter != null)
                    hashCode = hashCode * 59 + this.NotAfter.GetHashCode();
                if (this.Urlback != null)
                    hashCode = hashCode * 59 + this.Urlback.GetHashCode();
                if (this.Cancelback != null)
                    hashCode = hashCode * 59 + this.Cancelback.GetHashCode();
                if (this.TemplateName != null)
                    hashCode = hashCode * 59 + this.TemplateName.GetHashCode();
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
