
# SigningToday.Model.FillableForm

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**InstanceId** | **long** | It is a reference for internal use | [optional] [readonly] 
**Id** | **int** | Id of the _form_ | [optional] 
**DocumentId** | **int** | Id of the document | [optional] 
**Type** | **string** | Type of the fill form | [optional] 
**PositionX** | **float** | Position onto the X axis of the form, expressed in percentage | [optional] 
**PositionY** | **float** | Position onto the Y axis of the form, expressed in percentage | [optional] 
**Width** | **float** | Width of the form expressed in percentage | [optional] 
**Height** | **float** | Height of the form expressed in percentage | [optional] 
**Page** | **long** | Page of the document where the form is | [optional] 
**SignerId** | **int** | Id of the signer in the sign plan | [optional] 
**ToFill** | **bool** | **True** if the field need to be filled by the user. In case of a Signature it is **false**  | [optional] 
**Filled** | **bool** | True ones the form has been filled | [optional] 
**Invisible** | **bool** | True if the appearance has to be hidden | [optional] 
**ExtraData** | **Dictionary&lt;string, Object&gt;** | Extra information about the form | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

