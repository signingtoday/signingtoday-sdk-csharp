# SigningToday.Api.RobotApi

All URIs are relative to *https://web.sandbox.signingtoday.com/api*

Method | HTTP request | Description
------------- | ------------- | -------------
[**RobotConfigurationPut**](RobotApi.md#robotconfigurationput) | **PUT** /robot/configuration | Edit the Robot configuration



## RobotConfigurationPut

> void RobotConfigurationPut (RobotConfiguration robotConfiguration, string username = null, string domain = null)

Edit the Robot configuration

This API allows to edit the Robot configuration. 

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class RobotConfigurationPutExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RobotApi(Configuration.Default);
            var robotConfiguration = new RobotConfiguration(); // RobotConfiguration | RobotConfiguration.
            var username = thirdPartApp;  // string | The _username_ associated to the account (optional) 
            var domain = demo;  // string | The _domain_ associated to the account (optional) 

            try
            {
                // Edit the Robot configuration
                apiInstance.RobotConfigurationPut(robotConfiguration, username, domain);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling RobotApi.RobotConfigurationPut: " + e.Message );
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
 **robotConfiguration** | [**RobotConfiguration**](RobotConfiguration.md)| RobotConfiguration. | 
 **username** | **string**| The _username_ associated to the account | [optional] 
 **domain** | **string**| The _domain_ associated to the account | [optional] 

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
| **500** | Internal failure of the service. |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)

