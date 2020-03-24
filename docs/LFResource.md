
# SigningToday.Model.LFResource

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | **Guid** | Unique id of the resource | [optional] 
**Domain** | **string** | The _domain_ is the Organization which a user or a DST belongs | [optional] 
**Type** | **string** | Type of the resource, for example a _PDFResource_ | [optional] [readonly] 
**DstUuid** | **Guid** | Unique id of the _DST_ which the resource is correlated | [optional] [readonly] 
**Title** | **string** | Title of the resource | [optional] 
**Filename** | **string** | Name of the file uploaded, with its extension as well | [optional] 
**Url** | **string** | Url of the resource | [optional] [readonly] 
**Size** | **long** | Size of the resource | [optional] [readonly] 
**CreatedAt** | **DateTime** | Indicates when the resource has been uploaded | [optional] [readonly] 
**Mimetype** | **string** | _MIME_ type of the resource | [optional] [readonly] 
**Pages** | **int** | Indicates how many pages the resource is | [optional] 
**ExtraData** | **Dictionary&lt;string, Object&gt;** | Extra data of the resource | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

