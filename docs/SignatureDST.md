
# SigningToday.Model.SignatureDST

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Declinable** | **bool** | If true the signer is able to decline the Signature if he wants to | [optional] 
**Profile** | **string** | The _profile_ field of the Signature object specifies the modality of signature is going to be performed, and can be:   - _PADES_ :     - allows to exclusively sign a pdf file with the signature     directly affixed into the document;   - _CADES_ :     - allows to sign different types of documents; the signature     is not \&quot;physically\&quot; into the document but the signature and the file     are placed together in an envelope instead, making thus a _.p7m_     extension.  | [optional] 
**DisplayName** | **string** | This is the name will be displayed on the signature tray associated to the Signature has to be performed. Usually is the _full name_ of the user is going to sign | [optional] 
**Reason** | **string** | The reason of the Signature, or rather a motivational description associated to the Signature | [optional] 
**Signer** | **string** | The user that have to sign the digital signature transaction | [optional] 
**Description** | **string** | This is a simple description to attach with the Signature | [optional] 
**Urlback** | **string** | The url for the redirection from Signature tray when the digital signature transaction is completed or annulled | [optional] 
**Where** | [**SignatureDSTWhere**](SignatureDSTWhere.md) |  | [optional] 
**Constraints** | [**Object**](.md) | Particular constraints for the Signature. For example constraints about the _firs tname_ or _last name_ of the certificate associated with the identity is going to sign. The way to use this field is through the _django lookups_, for example:   - \&quot;certificate__subject_givenName__iexact&#x3D;JOHN\&quot;  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

