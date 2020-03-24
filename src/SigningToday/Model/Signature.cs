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
    /// The Signature is an object of SigningToday which contains all the information needed to _digitally sign a document_. This is possible thanks to the cerficate associated to the identity in the wallet of the user is going to perform the signature. The _profile_ field of the Signature object specifies the modality of signature is going to be performed, and can be:   - _PADES_ :     - allows to exclusively sign a pdf file with the signature     directly affixed into the document;   - _CADES_ :     - allows to sign different types of documents; the signature     is not \&quot;physically\&quot; into the document but the signature and the file     are placed together in an envelope instead, making thus a _.p7m_     extension.  Consistently to the other objects, the Signature, as well, has a status, which is helpful to understand if the signature has been performed already or not, if it is expired or it is errored due to a miskate during the creation of the digital signature transaction or the performing of the signature itself. 
    /// </summary>
    [DataContract]
    public partial class Signature :  IEquatable<Signature>, IValidatableObject
    {
        /// <summary>
        /// The status of the Signature. As the digital signature transaction is created the status of the Signature is _waiting_, if everything is legit than the status changes to _pending_, otherwise to _error_. Once the Signature is made the status changes to _performed_. If the DST expires before the Signature is performed then the status changes to _expired_
        /// </summary>
        /// <value>The status of the Signature. As the digital signature transaction is created the status of the Signature is _waiting_, if everything is legit than the status changes to _pending_, otherwise to _error_. Once the Signature is made the status changes to _performed_. If the DST expires before the Signature is performed then the status changes to _expired_</value>
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
            /// Enum Error for value: error
            /// </summary>
            [EnumMember(Value = "error")]
            Error = 5

        }

        /// <summary>
        /// The status of the Signature. As the digital signature transaction is created the status of the Signature is _waiting_, if everything is legit than the status changes to _pending_, otherwise to _error_. Once the Signature is made the status changes to _performed_. If the DST expires before the Signature is performed then the status changes to _expired_
        /// </summary>
        /// <value>The status of the Signature. As the digital signature transaction is created the status of the Signature is _waiting_, if everything is legit than the status changes to _pending_, otherwise to _error_. Once the Signature is made the status changes to _performed_. If the DST expires before the Signature is performed then the status changes to _expired_</value>
        [DataMember(Name="status", EmitDefaultValue=false)]
        public StatusEnum? Status { get; set; }
        /// <summary>
        /// The _profile_ field of the Signature object specifies the modality of signature is going to be performed, and can be:   - _PADES_ : allows to exclusively sign a pdf file with the signature     directly affixed into the document;   - _CADES_ : allows to sign different types of documents; the signature     is not \&quot;physically\&quot; into the document but the signature and the file     are placed together in an envelope instead, making thus a .p7m extension. 
        /// </summary>
        /// <value>The _profile_ field of the Signature object specifies the modality of signature is going to be performed, and can be:   - _PADES_ : allows to exclusively sign a pdf file with the signature     directly affixed into the document;   - _CADES_ : allows to sign different types of documents; the signature     is not \&quot;physically\&quot; into the document but the signature and the file     are placed together in an envelope instead, making thus a .p7m extension. </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ProfileEnum
        {
            /// <summary>
            /// Enum PadesBes for value: pades-bes
            /// </summary>
            [EnumMember(Value = "pades-bes")]
            PadesBes = 1,

            /// <summary>
            /// Enum PadesT for value: pades-t
            /// </summary>
            [EnumMember(Value = "pades-t")]
            PadesT = 2,

            /// <summary>
            /// Enum CadesBes for value: cades-bes
            /// </summary>
            [EnumMember(Value = "cades-bes")]
            CadesBes = 3,

            /// <summary>
            /// Enum CadesT for value: cades-t
            /// </summary>
            [EnumMember(Value = "cades-t")]
            CadesT = 4

        }

        /// <summary>
        /// The _profile_ field of the Signature object specifies the modality of signature is going to be performed, and can be:   - _PADES_ : allows to exclusively sign a pdf file with the signature     directly affixed into the document;   - _CADES_ : allows to sign different types of documents; the signature     is not \&quot;physically\&quot; into the document but the signature and the file     are placed together in an envelope instead, making thus a .p7m extension. 
        /// </summary>
        /// <value>The _profile_ field of the Signature object specifies the modality of signature is going to be performed, and can be:   - _PADES_ : allows to exclusively sign a pdf file with the signature     directly affixed into the document;   - _CADES_ : allows to sign different types of documents; the signature     is not \&quot;physically\&quot; into the document but the signature and the file     are placed together in an envelope instead, making thus a .p7m extension. </value>
        [DataMember(Name="profile", EmitDefaultValue=false)]
        public ProfileEnum? Profile { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Signature" /> class.
        /// </summary>
        /// <param name="id">The uuid code that identifies the Signature.</param>
        /// <param name="signer">The user that have to sign the digital signature transaction.</param>
        /// <param name="signerGroup">The group which the signer belongs. This field is used in the scenario of a digital signature transaction that has multiple signatures to be performed, where the signers belongs to the same group. Let&#39;s think to the group _\&quot;teachers\&quot;_ of a school. Thus is possible to add the _signer_group_ _\&quot;teachers\&quot;_ as signers of the digital signature transaction without worrying about who really belong to that group.</param>
        /// <param name="signatureTicket">This is the url where a signature tray is predisposed for a specific signer that have to sign a specific digital signature transaction. It is possible to set the signature tray language by the use of the **locate** query string - e.g. *?locate&#x3D;en* .</param>
        /// <param name="automatic">If true indicates that the signer is an _automatic_ one, thus the signature procedure will be different from a regular signer.</param>
        /// <param name="declineUrl">This is the url to decline a digital signature transaction.</param>
        /// <param name="descriptionHtml">This is a _html_ description to attach with the Signature.</param>
        /// <param name="status">The status of the Signature. As the digital signature transaction is created the status of the Signature is _waiting_, if everything is legit than the status changes to _pending_, otherwise to _error_. Once the Signature is made the status changes to _performed_. If the DST expires before the Signature is performed then the status changes to _expired_.</param>
        /// <param name="displayName">This is the name will be displayed on the signature tray associated to the Signature has to be performed. Usually is the _full name_ of the user is going to sign.</param>
        /// <param name="profile">The _profile_ field of the Signature object specifies the modality of signature is going to be performed, and can be:   - _PADES_ : allows to exclusively sign a pdf file with the signature     directly affixed into the document;   - _CADES_ : allows to sign different types of documents; the signature     is not \&quot;physically\&quot; into the document but the signature and the file     are placed together in an envelope instead, making thus a .p7m extension. .</param>
        /// <param name="reason">The reason of the Signature, or rather a motivational description associated to the Signature.</param>
        /// <param name="description">This is a simple description to attach with the Signature.</param>
        /// <param name="declinable">If true the signer is able to decline the Signature if he wants to.</param>
        /// <param name="urlback">The url for the redirection from Signature tray when the digital signature transaction is completed or annulled.</param>
        /// <param name="where">where.</param>
        /// <param name="constraints">Particular constraints for the Signature. For example constraints about the _firs tname_ or _last name_ of the certificate associated with the identity is going to sign. The way to use this field is through the _django lookups_, for example:   - \&quot;certificate__subject_givenName__iexact&#x3D;JOHN\&quot; .</param>
        public Signature(Guid id = default(Guid), string signer = default(string), string signerGroup = default(string), string signatureTicket = default(string), bool automatic = default(bool), string declineUrl = default(string), string descriptionHtml = default(string), StatusEnum? status = default(StatusEnum?), string displayName = default(string), ProfileEnum? profile = default(ProfileEnum?), string reason = default(string), string description = default(string), bool declinable = default(bool), string urlback = default(string), SignatureWhere where = default(SignatureWhere), Object constraints = default(Object))
        {
            this.Id = id;
            this.Signer = signer;
            this.SignerGroup = signerGroup;
            this.SignatureTicket = signatureTicket;
            this.Automatic = automatic;
            this.DeclineUrl = declineUrl;
            this.DescriptionHtml = descriptionHtml;
            this.Status = status;
            this.DisplayName = displayName;
            this.Profile = profile;
            this.Reason = reason;
            this.Description = description;
            this.Declinable = declinable;
            this.Urlback = urlback;
            this.Where = where;
            this.Constraints = constraints;
        }
        
        /// <summary>
        /// The uuid code that identifies the Signature
        /// </summary>
        /// <value>The uuid code that identifies the Signature</value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public Guid Id { get; set; }

        /// <summary>
        /// The user that have to sign the digital signature transaction
        /// </summary>
        /// <value>The user that have to sign the digital signature transaction</value>
        [DataMember(Name="signer", EmitDefaultValue=false)]
        public string Signer { get; set; }

        /// <summary>
        /// The group which the signer belongs. This field is used in the scenario of a digital signature transaction that has multiple signatures to be performed, where the signers belongs to the same group. Let&#39;s think to the group _\&quot;teachers\&quot;_ of a school. Thus is possible to add the _signer_group_ _\&quot;teachers\&quot;_ as signers of the digital signature transaction without worrying about who really belong to that group
        /// </summary>
        /// <value>The group which the signer belongs. This field is used in the scenario of a digital signature transaction that has multiple signatures to be performed, where the signers belongs to the same group. Let&#39;s think to the group _\&quot;teachers\&quot;_ of a school. Thus is possible to add the _signer_group_ _\&quot;teachers\&quot;_ as signers of the digital signature transaction without worrying about who really belong to that group</value>
        [DataMember(Name="signer_group", EmitDefaultValue=false)]
        public string SignerGroup { get; set; }

        /// <summary>
        /// This is the url where a signature tray is predisposed for a specific signer that have to sign a specific digital signature transaction. It is possible to set the signature tray language by the use of the **locate** query string - e.g. *?locate&#x3D;en* 
        /// </summary>
        /// <value>This is the url where a signature tray is predisposed for a specific signer that have to sign a specific digital signature transaction. It is possible to set the signature tray language by the use of the **locate** query string - e.g. *?locate&#x3D;en* </value>
        [DataMember(Name="signature_ticket", EmitDefaultValue=false)]
        public string SignatureTicket { get; set; }

        /// <summary>
        /// If true indicates that the signer is an _automatic_ one, thus the signature procedure will be different from a regular signer
        /// </summary>
        /// <value>If true indicates that the signer is an _automatic_ one, thus the signature procedure will be different from a regular signer</value>
        [DataMember(Name="automatic", EmitDefaultValue=false)]
        public bool Automatic { get; set; }

        /// <summary>
        /// This is the url to decline a digital signature transaction
        /// </summary>
        /// <value>This is the url to decline a digital signature transaction</value>
        [DataMember(Name="decline_url", EmitDefaultValue=false)]
        public string DeclineUrl { get; set; }

        /// <summary>
        /// This is a _html_ description to attach with the Signature
        /// </summary>
        /// <value>This is a _html_ description to attach with the Signature</value>
        [DataMember(Name="description_html", EmitDefaultValue=false)]
        public string DescriptionHtml { get; set; }


        /// <summary>
        /// This is the name will be displayed on the signature tray associated to the Signature has to be performed. Usually is the _full name_ of the user is going to sign
        /// </summary>
        /// <value>This is the name will be displayed on the signature tray associated to the Signature has to be performed. Usually is the _full name_ of the user is going to sign</value>
        [DataMember(Name="display_name", EmitDefaultValue=false)]
        public string DisplayName { get; set; }


        /// <summary>
        /// The reason of the Signature, or rather a motivational description associated to the Signature
        /// </summary>
        /// <value>The reason of the Signature, or rather a motivational description associated to the Signature</value>
        [DataMember(Name="reason", EmitDefaultValue=false)]
        public string Reason { get; set; }

        /// <summary>
        /// This is a simple description to attach with the Signature
        /// </summary>
        /// <value>This is a simple description to attach with the Signature</value>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }

        /// <summary>
        /// If true the signer is able to decline the Signature if he wants to
        /// </summary>
        /// <value>If true the signer is able to decline the Signature if he wants to</value>
        [DataMember(Name="declinable", EmitDefaultValue=false)]
        public bool Declinable { get; set; }

        /// <summary>
        /// The url for the redirection from Signature tray when the digital signature transaction is completed or annulled
        /// </summary>
        /// <value>The url for the redirection from Signature tray when the digital signature transaction is completed or annulled</value>
        [DataMember(Name="urlback", EmitDefaultValue=false)]
        public string Urlback { get; set; }

        /// <summary>
        /// Gets or Sets Where
        /// </summary>
        [DataMember(Name="where", EmitDefaultValue=false)]
        public SignatureWhere Where { get; set; }

        /// <summary>
        /// Particular constraints for the Signature. For example constraints about the _firs tname_ or _last name_ of the certificate associated with the identity is going to sign. The way to use this field is through the _django lookups_, for example:   - \&quot;certificate__subject_givenName__iexact&#x3D;JOHN\&quot; 
        /// </summary>
        /// <value>Particular constraints for the Signature. For example constraints about the _firs tname_ or _last name_ of the certificate associated with the identity is going to sign. The way to use this field is through the _django lookups_, for example:   - \&quot;certificate__subject_givenName__iexact&#x3D;JOHN\&quot; </value>
        [DataMember(Name="constraints", EmitDefaultValue=false)]
        public Object Constraints { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Signature {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Signer: ").Append(Signer).Append("\n");
            sb.Append("  SignerGroup: ").Append(SignerGroup).Append("\n");
            sb.Append("  SignatureTicket: ").Append(SignatureTicket).Append("\n");
            sb.Append("  Automatic: ").Append(Automatic).Append("\n");
            sb.Append("  DeclineUrl: ").Append(DeclineUrl).Append("\n");
            sb.Append("  DescriptionHtml: ").Append(DescriptionHtml).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  Profile: ").Append(Profile).Append("\n");
            sb.Append("  Reason: ").Append(Reason).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Declinable: ").Append(Declinable).Append("\n");
            sb.Append("  Urlback: ").Append(Urlback).Append("\n");
            sb.Append("  Where: ").Append(Where).Append("\n");
            sb.Append("  Constraints: ").Append(Constraints).Append("\n");
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
            return this.Equals(input as Signature);
        }

        /// <summary>
        /// Returns true if Signature instances are equal
        /// </summary>
        /// <param name="input">Instance of Signature to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Signature input)
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
                    this.Signer == input.Signer ||
                    (this.Signer != null &&
                    this.Signer.Equals(input.Signer))
                ) && 
                (
                    this.SignerGroup == input.SignerGroup ||
                    (this.SignerGroup != null &&
                    this.SignerGroup.Equals(input.SignerGroup))
                ) && 
                (
                    this.SignatureTicket == input.SignatureTicket ||
                    (this.SignatureTicket != null &&
                    this.SignatureTicket.Equals(input.SignatureTicket))
                ) && 
                (
                    this.Automatic == input.Automatic ||
                    (this.Automatic != null &&
                    this.Automatic.Equals(input.Automatic))
                ) && 
                (
                    this.DeclineUrl == input.DeclineUrl ||
                    (this.DeclineUrl != null &&
                    this.DeclineUrl.Equals(input.DeclineUrl))
                ) && 
                (
                    this.DescriptionHtml == input.DescriptionHtml ||
                    (this.DescriptionHtml != null &&
                    this.DescriptionHtml.Equals(input.DescriptionHtml))
                ) && 
                (
                    this.Status == input.Status ||
                    (this.Status != null &&
                    this.Status.Equals(input.Status))
                ) && 
                (
                    this.DisplayName == input.DisplayName ||
                    (this.DisplayName != null &&
                    this.DisplayName.Equals(input.DisplayName))
                ) && 
                (
                    this.Profile == input.Profile ||
                    (this.Profile != null &&
                    this.Profile.Equals(input.Profile))
                ) && 
                (
                    this.Reason == input.Reason ||
                    (this.Reason != null &&
                    this.Reason.Equals(input.Reason))
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.Declinable == input.Declinable ||
                    (this.Declinable != null &&
                    this.Declinable.Equals(input.Declinable))
                ) && 
                (
                    this.Urlback == input.Urlback ||
                    (this.Urlback != null &&
                    this.Urlback.Equals(input.Urlback))
                ) && 
                (
                    this.Where == input.Where ||
                    (this.Where != null &&
                    this.Where.Equals(input.Where))
                ) && 
                (
                    this.Constraints == input.Constraints ||
                    (this.Constraints != null &&
                    this.Constraints.Equals(input.Constraints))
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
                if (this.Signer != null)
                    hashCode = hashCode * 59 + this.Signer.GetHashCode();
                if (this.SignerGroup != null)
                    hashCode = hashCode * 59 + this.SignerGroup.GetHashCode();
                if (this.SignatureTicket != null)
                    hashCode = hashCode * 59 + this.SignatureTicket.GetHashCode();
                if (this.Automatic != null)
                    hashCode = hashCode * 59 + this.Automatic.GetHashCode();
                if (this.DeclineUrl != null)
                    hashCode = hashCode * 59 + this.DeclineUrl.GetHashCode();
                if (this.DescriptionHtml != null)
                    hashCode = hashCode * 59 + this.DescriptionHtml.GetHashCode();
                if (this.Status != null)
                    hashCode = hashCode * 59 + this.Status.GetHashCode();
                if (this.DisplayName != null)
                    hashCode = hashCode * 59 + this.DisplayName.GetHashCode();
                if (this.Profile != null)
                    hashCode = hashCode * 59 + this.Profile.GetHashCode();
                if (this.Reason != null)
                    hashCode = hashCode * 59 + this.Reason.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
                if (this.Declinable != null)
                    hashCode = hashCode * 59 + this.Declinable.GetHashCode();
                if (this.Urlback != null)
                    hashCode = hashCode * 59 + this.Urlback.GetHashCode();
                if (this.Where != null)
                    hashCode = hashCode * 59 + this.Where.GetHashCode();
                if (this.Constraints != null)
                    hashCode = hashCode * 59 + this.Constraints.GetHashCode();
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
