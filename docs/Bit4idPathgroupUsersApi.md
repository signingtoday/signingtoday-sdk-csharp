# SigningToday.Api.Bit4idPathgroupUsersApi

All URIs are relative to *https://web.sandbox.signingtoday.com/api*

Method | HTTP request | Description
------------- | ------------- | -------------
[**UserIdDelete**](Bit4idPathgroupUsersApi.md#useriddelete) | **DELETE** /user/{id} | Enable or disable a User
[**UserIdGet**](Bit4idPathgroupUsersApi.md#useridget) | **GET** /user/{id} | Retrieve a User
[**UserIdIdentitiesGet**](Bit4idPathgroupUsersApi.md#userididentitiesget) | **GET** /user/{id}/identities | Retrieve User identities
[**UserIdPut**](Bit4idPathgroupUsersApi.md#useridput) | **PUT** /user/{id} | Update a User
[**UserIdRolePut**](Bit4idPathgroupUsersApi.md#useridroleput) | **PUT** /user/{id}/role | Change the User role
[**UsersGet**](Bit4idPathgroupUsersApi.md#usersget) | **GET** /users | Retrieve Users
[**UsersGroupsGet**](Bit4idPathgroupUsersApi.md#usersgroupsget) | **GET** /users/groups | Retrieve UserGroups
[**UsersGroupsPost**](Bit4idPathgroupUsersApi.md#usersgroupspost) | **POST** /users/groups | Create a new UserGroups
[**UsersPost**](Bit4idPathgroupUsersApi.md#userspost) | **POST** /users | Create a new User



## UserIdDelete

> void UserIdDelete (Guid id, bool enabled = null)

Enable or disable a User

This API allows to **enable** or **disable** a User account. 

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class UserIdDeleteExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new Bit4idPathgroupUsersApi(Configuration.Default);
            var id = new Guid(); // Guid | The value of _the unique id_
            var enabled = true;  // bool | This is a _boolean_ parameter. If true the User is **enabled**  (optional)  (default to false)

            try
            {
                // Enable or disable a User
                apiInstance.UserIdDelete(id, enabled);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling Bit4idPathgroupUsersApi.UserIdDelete: " + e.Message );
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
 **enabled** | **bool**| This is a _boolean_ parameter. If true the User is **enabled**  | [optional] [default to false]

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
| **404** | The resource was not found. |  -  |
| **500** | Internal failure of the service. |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## UserIdGet

> User UserIdGet (Guid id)

Retrieve a User

This API allows to retrieve a User.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class UserIdGetExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new Bit4idPathgroupUsersApi(Configuration.Default);
            var id = new Guid(); // Guid | The value of _the unique id_

            try
            {
                // Retrieve a User
                User result = apiInstance.UserIdGet(id);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling Bit4idPathgroupUsersApi.UserIdGet: " + e.Message );
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

[**User**](User.md)

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json, */*

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The data matching the selection parameters. |  -  |
| **401** | User authentication was not effective (e.g. not provided, invalid or expired). |  -  |
| **403** | User is not allowed to perform the request. |  -  |
| **404** | The resource was not found. |  -  |
| **500** | Internal failure of the service. |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## UserIdIdentitiesGet

> List&lt;Identity&gt; UserIdIdentitiesGet (Guid id)

Retrieve User identities

This API allows to retrieve user identities.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class UserIdIdentitiesGetExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new Bit4idPathgroupUsersApi(Configuration.Default);
            var id = new Guid(); // Guid | The value of _the unique id_

            try
            {
                // Retrieve User identities
                List<Identity> result = apiInstance.UserIdIdentitiesGet(id);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling Bit4idPathgroupUsersApi.UserIdIdentitiesGet: " + e.Message );
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

[**List&lt;Identity&gt;**](Identity.md)

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json, */*

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The identities associated to the user. |  -  |
| **401** | User authentication was not effective (e.g. not provided, invalid or expired). |  -  |
| **403** | User is not allowed to perform the request. |  -  |
| **404** | The resource was not found. |  -  |
| **500** | Internal failure of the service. |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## UserIdPut

> void UserIdPut (Guid id, User user)

Update a User

This API allows to update a User.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class UserIdPutExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new Bit4idPathgroupUsersApi(Configuration.Default);
            var id = new Guid(); // Guid | The value of _the unique id_
            var user = new User(); // User | User replacing current object.

            try
            {
                // Update a User
                apiInstance.UserIdPut(id, user);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling Bit4idPathgroupUsersApi.UserIdPut: " + e.Message );
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
 **user** | [**User**](User.md)| User replacing current object. | 

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
| **400** | Result of a client passing incorrect or invalid data. |  -  |
| **401** | User authentication was not effective (e.g. not provided, invalid or expired). |  -  |
| **403** | User is not allowed to perform the request. |  -  |
| **404** | The resource was not found. |  -  |
| **500** | Internal failure of the service. |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## UserIdRolePut

> void UserIdRolePut (Guid id, string newRole)

Change the User role

This API allows to change the permissions associated to the users, (**capabilities**) according to predefined user roles. 

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class UserIdRolePutExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new Bit4idPathgroupUsersApi(Configuration.Default);
            var id = new Guid(); // Guid | The value of _the unique id_
            var newRole = instructor;  // string | The new **role** of the User. Allowed values are **admin**, **instructor**, **signer** 

            try
            {
                // Change the User role
                apiInstance.UserIdRolePut(id, newRole);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling Bit4idPathgroupUsersApi.UserIdRolePut: " + e.Message );
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
 **newRole** | **string**| The new **role** of the User. Allowed values are **admin**, **instructor**, **signer**  | 

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


## UsersGet

> UsersGetResponse UsersGet (int top = null, long skip = null, bool count = null, string orderBy = null, string filter = null)

Retrieve Users

This allows to get the list of the Users of an Organization.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class UsersGetExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new Bit4idPathgroupUsersApi(Configuration.Default);
            var top = 32;  // int | A number of results to return. Applied after **$skip**  (optional) 
            var skip = 64;  // long | An offset into the collection of results (optional) 
            var count = true;  // bool | If true, the server includes the count of all the items in the response  (optional) 
            var orderBy = $orderBy=updatedAt;  // string | An ordering definition (eg. $orderBy=updatedAt,desc) (optional) 
            var filter = $filter=name=="Milk";  // string | A filter definition (eg. $filter=name == \"Milk\" or surname == \"Bread\") (optional) 

            try
            {
                // Retrieve Users
                UsersGetResponse result = apiInstance.UsersGet(top, skip, count, orderBy, filter);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling Bit4idPathgroupUsersApi.UsersGet: " + e.Message );
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
 **orderBy** | **string**| An ordering definition (eg. $orderBy&#x3D;updatedAt,desc) | [optional] 
 **filter** | **string**| A filter definition (eg. $filter&#x3D;name &#x3D;&#x3D; \&quot;Milk\&quot; or surname &#x3D;&#x3D; \&quot;Bread\&quot;) | [optional] 

### Return type

[**UsersGetResponse**](UsersGetResponse.md)

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json, */*

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The data matching the selection parameters. |  -  |
| **400** | Result of a client passing incorrect or invalid data. |  -  |
| **401** | User authentication was not effective (e.g. not provided, invalid or expired). |  -  |
| **403** | User is not allowed to perform the request. |  -  |
| **500** | Internal failure of the service. |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## UsersGroupsGet

> UserGroupGetResponse UsersGroupsGet (int top = null, long skip = null, bool count = null, string orderBy = null, string filter = null)

Retrieve UserGroups

This API allows to get the list of the UserGroups.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class UsersGroupsGetExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new Bit4idPathgroupUsersApi(Configuration.Default);
            var top = 32;  // int | A number of results to return. Applied after **$skip**  (optional) 
            var skip = 64;  // long | An offset into the collection of results (optional) 
            var count = true;  // bool | If true, the server includes the count of all the items in the response  (optional) 
            var orderBy = $orderBy=updatedAt;  // string | An ordering definition (eg. $orderBy=updatedAt,desc) (optional) 
            var filter = $filter=name=="Milk";  // string | A filter definition (eg. $filter=name == \"Milk\" or surname == \"Bread\") (optional) 

            try
            {
                // Retrieve UserGroups
                UserGroupGetResponse result = apiInstance.UsersGroupsGet(top, skip, count, orderBy, filter);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling Bit4idPathgroupUsersApi.UsersGroupsGet: " + e.Message );
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
 **orderBy** | **string**| An ordering definition (eg. $orderBy&#x3D;updatedAt,desc) | [optional] 
 **filter** | **string**| A filter definition (eg. $filter&#x3D;name &#x3D;&#x3D; \&quot;Milk\&quot; or surname &#x3D;&#x3D; \&quot;Bread\&quot;) | [optional] 

### Return type

[**UserGroupGetResponse**](UserGroupGetResponse.md)

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json, */*

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The data matching the selection parameters. |  -  |
| **400** | Result of a client passing incorrect or invalid data. |  -  |
| **401** | User authentication was not effective (e.g. not provided, invalid or expired). |  -  |
| **403** | User is not allowed to perform the request. |  -  |
| **500** | Internal failure of the service. |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## UsersGroupsPost

> void UsersGroupsPost (List<UserGroup> userGroup)

Create a new UserGroups

This API allows to create a new UserGroups.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class UsersGroupsPostExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new Bit4idPathgroupUsersApi(Configuration.Default);
            var userGroup = new List<UserGroup>(); // List<UserGroup> | UserGroup list to be added.

            try
            {
                // Create a new UserGroups
                apiInstance.UsersGroupsPost(userGroup);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling Bit4idPathgroupUsersApi.UsersGroupsPost: " + e.Message );
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
 **userGroup** | [**List&lt;UserGroup&gt;**](UserGroup.md)| UserGroup list to be added. | 

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
| **400** | Result of a client passing incorrect or invalid data. |  -  |
| **401** | User authentication was not effective (e.g. not provided, invalid or expired). |  -  |
| **403** | User is not allowed to perform the request. |  -  |
| **500** | Internal failure of the service. |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## UsersPost

> Guid UsersPost (CreateUserRequest createUserRequest)

Create a new User

This API allows to create a new User.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class UsersPostExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new Bit4idPathgroupUsersApi(Configuration.Default);
            var createUserRequest = new CreateUserRequest(); // CreateUserRequest | 

            try
            {
                // Create a new User
                Guid result = apiInstance.UsersPost(createUserRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling Bit4idPathgroupUsersApi.UsersPost: " + e.Message );
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
 **createUserRequest** | [**CreateUserRequest**](CreateUserRequest.md)|  | 

### Return type

**Guid**

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

- **Content-Type**: application/json
- **Accept**: */*

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | The request has been satisfyied, new resource created. |  -  |
| **400** | Result of a client passing incorrect or invalid data. |  -  |
| **401** | User authentication was not effective (e.g. not provided, invalid or expired). |  -  |
| **403** | User is not allowed to perform the request. |  -  |
| **500** | Internal failure of the service. |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)

