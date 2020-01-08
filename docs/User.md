
# SigningToday.Model.User

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Automatic** | **bool** | If true indicates that the User is an _automatic_ one, thus the signature procedure will be different from a regular signer | [optional] 
**CreatedBy** | **string** | This field shows who created the User - _user_name@organization-id_. It may be a SigningToday system User as well | [optional] 
**Email** | **string** | The email associated to the User | [optional] 
**FirstName** | **string** | First name of the User | [optional] 
**Id** | **Guid** | The uuid code that identifies the User | 
**LastName** | **string** | Last name of the User | [optional] 
**Owner** | **bool** | The _owner field_ gives to the User administrative permissions | [optional] 
**Rao** | **bool** | The _rao field_ identifies a RAO User, the one can associate identities to the other users | [optional] 
**Status** | **string** | The status of the User | [optional] 
**Type** | **string** | The _type field_ identifies the permissions the User have | [optional] 
**Wallet** | [**List&lt;Identity&gt;**](Identity.md) | The wallet of an User identifies its portfolio of identities | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

