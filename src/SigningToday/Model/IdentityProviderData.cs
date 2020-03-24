/* 
 * Signing Today Web
 *
 * *Signing Today* is the perfect Digital Signature Gateway. Whenever in Your workflow You need to add one or more Digital Signatures to Your document, *Signing Today* is the right choice. You prepare Your documents, *Signing Today* takes care of all the rest: send invitations (`signature tickets`) to signers, collects their signatures, send You back the signed document. Integrating *Signing Today* in Your existing applications is very easy. Just follow these API specifications and get inspired by the many examples presented hereafter. 
 *
 * The version of the OpenAPI document: 2.0.0
 * 
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
    /// IdentityProviderData
    /// </summary>
    [DataContract]
    public partial class IdentityProviderData :  IEquatable<IdentityProviderData>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IdentityProviderData" /> class.
        /// </summary>
        /// <param name="smartcardID">smartcardID.</param>
        /// <param name="middlewareID">middlewareID.</param>
        /// <param name="aTR">aTR.</param>
        /// <param name="tokenInfo">tokenInfo.</param>
        /// <param name="reader">reader.</param>
        public IdentityProviderData(decimal smartcardID = default(decimal), string middlewareID = default(string), string aTR = default(string), IdentityProviderDataTokenInfo tokenInfo = default(IdentityProviderDataTokenInfo), string reader = default(string))
        {
            this.SmartcardID = smartcardID;
            this.MiddlewareID = middlewareID;
            this.ATR = aTR;
            this.TokenInfo = tokenInfo;
            this.Reader = reader;
        }
        
        /// <summary>
        /// Gets or Sets SmartcardID
        /// </summary>
        [DataMember(Name="smartcardID", EmitDefaultValue=false)]
        public decimal SmartcardID { get; set; }

        /// <summary>
        /// Gets or Sets MiddlewareID
        /// </summary>
        [DataMember(Name="middlewareID", EmitDefaultValue=false)]
        public string MiddlewareID { get; set; }

        /// <summary>
        /// Gets or Sets ATR
        /// </summary>
        [DataMember(Name="ATR", EmitDefaultValue=false)]
        public string ATR { get; set; }

        /// <summary>
        /// Gets or Sets TokenInfo
        /// </summary>
        [DataMember(Name="tokenInfo", EmitDefaultValue=false)]
        public IdentityProviderDataTokenInfo TokenInfo { get; set; }

        /// <summary>
        /// Gets or Sets Reader
        /// </summary>
        [DataMember(Name="reader", EmitDefaultValue=false)]
        public string Reader { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class IdentityProviderData {\n");
            sb.Append("  SmartcardID: ").Append(SmartcardID).Append("\n");
            sb.Append("  MiddlewareID: ").Append(MiddlewareID).Append("\n");
            sb.Append("  ATR: ").Append(ATR).Append("\n");
            sb.Append("  TokenInfo: ").Append(TokenInfo).Append("\n");
            sb.Append("  Reader: ").Append(Reader).Append("\n");
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
            return this.Equals(input as IdentityProviderData);
        }

        /// <summary>
        /// Returns true if IdentityProviderData instances are equal
        /// </summary>
        /// <param name="input">Instance of IdentityProviderData to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(IdentityProviderData input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.SmartcardID == input.SmartcardID ||
                    (this.SmartcardID != null &&
                    this.SmartcardID.Equals(input.SmartcardID))
                ) && 
                (
                    this.MiddlewareID == input.MiddlewareID ||
                    (this.MiddlewareID != null &&
                    this.MiddlewareID.Equals(input.MiddlewareID))
                ) && 
                (
                    this.ATR == input.ATR ||
                    (this.ATR != null &&
                    this.ATR.Equals(input.ATR))
                ) && 
                (
                    this.TokenInfo == input.TokenInfo ||
                    (this.TokenInfo != null &&
                    this.TokenInfo.Equals(input.TokenInfo))
                ) && 
                (
                    this.Reader == input.Reader ||
                    (this.Reader != null &&
                    this.Reader.Equals(input.Reader))
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
                if (this.SmartcardID != null)
                    hashCode = hashCode * 59 + this.SmartcardID.GetHashCode();
                if (this.MiddlewareID != null)
                    hashCode = hashCode * 59 + this.MiddlewareID.GetHashCode();
                if (this.ATR != null)
                    hashCode = hashCode * 59 + this.ATR.GetHashCode();
                if (this.TokenInfo != null)
                    hashCode = hashCode * 59 + this.TokenInfo.GetHashCode();
                if (this.Reader != null)
                    hashCode = hashCode * 59 + this.Reader.GetHashCode();
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
