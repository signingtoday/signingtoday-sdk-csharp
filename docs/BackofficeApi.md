# SigningToday.Api.BackofficeApi

All URIs are relative to *https://web.sandbox.signingtoday.com/api*

Method | HTTP request | Description
------------- | ------------- | -------------
[**OrganizationIdAlfrescoSyncGet**](BackofficeApi.md#organizationidalfrescosyncget) | **GET** /organization/{id}/alfrescoSync | Sync all completed DSTs on Alfresco
[**OrganizationIdAlfrescoSyncPost**](BackofficeApi.md#organizationidalfrescosyncpost) | **POST** /organization/{id}/alfrescoSync | Sync all completed DSTs on Alfresco
[**OrganizationIdDelete**](BackofficeApi.md#organizationiddelete) | **DELETE** /organization/{id} | Enable or disable an Organization account.
[**OrganizationIdGet**](BackofficeApi.md#organizationidget) | **GET** /organization/{id} | Retrieve info on one organization
[**OrganizationIdPublicGet**](BackofficeApi.md#organizationidpublicget) | **GET** /organization/public | Retrieve public resources
[**OrganizationIdPut**](BackofficeApi.md#organizationidput) | **PUT** /organization/{id} | Update info on one organization
[**OrganizationIdResourceGet**](BackofficeApi.md#organizationidresourceget) | **GET** /organization/{id}/resource | Get an organization resource
[**OrganizationIdResourcePut**](BackofficeApi.md#organizationidresourceput) | **PUT** /organization/{id}/resource | Create or overwrite an organization resource
[**OrganizationResourceIdDelete**](BackofficeApi.md#organizationresourceiddelete) | **DELETE** /organization/{id}/resource | Delete an organization resource
[**OrganizationResourcesGet**](BackofficeApi.md#organizationresourcesget) | **GET** /organization/{id}/resources | List all the organization resources
[**OrganizationTagsGet**](BackofficeApi.md#organizationtagsget) | **GET** /organization/tags | Retrieve organization tags
[**OrganizationsGet**](BackofficeApi.md#organizationsget) | **GET** /organizations | Get the list of organizations
[**OrganizationsPost**](BackofficeApi.md#organizationspost) | **POST** /organizations | Create a new organization



## OrganizationIdAlfrescoSyncGet

> AlfrescoSync OrganizationIdAlfrescoSyncGet (string id)

Sync all completed DSTs on Alfresco

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class OrganizationIdAlfrescoSyncGetExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BackofficeApi(Configuration.Default);
            var id = test_id;  // string | The value of the unique id

            try
            {
                // Sync all completed DSTs on Alfresco
                AlfrescoSync result = apiInstance.OrganizationIdAlfrescoSyncGet(id);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling BackofficeApi.OrganizationIdAlfrescoSyncGet: " + e.Message );
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
 **id** | **string**| The value of the unique id | 

### Return type

[**AlfrescoSync**](AlfrescoSync.md)

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json, */*

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **202** | OK |  -  |
| **401** | User authentication was not effective (e.g. not provided, invalid or expired). |  -  |
| **403** | User is not allowed to perform the request. |  -  |
| **404** | The resource was not found. |  -  |
| **500** | Internal failure of the service. |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## OrganizationIdAlfrescoSyncPost

> void OrganizationIdAlfrescoSyncPost (string id, AlfrescoSync alfrescoSync)

Sync all completed DSTs on Alfresco

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class OrganizationIdAlfrescoSyncPostExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BackofficeApi(Configuration.Default);
            var id = test_id;  // string | The value of the unique id
            var alfrescoSync = new AlfrescoSync(); // AlfrescoSync | Domain associated to the account.

            try
            {
                // Sync all completed DSTs on Alfresco
                apiInstance.OrganizationIdAlfrescoSyncPost(id, alfrescoSync);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling BackofficeApi.OrganizationIdAlfrescoSyncPost: " + e.Message );
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
 **id** | **string**| The value of the unique id | 
 **alfrescoSync** | [**AlfrescoSync**](AlfrescoSync.md)| Domain associated to the account. | 

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
| **202** | OK |  -  |
| **401** | User authentication was not effective (e.g. not provided, invalid or expired). |  -  |
| **403** | User is not allowed to perform the request. |  -  |
| **404** | The resource was not found. |  -  |
| **500** | Internal failure of the service. |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## OrganizationIdDelete

> void OrganizationIdDelete (string id, bool enabled = null)

Enable or disable an Organization account.

Enable or disable an Organization.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class OrganizationIdDeleteExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BackofficeApi(Configuration.Default);
            var id = test_id;  // string | The value of the unique id
            var enabled = true;  // bool | New status to set (optional)  (default to false)

            try
            {
                // Enable or disable an Organization account.
                apiInstance.OrganizationIdDelete(id, enabled);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling BackofficeApi.OrganizationIdDelete: " + e.Message );
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
 **id** | **string**| The value of the unique id | 
 **enabled** | **bool**| New status to set | [optional] [default to false]

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


## OrganizationIdGet

> Organization OrganizationIdGet (string id)

Retrieve info on one organization

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class OrganizationIdGetExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BackofficeApi(Configuration.Default);
            var id = test_id;  // string | The value of the unique id

            try
            {
                // Retrieve info on one organization
                Organization result = apiInstance.OrganizationIdGet(id);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling BackofficeApi.OrganizationIdGet: " + e.Message );
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
 **id** | **string**| The value of the unique id | 

### Return type

[**Organization**](Organization.md)

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
| **403** | User is not allowed to perform the request. |  -  |
| **404** | The resource was not found. |  -  |
| **500** | Internal failure of the service. |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## OrganizationIdPublicGet

> System.IO.Stream OrganizationIdPublicGet (string res, string id = null)

Retrieve public resources

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class OrganizationIdPublicGetExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            var apiInstance = new BackofficeApi(Configuration.Default);
            var res = logo;  // string | resource id
            var id = 05ea656f-df69-49b1-a12b-9bf640c427c2;  // string | organization id (optional) 

            try
            {
                // Retrieve public resources
                System.IO.Stream result = apiInstance.OrganizationIdPublicGet(res, id);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling BackofficeApi.OrganizationIdPublicGet: " + e.Message );
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
 **res** | **string**| resource id | 
 **id** | **string**| organization id | [optional] 

### Return type

**System.IO.Stream**

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/octet-stream, */*

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Resource content. |  -  |
| **401** | User authentication was not effective (e.g. not provided, invalid or expired). |  -  |
| **403** | User is not allowed to perform the request. |  -  |
| **404** | The resource was not found. |  -  |
| **500** | Internal failure of the service. |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## OrganizationIdPut

> void OrganizationIdPut (string id, Organization organization = null)

Update info on one organization

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class OrganizationIdPutExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BackofficeApi(Configuration.Default);
            var id = test_id;  // string | The value of the unique id
            var organization = new Organization(); // Organization |  (optional) 

            try
            {
                // Update info on one organization
                apiInstance.OrganizationIdPut(id, organization);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling BackofficeApi.OrganizationIdPut: " + e.Message );
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
 **id** | **string**| The value of the unique id | 
 **organization** | [**Organization**](Organization.md)|  | [optional] 

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


## OrganizationIdResourceGet

> System.IO.Stream OrganizationIdResourceGet (string id, string resPath)

Get an organization resource

Get an organization resource

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class OrganizationIdResourceGetExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BackofficeApi(Configuration.Default);
            var id = test_id;  // string | The value of the unique id
            var resPath = 05ea656f-df69-49b1-a12b-9bf640c427c2;  // string | 

            try
            {
                // Get an organization resource
                System.IO.Stream result = apiInstance.OrganizationIdResourceGet(id, resPath);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling BackofficeApi.OrganizationIdResourceGet: " + e.Message );
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
 **id** | **string**| The value of the unique id | 
 **resPath** | **string**|  | 

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
| **200** | An organization resource. |  -  |
| **401** | User authentication was not effective (e.g. not provided, invalid or expired). |  -  |
| **403** | User is not allowed to perform the request. |  -  |
| **404** | The resource was not found. |  -  |
| **500** | Internal failure of the service. |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## OrganizationIdResourcePut

> void OrganizationIdResourcePut (string id, string resPath, System.IO.Stream file)

Create or overwrite an organization resource

Create or overwrite an organization resource

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class OrganizationIdResourcePutExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BackofficeApi(Configuration.Default);
            var id = test_id;  // string | The value of the unique id
            var resPath = 05ea656f-df69-49b1-a12b-9bf640c427c2;  // string | 
            var file = BINARY_DATA_HERE;  // System.IO.Stream | The file to upload.

            try
            {
                // Create or overwrite an organization resource
                apiInstance.OrganizationIdResourcePut(id, resPath, file);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling BackofficeApi.OrganizationIdResourcePut: " + e.Message );
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
 **id** | **string**| The value of the unique id | 
 **resPath** | **string**|  | 
 **file** | **System.IO.Stream**| The file to upload. | 

### Return type

void (empty response body)

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

- **Content-Type**: multipart/form-data
- **Accept**: */*

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | The request has been satisfyied. No output. |  -  |
| **401** | User authentication was not effective (e.g. not provided, invalid or expired). |  -  |
| **403** | User is not allowed to perform the request. |  -  |
| **409** | Cannot satisfy the request because the resource is in an illegal status. |  -  |
| **500** | Internal failure of the service. |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## OrganizationResourceIdDelete

> void OrganizationResourceIdDelete (string id, string resPath)

Delete an organization resource

Deletes a Resource.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class OrganizationResourceIdDeleteExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BackofficeApi(Configuration.Default);
            var id = test_id;  // string | The value of the unique id
            var resPath = 05ea656f-df69-49b1-a12b-9bf640c427c2;  // string | 

            try
            {
                // Delete an organization resource
                apiInstance.OrganizationResourceIdDelete(id, resPath);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling BackofficeApi.OrganizationResourceIdDelete: " + e.Message );
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
 **id** | **string**| The value of the unique id | 
 **resPath** | **string**|  | 

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
| **409** | Cannot satisfy the request because the resource is in an illegal status. |  -  |
| **500** | Internal failure of the service. |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## OrganizationResourcesGet

> List&lt;string&gt; OrganizationResourcesGet (string id)

List all the organization resources

List all the organization resources.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class OrganizationResourcesGetExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BackofficeApi(Configuration.Default);
            var id = test_id;  // string | The value of the unique id

            try
            {
                // List all the organization resources
                List<string> result = apiInstance.OrganizationResourcesGet(id);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling BackofficeApi.OrganizationResourcesGet: " + e.Message );
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
 **id** | **string**| The value of the unique id | 

### Return type

**List<string>**

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
| **403** | User is not allowed to perform the request. |  -  |
| **404** | The resource was not found. |  -  |
| **409** | Cannot satisfy the request because the resource is in an illegal status. |  -  |
| **500** | Internal failure of the service. |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## OrganizationTagsGet

> List&lt;string&gt; OrganizationTagsGet ()

Retrieve organization tags

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class OrganizationTagsGetExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BackofficeApi(Configuration.Default);

            try
            {
                // Retrieve organization tags
                List<string> result = apiInstance.OrganizationTagsGet();
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling BackofficeApi.OrganizationTagsGet: " + e.Message );
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

**List<string>**

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json, */*

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Resource content. |  -  |
| **401** | User authentication was not effective (e.g. not provided, invalid or expired). |  -  |
| **403** | User is not allowed to perform the request. |  -  |
| **404** | The resource was not found. |  -  |
| **500** | Internal failure of the service. |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## OrganizationsGet

> OrganizationsGetResponse OrganizationsGet (int top = null, long skip = null, bool count = null, string filter = null)

Get the list of organizations

Get the list of organizations

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class OrganizationsGetExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BackofficeApi(Configuration.Default);
            var top = 32;  // int | A number of results to return. Applied after **$skip**  (optional) 
            var skip = 64;  // long | An offset into the collection of results (optional) 
            var count = true;  // bool | If true, the server includes the count of all the items in the response  (optional) 
            var filter = $filter=name=="Milk";  // string | A filter definition (eg. $filter=name == \"Milk\" or surname == \"Bread\") (optional) 

            try
            {
                // Get the list of organizations
                OrganizationsGetResponse result = apiInstance.OrganizationsGet(top, skip, count, filter);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling BackofficeApi.OrganizationsGet: " + e.Message );
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
 **filter** | **string**| A filter definition (eg. $filter&#x3D;name &#x3D;&#x3D; \&quot;Milk\&quot; or surname &#x3D;&#x3D; \&quot;Bread\&quot;) | [optional] 

### Return type

[**OrganizationsGetResponse**](OrganizationsGetResponse.md)

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The list of organizations. |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## OrganizationsPost

> void OrganizationsPost (Organization organization = null)

Create a new organization

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class OrganizationsPostExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BackofficeApi(Configuration.Default);
            var organization = new Organization(); // Organization |  (optional) 

            try
            {
                // Create a new organization
                apiInstance.OrganizationsPost(organization);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling BackofficeApi.OrganizationsPost: " + e.Message );
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
 **organization** | [**Organization**](Organization.md)|  | [optional] 

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

