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
    /// Organization
    /// </summary>
    [DataContract]
    public partial class Organization :  IEquatable<Organization>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Organization" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="emailOverrideFolderPath">emailOverrideFolderPath.</param>
        /// <param name="name">name.</param>
        /// <param name="contactEmail">contactEmail.</param>
        /// <param name="contactPhone">contactPhone.</param>
        /// <param name="nation">nation.</param>
        /// <param name="city">city.</param>
        /// <param name="privateSettings">privateSettings.</param>
        /// <param name="publicSettings">publicSettings.</param>
        /// <param name="settings">settings.</param>
        public Organization(string id = default(string), string emailOverrideFolderPath = default(string), string name = default(string), string contactEmail = default(string), string contactPhone = default(string), string nation = default(string), string city = default(string), OrganizationPrivateSettings privateSettings = default(OrganizationPrivateSettings), OrganizationPublicSettings publicSettings = default(OrganizationPublicSettings), OrganizationSettings settings = default(OrganizationSettings))
        {
            this.Id = id;
            this.EmailOverrideFolderPath = emailOverrideFolderPath;
            this.Name = name;
            this.ContactEmail = contactEmail;
            this.ContactPhone = contactPhone;
            this.Nation = nation;
            this.City = city;
            this.PrivateSettings = privateSettings;
            this.PublicSettings = publicSettings;
            this.Settings = settings;
        }
        
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets EmailOverrideFolderPath
        /// </summary>
        [DataMember(Name="emailOverrideFolderPath", EmitDefaultValue=false)]
        public string EmailOverrideFolderPath { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets ContactEmail
        /// </summary>
        [DataMember(Name="contactEmail", EmitDefaultValue=false)]
        public string ContactEmail { get; set; }

        /// <summary>
        /// Gets or Sets ContactPhone
        /// </summary>
        [DataMember(Name="contactPhone", EmitDefaultValue=false)]
        public string ContactPhone { get; set; }

        /// <summary>
        /// Gets or Sets Nation
        /// </summary>
        [DataMember(Name="nation", EmitDefaultValue=false)]
        public string Nation { get; set; }

        /// <summary>
        /// Gets or Sets City
        /// </summary>
        [DataMember(Name="city", EmitDefaultValue=false)]
        public string City { get; set; }

        /// <summary>
        /// Gets or Sets DeletedAt
        /// </summary>
        [DataMember(Name="deletedAt", EmitDefaultValue=false)]
        public DateTime DeletedAt { get; private set; }

        /// <summary>
        /// Gets or Sets PrivateSettings
        /// </summary>
        [DataMember(Name="privateSettings", EmitDefaultValue=false)]
        public OrganizationPrivateSettings PrivateSettings { get; set; }

        /// <summary>
        /// Gets or Sets PublicSettings
        /// </summary>
        [DataMember(Name="publicSettings", EmitDefaultValue=false)]
        public OrganizationPublicSettings PublicSettings { get; set; }

        /// <summary>
        /// Gets or Sets Settings
        /// </summary>
        [DataMember(Name="settings", EmitDefaultValue=false)]
        public OrganizationSettings Settings { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Organization {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  EmailOverrideFolderPath: ").Append(EmailOverrideFolderPath).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  ContactEmail: ").Append(ContactEmail).Append("\n");
            sb.Append("  ContactPhone: ").Append(ContactPhone).Append("\n");
            sb.Append("  Nation: ").Append(Nation).Append("\n");
            sb.Append("  City: ").Append(City).Append("\n");
            sb.Append("  DeletedAt: ").Append(DeletedAt).Append("\n");
            sb.Append("  PrivateSettings: ").Append(PrivateSettings).Append("\n");
            sb.Append("  PublicSettings: ").Append(PublicSettings).Append("\n");
            sb.Append("  Settings: ").Append(Settings).Append("\n");
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
            return this.Equals(input as Organization);
        }

        /// <summary>
        /// Returns true if Organization instances are equal
        /// </summary>
        /// <param name="input">Instance of Organization to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Organization input)
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
                    this.EmailOverrideFolderPath == input.EmailOverrideFolderPath ||
                    (this.EmailOverrideFolderPath != null &&
                    this.EmailOverrideFolderPath.Equals(input.EmailOverrideFolderPath))
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.ContactEmail == input.ContactEmail ||
                    (this.ContactEmail != null &&
                    this.ContactEmail.Equals(input.ContactEmail))
                ) && 
                (
                    this.ContactPhone == input.ContactPhone ||
                    (this.ContactPhone != null &&
                    this.ContactPhone.Equals(input.ContactPhone))
                ) && 
                (
                    this.Nation == input.Nation ||
                    (this.Nation != null &&
                    this.Nation.Equals(input.Nation))
                ) && 
                (
                    this.City == input.City ||
                    (this.City != null &&
                    this.City.Equals(input.City))
                ) && 
                (
                    this.DeletedAt == input.DeletedAt ||
                    (this.DeletedAt != null &&
                    this.DeletedAt.Equals(input.DeletedAt))
                ) && 
                (
                    this.PrivateSettings == input.PrivateSettings ||
                    (this.PrivateSettings != null &&
                    this.PrivateSettings.Equals(input.PrivateSettings))
                ) && 
                (
                    this.PublicSettings == input.PublicSettings ||
                    (this.PublicSettings != null &&
                    this.PublicSettings.Equals(input.PublicSettings))
                ) && 
                (
                    this.Settings == input.Settings ||
                    (this.Settings != null &&
                    this.Settings.Equals(input.Settings))
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
                if (this.EmailOverrideFolderPath != null)
                    hashCode = hashCode * 59 + this.EmailOverrideFolderPath.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.ContactEmail != null)
                    hashCode = hashCode * 59 + this.ContactEmail.GetHashCode();
                if (this.ContactPhone != null)
                    hashCode = hashCode * 59 + this.ContactPhone.GetHashCode();
                if (this.Nation != null)
                    hashCode = hashCode * 59 + this.Nation.GetHashCode();
                if (this.City != null)
                    hashCode = hashCode * 59 + this.City.GetHashCode();
                if (this.DeletedAt != null)
                    hashCode = hashCode * 59 + this.DeletedAt.GetHashCode();
                if (this.PrivateSettings != null)
                    hashCode = hashCode * 59 + this.PrivateSettings.GetHashCode();
                if (this.PublicSettings != null)
                    hashCode = hashCode * 59 + this.PublicSettings.GetHashCode();
                if (this.Settings != null)
                    hashCode = hashCode * 59 + this.Settings.GetHashCode();
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
