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
    /// SignatureDST
    /// </summary>
    [DataContract]
    public partial class SignatureDST :  IEquatable<SignatureDST>, IValidatableObject
    {
        /// <summary>
        /// The _profile_ field of the Signature object specifies the modality of signature is going to be performed, and can be:   - _PADES_ :     - allows to exclusively sign a pdf file with the signature     directly affixed into the document;   - _CADES_ :     - allows to sign different types of documents; the signature     is not \&quot;physically\&quot; into the document but the signature and the file     are placed together in an envelope instead, making thus a _.p7m_     extension. 
        /// </summary>
        /// <value>The _profile_ field of the Signature object specifies the modality of signature is going to be performed, and can be:   - _PADES_ :     - allows to exclusively sign a pdf file with the signature     directly affixed into the document;   - _CADES_ :     - allows to sign different types of documents; the signature     is not \&quot;physically\&quot; into the document but the signature and the file     are placed together in an envelope instead, making thus a _.p7m_     extension. </value>
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
        /// The _profile_ field of the Signature object specifies the modality of signature is going to be performed, and can be:   - _PADES_ :     - allows to exclusively sign a pdf file with the signature     directly affixed into the document;   - _CADES_ :     - allows to sign different types of documents; the signature     is not \&quot;physically\&quot; into the document but the signature and the file     are placed together in an envelope instead, making thus a _.p7m_     extension. 
        /// </summary>
        /// <value>The _profile_ field of the Signature object specifies the modality of signature is going to be performed, and can be:   - _PADES_ :     - allows to exclusively sign a pdf file with the signature     directly affixed into the document;   - _CADES_ :     - allows to sign different types of documents; the signature     is not \&quot;physically\&quot; into the document but the signature and the file     are placed together in an envelope instead, making thus a _.p7m_     extension. </value>
        [DataMember(Name="profile", EmitDefaultValue=false)]
        public ProfileEnum? Profile { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="SignatureDST" /> class.
        /// </summary>
        /// <param name="declinable">If true the signer is able to decline the Signature if he wants to.</param>
        /// <param name="profile">The _profile_ field of the Signature object specifies the modality of signature is going to be performed, and can be:   - _PADES_ :     - allows to exclusively sign a pdf file with the signature     directly affixed into the document;   - _CADES_ :     - allows to sign different types of documents; the signature     is not \&quot;physically\&quot; into the document but the signature and the file     are placed together in an envelope instead, making thus a _.p7m_     extension. .</param>
        /// <param name="displayName">This is the name will be displayed on the signature tray associated to the Signature has to be performed. Usually is the _full name_ of the user is going to sign.</param>
        /// <param name="reason">The reason of the Signature, or rather a motivational description associated to the Signature.</param>
        /// <param name="signer">The user that have to sign the digital signature transaction.</param>
        /// <param name="description">This is a simple description to attach with the Signature.</param>
        /// <param name="urlback">The url for the redirection from Signature tray when the digital signature transaction is completed or annulled.</param>
        /// <param name="where">where.</param>
        /// <param name="constraints">Particular constraints for the Signature. For example constraints about the _firs tname_ or _last name_ of the certificate associated with the identity is going to sign. The way to use this field is through the _django lookups_, for example:   - \&quot;certificate__subject_givenName__iexact&#x3D;JOHN\&quot; .</param>
        public SignatureDST(bool declinable = default(bool), ProfileEnum? profile = default(ProfileEnum?), string displayName = default(string), string reason = default(string), string signer = default(string), string description = default(string), string urlback = default(string), SignatureDSTWhere where = default(SignatureDSTWhere), Object constraints = default(Object))
        {
            this.Declinable = declinable;
            this.Profile = profile;
            this.DisplayName = displayName;
            this.Reason = reason;
            this.Signer = signer;
            this.Description = description;
            this.Urlback = urlback;
            this.Where = where;
            this.Constraints = constraints;
        }
        
        /// <summary>
        /// If true the signer is able to decline the Signature if he wants to
        /// </summary>
        /// <value>If true the signer is able to decline the Signature if he wants to</value>
        [DataMember(Name="declinable", EmitDefaultValue=false)]
        public bool Declinable { get; set; }


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
        /// The user that have to sign the digital signature transaction
        /// </summary>
        /// <value>The user that have to sign the digital signature transaction</value>
        [DataMember(Name="signer", EmitDefaultValue=false)]
        public string Signer { get; set; }

        /// <summary>
        /// This is a simple description to attach with the Signature
        /// </summary>
        /// <value>This is a simple description to attach with the Signature</value>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }

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
        public SignatureDSTWhere Where { get; set; }

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
            sb.Append("class SignatureDST {\n");
            sb.Append("  Declinable: ").Append(Declinable).Append("\n");
            sb.Append("  Profile: ").Append(Profile).Append("\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  Reason: ").Append(Reason).Append("\n");
            sb.Append("  Signer: ").Append(Signer).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
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
            return this.Equals(input as SignatureDST);
        }

        /// <summary>
        /// Returns true if SignatureDST instances are equal
        /// </summary>
        /// <param name="input">Instance of SignatureDST to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SignatureDST input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Declinable == input.Declinable ||
                    (this.Declinable != null &&
                    this.Declinable.Equals(input.Declinable))
                ) && 
                (
                    this.Profile == input.Profile ||
                    (this.Profile != null &&
                    this.Profile.Equals(input.Profile))
                ) && 
                (
                    this.DisplayName == input.DisplayName ||
                    (this.DisplayName != null &&
                    this.DisplayName.Equals(input.DisplayName))
                ) && 
                (
                    this.Reason == input.Reason ||
                    (this.Reason != null &&
                    this.Reason.Equals(input.Reason))
                ) && 
                (
                    this.Signer == input.Signer ||
                    (this.Signer != null &&
                    this.Signer.Equals(input.Signer))
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
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
                if (this.Declinable != null)
                    hashCode = hashCode * 59 + this.Declinable.GetHashCode();
                if (this.Profile != null)
                    hashCode = hashCode * 59 + this.Profile.GetHashCode();
                if (this.DisplayName != null)
                    hashCode = hashCode * 59 + this.DisplayName.GetHashCode();
                if (this.Reason != null)
                    hashCode = hashCode * 59 + this.Reason.GetHashCode();
                if (this.Signer != null)
                    hashCode = hashCode * 59 + this.Signer.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
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
