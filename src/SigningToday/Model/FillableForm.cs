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
    /// Two type of fillable exists; &#x60;SignatureForm&#x60; and &#x60;TextForm&#x60;. The former represents the association with the SignatureRequest, the latter represents any editable text form field to be filled before the signature process begins.
    /// </summary>
    [DataContract]
    public partial class FillableForm :  IEquatable<FillableForm>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FillableForm" /> class.
        /// </summary>
        /// <param name="id">Id of the _form_.</param>
        /// <param name="documentId">Id of the document.</param>
        /// <param name="type">Type of the fill form.</param>
        /// <param name="positionX">Position onto the X axis of the form, expressed in percentage.</param>
        /// <param name="positionY">Position onto the Y axis of the form, expressed in percentage.</param>
        /// <param name="width">Width of the form expressed in percentage.</param>
        /// <param name="height">Height of the form expressed in percentage.</param>
        /// <param name="page">Page of the document where the form is.</param>
        /// <param name="signerId">Id of the signer in the sign plan.</param>
        /// <param name="toFill">**True** if the field need to be filled by the user. In case of a Signature it is **false** .</param>
        /// <param name="filled">True ones the form has been filled.</param>
        /// <param name="invisible">True if the appearance has to be hidden.</param>
        /// <param name="extraData">Extra information about the form.</param>
        public FillableForm(int id = default(int), int documentId = default(int), string type = default(string), float positionX = default(float), float positionY = default(float), float width = default(float), float height = default(float), long page = default(long), int signerId = default(int), bool toFill = default(bool), bool filled = default(bool), bool invisible = default(bool), Dictionary<string, Object> extraData = default(Dictionary<string, Object>))
        {
            this.Id = id;
            this.DocumentId = documentId;
            this.Type = type;
            this.PositionX = positionX;
            this.PositionY = positionY;
            this.Width = width;
            this.Height = height;
            this.Page = page;
            this.SignerId = signerId;
            this.ToFill = toFill;
            this.Filled = filled;
            this.Invisible = invisible;
            this.ExtraData = extraData;
        }
        
        /// <summary>
        /// It is a reference for internal use
        /// </summary>
        /// <value>It is a reference for internal use</value>
        [DataMember(Name="_instance_id", EmitDefaultValue=false)]
        public long InstanceId { get; private set; }

        /// <summary>
        /// Id of the _form_
        /// </summary>
        /// <value>Id of the _form_</value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public int Id { get; set; }

        /// <summary>
        /// Id of the document
        /// </summary>
        /// <value>Id of the document</value>
        [DataMember(Name="documentId", EmitDefaultValue=false)]
        public int DocumentId { get; set; }

        /// <summary>
        /// Type of the fill form
        /// </summary>
        /// <value>Type of the fill form</value>
        [DataMember(Name="type", EmitDefaultValue=false)]
        public string Type { get; set; }

        /// <summary>
        /// Position onto the X axis of the form, expressed in percentage
        /// </summary>
        /// <value>Position onto the X axis of the form, expressed in percentage</value>
        [DataMember(Name="positionX", EmitDefaultValue=false)]
        public float PositionX { get; set; }

        /// <summary>
        /// Position onto the Y axis of the form, expressed in percentage
        /// </summary>
        /// <value>Position onto the Y axis of the form, expressed in percentage</value>
        [DataMember(Name="positionY", EmitDefaultValue=false)]
        public float PositionY { get; set; }

        /// <summary>
        /// Width of the form expressed in percentage
        /// </summary>
        /// <value>Width of the form expressed in percentage</value>
        [DataMember(Name="width", EmitDefaultValue=false)]
        public float Width { get; set; }

        /// <summary>
        /// Height of the form expressed in percentage
        /// </summary>
        /// <value>Height of the form expressed in percentage</value>
        [DataMember(Name="height", EmitDefaultValue=false)]
        public float Height { get; set; }

        /// <summary>
        /// Page of the document where the form is
        /// </summary>
        /// <value>Page of the document where the form is</value>
        [DataMember(Name="page", EmitDefaultValue=false)]
        public long Page { get; set; }

        /// <summary>
        /// Id of the signer in the sign plan
        /// </summary>
        /// <value>Id of the signer in the sign plan</value>
        [DataMember(Name="signerId", EmitDefaultValue=false)]
        public int SignerId { get; set; }

        /// <summary>
        /// **True** if the field need to be filled by the user. In case of a Signature it is **false** 
        /// </summary>
        /// <value>**True** if the field need to be filled by the user. In case of a Signature it is **false** </value>
        [DataMember(Name="toFill", EmitDefaultValue=false)]
        public bool ToFill { get; set; }

        /// <summary>
        /// True ones the form has been filled
        /// </summary>
        /// <value>True ones the form has been filled</value>
        [DataMember(Name="filled", EmitDefaultValue=false)]
        public bool Filled { get; set; }

        /// <summary>
        /// True if the appearance has to be hidden
        /// </summary>
        /// <value>True if the appearance has to be hidden</value>
        [DataMember(Name="invisible", EmitDefaultValue=false)]
        public bool Invisible { get; set; }

        /// <summary>
        /// Extra information about the form
        /// </summary>
        /// <value>Extra information about the form</value>
        [DataMember(Name="extraData", EmitDefaultValue=false)]
        public Dictionary<string, Object> ExtraData { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FillableForm {\n");
            sb.Append("  InstanceId: ").Append(InstanceId).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  DocumentId: ").Append(DocumentId).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  PositionX: ").Append(PositionX).Append("\n");
            sb.Append("  PositionY: ").Append(PositionY).Append("\n");
            sb.Append("  Width: ").Append(Width).Append("\n");
            sb.Append("  Height: ").Append(Height).Append("\n");
            sb.Append("  Page: ").Append(Page).Append("\n");
            sb.Append("  SignerId: ").Append(SignerId).Append("\n");
            sb.Append("  ToFill: ").Append(ToFill).Append("\n");
            sb.Append("  Filled: ").Append(Filled).Append("\n");
            sb.Append("  Invisible: ").Append(Invisible).Append("\n");
            sb.Append("  ExtraData: ").Append(ExtraData).Append("\n");
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
            return this.Equals(input as FillableForm);
        }

        /// <summary>
        /// Returns true if FillableForm instances are equal
        /// </summary>
        /// <param name="input">Instance of FillableForm to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FillableForm input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.InstanceId == input.InstanceId ||
                    (this.InstanceId != null &&
                    this.InstanceId.Equals(input.InstanceId))
                ) && 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.DocumentId == input.DocumentId ||
                    (this.DocumentId != null &&
                    this.DocumentId.Equals(input.DocumentId))
                ) && 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
                ) && 
                (
                    this.PositionX == input.PositionX ||
                    (this.PositionX != null &&
                    this.PositionX.Equals(input.PositionX))
                ) && 
                (
                    this.PositionY == input.PositionY ||
                    (this.PositionY != null &&
                    this.PositionY.Equals(input.PositionY))
                ) && 
                (
                    this.Width == input.Width ||
                    (this.Width != null &&
                    this.Width.Equals(input.Width))
                ) && 
                (
                    this.Height == input.Height ||
                    (this.Height != null &&
                    this.Height.Equals(input.Height))
                ) && 
                (
                    this.Page == input.Page ||
                    (this.Page != null &&
                    this.Page.Equals(input.Page))
                ) && 
                (
                    this.SignerId == input.SignerId ||
                    (this.SignerId != null &&
                    this.SignerId.Equals(input.SignerId))
                ) && 
                (
                    this.ToFill == input.ToFill ||
                    (this.ToFill != null &&
                    this.ToFill.Equals(input.ToFill))
                ) && 
                (
                    this.Filled == input.Filled ||
                    (this.Filled != null &&
                    this.Filled.Equals(input.Filled))
                ) && 
                (
                    this.Invisible == input.Invisible ||
                    (this.Invisible != null &&
                    this.Invisible.Equals(input.Invisible))
                ) && 
                (
                    this.ExtraData == input.ExtraData ||
                    this.ExtraData != null &&
                    input.ExtraData != null &&
                    this.ExtraData.SequenceEqual(input.ExtraData)
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
                if (this.InstanceId != null)
                    hashCode = hashCode * 59 + this.InstanceId.GetHashCode();
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
                if (this.DocumentId != null)
                    hashCode = hashCode * 59 + this.DocumentId.GetHashCode();
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
                if (this.PositionX != null)
                    hashCode = hashCode * 59 + this.PositionX.GetHashCode();
                if (this.PositionY != null)
                    hashCode = hashCode * 59 + this.PositionY.GetHashCode();
                if (this.Width != null)
                    hashCode = hashCode * 59 + this.Width.GetHashCode();
                if (this.Height != null)
                    hashCode = hashCode * 59 + this.Height.GetHashCode();
                if (this.Page != null)
                    hashCode = hashCode * 59 + this.Page.GetHashCode();
                if (this.SignerId != null)
                    hashCode = hashCode * 59 + this.SignerId.GetHashCode();
                if (this.ToFill != null)
                    hashCode = hashCode * 59 + this.ToFill.GetHashCode();
                if (this.Filled != null)
                    hashCode = hashCode * 59 + this.Filled.GetHashCode();
                if (this.Invisible != null)
                    hashCode = hashCode * 59 + this.Invisible.GetHashCode();
                if (this.ExtraData != null)
                    hashCode = hashCode * 59 + this.ExtraData.GetHashCode();
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