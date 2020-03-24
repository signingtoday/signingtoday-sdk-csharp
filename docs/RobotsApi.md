# SigningToday.Api.RobotsApi

All URIs are relative to *https://web.sandbox.signingtoday.com/api*

Method | HTTP request | Description
------------- | ------------- | -------------
[**RobotAuthenticationDelete**](RobotsApi.md#robotauthenticationdelete) | **DELETE** /robot/authentication | Clear a Robot authentication lifetime token
[**RobotAuthenticationGet**](RobotsApi.md#robotauthenticationget) | **GET** /robot/authentication | Retrieve the Robot authentication lifetime token
[**RobotConfigurationGet**](RobotsApi.md#robotconfigurationget) | **GET** /robot/configuration | Retrieve the Robot configuration
[**RobotDSTsPost**](RobotsApi.md#robotdstspost) | **POST** /robot/DSTs | Create a new DST in one call
[**RobotIdInstantiatePost**](RobotsApi.md#robotidinstantiatepost) | **POST** /robot/{id}/instantiate | Instantiate a DST from a template by robot



## RobotAuthenticationDelete

> void RobotAuthenticationDelete (string username = null, string domain = null)

Clear a Robot authentication lifetime token

This API allows to clear the Robot authentication lifetime token.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class RobotAuthenticationDeleteExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RobotsApi(Configuration.Default);
            var username = thirdPartApp;  // string | The _username_ associated to the account (optional) 
            var domain = demo;  // string | The _domain_ associated to the account (optional) 

            try
            {
                // Clear a Robot authentication lifetime token
                apiInstance.RobotAuthenticationDelete(username, domain);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling RobotsApi.RobotAuthenticationDelete: " + e.Message );
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
 **username** | **string**| The _username_ associated to the account | [optional] 
 **domain** | **string**| The _domain_ associated to the account | [optional] 

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


## RobotAuthenticationGet

> RobotAuthenticationToken RobotAuthenticationGet (string username = null, string domain = null)

Retrieve the Robot authentication lifetime token

This API allows to generate or retrieves the Robot authentication lifetime token for the specified robot account, or the current logged in account. 

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class RobotAuthenticationGetExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RobotsApi(Configuration.Default);
            var username = thirdPartApp;  // string | The _username_ associated to the account (optional) 
            var domain = demo;  // string | The _domain_ associated to the account (optional) 

            try
            {
                // Retrieve the Robot authentication lifetime token
                RobotAuthenticationToken result = apiInstance.RobotAuthenticationGet(username, domain);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling RobotsApi.RobotAuthenticationGet: " + e.Message );
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
 **username** | **string**| The _username_ associated to the account | [optional] 
 **domain** | **string**| The _domain_ associated to the account | [optional] 

### Return type

[**RobotAuthenticationToken**](RobotAuthenticationToken.md)

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json, */*

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The lifetime robot token. |  -  |
| **401** | User authentication was not effective (e.g. not provided, invalid or expired). |  -  |
| **500** | Internal failure of the service. |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## RobotConfigurationGet

> RobotConfiguration RobotConfigurationGet (string username = null, string domain = null)

Retrieve the Robot configuration

This API allows to retrieve the Robot configuration. 

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class RobotConfigurationGetExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RobotsApi(Configuration.Default);
            var username = thirdPartApp;  // string | The _username_ associated to the account (optional) 
            var domain = demo;  // string | The _domain_ associated to the account (optional) 

            try
            {
                // Retrieve the Robot configuration
                RobotConfiguration result = apiInstance.RobotConfigurationGet(username, domain);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling RobotsApi.RobotConfigurationGet: " + e.Message );
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
 **username** | **string**| The _username_ associated to the account | [optional] 
 **domain** | **string**| The _domain_ associated to the account | [optional] 

### Return type

[**RobotConfiguration**](RobotConfiguration.md)

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json, */*

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The Robot configuration. |  -  |
| **401** | User authentication was not effective (e.g. not provided, invalid or expired). |  -  |
| **500** | Internal failure of the service. |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## RobotDSTsPost

> DigitalSignatureTransaction RobotDSTsPost (CreateDigitalSignatureTransaction createDigitalSignatureTransaction)

Create a new DST in one call

This API allows to create a new DST with a more convenient interface for client applications. The purpose is to provide a method for the creation of a DST in order to semplify the integration into third part applications. 

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class RobotDSTsPostExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RobotsApi(Configuration.Default);
            var createDigitalSignatureTransaction = new CreateDigitalSignatureTransaction(); // CreateDigitalSignatureTransaction | description

            try
            {
                // Create a new DST in one call
                DigitalSignatureTransaction result = apiInstance.RobotDSTsPost(createDigitalSignatureTransaction);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling RobotsApi.RobotDSTsPost: " + e.Message );
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
 **createDigitalSignatureTransaction** | [**CreateDigitalSignatureTransaction**](CreateDigitalSignatureTransaction.md)| description | 

### Return type

[**DigitalSignatureTransaction**](DigitalSignatureTransaction.md)

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

- **Content-Type**: application/json
- **Accept**: application/json, */*

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The new DST. |  -  |
| **400** | Result of a client passing incorrect or invalid data. |  -  |
| **401** | User authentication was not effective (e.g. not provided, invalid or expired). |  -  |
| **403** | User is not allowed to perform the request. |  -  |
| **404** | The resource was not found. |  -  |
| **409** | Cannot satisfy the request because the resource is in an illegal status. |  -  |
| **500** | Internal failure of the service. |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## RobotIdInstantiatePost

> DigitalSignatureTransaction RobotIdInstantiatePost (Guid id, InstantiateDSTTemplate instantiateDSTTemplate)

Instantiate a DST from a template by robot

This API allows to instantiate a DST from a template patching parts of its data structure. 

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class RobotIdInstantiatePostExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RobotsApi(Configuration.Default);
            var id = new Guid(); // Guid | The value of _the unique id_
            var instantiateDSTTemplate = new InstantiateDSTTemplate(); // InstantiateDSTTemplate | 

            try
            {
                // Instantiate a DST from a template by robot
                DigitalSignatureTransaction result = apiInstance.RobotIdInstantiatePost(id, instantiateDSTTemplate);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling RobotsApi.RobotIdInstantiatePost: " + e.Message );
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
 **instantiateDSTTemplate** | [**InstantiateDSTTemplate**](InstantiateDSTTemplate.md)|  | 

### Return type

[**DigitalSignatureTransaction**](DigitalSignatureTransaction.md)

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

- **Content-Type**: application/json
- **Accept**: application/json, */*

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The new DST that has been generated as an instance of the template. |  -  |
| **401** | User authentication was not effective (e.g. not provided, invalid or expired). |  -  |
| **403** | User is not allowed to perform the request. |  -  |
| **404** | The resource was not found. |  -  |
| **409** | Cannot satisfy the request because the resource is in an illegal status. |  -  |
| **500** | Internal failure of the service. |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)

