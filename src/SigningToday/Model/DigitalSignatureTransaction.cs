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
    /// The **Digital Signature Transaction** is the core object at the center of every &#x60;digital signature workflow&#x60; in Signing Today. It is a &#x60;collection&#x60; element and holds every document (to be signed or just attached to the transaction) as well as the signature plan required to fulfill the transaction; how many signatures are required, are there any forms to be filled, appearance, signature sequence, signers... everything starts here. 
    /// </summary>
    [DataContract]
    public partial class DigitalSignatureTransaction :  IEquatable<DigitalSignatureTransaction>, IValidatableObject
    {
        /// <summary>
        /// Status of the _Digital Signature Transaction_
        /// </summary>
        /// <value>Status of the _Digital Signature Transaction_</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusEnum
        {
            /// <summary>
            /// Enum Draft for value: draft
            /// </summary>
            [EnumMember(Value = "draft")]
            Draft = 1,

            /// <summary>
            /// Enum DownloadingInDraft for value: downloadingInDraft
            /// </summary>
            [EnumMember(Value = "downloadingInDraft")]
            DownloadingInDraft = 2,

            /// <summary>
            /// Enum DownloadingInPublished for value: downloadingInPublished
            /// </summary>
            [EnumMember(Value = "downloadingInPublished")]
            DownloadingInPublished = 3,

            /// <summary>
            /// Enum Published for value: published
            /// </summary>
            [EnumMember(Value = "published")]
            Published = 4,

            /// <summary>
            /// Enum ToFill for value: toFill
            /// </summary>
            [EnumMember(Value = "toFill")]
            ToFill = 5,

            /// <summary>
            /// Enum ToSign for value: toSign
            /// </summary>
            [EnumMember(Value = "toSign")]
            ToSign = 6,

            /// <summary>
            /// Enum Expired for value: expired
            /// </summary>
            [EnumMember(Value = "expired")]
            Expired = 7,

            /// <summary>
            /// Enum Signed for value: signed
            /// </summary>
            [EnumMember(Value = "signed")]
            Signed = 8,

            /// <summary>
            /// Enum Rejected for value: rejected
            /// </summary>
            [EnumMember(Value = "rejected")]
            Rejected = 9,

            /// <summary>
            /// Enum Error for value: error
            /// </summary>
            [EnumMember(Value = "error")]
            Error = 10

        }

        /// <summary>
        /// Status of the _Digital Signature Transaction_
        /// </summary>
        /// <value>Status of the _Digital Signature Transaction_</value>
        [DataMember(Name="status", EmitDefaultValue=false)]
        public StatusEnum? Status { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="DigitalSignatureTransaction" /> class.
        /// </summary>
        /// <param name="domain">The _domain_ is the Organization which a user or a DST belongs.</param>
        /// <param name="title">Title of the Digital Signature Transaction.</param>
        /// <param name="documents">The _documents_ field is an array containing document objects, where everyone of them is defined as follows .</param>
        /// <param name="resources">An array of resources attached to the _DST_, each one defined as follows.</param>
        /// <param name="signatures">An array of signatures, each one defined as follows.</param>
        /// <param name="errorMessage">The explication of the occurred error.</param>
        /// <param name="tags">An array of tags for the _DST_. In such way is possible to tag in the same way some _DSTs_ in order to keep them organized and been easy to find them through the custom search.</param>
        /// <param name="template">Indicates if a template has been used to create the DST or not.</param>
        /// <param name="publicTemplate">Indicates if a public template has been used to create the DST or not.</param>
        /// <param name="extraData">Extra information about the _DST_.</param>
        /// <param name="visibleTo">UUIDs of the users to which the DST is visible.</param>
        /// <param name="ccGroups">Name of groups that are informed about the DST.</param>
        /// <param name="ccUsers">UUIDs of the users that are informed about the DST.</param>
        /// <param name="urgent">True if the DST is flagged as urgent.</param>
        public DigitalSignatureTransaction(string domain = default(string), string title = default(string), List<Document> documents = default(List<Document>), List<LFResource> resources = default(List<LFResource>), List<Signature> signatures = default(List<Signature>), string errorMessage = default(string), List<string> tags = default(List<string>), bool template = default(bool), bool publicTemplate = default(bool), Dictionary<string, Object> extraData = default(Dictionary<string, Object>), List<Guid> visibleTo = default(List<Guid>), List<string> ccGroups = default(List<string>), List<Guid> ccUsers = default(List<Guid>), bool urgent = default(bool))
        {
            this.Domain = domain;
            this.Title = title;
            this.Documents = documents;
            this.Resources = resources;
            this.Signatures = signatures;
            this.ErrorMessage = errorMessage;
            this.Tags = tags;
            this.Template = template;
            this.PublicTemplate = publicTemplate;
            this.ExtraData = extraData;
            this.VisibleTo = visibleTo;
            this.CcGroups = ccGroups;
            this.CcUsers = ccUsers;
            this.Urgent = urgent;
        }
        
        /// <summary>
        /// The uuid code that identifies the Digital Signature Transaction
        /// </summary>
        /// <value>The uuid code that identifies the Digital Signature Transaction</value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public Guid Id { get; private set; }

        /// <summary>
        /// The _domain_ is the Organization which a user or a DST belongs
        /// </summary>
        /// <value>The _domain_ is the Organization which a user or a DST belongs</value>
        [DataMember(Name="domain", EmitDefaultValue=false)]
        public string Domain { get; set; }

        /// <summary>
        /// Title of the Digital Signature Transaction
        /// </summary>
        /// <value>Title of the Digital Signature Transaction</value>
        [DataMember(Name="title", EmitDefaultValue=false)]
        public string Title { get; set; }

        /// <summary>
        /// The _DST_ which this one replaces
        /// </summary>
        /// <value>The _DST_ which this one replaces</value>
        [DataMember(Name="replaces", EmitDefaultValue=false)]
        public Guid Replaces { get; private set; }

        /// <summary>
        /// The _DST_ which has replaces the current one
        /// </summary>
        /// <value>The _DST_ which has replaces the current one</value>
        [DataMember(Name="replacedBy", EmitDefaultValue=false)]
        public Guid ReplacedBy { get; private set; }

        /// <summary>
        /// The user created the Digital Signature Transaction
        /// </summary>
        /// <value>The user created the Digital Signature Transaction</value>
        [DataMember(Name="createdByUser", EmitDefaultValue=false)]
        public Guid CreatedByUser { get; private set; }

        /// <summary>
        /// Date of creation of the Digital Signature Transaction
        /// </summary>
        /// <value>Date of creation of the Digital Signature Transaction</value>
        [DataMember(Name="createdAt", EmitDefaultValue=false)]
        public DateTime CreatedAt { get; private set; }

        /// <summary>
        /// The _documents_ field is an array containing document objects, where everyone of them is defined as follows 
        /// </summary>
        /// <value>The _documents_ field is an array containing document objects, where everyone of them is defined as follows </value>
        [DataMember(Name="documents", EmitDefaultValue=false)]
        public List<Document> Documents { get; set; }

        /// <summary>
        /// The _date-time_ the DST has been published
        /// </summary>
        /// <value>The _date-time_ the DST has been published</value>
        [DataMember(Name="publishedAt", EmitDefaultValue=false)]
        public DateTime PublishedAt { get; private set; }

        /// <summary>
        /// Indicates when the DST will expire
        /// </summary>
        /// <value>Indicates when the DST will expire</value>
        [DataMember(Name="expiresAt", EmitDefaultValue=false)]
        public DateTime ExpiresAt { get; private set; }

        /// <summary>
        /// An array of resources attached to the _DST_, each one defined as follows
        /// </summary>
        /// <value>An array of resources attached to the _DST_, each one defined as follows</value>
        [DataMember(Name="resources", EmitDefaultValue=false)]
        public List<LFResource> Resources { get; set; }

        /// <summary>
        /// An array of signatures, each one defined as follows
        /// </summary>
        /// <value>An array of signatures, each one defined as follows</value>
        [DataMember(Name="signatures", EmitDefaultValue=false)]
        public List<Signature> Signatures { get; set; }


        /// <summary>
        /// The explication of the occurred error
        /// </summary>
        /// <value>The explication of the occurred error</value>
        [DataMember(Name="errorMessage", EmitDefaultValue=false)]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Indicates when the _DST_ has been deleted
        /// </summary>
        /// <value>Indicates when the _DST_ has been deleted</value>
        [DataMember(Name="deletedAt", EmitDefaultValue=false)]
        public DateTime DeletedAt { get; private set; }

        /// <summary>
        /// An array of tags for the _DST_. In such way is possible to tag in the same way some _DSTs_ in order to keep them organized and been easy to find them through the custom search
        /// </summary>
        /// <value>An array of tags for the _DST_. In such way is possible to tag in the same way some _DSTs_ in order to keep them organized and been easy to find them through the custom search</value>
        [DataMember(Name="tags", EmitDefaultValue=false)]
        public List<string> Tags { get; set; }

        /// <summary>
        /// Indicates if a template has been used to create the DST or not
        /// </summary>
        /// <value>Indicates if a template has been used to create the DST or not</value>
        [DataMember(Name="template", EmitDefaultValue=false)]
        public bool Template { get; set; }

        /// <summary>
        /// Indicates if a public template has been used to create the DST or not
        /// </summary>
        /// <value>Indicates if a public template has been used to create the DST or not</value>
        [DataMember(Name="publicTemplate", EmitDefaultValue=false)]
        public bool PublicTemplate { get; set; }

        /// <summary>
        /// Extra information about the _DST_
        /// </summary>
        /// <value>Extra information about the _DST_</value>
        [DataMember(Name="extraData", EmitDefaultValue=false)]
        public Dictionary<string, Object> ExtraData { get; set; }

        /// <summary>
        /// UUIDs of the users to which the DST is visible
        /// </summary>
        /// <value>UUIDs of the users to which the DST is visible</value>
        [DataMember(Name="visibleTo", EmitDefaultValue=false)]
        public List<Guid> VisibleTo { get; set; }

        /// <summary>
        /// Name of groups that are informed about the DST
        /// </summary>
        /// <value>Name of groups that are informed about the DST</value>
        [DataMember(Name="ccGroups", EmitDefaultValue=false)]
        public List<string> CcGroups { get; set; }

        /// <summary>
        /// UUIDs of the users that are informed about the DST
        /// </summary>
        /// <value>UUIDs of the users that are informed about the DST</value>
        [DataMember(Name="ccUsers", EmitDefaultValue=false)]
        public List<Guid> CcUsers { get; set; }

        /// <summary>
        /// True if the DST is flagged as urgent
        /// </summary>
        /// <value>True if the DST is flagged as urgent</value>
        [DataMember(Name="urgent", EmitDefaultValue=false)]
        public bool Urgent { get; set; }

        /// <summary>
        /// Indicates the last update of the DST, such as the performing of a signature
        /// </summary>
        /// <value>Indicates the last update of the DST, such as the performing of a signature</value>
        [DataMember(Name="updatedAt", EmitDefaultValue=false)]
        public DateTime UpdatedAt { get; private set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class DigitalSignatureTransaction {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Domain: ").Append(Domain).Append("\n");
            sb.Append("  Title: ").Append(Title).Append("\n");
            sb.Append("  Replaces: ").Append(Replaces).Append("\n");
            sb.Append("  ReplacedBy: ").Append(ReplacedBy).Append("\n");
            sb.Append("  CreatedByUser: ").Append(CreatedByUser).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  Documents: ").Append(Documents).Append("\n");
            sb.Append("  PublishedAt: ").Append(PublishedAt).Append("\n");
            sb.Append("  ExpiresAt: ").Append(ExpiresAt).Append("\n");
            sb.Append("  Resources: ").Append(Resources).Append("\n");
            sb.Append("  Signatures: ").Append(Signatures).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  ErrorMessage: ").Append(ErrorMessage).Append("\n");
            sb.Append("  DeletedAt: ").Append(DeletedAt).Append("\n");
            sb.Append("  Tags: ").Append(Tags).Append("\n");
            sb.Append("  Template: ").Append(Template).Append("\n");
            sb.Append("  PublicTemplate: ").Append(PublicTemplate).Append("\n");
            sb.Append("  ExtraData: ").Append(ExtraData).Append("\n");
            sb.Append("  VisibleTo: ").Append(VisibleTo).Append("\n");
            sb.Append("  CcGroups: ").Append(CcGroups).Append("\n");
            sb.Append("  CcUsers: ").Append(CcUsers).Append("\n");
            sb.Append("  Urgent: ").Append(Urgent).Append("\n");
            sb.Append("  UpdatedAt: ").Append(UpdatedAt).Append("\n");
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
            return this.Equals(input as DigitalSignatureTransaction);
        }

        /// <summary>
        /// Returns true if DigitalSignatureTransaction instances are equal
        /// </summary>
        /// <param name="input">Instance of DigitalSignatureTransaction to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DigitalSignatureTransaction input)
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
                    this.Domain == input.Domain ||
                    (this.Domain != null &&
                    this.Domain.Equals(input.Domain))
                ) && 
                (
                    this.Title == input.Title ||
                    (this.Title != null &&
                    this.Title.Equals(input.Title))
                ) && 
                (
                    this.Replaces == input.Replaces ||
                    (this.Replaces != null &&
                    this.Replaces.Equals(input.Replaces))
                ) && 
                (
                    this.ReplacedBy == input.ReplacedBy ||
                    (this.ReplacedBy != null &&
                    this.ReplacedBy.Equals(input.ReplacedBy))
                ) && 
                (
                    this.CreatedByUser == input.CreatedByUser ||
                    (this.CreatedByUser != null &&
                    this.CreatedByUser.Equals(input.CreatedByUser))
                ) && 
                (
                    this.CreatedAt == input.CreatedAt ||
                    (this.CreatedAt != null &&
                    this.CreatedAt.Equals(input.CreatedAt))
                ) && 
                (
                    this.Documents == input.Documents ||
                    this.Documents != null &&
                    input.Documents != null &&
                    this.Documents.SequenceEqual(input.Documents)
                ) && 
                (
                    this.PublishedAt == input.PublishedAt ||
                    (this.PublishedAt != null &&
                    this.PublishedAt.Equals(input.PublishedAt))
                ) && 
                (
                    this.ExpiresAt == input.ExpiresAt ||
                    (this.ExpiresAt != null &&
                    this.ExpiresAt.Equals(input.ExpiresAt))
                ) && 
                (
                    this.Resources == input.Resources ||
                    this.Resources != null &&
                    input.Resources != null &&
                    this.Resources.SequenceEqual(input.Resources)
                ) && 
                (
                    this.Signatures == input.Signatures ||
                    this.Signatures != null &&
                    input.Signatures != null &&
                    this.Signatures.SequenceEqual(input.Signatures)
                ) && 
                (
                    this.Status == input.Status ||
                    (this.Status != null &&
                    this.Status.Equals(input.Status))
                ) && 
                (
                    this.ErrorMessage == input.ErrorMessage ||
                    (this.ErrorMessage != null &&
                    this.ErrorMessage.Equals(input.ErrorMessage))
                ) && 
                (
                    this.DeletedAt == input.DeletedAt ||
                    (this.DeletedAt != null &&
                    this.DeletedAt.Equals(input.DeletedAt))
                ) && 
                (
                    this.Tags == input.Tags ||
                    this.Tags != null &&
                    input.Tags != null &&
                    this.Tags.SequenceEqual(input.Tags)
                ) && 
                (
                    this.Template == input.Template ||
                    (this.Template != null &&
                    this.Template.Equals(input.Template))
                ) && 
                (
                    this.PublicTemplate == input.PublicTemplate ||
                    (this.PublicTemplate != null &&
                    this.PublicTemplate.Equals(input.PublicTemplate))
                ) && 
                (
                    this.ExtraData == input.ExtraData ||
                    this.ExtraData != null &&
                    input.ExtraData != null &&
                    this.ExtraData.SequenceEqual(input.ExtraData)
                ) && 
                (
                    this.VisibleTo == input.VisibleTo ||
                    this.VisibleTo != null &&
                    input.VisibleTo != null &&
                    this.VisibleTo.SequenceEqual(input.VisibleTo)
                ) && 
                (
                    this.CcGroups == input.CcGroups ||
                    this.CcGroups != null &&
                    input.CcGroups != null &&
                    this.CcGroups.SequenceEqual(input.CcGroups)
                ) && 
                (
                    this.CcUsers == input.CcUsers ||
                    this.CcUsers != null &&
                    input.CcUsers != null &&
                    this.CcUsers.SequenceEqual(input.CcUsers)
                ) && 
                (
                    this.Urgent == input.Urgent ||
                    (this.Urgent != null &&
                    this.Urgent.Equals(input.Urgent))
                ) && 
                (
                    this.UpdatedAt == input.UpdatedAt ||
                    (this.UpdatedAt != null &&
                    this.UpdatedAt.Equals(input.UpdatedAt))
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
                if (this.Domain != null)
                    hashCode = hashCode * 59 + this.Domain.GetHashCode();
                if (this.Title != null)
                    hashCode = hashCode * 59 + this.Title.GetHashCode();
                if (this.Replaces != null)
                    hashCode = hashCode * 59 + this.Replaces.GetHashCode();
                if (this.ReplacedBy != null)
                    hashCode = hashCode * 59 + this.ReplacedBy.GetHashCode();
                if (this.CreatedByUser != null)
                    hashCode = hashCode * 59 + this.CreatedByUser.GetHashCode();
                if (this.CreatedAt != null)
                    hashCode = hashCode * 59 + this.CreatedAt.GetHashCode();
                if (this.Documents != null)
                    hashCode = hashCode * 59 + this.Documents.GetHashCode();
                if (this.PublishedAt != null)
                    hashCode = hashCode * 59 + this.PublishedAt.GetHashCode();
                if (this.ExpiresAt != null)
                    hashCode = hashCode * 59 + this.ExpiresAt.GetHashCode();
                if (this.Resources != null)
                    hashCode = hashCode * 59 + this.Resources.GetHashCode();
                if (this.Signatures != null)
                    hashCode = hashCode * 59 + this.Signatures.GetHashCode();
                if (this.Status != null)
                    hashCode = hashCode * 59 + this.Status.GetHashCode();
                if (this.ErrorMessage != null)
                    hashCode = hashCode * 59 + this.ErrorMessage.GetHashCode();
                if (this.DeletedAt != null)
                    hashCode = hashCode * 59 + this.DeletedAt.GetHashCode();
                if (this.Tags != null)
                    hashCode = hashCode * 59 + this.Tags.GetHashCode();
                if (this.Template != null)
                    hashCode = hashCode * 59 + this.Template.GetHashCode();
                if (this.PublicTemplate != null)
                    hashCode = hashCode * 59 + this.PublicTemplate.GetHashCode();
                if (this.ExtraData != null)
                    hashCode = hashCode * 59 + this.ExtraData.GetHashCode();
                if (this.VisibleTo != null)
                    hashCode = hashCode * 59 + this.VisibleTo.GetHashCode();
                if (this.CcGroups != null)
                    hashCode = hashCode * 59 + this.CcGroups.GetHashCode();
                if (this.CcUsers != null)
                    hashCode = hashCode * 59 + this.CcUsers.GetHashCode();
                if (this.Urgent != null)
                    hashCode = hashCode * 59 + this.Urgent.GetHashCode();
                if (this.UpdatedAt != null)
                    hashCode = hashCode * 59 + this.UpdatedAt.GetHashCode();
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