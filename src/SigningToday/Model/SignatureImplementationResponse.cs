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
    /// SignatureImplementationResponse
    /// </summary>
    [DataContract]
    public partial class SignatureImplementationResponse :  IEquatable<SignatureImplementationResponse>, IValidatableObject
    {
        /// <summary>
        /// Defines SigningTime
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum SigningTimeEnum
        {
            /// <summary>
            /// Enum Pdf for value: pdf
            /// </summary>
            [EnumMember(Value = "pdf")]
            Pdf = 1

        }

        /// <summary>
        /// Gets or Sets SigningTime
        /// </summary>
        [DataMember(Name="signing_time", EmitDefaultValue=false)]
        public SigningTimeEnum? SigningTime { get; set; }
        /// <summary>
        /// Defines PadesSubfilter
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum PadesSubfilterEnum
        {
            /// <summary>
            /// Enum ETSICAdESDetached for value: ETSI.CAdES.detached
            /// </summary>
            [EnumMember(Value = "ETSI.CAdES.detached")]
            ETSICAdESDetached = 1

        }

        /// <summary>
        /// Gets or Sets PadesSubfilter
        /// </summary>
        [DataMember(Name="pades_subfilter", EmitDefaultValue=false)]
        public PadesSubfilterEnum? PadesSubfilter { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="SignatureImplementationResponse" /> class.
        /// </summary>
        /// <param name="profile">profile.</param>
        /// <param name="providerId">providerId.</param>
        /// <param name="position">position.</param>
        /// <param name="group">Number of the groups which the signer belongs during digital signature transaction creation.</param>
        /// <param name="certificate">certificate.</param>
        /// <param name="title">title.</param>
        /// <param name="dst">dst.</param>
        /// <param name="signingTime">signingTime.</param>
        /// <param name="reason">reason.</param>
        /// <param name="channel">channel.</param>
        /// <param name="signatureText">signatureText.</param>
        /// <param name="signature">signature.</param>
        /// <param name="signatureAppearanceUri">signatureAppearanceUri.</param>
        /// <param name="padesSubfilter">padesSubfilter.</param>
        /// <param name="document">document.</param>
        /// <param name="page">page.</param>
        /// <param name="identity">identity.</param>
        public SignatureImplementationResponse(Profile profile = default(Profile), ProviderId providerId = default(ProviderId), Position position = default(Position), int group = default(int), Certificate certificate = default(Certificate), Title title = default(Title), Id dst = default(Id), SigningTimeEnum? signingTime = default(SigningTimeEnum?), Reason reason = default(Reason), SignatureImplementationResponseChannel channel = default(SignatureImplementationResponseChannel), string signatureText = default(string), Id signature = default(Id), SignatureAppearanceUri signatureAppearanceUri = default(SignatureAppearanceUri), PadesSubfilterEnum? padesSubfilter = default(PadesSubfilterEnum?), string document = default(string), int page = default(int), Id identity = default(Id))
        {
            this.Profile = profile;
            this.ProviderId = providerId;
            this.Position = position;
            this.Group = group;
            this.Certificate = certificate;
            this.Title = title;
            this.Dst = dst;
            this.SigningTime = signingTime;
            this.Reason = reason;
            this.Channel = channel;
            this.SignatureText = signatureText;
            this.Signature = signature;
            this.SignatureAppearanceUri = signatureAppearanceUri;
            this.PadesSubfilter = padesSubfilter;
            this.Document = document;
            this.Page = page;
            this.Identity = identity;
        }
        
        /// <summary>
        /// Gets or Sets Profile
        /// </summary>
        [DataMember(Name="profile", EmitDefaultValue=false)]
        public Profile Profile { get; set; }

        /// <summary>
        /// Gets or Sets ProviderId
        /// </summary>
        [DataMember(Name="provider_id", EmitDefaultValue=false)]
        public ProviderId ProviderId { get; set; }

        /// <summary>
        /// Gets or Sets Position
        /// </summary>
        [DataMember(Name="position", EmitDefaultValue=false)]
        public Position Position { get; set; }

        /// <summary>
        /// Number of the groups which the signer belongs during digital signature transaction creation
        /// </summary>
        /// <value>Number of the groups which the signer belongs during digital signature transaction creation</value>
        [DataMember(Name="group", EmitDefaultValue=false)]
        public int Group { get; set; }

        /// <summary>
        /// Gets or Sets Certificate
        /// </summary>
        [DataMember(Name="certificate", EmitDefaultValue=false)]
        public Certificate Certificate { get; set; }

        /// <summary>
        /// Gets or Sets Title
        /// </summary>
        [DataMember(Name="title", EmitDefaultValue=false)]
        public Title Title { get; set; }

        /// <summary>
        /// Gets or Sets Dst
        /// </summary>
        [DataMember(Name="dst", EmitDefaultValue=false)]
        public Id Dst { get; set; }


        /// <summary>
        /// Gets or Sets Reason
        /// </summary>
        [DataMember(Name="reason", EmitDefaultValue=false)]
        public Reason Reason { get; set; }

        /// <summary>
        /// Gets or Sets Channel
        /// </summary>
        [DataMember(Name="channel", EmitDefaultValue=false)]
        public SignatureImplementationResponseChannel Channel { get; set; }

        /// <summary>
        /// Gets or Sets SignatureText
        /// </summary>
        [DataMember(Name="signature_text", EmitDefaultValue=false)]
        public string SignatureText { get; set; }

        /// <summary>
        /// Gets or Sets Signature
        /// </summary>
        [DataMember(Name="signature", EmitDefaultValue=false)]
        public Id Signature { get; set; }

        /// <summary>
        /// Gets or Sets SignatureAppearanceUri
        /// </summary>
        [DataMember(Name="signature_appearance_uri", EmitDefaultValue=false)]
        public SignatureAppearanceUri SignatureAppearanceUri { get; set; }


        /// <summary>
        /// Gets or Sets Document
        /// </summary>
        [DataMember(Name="document", EmitDefaultValue=false)]
        public string Document { get; set; }

        /// <summary>
        /// Gets or Sets Page
        /// </summary>
        [DataMember(Name="page", EmitDefaultValue=false)]
        public int Page { get; set; }

        /// <summary>
        /// Gets or Sets Identity
        /// </summary>
        [DataMember(Name="identity", EmitDefaultValue=false)]
        public Id Identity { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SignatureImplementationResponse {\n");
            sb.Append("  Profile: ").Append(Profile).Append("\n");
            sb.Append("  ProviderId: ").Append(ProviderId).Append("\n");
            sb.Append("  Position: ").Append(Position).Append("\n");
            sb.Append("  Group: ").Append(Group).Append("\n");
            sb.Append("  Certificate: ").Append(Certificate).Append("\n");
            sb.Append("  Title: ").Append(Title).Append("\n");
            sb.Append("  Dst: ").Append(Dst).Append("\n");
            sb.Append("  SigningTime: ").Append(SigningTime).Append("\n");
            sb.Append("  Reason: ").Append(Reason).Append("\n");
            sb.Append("  Channel: ").Append(Channel).Append("\n");
            sb.Append("  SignatureText: ").Append(SignatureText).Append("\n");
            sb.Append("  Signature: ").Append(Signature).Append("\n");
            sb.Append("  SignatureAppearanceUri: ").Append(SignatureAppearanceUri).Append("\n");
            sb.Append("  PadesSubfilter: ").Append(PadesSubfilter).Append("\n");
            sb.Append("  Document: ").Append(Document).Append("\n");
            sb.Append("  Page: ").Append(Page).Append("\n");
            sb.Append("  Identity: ").Append(Identity).Append("\n");
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
            return this.Equals(input as SignatureImplementationResponse);
        }

        /// <summary>
        /// Returns true if SignatureImplementationResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of SignatureImplementationResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SignatureImplementationResponse input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Profile == input.Profile ||
                    (this.Profile != null &&
                    this.Profile.Equals(input.Profile))
                ) && 
                (
                    this.ProviderId == input.ProviderId ||
                    (this.ProviderId != null &&
                    this.ProviderId.Equals(input.ProviderId))
                ) && 
                (
                    this.Position == input.Position ||
                    (this.Position != null &&
                    this.Position.Equals(input.Position))
                ) && 
                (
                    this.Group == input.Group ||
                    (this.Group != null &&
                    this.Group.Equals(input.Group))
                ) && 
                (
                    this.Certificate == input.Certificate ||
                    (this.Certificate != null &&
                    this.Certificate.Equals(input.Certificate))
                ) && 
                (
                    this.Title == input.Title ||
                    (this.Title != null &&
                    this.Title.Equals(input.Title))
                ) && 
                (
                    this.Dst == input.Dst ||
                    (this.Dst != null &&
                    this.Dst.Equals(input.Dst))
                ) && 
                (
                    this.SigningTime == input.SigningTime ||
                    (this.SigningTime != null &&
                    this.SigningTime.Equals(input.SigningTime))
                ) && 
                (
                    this.Reason == input.Reason ||
                    (this.Reason != null &&
                    this.Reason.Equals(input.Reason))
                ) && 
                (
                    this.Channel == input.Channel ||
                    (this.Channel != null &&
                    this.Channel.Equals(input.Channel))
                ) && 
                (
                    this.SignatureText == input.SignatureText ||
                    (this.SignatureText != null &&
                    this.SignatureText.Equals(input.SignatureText))
                ) && 
                (
                    this.Signature == input.Signature ||
                    (this.Signature != null &&
                    this.Signature.Equals(input.Signature))
                ) && 
                (
                    this.SignatureAppearanceUri == input.SignatureAppearanceUri ||
                    (this.SignatureAppearanceUri != null &&
                    this.SignatureAppearanceUri.Equals(input.SignatureAppearanceUri))
                ) && 
                (
                    this.PadesSubfilter == input.PadesSubfilter ||
                    (this.PadesSubfilter != null &&
                    this.PadesSubfilter.Equals(input.PadesSubfilter))
                ) && 
                (
                    this.Document == input.Document ||
                    (this.Document != null &&
                    this.Document.Equals(input.Document))
                ) && 
                (
                    this.Page == input.Page ||
                    (this.Page != null &&
                    this.Page.Equals(input.Page))
                ) && 
                (
                    this.Identity == input.Identity ||
                    (this.Identity != null &&
                    this.Identity.Equals(input.Identity))
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
                if (this.Profile != null)
                    hashCode = hashCode * 59 + this.Profile.GetHashCode();
                if (this.ProviderId != null)
                    hashCode = hashCode * 59 + this.ProviderId.GetHashCode();
                if (this.Position != null)
                    hashCode = hashCode * 59 + this.Position.GetHashCode();
                if (this.Group != null)
                    hashCode = hashCode * 59 + this.Group.GetHashCode();
                if (this.Certificate != null)
                    hashCode = hashCode * 59 + this.Certificate.GetHashCode();
                if (this.Title != null)
                    hashCode = hashCode * 59 + this.Title.GetHashCode();
                if (this.Dst != null)
                    hashCode = hashCode * 59 + this.Dst.GetHashCode();
                if (this.SigningTime != null)
                    hashCode = hashCode * 59 + this.SigningTime.GetHashCode();
                if (this.Reason != null)
                    hashCode = hashCode * 59 + this.Reason.GetHashCode();
                if (this.Channel != null)
                    hashCode = hashCode * 59 + this.Channel.GetHashCode();
                if (this.SignatureText != null)
                    hashCode = hashCode * 59 + this.SignatureText.GetHashCode();
                if (this.Signature != null)
                    hashCode = hashCode * 59 + this.Signature.GetHashCode();
                if (this.SignatureAppearanceUri != null)
                    hashCode = hashCode * 59 + this.SignatureAppearanceUri.GetHashCode();
                if (this.PadesSubfilter != null)
                    hashCode = hashCode * 59 + this.PadesSubfilter.GetHashCode();
                if (this.Document != null)
                    hashCode = hashCode * 59 + this.Document.GetHashCode();
                if (this.Page != null)
                    hashCode = hashCode * 59 + this.Page.GetHashCode();
                if (this.Identity != null)
                    hashCode = hashCode * 59 + this.Identity.GetHashCode();
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
