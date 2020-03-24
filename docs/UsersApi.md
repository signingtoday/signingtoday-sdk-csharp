# SigningToday.Api.UsersApi

All URIs are relative to *https://sandbox.signingtoday.com/api/v1*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateUser**](UsersApi.md#createuser) | **POST** /{organization-id}/users | Create a user of the organization
[**GetUser**](UsersApi.md#getuser) | **GET** /{organization-id}/users/{user-id} | Get information about an user
[**ListUsers**](UsersApi.md#listusers) | **GET** /{organization-id}/users | Enumerate the users of an organization
[**UpdateUser**](UsersApi.md#updateuser) | **PUT** /{organization-id}/users/{user-id} | Edit one or more user properties



## CreateUser

> InlineResponse201 CreateUser (string organizationId, CreateUser createUser)

Create a user of the organization

This API allows to create a new user of the organization. 

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class CreateUserExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://sandbox.signingtoday.com/api/v1";
            // Configure API key authorization: ApiKeyAuth
            Configuration.Default.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new UsersApi(Configuration.Default);
            var organizationId = api-demo;  // string | The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization  (default to "api-demo")
            var createUser = new CreateUser(); // CreateUser | The new user object to create

            try
            {
                // Create a user of the organization
                InlineResponse201 result = apiInstance.CreateUser(organizationId, createUser);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling UsersApi.CreateUser: " + e.Message );
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
 **createUser** | [**CreateUser**](CreateUser.md)| The new user object to create | 

### Return type

[**InlineResponse201**](InlineResponse201.md)

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


## GetUser

> InlineResponse201 GetUser (string organizationId, Id userId)

Get information about an user

This API allows to get information about an user. 

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class GetUserExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://sandbox.signingtoday.com/api/v1";
            // Configure API key authorization: ApiKeyAuth
            Configuration.Default.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new UsersApi(Configuration.Default);
            var organizationId = api-demo;  // string | The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization  (default to "api-demo")
            var userId = new Id(); // Id | The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user 

            try
            {
                // Get information about an user
                InlineResponse201 result = apiInstance.GetUser(organizationId, userId);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling UsersApi.GetUser: " + e.Message );
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

### Return type

[**InlineResponse201**](InlineResponse201.md)

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


## ListUsers

> InlineResponse2001 ListUsers (string organizationId, string whereMembershipId = null, string whereEmail = null, string whereLastName = null, string whereFirstName = null, bool whereAutomatic = null, bool whereRao = null, int page = null, int count = null, string whereOrder = null)

Enumerate the users of an organization

This API allows to enumerate the users of an organization. 

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class ListUsersExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://sandbox.signingtoday.com/api/v1";
            // Configure API key authorization: ApiKeyAuth
            Configuration.Default.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new UsersApi(Configuration.Default);
            var organizationId = api-demo;  // string | The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization  (default to "api-demo")
            var whereMembershipId = jdo;  // string | Returns the users that have the specified id (optional) 
            var whereEmail = test@mail.com;  // string | Returns the users that have the specified email (optional) 
            var whereLastName = Doe;  // string | Returns the users that have the specified last name (optional) 
            var whereFirstName = John;  // string | Returns the users that have the specified first name (optional) 
            var whereAutomatic = false;  // bool | If set up to **true** returns automatic users only, otherwise returns non automatic users only (optional) 
            var whereRao = false;  // bool | If set up to **true** returns rao users only, otherwise returns non rao users only (optional) 
            var page = 1;  // int | Restricts the search to the chosen page (optional) 
            var count = 56;  // int | Sets the number of users per page to display (optional)  (default to 100)
            var whereOrder = where_first_name;  // string | The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \"**-**\" in front of the value indicates descending order), then the second value and so on (optional) 

            try
            {
                // Enumerate the users of an organization
                InlineResponse2001 result = apiInstance.ListUsers(organizationId, whereMembershipId, whereEmail, whereLastName, whereFirstName, whereAutomatic, whereRao, page, count, whereOrder);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling UsersApi.ListUsers: " + e.Message );
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
 **whereMembershipId** | **string**| Returns the users that have the specified id | [optional] 
 **whereEmail** | **string**| Returns the users that have the specified email | [optional] 
 **whereLastName** | **string**| Returns the users that have the specified last name | [optional] 
 **whereFirstName** | **string**| Returns the users that have the specified first name | [optional] 
 **whereAutomatic** | **bool**| If set up to **true** returns automatic users only, otherwise returns non automatic users only | [optional] 
 **whereRao** | **bool**| If set up to **true** returns rao users only, otherwise returns non rao users only | [optional] 
 **page** | **int**| Restricts the search to the chosen page | [optional] 
 **count** | **int**| Sets the number of users per page to display | [optional] [default to 100]
 **whereOrder** | **string**| The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on | [optional] 

### Return type

[**InlineResponse2001**](InlineResponse2001.md)

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


## UpdateUser

> InlineResponse201 UpdateUser (string organizationId, Id userId, UpdateUser updateUser)

Edit one or more user properties

This API allows to edit one or more user properties. 

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class UpdateUserExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://sandbox.signingtoday.com/api/v1";
            // Configure API key authorization: ApiKeyAuth
            Configuration.Default.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new UsersApi(Configuration.Default);
            var organizationId = api-demo;  // string | The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization  (default to "api-demo")
            var userId = new Id(); // Id | The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user 
            var updateUser = new UpdateUser(); // UpdateUser | User properties to be edited

            try
            {
                // Edit one or more user properties
                InlineResponse201 result = apiInstance.UpdateUser(organizationId, userId, updateUser);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling UsersApi.UpdateUser: " + e.Message );
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
 **updateUser** | [**UpdateUser**](UpdateUser.md)| User properties to be edited | 

### Return type

[**InlineResponse201**](InlineResponse201.md)

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

