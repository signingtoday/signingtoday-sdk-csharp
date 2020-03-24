# SigningToday.Api.SigningServicesApi

All URIs are relative to *https://web.sandbox.signingtoday.com/api*

Method | HTTP request | Description
------------- | ------------- | -------------
[**SignServiceOpen**](SigningServicesApi.md#signserviceopen) | **POST** /sign-service/open | sign-service open post
[**SignServiceOpenId**](SigningServicesApi.md#signserviceopenid) | **POST** /sign-service/open/{transaction-id} | sign-service-open-transaction-id post
[**SignatureIdPerformIdPost**](SigningServicesApi.md#signatureidperformidpost) | **POST** /sign-service/{signature-id}/perform/{identity-id} | sign-service-signature-id-perform-identity-id post



## SignServiceOpen

> Object SignServiceOpen ()

sign-service open post

description bla bla

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class SignServiceOpenExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SigningServicesApi(Configuration.Default);

            try
            {
                // sign-service open post
                Object result = apiInstance.SignServiceOpen();
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling SigningServicesApi.SignServiceOpen: " + e.Message );
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

**Object**

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## SignServiceOpenId

> Object SignServiceOpenId (string transactionId)

sign-service-open-transaction-id post

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class SignServiceOpenIdExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SigningServicesApi(Configuration.Default);
            var transactionId = transactionId_example;  // string | 

            try
            {
                // sign-service-open-transaction-id post
                Object result = apiInstance.SignServiceOpenId(transactionId);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling SigningServicesApi.SignServiceOpenId: " + e.Message );
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
 **transactionId** | **string**|  | 

### Return type

**Object**

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json, */*

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **401** | User authentication was not effective (e.g. not provided, invalid or expired). |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## SignatureIdPerformIdPost

> Object SignatureIdPerformIdPost (string signatureId, string identityId, InlineObject8 inlineObject8 = null)

sign-service-signature-id-perform-identity-id post

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class SignatureIdPerformIdPostExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SigningServicesApi(Configuration.Default);
            var signatureId = signatureId_example;  // string | 
            var identityId = 737dc132-a3f0-11e9-a2a3-2a2ae2dbcce4;  // string | 
            var inlineObject8 = new InlineObject8(); // InlineObject8 |  (optional) 

            try
            {
                // sign-service-signature-id-perform-identity-id post
                Object result = apiInstance.SignatureIdPerformIdPost(signatureId, identityId, inlineObject8);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling SigningServicesApi.SignatureIdPerformIdPost: " + e.Message );
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
 **signatureId** | **string**|  | 
 **identityId** | **string**|  | 
 **inlineObject8** | [**InlineObject8**](InlineObject8.md)|  | [optional] 

### Return type

**Object**

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

- **Content-Type**: application/json
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)

