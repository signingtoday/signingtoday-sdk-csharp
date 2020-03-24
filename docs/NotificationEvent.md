
# SigningToday.Model.NotificationEvent

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | **long** |  | [optional] [readonly] 
**Time** | **DateTime** |  | [optional] [readonly] 
**DstId** | **Guid** |  | [optional] [readonly] 
**UserId** | **Guid** |  | [optional] [readonly] 
**DstTitle** | **string** |  | [optional] 
**Username** | **string** | If present limits the notification to one user account, otherwise is to be intended for all (active) user accounts (e.g. PC/devices, etc). Indeed one principal (User) could have multiple account (credentials)  | [optional] 
**Email** | **string** |  | [optional] 
**Event** | **string** |  | [optional] [readonly] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

