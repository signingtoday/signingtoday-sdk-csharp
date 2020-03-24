
# SigningToday.Model.Identity

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | **Guid** | The uuid code that identifies the Identity | [optional] 
**Certificate** | **string** | The X.509 certificate in PEM format of the Identity | [optional] 
**NotAfter** | **string** | Deadline of the Identity, expressed in ISO format | [optional] 
**Status** | **string** | Identity status which can be one of the following. When an identity request is send, the identity is created and the status is **pending** until the provider dont&#39;approve the request. Then status of the identity changes to **active**. If for some reason an error occurs during the process, or after that, the status will be **error**  | [optional] 
**Next** | **string** | The next step to complete the activation procedure | [optional] 
**Actions** | [**IdentityActions**](IdentityActions.md) |  | [optional] 
**Provider** | **string** | The name of the provider that issued the certificate for the Identity | [optional] 
**Label** | **string** | The label is an arbitrary name is possible to associate to an idenity. Doing so allows to distinguish different identities issued from the same provider during the performance of the signature in the signature tray | [optional] 
**SignatureAppearanceUri** | **string** | This is the url to the image that will be impressed on the document after the performance of the signature  | [optional] 
**ProviderId** | **Guid** | _provider_id_ is the univocal name of the provider that issued the identity  | [optional] 
**ProviderType** | **string** | Type of the provider. The most usual type is **cloud**  | [optional] 
**ProviderData** | [**Object**](.md) | Data of the provider that issued the certificate, it is variable from provider to provider | [optional] 
**ProviderImage** | **string** | This is the logo of the provider that issued the identity | [optional] 
**SendOtpUrl** | **string** | The url to send a one time password to the user which the identity is associated | [optional] 
**SignUrl** | **string** | The url to sign a document of a digital signature transaction | [optional] 
**HasBeenImported** | **bool** | If the Identity has been imported from another pre-existing Identity the has_been_imported field is set to **true** | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

