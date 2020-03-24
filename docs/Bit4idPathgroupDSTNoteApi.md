# SigningToday.Api.Bit4idPathgroupDSTNoteApi

All URIs are relative to *https://web.sandbox.signingtoday.com/api*

Method | HTTP request | Description
------------- | ------------- | -------------
[**DSTIdNoteGet**](Bit4idPathgroupDSTNoteApi.md#dstidnoteget) | **GET** /DST/{id}/note | Retrieve the DSTNotes associated to the DST
[**DSTIdNoteNoteIdDelete**](Bit4idPathgroupDSTNoteApi.md#dstidnotenoteiddelete) | **DELETE** /DST/{id}/note/{noteId} | Delete a DSTNote
[**DSTIdNoteNoteIdPut**](Bit4idPathgroupDSTNoteApi.md#dstidnotenoteidput) | **PUT** /DST/{id}/note/{noteId} | Edit a DSTNote
[**DSTIdNotePost**](Bit4idPathgroupDSTNoteApi.md#dstidnotepost) | **POST** /DST/{id}/note | Append a new DSTNote



## DSTIdNoteGet

> List&lt;DSTNote&gt; DSTIdNoteGet (Guid id)

Retrieve the DSTNotes associated to the DST

This API allows to retrieve the DST Notes associated to the DST.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class DSTIdNoteGetExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new Bit4idPathgroupDSTNoteApi(Configuration.Default);
            var id = new Guid(); // Guid | The value of _the unique id_

            try
            {
                // Retrieve the DSTNotes associated to the DST
                List<DSTNote> result = apiInstance.DSTIdNoteGet(id);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling Bit4idPathgroupDSTNoteApi.DSTIdNoteGet: " + e.Message );
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

[**List&lt;DSTNote&gt;**](DSTNote.md)

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json, */*

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The DSTNotes |  -  |
| **401** | User authentication was not effective (e.g. not provided, invalid or expired). |  -  |
| **403** | User is not allowed to perform the request. |  -  |
| **404** | The resource was not found. |  -  |
| **500** | Internal failure of the service. |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## DSTIdNoteNoteIdDelete

> void DSTIdNoteNoteIdDelete (Guid id, long noteId)

Delete a DSTNote

This API allows to delete a DSTNote.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class DSTIdNoteNoteIdDeleteExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new Bit4idPathgroupDSTNoteApi(Configuration.Default);
            var id = new Guid(); // Guid | The value of _the unique id_
            var noteId = 14;  // long | The reference of a DSTNote

            try
            {
                // Delete a DSTNote
                apiInstance.DSTIdNoteNoteIdDelete(id, noteId);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling Bit4idPathgroupDSTNoteApi.DSTIdNoteNoteIdDelete: " + e.Message );
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
 **noteId** | **long**| The reference of a DSTNote | 

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


## DSTIdNoteNoteIdPut

> DSTNote DSTIdNoteNoteIdPut (Guid id, long noteId, DSTNote dSTNote)

Edit a DSTNote

This API allows to edit a DSTNote.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class DSTIdNoteNoteIdPutExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new Bit4idPathgroupDSTNoteApi(Configuration.Default);
            var id = new Guid(); // Guid | The value of _the unique id_
            var noteId = 14;  // long | The reference of a DSTNote
            var dSTNote = new DSTNote(); // DSTNote | DSTNote replacing current object.

            try
            {
                // Edit a DSTNote
                DSTNote result = apiInstance.DSTIdNoteNoteIdPut(id, noteId, dSTNote);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling Bit4idPathgroupDSTNoteApi.DSTIdNoteNoteIdPut: " + e.Message );
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
 **noteId** | **long**| The reference of a DSTNote | 
 **dSTNote** | [**DSTNote**](DSTNote.md)| DSTNote replacing current object. | 

### Return type

[**DSTNote**](DSTNote.md)

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

- **Content-Type**: application/json
- **Accept**: application/json, */*

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The updated DSTNote. |  -  |
| **400** | Result of a client passing incorrect or invalid data. |  -  |
| **401** | User authentication was not effective (e.g. not provided, invalid or expired). |  -  |
| **403** | User is not allowed to perform the request. |  -  |
| **404** | The resource was not found. |  -  |
| **500** | Internal failure of the service. |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## DSTIdNotePost

> DSTNote DSTIdNotePost (Guid id, InlineObject1 inlineObject1 = null)

Append a new DSTNote

This API allows to append a new DSTNote to the DST.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class DSTIdNotePostExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new Bit4idPathgroupDSTNoteApi(Configuration.Default);
            var id = new Guid(); // Guid | The value of _the unique id_
            var inlineObject1 = new InlineObject1(); // InlineObject1 |  (optional) 

            try
            {
                // Append a new DSTNote
                DSTNote result = apiInstance.DSTIdNotePost(id, inlineObject1);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling Bit4idPathgroupDSTNoteApi.DSTIdNotePost: " + e.Message );
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
 **inlineObject1** | [**InlineObject1**](InlineObject1.md)|  | [optional] 

### Return type

[**DSTNote**](DSTNote.md)

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

- **Content-Type**: application/json
- **Accept**: application/json, */*

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The DSTNote just added |  -  |
| **401** | User authentication was not effective (e.g. not provided, invalid or expired). |  -  |
| **403** | User is not allowed to perform the request. |  -  |
| **404** | The resource was not found. |  -  |
| **409** | Cannot satisfy the request because the resource is in an illegal status. |  -  |
| **500** | Internal failure of the service. |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)

