
# SigningToday.Model.CreateDigitalSignatureTransaction

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Title** | **string** | Title of the _Digital Signature Transaction_ | [optional] 
**Documents** | [**List&lt;CreateDocument&gt;**](CreateDocument.md) | The document or documents of the _DST_ | [optional] 
**Status** | **string** | Status of the _DST_ | [optional] 
**ExpiresAt** | **DateTime** | Date of expiration of the _DST_ | [optional] 
**Tags** | **List&lt;string&gt;** | An array of tags for the DST. In such way is possible to tag in the same way some DSTs in order to keep them organized and been easy to find them through the custom search | [optional] 
**Template** | **bool** | True if the _DST_ has been created from a template | [optional] 
**PublicTemplate** | **bool** | Indicates if a public template has been used to create the DST or not | [optional] 
**CcGroups** | **List&lt;string&gt;** | Name of groups that are informed about the DST. | [optional] 
**CcUsers** | **List&lt;Guid&gt;** | UUIDs of the users that are informed about the DST. | [optional] 
**Urgent** | **bool** | True if the DST is flagged as urgent | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

