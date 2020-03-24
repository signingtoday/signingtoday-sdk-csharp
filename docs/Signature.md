
# SigningToday.Model.Signature

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**InstanceId** | **long** | It is a reference for internal use | [optional] [readonly] 
**DocumentId** | **int** | Id of the document | [optional] 
**SignatureRequestId** | **int** | Id of the requested signature | [optional] 
**SignedAt** | **DateTime** | Indicates when the DST has been signed | [optional] 
**DeclinedReason** | **string** |  | [optional] 
**Status** | **string** | Status of the signature, which can be _signed_ or _declined_ | [optional] [readonly] 
**ExtraData** | **Dictionary&lt;string, Object&gt;** | Extra data of the signature | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

