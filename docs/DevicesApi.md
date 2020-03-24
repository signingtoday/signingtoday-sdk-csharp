# SigningToday.Api.DevicesApi

All URIs are relative to *https://web.sandbox.signingtoday.com/api*

Method | HTTP request | Description
------------- | ------------- | -------------
[**DeviceAuthorizationDelete**](DevicesApi.md#deviceauthorizationdelete) | **DELETE** /device/authorization | Clear a trusted device
[**DeviceAuthorizationGet**](DevicesApi.md#deviceauthorizationget) | **GET** /device/authorization | Retrieve a challenge for authorizing a new trusted device
[**DeviceAuthorizationPost**](DevicesApi.md#deviceauthorizationpost) | **POST** /device/authorization | Register a new trusted device
[**DevicesGet**](DevicesApi.md#devicesget) | **GET** /devices | Get the list of trusted devices



## DeviceAuthorizationDelete

> void DeviceAuthorizationDelete (string deviceId, Guid userId = null)

Clear a trusted device

This APIs allows to deregister a _deviceId_ of a trusted device.  It also deletes any notification push-token associated to the trusted device. 

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class DeviceAuthorizationDeleteExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DevicesApi(Configuration.Default);
            var deviceId = 05ea656f-df69-49b1-a12b-9bf640c427c2;  // string | The _deviceId_ to deregister
            var userId = new Guid(); // Guid | Select the objects relative to the user specified by the parameter. If not specified will be used the id of the current authenticated user (optional) 

            try
            {
                // Clear a trusted device
                apiInstance.DeviceAuthorizationDelete(deviceId, userId);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling DevicesApi.DeviceAuthorizationDelete: " + e.Message );
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
 **userId** | [**Guid**](Guid.md)| Select the objects relative to the user specified by the parameter. If not specified will be used the id of the current authenticated user | [optional] 

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


## DeviceAuthorizationGet

> DeviceAuthorizationResponse DeviceAuthorizationGet ()

Retrieve a challenge for authorizing a new trusted device

This API allows to retrieve a challenge in order to authorize a new trusted device.   - If asked in image/png the challenge is given encoded as a QR-Code image.   - An invocation of the endpoint invalidate any previous challenge.   - The challenge lasts 10 minutes. 

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class DeviceAuthorizationGetExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DevicesApi(Configuration.Default);

            try
            {
                // Retrieve a challenge for authorizing a new trusted device
                DeviceAuthorizationResponse result = apiInstance.DeviceAuthorizationGet();
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling DevicesApi.DeviceAuthorizationGet: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters

This endpoint does not need any parameter.

### Return type

[**DeviceAuthorizationResponse**](DeviceAuthorizationResponse.md)

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json, image/png, */*

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The challenge to be used for the authorization. |  -  |
| **401** | User authentication was not effective (e.g. not provided, invalid or expired). |  -  |
| **500** | Internal failure of the service. |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## DeviceAuthorizationPost

> List&lt;Guid&gt; DeviceAuthorizationPost (InlineObject7 inlineObject7)

Register a new trusted device

This API allows to register a new trusted device. If the device is already present, it returns the current associated Token and updates the name. 

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class DeviceAuthorizationPostExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            var apiInstance = new DevicesApi(Configuration.Default);
            var inlineObject7 = new InlineObject7(); // InlineObject7 | 

            try
            {
                // Register a new trusted device
                List<Guid> result = apiInstance.DeviceAuthorizationPost(inlineObject7);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling DevicesApi.DeviceAuthorizationPost: " + e.Message );
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
 **inlineObject7** | [**InlineObject7**](InlineObject7.md)|  | 

### Return type

**List<Guid>**

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json
- **Accept**: application/json, */*

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The token to be used for next calls of the endpoint /device/authorize. |  -  |
| **401** | User authentication was not effective (e.g. not provided, invalid or expired). |  -  |
| **500** | Internal failure of the service. |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## DevicesGet

> TrustedDevicesGetResponse DevicesGet (Guid userId = null, int top = null, long skip = null, bool count = null)

Get the list of trusted devices

The API allows to enumerate all the devices of a user. 

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class DevicesGetExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DevicesApi(Configuration.Default);
            var userId = new Guid(); // Guid | Select the objects relative to the user specified by the parameter. If not specified will be used the id of the current authenticated user (optional) 
            var top = 32;  // int | A number of results to return. Applied after **$skip**  (optional) 
            var skip = 64;  // long | An offset into the collection of results (optional) 
            var count = true;  // bool | If true, the server includes the count of all the items in the response  (optional) 

            try
            {
                // Get the list of trusted devices
                TrustedDevicesGetResponse result = apiInstance.DevicesGet(userId, top, skip, count);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling DevicesApi.DevicesGet: " + e.Message );
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
 **userId** | [**Guid**](Guid.md)| Select the objects relative to the user specified by the parameter. If not specified will be used the id of the current authenticated user | [optional] 
 **top** | **int**| A number of results to return. Applied after **$skip**  | [optional] 
 **skip** | **long**| An offset into the collection of results | [optional] 
 **count** | **bool**| If true, the server includes the count of all the items in the response  | [optional] 

### Return type

[**TrustedDevicesGetResponse**](TrustedDevicesGetResponse.md)

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json, */*

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The list of trusted devices. |  -  |
| **401** | User authentication was not effective (e.g. not provided, invalid or expired). |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)

