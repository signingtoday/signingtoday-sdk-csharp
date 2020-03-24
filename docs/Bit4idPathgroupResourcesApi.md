# SigningToday.Api.Bit4idPathgroupResourcesApi

All URIs are relative to *https://web.sandbox.signingtoday.com/api*

Method | HTTP request | Description
------------- | ------------- | -------------
[**DSTIdResourcesGet**](Bit4idPathgroupResourcesApi.md#dstidresourcesget) | **GET** /DST/{id}/resources | Retrieve all resources associated to a DST
[**DSTIdResourcesPatch**](Bit4idPathgroupResourcesApi.md#dstidresourcespatch) | **PATCH** /DST/{id}/resources | Append a new resource to a DST
[**DSTResourceIdDelete**](Bit4idPathgroupResourcesApi.md#dstresourceiddelete) | **DELETE** /DST/resource/{id} | Delete a Resource
[**ResourceIdGet**](Bit4idPathgroupResourcesApi.md#resourceidget) | **GET** /resource/{id} | Retrieve a Resource
[**ResourceIdPut**](Bit4idPathgroupResourcesApi.md#resourceidput) | **PUT** /resource/{id} | Update a Resource
[**UserIdIdentityIdentityIdAppearanceDelete**](Bit4idPathgroupResourcesApi.md#userididentityidentityidappearancedelete) | **DELETE** /user/{id}/identity/{identity-id}/appearance | Delete a user appearance resource.
[**UserIdIdentityIdentityIdAppearanceGet**](Bit4idPathgroupResourcesApi.md#userididentityidentityidappearanceget) | **GET** /user/{id}/identity/{identity-id}/appearance | Download an identity appearance resource
[**UserIdIdentityIdentityIdAppearancePost**](Bit4idPathgroupResourcesApi.md#userididentityidentityidappearancepost) | **POST** /user/{id}/identity/{identity-id}/appearance | Add a graphical appearance to a user&#39;s identity



## DSTIdResourcesGet

> System.IO.Stream DSTIdResourcesGet (Guid id)

Retrieve all resources associated to a DST

This API allows to retrieve all resources associated to a DST.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class DSTIdResourcesGetExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new Bit4idPathgroupResourcesApi(Configuration.Default);
            var id = new Guid(); // Guid | The value of _the unique id_

            try
            {
                // Retrieve all resources associated to a DST
                System.IO.Stream result = apiInstance.DSTIdResourcesGet(id);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling Bit4idPathgroupResourcesApi.DSTIdResourcesGet: " + e.Message );
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

**System.IO.Stream**

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/octet-stream, */*

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The response body contains all resources associated to a DST into a zip file. |  -  |
| **401** | User authentication was not effective (e.g. not provided, invalid or expired). |  -  |
| **403** | User is not allowed to perform the request. |  -  |
| **404** | The resource was not found. |  -  |
| **500** | Internal failure of the service. |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## DSTIdResourcesPatch

> DigitalSignatureTransaction DSTIdResourcesPatch (Guid id, System.IO.Stream file, string filename, string resourceType, string title = null)

Append a new resource to a DST

This API allows to append a new Resource to a DST.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class DSTIdResourcesPatchExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new Bit4idPathgroupResourcesApi(Configuration.Default);
            var id = new Guid(); // Guid | The value of _the unique id_
            var file = BINARY_DATA_HERE;  // System.IO.Stream | The file to upload
            var filename = filename_example;  // string | The name of the file
            var resourceType = resourceType_example;  // string | 
            var title = title_example;  // string | User-defined title of the resource. (optional) 

            try
            {
                // Append a new resource to a DST
                DigitalSignatureTransaction result = apiInstance.DSTIdResourcesPatch(id, file, filename, resourceType, title);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling Bit4idPathgroupResourcesApi.DSTIdResourcesPatch: " + e.Message );
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
 **file** | **System.IO.Stream**| The file to upload | 
 **filename** | **string**| The name of the file | 
 **resourceType** | **string**|  | 
 **title** | **string**| User-defined title of the resource. | [optional] 

### Return type

[**DigitalSignatureTransaction**](DigitalSignatureTransaction.md)

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

- **Content-Type**: multipart/form-data
- **Accept**: application/json, */*

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The DST patched with the new resource. |  -  |
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


## DSTResourceIdDelete

> DigitalSignatureTransaction DSTResourceIdDelete (Guid id)

Delete a Resource

This API allows to delete a Resource.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class DSTResourceIdDeleteExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new Bit4idPathgroupResourcesApi(Configuration.Default);
            var id = new Guid(); // Guid | The value of _the unique id_

            try
            {
                // Delete a Resource
                DigitalSignatureTransaction result = apiInstance.DSTResourceIdDelete(id);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling Bit4idPathgroupResourcesApi.DSTResourceIdDelete: " + e.Message );
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

[**DigitalSignatureTransaction**](DigitalSignatureTransaction.md)

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json, */*

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The DST Updated. |  -  |
| **401** | User authentication was not effective (e.g. not provided, invalid or expired). |  -  |
| **403** | User is not allowed to perform the request. |  -  |
| **404** | The resource was not found. |  -  |
| **409** | Cannot satisfy the request because the resource is in an illegal status. |  -  |
| **500** | Internal failure of the service. |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## ResourceIdGet

> System.IO.Stream ResourceIdGet (Guid id)

Retrieve a Resource

This API allows to retrieve a Resource.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class ResourceIdGetExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new Bit4idPathgroupResourcesApi(Configuration.Default);
            var id = new Guid(); // Guid | The value of _the unique id_

            try
            {
                // Retrieve a Resource
                System.IO.Stream result = apiInstance.ResourceIdGet(id);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling Bit4idPathgroupResourcesApi.ResourceIdGet: " + e.Message );
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

**System.IO.Stream**

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/octet-stream, */*

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The response is the binary resource file content. |  -  |
| **401** | User authentication was not effective (e.g. not provided, invalid or expired). |  -  |
| **403** | User is not allowed to perform the request. |  -  |
| **404** | The resource was not found. |  -  |
| **500** | Internal failure of the service. |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## ResourceIdPut

> void ResourceIdPut (Guid id, LFResource lFResource)

Update a Resource

This API allows to update a Resource.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class ResourceIdPutExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new Bit4idPathgroupResourcesApi(Configuration.Default);
            var id = new Guid(); // Guid | The value of _the unique id_
            var lFResource = new LFResource(); // LFResource | Resource replacing current object.

            try
            {
                // Update a Resource
                apiInstance.ResourceIdPut(id, lFResource);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling Bit4idPathgroupResourcesApi.ResourceIdPut: " + e.Message );
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
 **lFResource** | [**LFResource**](LFResource.md)| Resource replacing current object. | 

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
| **409** | Cannot satisfy the request because the resource is in an illegal status. |  -  |
| **500** | Internal failure of the service. |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## UserIdIdentityIdentityIdAppearanceDelete

> void UserIdIdentityIdentityIdAppearanceDelete (Guid id, Guid identityId)

Delete a user appearance resource.

This API allows to delete an identity appearance resource.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class UserIdIdentityIdentityIdAppearanceDeleteExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new Bit4idPathgroupResourcesApi(Configuration.Default);
            var id = new Guid(); // Guid | The value of _the unique id_
            var identityId = new Guid(); // Guid | The unique id of the _Identity_

            try
            {
                // Delete a user appearance resource.
                apiInstance.UserIdIdentityIdentityIdAppearanceDelete(id, identityId);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling Bit4idPathgroupResourcesApi.UserIdIdentityIdentityIdAppearanceDelete: " + e.Message );
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
 **identityId** | [**Guid**](Guid.md)| The unique id of the _Identity_ | 

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


## UserIdIdentityIdentityIdAppearanceGet

> System.IO.Stream UserIdIdentityIdentityIdAppearanceGet (Guid id, Guid identityId)

Download an identity appearance resource

This API allows to get the identity appearance resource.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class UserIdIdentityIdentityIdAppearanceGetExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new Bit4idPathgroupResourcesApi(Configuration.Default);
            var id = new Guid(); // Guid | The value of _the unique id_
            var identityId = new Guid(); // Guid | The unique id of the _Identity_

            try
            {
                // Download an identity appearance resource
                System.IO.Stream result = apiInstance.UserIdIdentityIdentityIdAppearanceGet(id, identityId);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling Bit4idPathgroupResourcesApi.UserIdIdentityIdentityIdAppearanceGet: " + e.Message );
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
 **identityId** | [**Guid**](Guid.md)| The unique id of the _Identity_ | 

### Return type

**System.IO.Stream**

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/octet-stream, */*

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The response is the binary resource file content. |  -  |
| **401** | User authentication was not effective (e.g. not provided, invalid or expired). |  -  |
| **403** | User is not allowed to perform the request. |  -  |
| **404** | The resource was not found. |  -  |
| **500** | Internal failure of the service. |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## UserIdIdentityIdentityIdAppearancePost

> LFResource UserIdIdentityIdentityIdAppearancePost (Guid id, Guid identityId, System.IO.Stream file, string filename, string resourceType, string title = null)

Add a graphical appearance to a user's identity

This API allows to add a graphical appearance to the identity of a user.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class UserIdIdentityIdentityIdAppearancePostExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new Bit4idPathgroupResourcesApi(Configuration.Default);
            var id = new Guid(); // Guid | The value of _the unique id_
            var identityId = new Guid(); // Guid | The unique id of the _Identity_
            var file = BINARY_DATA_HERE;  // System.IO.Stream | The path of the file to upload
            var filename = filename_example;  // string | The name of the file
            var resourceType = resourceType_example;  // string | The type of the resource
            var title = title_example;  // string | User-defined title of the resource (optional) 

            try
            {
                // Add a graphical appearance to a user's identity
                LFResource result = apiInstance.UserIdIdentityIdentityIdAppearancePost(id, identityId, file, filename, resourceType, title);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling Bit4idPathgroupResourcesApi.UserIdIdentityIdentityIdAppearancePost: " + e.Message );
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
 **identityId** | [**Guid**](Guid.md)| The unique id of the _Identity_ | 
 **file** | **System.IO.Stream**| The path of the file to upload | 
 **filename** | **string**| The name of the file | 
 **resourceType** | **string**| The type of the resource | 
 **title** | **string**| User-defined title of the resource | [optional] 

### Return type

[**LFResource**](LFResource.md)

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

- **Content-Type**: multipart/form-data
- **Accept**: application/json, */*

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The new created Resource |  -  |
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

