# SigningToday.Api.Bit4idPathgroupServicesApi

All URIs are relative to *https://web.sandbox.signingtoday.com/api*

Method | HTTP request | Description
------------- | ------------- | -------------
[**AuthChangePasswordPost**](Bit4idPathgroupServicesApi.md#authchangepasswordpost) | **POST** /auth/changePassword | Consume a token to change the password
[**AuthPasswordLostGet**](Bit4idPathgroupServicesApi.md#authpasswordlostget) | **GET** /auth/passwordLost | Request to recover own password
[**AuthPasswordResetGet**](Bit4idPathgroupServicesApi.md#authpasswordresetget) | **GET** /auth/passwordReset | Reset a user password with superuser
[**AuthPasswordResetPost**](Bit4idPathgroupServicesApi.md#authpasswordresetpost) | **POST** /auth/passwordReset | Reset your own password
[**AuthPasswordTokenGet**](Bit4idPathgroupServicesApi.md#authpasswordtokenget) | **GET** /auth/passwordToken | Get token to change password
[**AuthSamlPost**](Bit4idPathgroupServicesApi.md#authsamlpost) | **POST** /auth/saml | Register or Update a SAML user
[**AuthUser**](Bit4idPathgroupServicesApi.md#authuser) | **GET** /auth/user | Return the current logged in user
[**ConfigurationGet**](Bit4idPathgroupServicesApi.md#configurationget) | **GET** /service/configuration | Retrieve the App configuration
[**LogoutUser**](Bit4idPathgroupServicesApi.md#logoutuser) | **GET** /auth/logout | Log out current user terminating the session
[**OauthTokenPost**](Bit4idPathgroupServicesApi.md#oauthtokenpost) | **POST** /oauth/token | Get the bearer token
[**PdfResourceIdThumbsGet**](Bit4idPathgroupServicesApi.md#pdfresourceidthumbsget) | **GET** /pdfResource/{id}/thumbs | Retrieve a Resource (of service)
[**ServiceChangePasswordPost**](Bit4idPathgroupServicesApi.md#servicechangepasswordpost) | **POST** /service/changePassword | Change the password of a service user
[**ServiceUsersSyncPost**](Bit4idPathgroupServicesApi.md#serviceuserssyncpost) | **POST** /service/users/sync | Sync user accounts



## AuthChangePasswordPost

> void AuthChangePasswordPost (string passwordToken, string body)

Consume a token to change the password

This API allows to change the password by consuming a token.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class AuthChangePasswordPostExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            var apiInstance = new Bit4idPathgroupServicesApi(Configuration.Default);
            var passwordToken = 05ea656f-df69-49b1-a12b-9bf640c427c2;  // string | The password token issued to change password
            var body = body_example;  // string | New password associated to the account (BCrypt)

            try
            {
                // Consume a token to change the password
                apiInstance.AuthChangePasswordPost(passwordToken, body);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling Bit4idPathgroupServicesApi.AuthChangePasswordPost: " + e.Message );
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
 **passwordToken** | **string**| The password token issued to change password | 
 **body** | **string**| New password associated to the account (BCrypt) | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: text/plain
- **Accept**: */*

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | The request has been satisfyied. No output. |  -  |
| **409** | Cannot satisfy the request because the resource is in an illegal status. |  -  |
| **500** | Internal failure of the service. |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## AuthPasswordLostGet

> void AuthPasswordLostGet (string username, string domain)

Request to recover own password

This API requests to recover the own password.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class AuthPasswordLostGetExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            var apiInstance = new Bit4idPathgroupServicesApi(Configuration.Default);
            var username = jdo;  // string | Username associated to the account
            var domain = demo;  // string | Domain associated to the account

            try
            {
                // Request to recover own password
                apiInstance.AuthPasswordLostGet(username, domain);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling Bit4idPathgroupServicesApi.AuthPasswordLostGet: " + e.Message );
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
 **username** | **string**| Username associated to the account | 
 **domain** | **string**| Domain associated to the account | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: */*

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | The request has been satisfyied. No output. |  -  |
| **500** | Internal failure of the service. |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## AuthPasswordResetGet

> void AuthPasswordResetGet (string username, string domain)

Reset a user password with superuser

This API allows to reset the password of a user. This is possible when the request is performed with a superuser.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class AuthPasswordResetGetExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new Bit4idPathgroupServicesApi(Configuration.Default);
            var username = jdo;  // string | Username associated to the account
            var domain = demo;  // string | Domain associated to the account

            try
            {
                // Reset a user password with superuser
                apiInstance.AuthPasswordResetGet(username, domain);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling Bit4idPathgroupServicesApi.AuthPasswordResetGet: " + e.Message );
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
 **username** | **string**| Username associated to the account | 
 **domain** | **string**| Domain associated to the account | 

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
| **403** | User is not allowed to perform the request. |  -  |
| **500** | Internal failure of the service. |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## AuthPasswordResetPost

> void AuthPasswordResetPost (InlineObject4 inlineObject4)

Reset your own password

This API allows to reset your own password knowing the previous one with a logged user.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class AuthPasswordResetPostExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new Bit4idPathgroupServicesApi(Configuration.Default);
            var inlineObject4 = new InlineObject4(); // InlineObject4 | 

            try
            {
                // Reset your own password
                apiInstance.AuthPasswordResetPost(inlineObject4);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling Bit4idPathgroupServicesApi.AuthPasswordResetPost: " + e.Message );
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
 **inlineObject4** | [**InlineObject4**](InlineObject4.md)|  | 

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
| **403** | User is not allowed to perform the request. |  -  |
| **500** | Internal failure of the service. |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## AuthPasswordTokenGet

> List&lt;Object&gt; AuthPasswordTokenGet ()

Get token to change password

This API allows to get a password token to use in order to change a password.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class AuthPasswordTokenGetExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new Bit4idPathgroupServicesApi(Configuration.Default);

            try
            {
                // Get token to change password
                List<Object> result = apiInstance.AuthPasswordTokenGet();
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling Bit4idPathgroupServicesApi.AuthPasswordTokenGet: " + e.Message );
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

**List<Object>**

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json, */*

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | A password token associated to the logged user. |  -  |
| **500** | Internal failure of the service. |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## AuthSamlPost

> void AuthSamlPost (string domain, string iDToken1, string iDToken2)

Register or Update a SAML user

This API allows to register or Update a SAML user.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class AuthSamlPostExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            var apiInstance = new Bit4idPathgroupServicesApi(Configuration.Default);
            var domain = domain_example;  // string | SAML domain
            var iDToken1 = iDToken1_example;  // string | The BASE64-encoded SAML Reply in JSON
            var iDToken2 = iDToken2_example;  // string | The Hex-encoded HMAC-SHA256 of the decoded IDToken1

            try
            {
                // Register or Update a SAML user
                apiInstance.AuthSamlPost(domain, iDToken1, iDToken2);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling Bit4idPathgroupServicesApi.AuthSamlPost: " + e.Message );
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
 **domain** | **string**| SAML domain | 
 **iDToken1** | **string**| The BASE64-encoded SAML Reply in JSON | 
 **iDToken2** | **string**| The Hex-encoded HMAC-SHA256 of the decoded IDToken1 | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/x-www-form-urlencoded
- **Accept**: */*

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **303** | Redirect to frontend page with new auth token (Post/Redirect/Get design pattern). |  -  |
| **409** | Cannot satisfy the request because the resource is in an illegal status. |  -  |
| **500** | Internal failure of the service. |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## AuthUser

> User AuthUser ()

Return the current logged in user

This API allows to retrieve the current logged in user.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class AuthUserExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new Bit4idPathgroupServicesApi(Configuration.Default);

            try
            {
                // Return the current logged in user
                User result = apiInstance.AuthUser();
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling Bit4idPathgroupServicesApi.AuthUser: " + e.Message );
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

[**User**](User.md)

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json, */*

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Return current logged in user |  -  |
| **401** | User authentication was not effective (e.g. not provided, invalid or expired). |  -  |
| **500** | Internal failure of the service. |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## ConfigurationGet

> Dictionary&lt;string, Object&gt; ConfigurationGet ()

Retrieve the App configuration

This API allows to get the public configuration associated to the application. 

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class ConfigurationGetExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            var apiInstance = new Bit4idPathgroupServicesApi(Configuration.Default);

            try
            {
                // Retrieve the App configuration
                Dictionary<string, Object> result = apiInstance.ConfigurationGet();
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling Bit4idPathgroupServicesApi.ConfigurationGet: " + e.Message );
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

**Dictionary<string, Object>**

### Authorization

No authorization required

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


## LogoutUser

> void LogoutUser ()

Log out current user terminating the session

This API allows to Log out current user.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class LogoutUserExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new Bit4idPathgroupServicesApi(Configuration.Default);

            try
            {
                // Log out current user terminating the session
                apiInstance.LogoutUser();
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling Bit4idPathgroupServicesApi.LogoutUser: " + e.Message );
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


## OauthTokenPost

> InlineResponse200 OauthTokenPost (string username = null, string password = null, string grantType = null)

Get the bearer token

This API allows to get the token needed to access other APIs through the OAuth2 authentication.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class OauthTokenPostExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure HTTP basic authorization: Basic
            Configuration.Default.Username = "YOUR_USERNAME";
            Configuration.Default.Password = "YOUR_PASSWORD";

            var apiInstance = new Bit4idPathgroupServicesApi(Configuration.Default);
            var username = username_example;  // string | The username in the form _username_@_domain_ where *domain* is the organization the user belongs to (optional) 
            var password = password_example;  // string | This is the actual password of the user (optional) 
            var grantType = grantType_example;  // string | A parameter that indicates the type of the grant in order to perform the basic authentication (optional) 

            try
            {
                // Get the bearer token
                InlineResponse200 result = apiInstance.OauthTokenPost(username, password, grantType);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling Bit4idPathgroupServicesApi.OauthTokenPost: " + e.Message );
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
 **username** | **string**| The username in the form _username_@_domain_ where *domain* is the organization the user belongs to | [optional] 
 **password** | **string**| This is the actual password of the user | [optional] 
 **grantType** | **string**| A parameter that indicates the type of the grant in order to perform the basic authentication | [optional] 

### Return type

[**InlineResponse200**](InlineResponse200.md)

### Authorization

[Basic](../README.md#Basic)

### HTTP request headers

- **Content-Type**: multipart/form-data
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OAuth Access Token |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## PdfResourceIdThumbsGet

> System.IO.Stream PdfResourceIdThumbsGet (Guid id, int page, int width = null)

Retrieve a Resource (of service)

This API allows to extract thumbnails from a PDF Resource.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class PdfResourceIdThumbsGetExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new Bit4idPathgroupServicesApi(Configuration.Default);
            var id = new Guid(); // Guid | The value of _the unique id_
            var page = 1;  // int | The page to retrieve
            var width = 20;  // int | The output image width (optional) 

            try
            {
                // Retrieve a Resource (of service)
                System.IO.Stream result = apiInstance.PdfResourceIdThumbsGet(id, page, width);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling Bit4idPathgroupServicesApi.PdfResourceIdThumbsGet: " + e.Message );
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
 **page** | **int**| The page to retrieve | 
 **width** | **int**| The output image width | [optional] 

### Return type

**System.IO.Stream**

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: image/jpeg, */*

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The output is a raw string. The thumbnails of the page requested for the PDF resource. |  -  |
| **400** | Result of a client passing incorrect or invalid data. |  -  |
| **401** | User authentication was not effective (e.g. not provided, invalid or expired). |  -  |
| **403** | User is not allowed to perform the request. |  -  |
| **404** | The resource was not found. |  -  |
| **500** | Internal failure of the service. |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## ServiceChangePasswordPost

> void ServiceChangePasswordPost (string username, string domain, string body)

Change the password of a service user

This API allows to change the password of a **service user**. 

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class ServiceChangePasswordPostExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new Bit4idPathgroupServicesApi(Configuration.Default);
            var username = jdo;  // string | Username associated to the account
            var domain = demo;  // string | Domain associated to the account
            var body = body_example;  // string | New password associated to the account (BCrypt)

            try
            {
                // Change the password of a service user
                apiInstance.ServiceChangePasswordPost(username, domain, body);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling Bit4idPathgroupServicesApi.ServiceChangePasswordPost: " + e.Message );
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
 **username** | **string**| Username associated to the account | 
 **domain** | **string**| Domain associated to the account | 
 **body** | **string**| New password associated to the account (BCrypt) | 

### Return type

void (empty response body)

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

- **Content-Type**: text/plain
- **Accept**: */*

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | The request has been satisfyied. No output. |  -  |
| **409** | Cannot satisfy the request because the resource is in an illegal status. |  -  |
| **500** | Internal failure of the service. |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## ServiceUsersSyncPost

> UserSyncReport ServiceUsersSyncPost (List<InlineObject> inlineObject)

Sync user accounts

This API allows to sync user accounts.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class ServiceUsersSyncPostExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new Bit4idPathgroupServicesApi(Configuration.Default);
            var inlineObject = new List<InlineObject>(); // List<InlineObject> | User Accounts

            try
            {
                // Sync user accounts
                UserSyncReport result = apiInstance.ServiceUsersSyncPost(inlineObject);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling Bit4idPathgroupServicesApi.ServiceUsersSyncPost: " + e.Message );
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
 **inlineObject** | [**List&lt;InlineObject&gt;**](InlineObject.md)| User Accounts | 

### Return type

[**UserSyncReport**](UserSyncReport.md)

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

- **Content-Type**: application/json
- **Accept**: application/json, */*

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Report of last sync. |  -  |
| **400** | Result of a client passing incorrect or invalid data. |  -  |
| **401** | User authentication was not effective (e.g. not provided, invalid or expired). |  -  |
| **403** | User is not allowed to perform the request. |  -  |
| **500** | Internal failure of the service. |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)

