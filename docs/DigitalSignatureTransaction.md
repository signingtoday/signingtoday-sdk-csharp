
# SigningToday.Model.DigitalSignatureTransaction

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | **Guid** | The uuid code that identifies the Digital Signature Transaction | [optional] [readonly] 
**Domain** | **string** | The _domain_ is the Organization which a user or a DST belongs | [optional] 
**Title** | **string** | Title of the Digital Signature Transaction | [optional] 
**Replaces** | **Guid** | The _DST_ which this one replaces | [optional] [readonly] 
**ReplacedBy** | **Guid** | The _DST_ which has replaces the current one | [optional] [readonly] 
**CreatedByUser** | **Guid** | The user created the Digital Signature Transaction | [optional] [readonly] 
**CreatedAt** | **DateTime** | Date of creation of the Digital Signature Transaction | [optional] [readonly] 
**Documents** | [**List&lt;Document&gt;**](Document.md) | The _documents_ field is an array containing document objects, where everyone of them is defined as follows  | [optional] 
**PublishedAt** | **DateTime** | The _date-time_ the DST has been published | [optional] [readonly] 
**ExpiresAt** | **DateTime** | Indicates when the DST will expire | [optional] [readonly] 
**Resources** | [**List&lt;LFResource&gt;**](LFResource.md) | An array of resources attached to the _DST_, each one defined as follows | [optional] 
**Signatures** | [**List&lt;Signature&gt;**](Signature.md) | An array of signatures, each one defined as follows | [optional] 
**Status** | **string** | Status of the _Digital Signature Transaction_ | [optional] [readonly] 
**ErrorMessage** | **string** | The explication of the occurred error | [optional] 
**DeletedAt** | **DateTime** | Indicates when the _DST_ has been deleted | [optional] [readonly] 
**Tags** | **List&lt;string&gt;** | An array of tags for the _DST_. In such way is possible to tag in the same way some _DSTs_ in order to keep them organized and been easy to find them through the custom search | [optional] 
**Template** | **bool** | Indicates if a template has been used to create the DST or not | [optional] 
**PublicTemplate** | **bool** | Indicates if a public template has been used to create the DST or not | [optional] 
**ExtraData** | **Dictionary&lt;string, Object&gt;** | Extra information about the _DST_ | [optional] 
**VisibleTo** | **List&lt;Guid&gt;** | UUIDs of the users to which the DST is visible | [optional] 
**CcGroups** | **List&lt;string&gt;** | Name of groups that are informed about the DST | [optional] 
**CcUsers** | **List&lt;Guid&gt;** | UUIDs of the users that are informed about the DST | [optional] 
**Urgent** | **bool** | True if the DST is flagged as urgent | [optional] 
**UpdatedAt** | **DateTime** | Indicates the last update of the DST, such as the performing of a signature | [optional] [readonly] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

