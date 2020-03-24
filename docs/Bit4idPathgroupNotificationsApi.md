# SigningToday.Api.Bit4idPathgroupNotificationsApi

All URIs are relative to *https://web.sandbox.signingtoday.com/api*

Method | HTTP request | Description
------------- | ------------- | -------------
[**NotificationsDstIdDelete**](Bit4idPathgroupNotificationsApi.md#notificationsdstiddelete) | **DELETE** /notifications/dst/{id} | Clear Notifications for a DST
[**NotificationsDstsGet**](Bit4idPathgroupNotificationsApi.md#notificationsdstsget) | **GET** /notifications/dsts | Get latest DST Notifications
[**NotificationsPushTokenDelete**](Bit4idPathgroupNotificationsApi.md#notificationspushtokendelete) | **DELETE** /notifications/push-token | Clear a registered push notification token
[**NotificationsPushTokenPost**](Bit4idPathgroupNotificationsApi.md#notificationspushtokenpost) | **POST** /notifications/push-token | Register a token for push notifications



## NotificationsDstIdDelete

> void NotificationsDstIdDelete (Guid id)

Clear Notifications for a DST

This API notifies that a user consumed all active notifications for a DST.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class NotificationsDstIdDeleteExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new Bit4idPathgroupNotificationsApi(Configuration.Default);
            var id = new Guid(); // Guid | The value of _the unique id_

            try
            {
                // Clear Notifications for a DST
                apiInstance.NotificationsDstIdDelete(id);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling Bit4idPathgroupNotificationsApi.NotificationsDstIdDelete: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | [**Guid**](Guid.md)| The value of _the unique id_ | 

### Return type

void (empty response body)

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: */*

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | The request has been satisfyied. No output. |  -  |
| **401** | User authentication was not effective (e.g. not provided, invalid or expired). |  -  |
| **500** | Internal failure of the service. |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## NotificationsDstsGet

> NotificationsResponse NotificationsDstsGet (int top = null, long skip = null, bool count = null)

Get latest DST Notifications

This APIs allows to get latest user Notifications for DSTs sorted desc by time.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class NotificationsDstsGetExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new Bit4idPathgroupNotificationsApi(Configuration.Default);
            var top = 32;  // int | A number of results to return. Applied after **$skip**  (optional) 
            var skip = 64;  // long | An offset into the collection of results (optional) 
            var count = true;  // bool | If true, the server includes the count of all the items in the response  (optional) 

            try
            {
                // Get latest DST Notifications
                NotificationsResponse result = apiInstance.NotificationsDstsGet(top, skip, count);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling Bit4idPathgroupNotificationsApi.NotificationsDstsGet: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **top** | **int**| A number of results to return. Applied after **$skip**  | [optional] 
 **skip** | **long**| An offset into the collection of results | [optional] 
 **count** | **bool**| If true, the server includes the count of all the items in the response  | [optional] 

### Return type

[**NotificationsResponse**](NotificationsResponse.md)

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json, */*

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Last DST notifications. |  -  |
| **401** | User authentication was not effective (e.g. not provided, invalid or expired). |  -  |
| **500** | Internal failure of the service. |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## NotificationsPushTokenDelete

> void NotificationsPushTokenDelete (string deviceId)

Clear a registered push notification token

This API deregister a deviceId from the push notifications.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class NotificationsPushTokenDeleteExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new Bit4idPathgroupNotificationsApi(Configuration.Default);
            var deviceId = 05ea656f-df69-49b1-a12b-9bf640c427c2;  // string | The _deviceId_ to deregister

            try
            {
                // Clear a registered push notification token
                apiInstance.NotificationsPushTokenDelete(deviceId);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling Bit4idPathgroupNotificationsApi.NotificationsPushTokenDelete: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **deviceId** | **string**| The _deviceId_ to deregister | 

### Return type

void (empty response body)

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: */*

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | The request has been satisfyied. No output. |  -  |
| **401** | User authentication was not effective (e.g. not provided, invalid or expired). |  -  |
| **500** | Internal failure of the service. |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## NotificationsPushTokenPost

> void NotificationsPushTokenPost (InlineObject6 inlineObject6)

Register a token for push notifications

This API allows to register a token for push notifications. Only trusted deviceId can be registered. 

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class NotificationsPushTokenPostExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new Bit4idPathgroupNotificationsApi(Configuration.Default);
            var inlineObject6 = new InlineObject6(); // InlineObject6 | 

            try
            {
                // Register a token for push notifications
                apiInstance.NotificationsPushTokenPost(inlineObject6);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling Bit4idPathgroupNotificationsApi.NotificationsPushTokenPost: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **inlineObject6** | [**InlineObject6**](InlineObject6.md)|  | 

### Return type

void (empty response body)

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

- **Content-Type**: application/json
- **Accept**: */*

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | The request has been satisfyied. No output. |  -  |
| **401** | User authentication was not effective (e.g. not provided, invalid or expired). |  -  |
| **409** | Cannot satisfy the request because the resource is in an illegal status. |  -  |
| **500** | Internal failure of the service. |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)

