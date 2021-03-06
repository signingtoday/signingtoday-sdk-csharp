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
    /// SignatureStatusChangedNotificationDocument
    /// </summary>
    [DataContract]
    public partial class SignatureStatusChangedNotificationDocument :  IEquatable<SignatureStatusChangedNotificationDocument>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SignatureStatusChangedNotificationDocument" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected SignatureStatusChangedNotificationDocument() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="SignatureStatusChangedNotificationDocument" /> class.
        /// </summary>
        /// <param name="displayName">displayName (required).</param>
        /// <param name="id">id (required).</param>
        /// <param name="order">order (required).</param>
        public SignatureStatusChangedNotificationDocument(string displayName = default(string), int id = default(int), int order = default(int))
        {
            // to ensure "displayName" is required (not null)
            if (displayName == null)
            {
                throw new InvalidDataException("displayName is a required property for SignatureStatusChangedNotificationDocument and cannot be null");
            }
            else
            {
                this.DisplayName = displayName;
            }
            
            // to ensure "id" is required (not null)
            if (id == null)
            {
                throw new InvalidDataException("id is a required property for SignatureStatusChangedNotificationDocument and cannot be null");
            }
            else
            {
                this.Id = id;
            }
            
            // to ensure "order" is required (not null)
            if (order == null)
            {
                throw new InvalidDataException("order is a required property for SignatureStatusChangedNotificationDocument and cannot be null");
            }
            else
            {
                this.Order = order;
            }
            
        }
        
        /// <summary>
        /// Gets or Sets DisplayName
        /// </summary>
        [DataMember(Name="display_name", EmitDefaultValue=false)]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets Order
        /// </summary>
        [DataMember(Name="order", EmitDefaultValue=false)]
        public int Order { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SignatureStatusChangedNotificationDocument {\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Order: ").Append(Order).Append("\n");
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
            return this.Equals(input as SignatureStatusChangedNotificationDocument);
        }

        /// <summary>
        /// Returns true if SignatureStatusChangedNotificationDocument instances are equal
        /// </summary>
        /// <param name="input">Instance of SignatureStatusChangedNotificationDocument to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SignatureStatusChangedNotificationDocument input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.DisplayName == input.DisplayName ||
                    (this.DisplayName != null &&
                    this.DisplayName.Equals(input.DisplayName))
                ) && 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.Order == input.Order ||
                    (this.Order != null &&
                    this.Order.Equals(input.Order))
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
                if (this.DisplayName != null)
                    hashCode = hashCode * 59 + this.DisplayName.GetHashCode();
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
                if (this.Order != null)
                    hashCode = hashCode * 59 + this.Order.GetHashCode();
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
