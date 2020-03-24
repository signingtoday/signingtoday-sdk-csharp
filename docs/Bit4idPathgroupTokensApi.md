# SigningToday.Api.Bit4idPathgroupTokensApi

All URIs are relative to *https://sandbox.signingtoday.com/api/v1*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateToken**](Bit4idPathgroupTokensApi.md#createtoken) | **POST** /{organization-id}/tokens | Create an application token
[**DeleteToken**](Bit4idPathgroupTokensApi.md#deletetoken) | **DELETE** /{organization-id}/tokens/{token-id} | Delete a token of the organization
[**GetToken**](Bit4idPathgroupTokensApi.md#gettoken) | **GET** /{organization-id}/tokens/{token-id} | Get information about a token
[**ListTokens**](Bit4idPathgroupTokensApi.md#listtokens) | **GET** /{organization-id}/tokens | Enumerate the tokens of an organization
[**ListUserTokens**](Bit4idPathgroupTokensApi.md#listusertokens) | **GET** /{organization-id}/users/{user-id}/tokens | Enumerate the tokens of an user
[**UpdateToken**](Bit4idPathgroupTokensApi.md#updatetoken) | **PUT** /{organization-id}/tokens/{token-id} | Update the properties of a token



## CreateToken

> InlineResponse2015 CreateToken (string organizationId, CreateToken createToken)

Create an application token

This API allows to create an application token. 

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class CreateTokenExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://sandbox.signingtoday.com/api/v1";
            // Configure API key authorization: ApiKeyAuth
            Configuration.Default.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new Bit4idPathgroupTokensApi(Configuration.Default);
            var organizationId = api-demo;  // string | The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization  (default to "api-demo")
            var createToken = new CreateToken(); // CreateToken | Token data

            try
            {
                // Create an application token
                InlineResponse2015 result = apiInstance.CreateToken(organizationId, createToken);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling Bit4idPathgroupTokensApi.CreateToken: " + e.Message );
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
 **organizationId** | **string**| The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization  | [default to &quot;api-demo&quot;]
 **createToken** | [**CreateToken**](CreateToken.md)| Token data | 

### Return type

[**InlineResponse2015**](InlineResponse2015.md)

### Authorization

[ApiKeyAuth](../README.md#ApiKeyAuth)

### HTTP request headers

- **Content-Type**: application/json
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Created |  -  |
| **400** | Bad Request |  -  |
| **401** | Unauthorized |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## DeleteToken

> InlineResponse2012 DeleteToken (string organizationId, Id tokenId)

Delete a token of the organization

This API allows to delete a token of the organization. 

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class DeleteTokenExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://sandbox.signingtoday.com/api/v1";
            // Configure API key authorization: ApiKeyAuth
            Configuration.Default.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new Bit4idPathgroupTokensApi(Configuration.Default);
            var organizationId = api-demo;  // string | The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization  (default to "api-demo")
            var tokenId = new Id(); // Id | The **token-id** is the uuid code that identifies a token. It is, as well, used to restrict the requested operation to the scope of that token 

            try
            {
                // Delete a token of the organization
                InlineResponse2012 result = apiInstance.DeleteToken(organizationId, tokenId);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling Bit4idPathgroupTokensApi.DeleteToken: " + e.Message );
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
 **organizationId** | **string**| The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization  | [default to &quot;api-demo&quot;]
 **tokenId** | [**Id**](Id.md)| The **token-id** is the uuid code that identifies a token. It is, as well, used to restrict the requested operation to the scope of that token  | 

### Return type

[**InlineResponse2012**](InlineResponse2012.md)

### Authorization

[ApiKeyAuth](../README.md#ApiKeyAuth)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **401** | Unauthorized |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## GetToken

> InlineResponse2015 GetToken (string organizationId, Id tokenId)

Get information about a token

This API allows to get information about a token. 

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class GetTokenExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://sandbox.signingtoday.com/api/v1";
            // Configure API key authorization: ApiKeyAuth
            Configuration.Default.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new Bit4idPathgroupTokensApi(Configuration.Default);
            var organizationId = api-demo;  // string | The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization  (default to "api-demo")
            var tokenId = new Id(); // Id | The **token-id** is the uuid code that identifies a token. It is, as well, used to restrict the requested operation to the scope of that token 

            try
            {
                // Get information about a token
                InlineResponse2015 result = apiInstance.GetToken(organizationId, tokenId);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling Bit4idPathgroupTokensApi.GetToken: " + e.Message );
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
 **organizationId** | **string**| The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization  | [default to &quot;api-demo&quot;]
 **tokenId** | [**Id**](Id.md)| The **token-id** is the uuid code that identifies a token. It is, as well, used to restrict the requested operation to the scope of that token  | 

### Return type

[**InlineResponse2015**](InlineResponse2015.md)

### Authorization

[ApiKeyAuth](../README.md#ApiKeyAuth)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **401** | Unauthorized |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## ListTokens

> InlineResponse2004 ListTokens (string organizationId, string whereUser = null, string whereLabel = null, int count = null, int page = null, string whereOrder = null)

Enumerate the tokens of an organization

This API allows to enumerate the tokens of an organization. 

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class ListTokensExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://sandbox.signingtoday.com/api/v1";
            // Configure API key authorization: ApiKeyAuth
            Configuration.Default.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new Bit4idPathgroupTokensApi(Configuration.Default);
            var organizationId = api-demo;  // string | The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization  (default to "api-demo")
            var whereUser = jdo;  // string | Returns the tokens of the specified user, searched by its id (optional) 
            var whereLabel = token;  // string | Returns the tokens with the specified label (optional) 
            var count = 56;  // int | Sets the number of tokens per page to display (optional)  (default to 100)
            var page = 1;  // int | Restricts the search to chosen page (optional) 
            var whereOrder = where_first_name;  // string | The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \"**-**\" in front of the value indicates descending order), then the second value and so on (optional) 

            try
            {
                // Enumerate the tokens of an organization
                InlineResponse2004 result = apiInstance.ListTokens(organizationId, whereUser, whereLabel, count, page, whereOrder);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling Bit4idPathgroupTokensApi.ListTokens: " + e.Message );
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
 **organizationId** | **string**| The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization  | [default to &quot;api-demo&quot;]
 **whereUser** | **string**| Returns the tokens of the specified user, searched by its id | [optional] 
 **whereLabel** | **string**| Returns the tokens with the specified label | [optional] 
 **count** | **int**| Sets the number of tokens per page to display | [optional] [default to 100]
 **page** | **int**| Restricts the search to chosen page | [optional] 
 **whereOrder** | **string**| The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on | [optional] 

### Return type

[**InlineResponse2004**](InlineResponse2004.md)

### Authorization

[ApiKeyAuth](../README.md#ApiKeyAuth)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **401** | Unauthorized |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## ListUserTokens

> InlineResponse2004 ListUserTokens (string organizationId, Id userId, int page = null, int count = null, string whereOrder = null)

Enumerate the tokens of an user

This API allows to enumerate all the tokens of an user. 

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class ListUserTokensExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://sandbox.signingtoday.com/api/v1";
            // Configure API key authorization: ApiKeyAuth
            Configuration.Default.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new Bit4idPathgroupTokensApi(Configuration.Default);
            var organizationId = api-demo;  // string | The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization  (default to "api-demo")
            var userId = new Id(); // Id | The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user 
            var page = 1;  // int | Restricts the search to the chosen page (optional) 
            var count = 56;  // int | Sets the number of users per page to display (optional)  (default to 100)
            var whereOrder = where_first_name;  // string | The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \"**-**\" in front of the value indicates descending order), then the second value and so on (optional) 

            try
            {
                // Enumerate the tokens of an user
                InlineResponse2004 result = apiInstance.ListUserTokens(organizationId, userId, page, count, whereOrder);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling Bit4idPathgroupTokensApi.ListUserTokens: " + e.Message );
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
 **organizationId** | **string**| The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization  | [default to &quot;api-demo&quot;]
 **userId** | [**Id**](Id.md)| The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user  | 
 **page** | **int**| Restricts the search to the chosen page | [optional] 
 **count** | **int**| Sets the number of users per page to display | [optional] [default to 100]
 **whereOrder** | **string**| The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on | [optional] 

### Return type

[**InlineResponse2004**](InlineResponse2004.md)

### Authorization

[ApiKeyAuth](../README.md#ApiKeyAuth)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **401** | Unauthorized |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## UpdateToken

> InlineResponse2015 UpdateToken (string organizationId, Id tokenId, UpdateToken updateToken)

Update the properties of a token

This API allows to update the properties of a token. 

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class UpdateTokenExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://sandbox.signingtoday.com/api/v1";
            // Configure API key authorization: ApiKeyAuth
            Configuration.Default.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new Bit4idPathgroupTokensApi(Configuration.Default);
            var organizationId = api-demo;  // string | The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization  (default to "api-demo")
            var tokenId = new Id(); // Id | The **token-id** is the uuid code that identifies a token. It is, as well, used to restrict the requested operation to the scope of that token 
            var updateToken = new UpdateToken(); // UpdateToken | Token data

            try
            {
                // Update the properties of a token
                InlineResponse2015 result = apiInstance.UpdateToken(organizationId, tokenId, updateToken);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling Bit4idPathgroupTokensApi.UpdateToken: " + e.Message );
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
 **organizationId** | **string**| The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization  | [default to &quot;api-demo&quot;]
 **tokenId** | [**Id**](Id.md)| The **token-id** is the uuid code that identifies a token. It is, as well, used to restrict the requested operation to the scope of that token  | 
 **updateToken** | [**UpdateToken**](UpdateToken.md)| Token data | 

### Return type

[**InlineResponse2015**](InlineResponse2015.md)

### Authorization

[ApiKeyAuth](../README.md#ApiKeyAuth)

### HTTP request headers

- **Content-Type**: application/json
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **401** | Unauthorized |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)

