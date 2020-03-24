
# SigningToday.Model.User

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | **Guid** | The unique id of the User | [optional] [readonly] 
**Username** | **string** | The username of the User. The username is used to login | [optional] 
**Domain** | **string** | The _domain_ is the Organization which a user or a DST belongs | [optional] 
**Language** | **string** | The default language of the User | [optional] 
**Name** | **string** | The name of the User | [optional] 
**Surname** | **string** | The name of the User | [optional] 
**Email** | **string** | The email address of the User | [optional] 
**Phone** | **decimal** | The phone number of the User | [optional] 
**Role** | **string** | The role of the User. The **admin** can create users, as well as DSTs and can sign. The **instructor** can create DSTs and sign. The **signer** can only sign documents.  | [optional] 
**Groups** | [**List&lt;UserGroup&gt;**](UserGroup.md) | A group of users. This is useful during DSTs creation, it is possible to select a group as signers. This way all the components of that group have to sign the document | [optional] 
**Capabilities** | **List&lt;string&gt;** | The capabilities represents the action a user is able to do | [optional] 
**CreatedBy** | **Guid** | The one which created the User | [optional] [readonly] 
**CreatedAt** | **DateTime** | The date of the creation of the User | [optional] [readonly] 
**DeletedAt** | **DateTime** | The date of deletion of the User | [optional] [readonly] 
**Automatic** | **bool** | If true the user is automatic | [optional] [readonly] 
**ExtraData** | **Dictionary&lt;string, Object&gt;** | Extra data associated to the User | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

