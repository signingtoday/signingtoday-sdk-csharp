
# SigningToday.Model.Document

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**InstanceId** | **long** | It is a reference for internal use | [optional] [readonly] 
**Id** | **int** | Unique Id of the document | [optional] 
**PlainDocumentUuid** | **Guid** | Id of the associated Resource (plain PDF file e.g. the one uploaded by the user) | [optional] 
**FilledDocumentUuid** | **Guid** | Id of the associated PDF file that contains all the forms filled (present only once the whole document has been filled) | [optional] [readonly] 
**SignedDocumentUuid** | **Guid** | Id of the associated PDF file that contains all the signatures  (present only once the whole document has been signed) | [optional] [readonly] 
**Status** | **string** | The status of the _Document_, which can be: - \&quot;plain\&quot;: The document has been correctly updated by the user - \&quot;filled\&quot;: The document has been filled - \&quot;signed\&quot;: The document has been signed  | [optional] [readonly] 
**Forms** | [**List&lt;FillableForm&gt;**](FillableForm.md) | The fillable elements of the document. Use the type field to identify textual fillable fields and signature fields | [optional] 
**SignatureRequests** | [**List&lt;SignatureRequest&gt;**](SignatureRequest.md) | The list of signature request of the document | [optional] 
**SignerGroups** | [**List&lt;SignersGroup&gt;**](SignersGroup.md) | The sign plan for the document | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

