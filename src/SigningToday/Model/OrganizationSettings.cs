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
    /// Default settings it is possible to setup for the Organization
    /// </summary>
    [DataContract]
    public partial class OrganizationSettings :  IEquatable<OrganizationSettings>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrganizationSettings" /> class.
        /// </summary>
        /// <param name="defaultRao">This is the default *RAO* user of the Organization. A rao user is the one can associate identities to the other users .</param>
        /// <param name="dstDefaultDays">This is the default deadline before the expiration of a digital signature transaction (default to 3).</param>
        /// <param name="signatureAppearance">This is the url to the default signature appearance will be used for every member of the organization. In the scenario of a user that owns an identity with a signature_appearance will be uset the image associated to the identity rather than the default one .</param>
        public OrganizationSettings(string defaultRao = default(string), int dstDefaultDays = 3, string signatureAppearance = default(string))
        {
            this.DefaultRao = defaultRao;
            // use default value if no "dstDefaultDays" provided
            if (dstDefaultDays == null)
            {
                this.DstDefaultDays = 3;
            }
            else
            {
                this.DstDefaultDays = dstDefaultDays;
            }
            this.SignatureAppearance = signatureAppearance;
        }
        
        /// <summary>
        /// This is the default *RAO* user of the Organization. A rao user is the one can associate identities to the other users 
        /// </summary>
        /// <value>This is the default *RAO* user of the Organization. A rao user is the one can associate identities to the other users </value>
        [DataMember(Name="default_rao", EmitDefaultValue=false)]
        public string DefaultRao { get; set; }

        /// <summary>
        /// This is the default deadline before the expiration of a digital signature transaction
        /// </summary>
        /// <value>This is the default deadline before the expiration of a digital signature transaction</value>
        [DataMember(Name="dst_default_days", EmitDefaultValue=false)]
        public int DstDefaultDays { get; set; }

        /// <summary>
        /// This is the url to the default signature appearance will be used for every member of the organization. In the scenario of a user that owns an identity with a signature_appearance will be uset the image associated to the identity rather than the default one 
        /// </summary>
        /// <value>This is the url to the default signature appearance will be used for every member of the organization. In the scenario of a user that owns an identity with a signature_appearance will be uset the image associated to the identity rather than the default one </value>
        [DataMember(Name="signature_appearance", EmitDefaultValue=false)]
        public string SignatureAppearance { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OrganizationSettings {\n");
            sb.Append("  DefaultRao: ").Append(DefaultRao).Append("\n");
            sb.Append("  DstDefaultDays: ").Append(DstDefaultDays).Append("\n");
            sb.Append("  SignatureAppearance: ").Append(SignatureAppearance).Append("\n");
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
            return this.Equals(input as OrganizationSettings);
        }

        /// <summary>
        /// Returns true if OrganizationSettings instances are equal
        /// </summary>
        /// <param name="input">Instance of OrganizationSettings to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OrganizationSettings input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.DefaultRao == input.DefaultRao ||
                    (this.DefaultRao != null &&
                    this.DefaultRao.Equals(input.DefaultRao))
                ) && 
                (
                    this.DstDefaultDays == input.DstDefaultDays ||
                    (this.DstDefaultDays != null &&
                    this.DstDefaultDays.Equals(input.DstDefaultDays))
                ) && 
                (
                    this.SignatureAppearance == input.SignatureAppearance ||
                    (this.SignatureAppearance != null &&
                    this.SignatureAppearance.Equals(input.SignatureAppearance))
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
                if (this.DefaultRao != null)
                    hashCode = hashCode * 59 + this.DefaultRao.GetHashCode();
                if (this.DstDefaultDays != null)
                    hashCode = hashCode * 59 + this.DstDefaultDays.GetHashCode();
                if (this.SignatureAppearance != null)
                    hashCode = hashCode * 59 + this.SignatureAppearance.GetHashCode();
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
