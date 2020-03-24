# SigningToday.Api.Bit4idPathgroupIdentitiesApi

All URIs are relative to *https://sandbox.signingtoday.com/api/v1*

Method | HTTP request | Description
------------- | ------------- | -------------
[**AssociateAppearance**](Bit4idPathgroupIdentitiesApi.md#associateappearance) | **POST** /{organization-id}/identities/{identity-id}/appearance | Associate an appearance to an identity
[**AssociateIdentity**](Bit4idPathgroupIdentitiesApi.md#associateidentity) | **POST** /{organization-id}/users/{user-id}/wallet | Associate to an user an already existing identity
[**CreateTokenFromIdentity**](Bit4idPathgroupIdentitiesApi.md#createtokenfromidentity) | **POST** /{organization-id}/identities/create/token | Create an identity from token
[**DeleteAppearance**](Bit4idPathgroupIdentitiesApi.md#deleteappearance) | **DELETE** /{organization-id}/identities/{identity-id}/appearance | Delete the appearance of an identity
[**DeleteEnrollmentRequest**](Bit4idPathgroupIdentitiesApi.md#deleteenrollmentrequest) | **DELETE** /{organization-id}/identity-requests/{enrollment-id} | Delete an enrollment request
[**DeleteIdentity**](Bit4idPathgroupIdentitiesApi.md#deleteidentity) | **DELETE** /{organization-id}/identities/{identity-id} | Delete an identity
[**GetEnrollmentRequest**](Bit4idPathgroupIdentitiesApi.md#getenrollmentrequest) | **GET** /{organization-id}/identity-requests/{enrollment-id} | Get information about an enrollment request
[**GetIdentity**](Bit4idPathgroupIdentitiesApi.md#getidentity) | **GET** /{organization-id}/identities/{identity-id} | Get information about an identity
[**ListEnrollmentRequests**](Bit4idPathgroupIdentitiesApi.md#listenrollmentrequests) | **GET** /{organization-id}/identity-requests | Enumerate the enrollment requests of an organization
[**ListIdentities**](Bit4idPathgroupIdentitiesApi.md#listidentities) | **GET** /{organization-id}/identities | Enumerate the identities of an organization
[**ListUserEnrollments**](Bit4idPathgroupIdentitiesApi.md#listuserenrollments) | **GET** /{organization-id}/users/{user-id}/identity-requests | List the enrollments of an user
[**ListUserIdentities**](Bit4idPathgroupIdentitiesApi.md#listuseridentities) | **GET** /{organization-id}/users/{user-id}/wallet | Enumerate the identities of an user
[**RenewIdentity**](Bit4idPathgroupIdentitiesApi.md#renewidentity) | **POST** /{organization-id}/identity-requests/{enrollment-id}/renew | Renew an Identity
[**RequestEnrollment**](Bit4idPathgroupIdentitiesApi.md#requestenrollment) | **POST** /{organization-id}/enroll | Submit an enrollment request



## AssociateAppearance

> InlineResponse2011 AssociateAppearance (string organizationId, Id identityId, InlineObject inlineObject)

Associate an appearance to an identity

Associate a signature appearance to an already existing identity through an url to an image. This appearance will be displayed on the document after the signature. 

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class AssociateAppearanceExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://sandbox.signingtoday.com/api/v1";
            // Configure API key authorization: ApiKeyAuth
            Configuration.Default.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new Bit4idPathgroupIdentitiesApi(Configuration.Default);
            var organizationId = api-demo;  // string | The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization  (default to "api-demo")
            var identityId = new Id(); // Id | The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity 
            var inlineObject = new InlineObject(); // InlineObject | 

            try
            {
                // Associate an appearance to an identity
                InlineResponse2011 result = apiInstance.AssociateAppearance(organizationId, identityId, inlineObject);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling Bit4idPathgroupIdentitiesApi.AssociateAppearance: " + e.Message );
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
 **identityId** | [**Id**](Id.md)| The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity  | 
 **inlineObject** | [**InlineObject**](InlineObject.md)|  | 

### Return type

[**InlineResponse2011**](InlineResponse2011.md)

### Authorization

[ApiKeyAuth](../README.md#ApiKeyAuth)

### HTTP request headers

- **Content-Type**: application/json
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **400** | Bad Request |  -  |
| **401** | Unauthorized |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## AssociateIdentity

> InlineResponse2011 AssociateIdentity (string organizationId, Id userId, IdentityAssociation identityAssociation)

Associate to an user an already existing identity

Associate to an user of the organization an already existing identity of a provider. The _provider_data_ field is an object and is different for each provider. The minimum set of information to provide as provider_data is the following:   - **aruba**     - _auth_domain_ : string     - _username_ : string     - _password_ : string   - **aruba-auto**     - _auth_domain_ : string     - _username_ : string     - _password_ : string   - **infocert**     - _username_ : string     - _password_ : string   - **namirial**     - _id_titolare_ : string     - _id_otp_ : string     - _username_ : string     - _password_ : string 

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class AssociateIdentityExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://sandbox.signingtoday.com/api/v1";
            // Configure API key authorization: ApiKeyAuth
            Configuration.Default.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new Bit4idPathgroupIdentitiesApi(Configuration.Default);
            var organizationId = api-demo;  // string | The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization  (default to "api-demo")
            var userId = new Id(); // Id | The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user 
            var identityAssociation = new IdentityAssociation(); // IdentityAssociation | Provider data to associate

            try
            {
                // Associate to an user an already existing identity
                InlineResponse2011 result = apiInstance.AssociateIdentity(organizationId, userId, identityAssociation);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling Bit4idPathgroupIdentitiesApi.AssociateIdentity: " + e.Message );
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
 **identityAssociation** | [**IdentityAssociation**](IdentityAssociation.md)| Provider data to associate | 

### Return type

[**InlineResponse2011**](InlineResponse2011.md)

### Authorization

[ApiKeyAuth](../README.md#ApiKeyAuth)

### HTTP request headers

- **Content-Type**: application/json
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Created |  -  |
| **401** | Unauthorized |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## CreateTokenFromIdentity

> InlineResponse2012 CreateTokenFromIdentity (string organizationId, CreateIdentitybyToken createIdentitybyToken)

Create an identity from token

This API allows to create an identity from a token. 

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class CreateTokenFromIdentityExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://sandbox.signingtoday.com/api/v1";
            // Configure API key authorization: ApiKeyAuth
            Configuration.Default.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new Bit4idPathgroupIdentitiesApi(Configuration.Default);
            var organizationId = api-demo;  // string | The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization  (default to "api-demo")
            var createIdentitybyToken = new CreateIdentitybyToken(); // CreateIdentitybyToken | Body of the request to create an identity from a token

            try
            {
                // Create an identity from token
                InlineResponse2012 result = apiInstance.CreateTokenFromIdentity(organizationId, createIdentitybyToken);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling Bit4idPathgroupIdentitiesApi.CreateTokenFromIdentity: " + e.Message );
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
 **createIdentitybyToken** | [**CreateIdentitybyToken**](CreateIdentitybyToken.md)| Body of the request to create an identity from a token | 

### Return type

[**InlineResponse2012**](InlineResponse2012.md)

### Authorization

[ApiKeyAuth](../README.md#ApiKeyAuth)

### HTTP request headers

- **Content-Type**: application/json
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Created |  -  |
| **401** | Unauthorized |  -  |
| **403** | Forbidden |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## DeleteAppearance

> InlineResponse2011 DeleteAppearance (string organizationId, Id identityId)

Delete the appearance of an identity

This API allows to delete the appearance associated to an identity. 

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class DeleteAppearanceExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://sandbox.signingtoday.com/api/v1";
            // Configure API key authorization: ApiKeyAuth
            Configuration.Default.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new Bit4idPathgroupIdentitiesApi(Configuration.Default);
            var organizationId = api-demo;  // string | The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization  (default to "api-demo")
            var identityId = new Id(); // Id | The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity 

            try
            {
                // Delete the appearance of an identity
                InlineResponse2011 result = apiInstance.DeleteAppearance(organizationId, identityId);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling Bit4idPathgroupIdentitiesApi.DeleteAppearance: " + e.Message );
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
 **identityId** | [**Id**](Id.md)| The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity  | 

### Return type

[**InlineResponse2011**](InlineResponse2011.md)

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


## DeleteEnrollmentRequest

> InlineResponse2012 DeleteEnrollmentRequest (string organizationId, Id enrollmentId)

Delete an enrollment request

This API allows to delete an enrollment request. 

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class DeleteEnrollmentRequestExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://sandbox.signingtoday.com/api/v1";
            // Configure API key authorization: ApiKeyAuth
            Configuration.Default.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new Bit4idPathgroupIdentitiesApi(Configuration.Default);
            var organizationId = api-demo;  // string | The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization  (default to "api-demo")
            var enrollmentId = new Id(); // Id | The **enrollment-id** is the uuid code that identifies a specific enrollment request 

            try
            {
                // Delete an enrollment request
                InlineResponse2012 result = apiInstance.DeleteEnrollmentRequest(organizationId, enrollmentId);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling Bit4idPathgroupIdentitiesApi.DeleteEnrollmentRequest: " + e.Message );
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
 **enrollmentId** | [**Id**](Id.md)| The **enrollment-id** is the uuid code that identifies a specific enrollment request  | 

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


## DeleteIdentity

> InlineResponse2006 DeleteIdentity (string organizationId, Id identityId)

Delete an identity

This API allows to delete an identity of an user. 

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class DeleteIdentityExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://sandbox.signingtoday.com/api/v1";
            // Configure API key authorization: ApiKeyAuth
            Configuration.Default.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new Bit4idPathgroupIdentitiesApi(Configuration.Default);
            var organizationId = api-demo;  // string | The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization  (default to "api-demo")
            var identityId = new Id(); // Id | The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity 

            try
            {
                // Delete an identity
                InlineResponse2006 result = apiInstance.DeleteIdentity(organizationId, identityId);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling Bit4idPathgroupIdentitiesApi.DeleteIdentity: " + e.Message );
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
 **identityId** | [**Id**](Id.md)| The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity  | 

### Return type

[**InlineResponse2006**](InlineResponse2006.md)

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


## GetEnrollmentRequest

> InlineResponse2007 GetEnrollmentRequest (string organizationId, Id enrollmentId)

Get information about an enrollment request

This API allows to get information about an enrollment request. 

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class GetEnrollmentRequestExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://sandbox.signingtoday.com/api/v1";
            // Configure API key authorization: ApiKeyAuth
            Configuration.Default.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new Bit4idPathgroupIdentitiesApi(Configuration.Default);
            var organizationId = api-demo;  // string | The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization  (default to "api-demo")
            var enrollmentId = new Id(); // Id | The **enrollment-id** is the uuid code that identifies a specific enrollment request 

            try
            {
                // Get information about an enrollment request
                InlineResponse2007 result = apiInstance.GetEnrollmentRequest(organizationId, enrollmentId);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling Bit4idPathgroupIdentitiesApi.GetEnrollmentRequest: " + e.Message );
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
 **enrollmentId** | [**Id**](Id.md)| The **enrollment-id** is the uuid code that identifies a specific enrollment request  | 

### Return type

[**InlineResponse2007**](InlineResponse2007.md)

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


## GetIdentity

> InlineResponse2005 GetIdentity (string organizationId, Id identityId, string whereOrder = null)

Get information about an identity

This API allows to get all the information of an identity. 

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class GetIdentityExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://sandbox.signingtoday.com/api/v1";
            // Configure API key authorization: ApiKeyAuth
            Configuration.Default.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new Bit4idPathgroupIdentitiesApi(Configuration.Default);
            var organizationId = api-demo;  // string | The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization  (default to "api-demo")
            var identityId = new Id(); // Id | The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity 
            var whereOrder = where_first_name;  // string | The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \"**-**\" in front of the value indicates descending order), then the second value and so on (optional) 

            try
            {
                // Get information about an identity
                InlineResponse2005 result = apiInstance.GetIdentity(organizationId, identityId, whereOrder);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling Bit4idPathgroupIdentitiesApi.GetIdentity: " + e.Message );
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
 **identityId** | [**Id**](Id.md)| The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity  | 
 **whereOrder** | **string**| The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on | [optional] 

### Return type

[**InlineResponse2005**](InlineResponse2005.md)

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


## ListEnrollmentRequests

> InlineResponse2003 ListEnrollmentRequests (string organizationId, string whereProvider = null, string whereUser = null, string whereFirstName = null, string whereLastName = null, string whereRegisteredBy = null, string whereFiscalCode = null, int page = null, int count = null, string whereOrder = null)

Enumerate the enrollment requests of an organization

This API allows to enumerate the enrollment requests of an organization. 

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class ListEnrollmentRequestsExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://sandbox.signingtoday.com/api/v1";
            // Configure API key authorization: ApiKeyAuth
            Configuration.Default.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new Bit4idPathgroupIdentitiesApi(Configuration.Default);
            var organizationId = api-demo;  // string | The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization  (default to "api-demo")
            var whereProvider = sms;  // string | Returns the identity requests that have been issued by the specified provider (optional) 
            var whereUser = msa;  // string | Returns the identity requests of the specified user, searched by its id (optional) 
            var whereFirstName = John;  // string | Returns the identity requests of the users that have the specified first name (optional) 
            var whereLastName = Doe;  // string | Returns the identity requests of the users that have the specified last name (optional) 
            var whereRegisteredBy = fba;  // string | Returns the identity requests registered by this user (optional) 
            var whereFiscalCode = MLLSNT82P65Z404U;  // string | Returns the identity requests have the specified fiscal code (optional) 
            var page = 1;  // int | Restricts the search to the chosen page (optional) 
            var count = 56;  // int | Sets the number of users per page to display (optional)  (default to 100)
            var whereOrder = where_first_name;  // string | The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \"**-**\" in front of the value indicates descending order), then the second value and so on (optional) 

            try
            {
                // Enumerate the enrollment requests of an organization
                InlineResponse2003 result = apiInstance.ListEnrollmentRequests(organizationId, whereProvider, whereUser, whereFirstName, whereLastName, whereRegisteredBy, whereFiscalCode, page, count, whereOrder);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling Bit4idPathgroupIdentitiesApi.ListEnrollmentRequests: " + e.Message );
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
 **whereProvider** | **string**| Returns the identity requests that have been issued by the specified provider | [optional] 
 **whereUser** | **string**| Returns the identity requests of the specified user, searched by its id | [optional] 
 **whereFirstName** | **string**| Returns the identity requests of the users that have the specified first name | [optional] 
 **whereLastName** | **string**| Returns the identity requests of the users that have the specified last name | [optional] 
 **whereRegisteredBy** | **string**| Returns the identity requests registered by this user | [optional] 
 **whereFiscalCode** | **string**| Returns the identity requests have the specified fiscal code | [optional] 
 **page** | **int**| Restricts the search to the chosen page | [optional] 
 **count** | **int**| Sets the number of users per page to display | [optional] [default to 100]
 **whereOrder** | **string**| The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on | [optional] 

### Return type

[**InlineResponse2003**](InlineResponse2003.md)

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


## ListIdentities

> InlineResponse2002 ListIdentities (string organizationId, string whereProvider = null, string whereUser = null, string whereFirstName = null, string whereLastName = null, string whereRegisteredBy = null, string whereFiscalCode = null, int page = null, int count = null, string whereOrder = null)

Enumerate the identities of an organization

This API allows to enumerate all the users of an organization. It is possible to filter the data using the supported _django lookups_. 

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class ListIdentitiesExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://sandbox.signingtoday.com/api/v1";
            // Configure API key authorization: ApiKeyAuth
            Configuration.Default.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new Bit4idPathgroupIdentitiesApi(Configuration.Default);
            var organizationId = api-demo;  // string | The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization  (default to "api-demo")
            var whereProvider = sms;  // string | Returns the identities that have been issued by the specified provider (optional) 
            var whereUser = msa;  // string | Returns the identities of the specified user, searched by its id (optional) 
            var whereFirstName = John;  // string | Returns the identities of the users that have the specified first name (optional) 
            var whereLastName = Doe;  // string | Returns the identities of the users that have the specified last name (optional) 
            var whereRegisteredBy = fba;  // string | Returns the identities registered by this user (optional) 
            var whereFiscalCode = MLLSNT82P65Z404U;  // string | Returns the identities that have the specified fiscal code (optional) 
            var page = 1;  // int | Restricts the search to the chosen page (optional) 
            var count = 56;  // int | Sets the number of users per page to display (optional)  (default to 100)
            var whereOrder = where_first_name;  // string | The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \"**-**\" in front of the value indicates descending order), then the second value and so on (optional) 

            try
            {
                // Enumerate the identities of an organization
                InlineResponse2002 result = apiInstance.ListIdentities(organizationId, whereProvider, whereUser, whereFirstName, whereLastName, whereRegisteredBy, whereFiscalCode, page, count, whereOrder);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling Bit4idPathgroupIdentitiesApi.ListIdentities: " + e.Message );
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
 **whereProvider** | **string**| Returns the identities that have been issued by the specified provider | [optional] 
 **whereUser** | **string**| Returns the identities of the specified user, searched by its id | [optional] 
 **whereFirstName** | **string**| Returns the identities of the users that have the specified first name | [optional] 
 **whereLastName** | **string**| Returns the identities of the users that have the specified last name | [optional] 
 **whereRegisteredBy** | **string**| Returns the identities registered by this user | [optional] 
 **whereFiscalCode** | **string**| Returns the identities that have the specified fiscal code | [optional] 
 **page** | **int**| Restricts the search to the chosen page | [optional] 
 **count** | **int**| Sets the number of users per page to display | [optional] [default to 100]
 **whereOrder** | **string**| The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on | [optional] 

### Return type

[**InlineResponse2002**](InlineResponse2002.md)

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


## ListUserEnrollments

> InlineResponse2003 ListUserEnrollments (string organizationId, Id userId, int page = null, int count = null, string whereOrder = null)

List the enrollments of an user

This API allows to list all the enrollments of an user. 

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class ListUserEnrollmentsExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://sandbox.signingtoday.com/api/v1";
            // Configure API key authorization: ApiKeyAuth
            Configuration.Default.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new Bit4idPathgroupIdentitiesApi(Configuration.Default);
            var organizationId = api-demo;  // string | The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization  (default to "api-demo")
            var userId = new Id(); // Id | The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user 
            var page = 1;  // int | Restricts the search to the chosen page (optional) 
            var count = 56;  // int | Sets the number of users per page to display (optional)  (default to 100)
            var whereOrder = where_first_name;  // string | The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \"**-**\" in front of the value indicates descending order), then the second value and so on (optional) 

            try
            {
                // List the enrollments of an user
                InlineResponse2003 result = apiInstance.ListUserEnrollments(organizationId, userId, page, count, whereOrder);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling Bit4idPathgroupIdentitiesApi.ListUserEnrollments: " + e.Message );
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

[**InlineResponse2003**](InlineResponse2003.md)

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


## ListUserIdentities

> InlineResponse2002 ListUserIdentities (string organizationId, Id userId, int page = null, int count = null, string whereOrder = null)

Enumerate the identities of an user

This API allows to enumerate all the identities of an user, which are located in its wallet. 

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class ListUserIdentitiesExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://sandbox.signingtoday.com/api/v1";
            // Configure API key authorization: ApiKeyAuth
            Configuration.Default.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new Bit4idPathgroupIdentitiesApi(Configuration.Default);
            var organizationId = api-demo;  // string | The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization  (default to "api-demo")
            var userId = new Id(); // Id | The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user 
            var page = 1;  // int | Restricts the search to the chosen page (optional) 
            var count = 56;  // int | Sets the number of users per page to display (optional)  (default to 100)
            var whereOrder = where_first_name;  // string | The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \"**-**\" in front of the value indicates descending order), then the second value and so on (optional) 

            try
            {
                // Enumerate the identities of an user
                InlineResponse2002 result = apiInstance.ListUserIdentities(organizationId, userId, page, count, whereOrder);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling Bit4idPathgroupIdentitiesApi.ListUserIdentities: " + e.Message );
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

[**InlineResponse2002**](InlineResponse2002.md)

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


## RenewIdentity

> InlineResponse2007 RenewIdentity (string organizationId, Id enrollmentId, InlineObject1 inlineObject1)

Renew an Identity

This API allows to renew an Identity of a user. 

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class RenewIdentityExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://sandbox.signingtoday.com/api/v1";
            // Configure API key authorization: ApiKeyAuth
            Configuration.Default.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new Bit4idPathgroupIdentitiesApi(Configuration.Default);
            var organizationId = api-demo;  // string | The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization  (default to "api-demo")
            var enrollmentId = new Id(); // Id | The **enrollment-id** is the uuid code that identifies a specific enrollment request 
            var inlineObject1 = new InlineObject1(); // InlineObject1 | 

            try
            {
                // Renew an Identity
                InlineResponse2007 result = apiInstance.RenewIdentity(organizationId, enrollmentId, inlineObject1);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling Bit4idPathgroupIdentitiesApi.RenewIdentity: " + e.Message );
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
 **enrollmentId** | [**Id**](Id.md)| The **enrollment-id** is the uuid code that identifies a specific enrollment request  | 
 **inlineObject1** | [**InlineObject1**](InlineObject1.md)|  | 

### Return type

[**InlineResponse2007**](InlineResponse2007.md)

### Authorization

[ApiKeyAuth](../README.md#ApiKeyAuth)

### HTTP request headers

- **Content-Type**: application/json
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |
| **400** | Bad Request |  -  |
| **401** | Unauthorized |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## RequestEnrollment

> InlineResponse2007 RequestEnrollment (string organizationId, IdentityRequest identityRequest)

Submit an enrollment request

This API allows to submit an enrollment request. The user of the request will be created if it does not exists already. 

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class RequestEnrollmentExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://sandbox.signingtoday.com/api/v1";
            // Configure API key authorization: ApiKeyAuth
            Configuration.Default.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new Bit4idPathgroupIdentitiesApi(Configuration.Default);
            var organizationId = api-demo;  // string | The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization  (default to "api-demo")
            var identityRequest = new IdentityRequest(); // IdentityRequest | The enrollment request to submit

            try
            {
                // Submit an enrollment request
                InlineResponse2007 result = apiInstance.RequestEnrollment(organizationId, identityRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling Bit4idPathgroupIdentitiesApi.RequestEnrollment: " + e.Message );
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
 **identityRequest** | [**IdentityRequest**](IdentityRequest.md)| The enrollment request to submit | 

### Return type

[**InlineResponse2007**](InlineResponse2007.md)

### Authorization

[ApiKeyAuth](../README.md#ApiKeyAuth)

### HTTP request headers

- **Content-Type**: application/json
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Created |  -  |
| **401** | Unauthorized |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **409** | Conflict |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)

