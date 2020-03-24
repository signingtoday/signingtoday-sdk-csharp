# SigningToday.Api.DigitalSignatureTransactionsApi

All URIs are relative to *https://web.sandbox.signingtoday.com/api*

Method | HTTP request | Description
------------- | ------------- | -------------
[**DSTIdAuditGet**](DigitalSignatureTransactionsApi.md#dstidauditget) | **GET** /DST/{id}/audit | Retrieve the audit records associated to the DST
[**DSTIdDelete**](DigitalSignatureTransactionsApi.md#dstiddelete) | **DELETE** /DST/{id} | Delete a DST
[**DSTIdFillPatch**](DigitalSignatureTransactionsApi.md#dstidfillpatch) | **PATCH** /DST/{id}/fill | Fill a form of a DST
[**DSTIdGet**](DigitalSignatureTransactionsApi.md#dstidget) | **GET** /DST/{id} | Retrieve a DST
[**DSTIdInstantiatePost**](DigitalSignatureTransactionsApi.md#dstidinstantiatepost) | **POST** /DST/{id}/instantiate | Instantiate a DST from a template
[**DSTIdModifyPost**](DigitalSignatureTransactionsApi.md#dstidmodifypost) | **POST** /DST/{id}/modify | Modify a published DST template
[**DSTIdNotifyPost**](DigitalSignatureTransactionsApi.md#dstidnotifypost) | **POST** /DST/{id}/notify | Send notifications for a DST
[**DSTIdPublishPost**](DigitalSignatureTransactionsApi.md#dstidpublishpost) | **POST** /DST/{id}/publish | Publish a DST
[**DSTIdPut**](DigitalSignatureTransactionsApi.md#dstidput) | **PUT** /DST/{id} | Update a DST
[**DSTIdReplacePost**](DigitalSignatureTransactionsApi.md#dstidreplacepost) | **POST** /DST/{id}/replace | Replace a rejected DST
[**DSTIdSignDocIdSignIdGet**](DigitalSignatureTransactionsApi.md#dstidsigndocidsignidget) | **GET** /DST/{id}/sign/{docId}/{signId} | Return the address for signing
[**DSTIdTemplatizePost**](DigitalSignatureTransactionsApi.md#dstidtemplatizepost) | **POST** /DST/{id}/templatize | Create a template from a DST
[**DSTsGet**](DigitalSignatureTransactionsApi.md#dstsget) | **GET** /DSTs | Retrieve DSTs
[**DSTsPost**](DigitalSignatureTransactionsApi.md#dstspost) | **POST** /DSTs | Create a new DST



## DSTIdAuditGet

> List&lt;AuditRecord&gt; DSTIdAuditGet (Guid id)

Retrieve the audit records associated to the DST

This API allows to retrieves the audit records associated to the DST.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class DSTIdAuditGetExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DigitalSignatureTransactionsApi(Configuration.Default);
            var id = new Guid(); // Guid | The value of _the unique id_

            try
            {
                // Retrieve the audit records associated to the DST
                List<AuditRecord> result = apiInstance.DSTIdAuditGet(id);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling DigitalSignatureTransactionsApi.DSTIdAuditGet: " + e.Message );
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

[**List&lt;AuditRecord&gt;**](AuditRecord.md)

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json, */*

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The audit associated to the DST sorted by date. |  -  |
| **401** | User authentication was not effective (e.g. not provided, invalid or expired). |  -  |
| **403** | User is not allowed to perform the request. |  -  |
| **404** | The resource was not found. |  -  |
| **500** | Internal failure of the service. |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## DSTIdDelete

> void DSTIdDelete (Guid id)

Delete a DST

This API allows to delete a DST. Actually the DST is marked as deleted thus not displayed anymore into the organization, but it will still be present in the database.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class DSTIdDeleteExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DigitalSignatureTransactionsApi(Configuration.Default);
            var id = new Guid(); // Guid | The value of _the unique id_

            try
            {
                // Delete a DST
                apiInstance.DSTIdDelete(id);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling DigitalSignatureTransactionsApi.DSTIdDelete: " + e.Message );
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


## DSTIdFillPatch

> DigitalSignatureTransaction DSTIdFillPatch (Guid id, FillableForm fillableForm)

Fill a form of a DST

This API allows to fill a form of a DST.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class DSTIdFillPatchExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DigitalSignatureTransactionsApi(Configuration.Default);
            var id = new Guid(); // Guid | The value of _the unique id_
            var fillableForm = new FillableForm(); // FillableForm | The form filled by the user.

            try
            {
                // Fill a form of a DST
                DigitalSignatureTransaction result = apiInstance.DSTIdFillPatch(id, fillableForm);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling DigitalSignatureTransactionsApi.DSTIdFillPatch: " + e.Message );
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
 **fillableForm** | [**FillableForm**](FillableForm.md)| The form filled by the user. | 

### Return type

[**DigitalSignatureTransaction**](DigitalSignatureTransaction.md)

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

- **Content-Type**: application/json
- **Accept**: application/json, */*

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The DST has been modified according to the operation. |  -  |
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


## DSTIdGet

> DigitalSignatureTransaction DSTIdGet (Guid id)

Retrieve a DST

This API allows to retrieve a DST.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class DSTIdGetExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DigitalSignatureTransactionsApi(Configuration.Default);
            var id = new Guid(); // Guid | The value of _the unique id_

            try
            {
                // Retrieve a DST
                DigitalSignatureTransaction result = apiInstance.DSTIdGet(id);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling DigitalSignatureTransactionsApi.DSTIdGet: " + e.Message );
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
| **200** | The data matching the selection parameters. |  -  |
| **401** | User authentication was not effective (e.g. not provided, invalid or expired). |  -  |
| **404** | The resource was not found. |  -  |
| **500** | Internal failure of the service. |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## DSTIdInstantiatePost

> DigitalSignatureTransaction DSTIdInstantiatePost (Guid id)

Instantiate a DST from a template

This API allows to instantiate a DST from a template by specifying the template Id.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class DSTIdInstantiatePostExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DigitalSignatureTransactionsApi(Configuration.Default);
            var id = new Guid(); // Guid | The value of _the unique id_

            try
            {
                // Instantiate a DST from a template
                DigitalSignatureTransaction result = apiInstance.DSTIdInstantiatePost(id);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling DigitalSignatureTransactionsApi.DSTIdInstantiatePost: " + e.Message );
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
| **200** | The new DST that has been generated as an instance of the template. |  -  |
| **401** | User authentication was not effective (e.g. not provided, invalid or expired). |  -  |
| **403** | User is not allowed to perform the request. |  -  |
| **404** | The resource was not found. |  -  |
| **409** | Cannot satisfy the request because the resource is in an illegal status. |  -  |
| **500** | Internal failure of the service. |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## DSTIdModifyPost

> DigitalSignatureTransaction DSTIdModifyPost (Guid id)

Modify a published DST template

This API allows to move a published DST to DRAFT, allowing the modification. This way is possible to modify a _DST Template_. 

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class DSTIdModifyPostExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DigitalSignatureTransactionsApi(Configuration.Default);
            var id = new Guid(); // Guid | The value of _the unique id_

            try
            {
                // Modify a published DST template
                DigitalSignatureTransaction result = apiInstance.DSTIdModifyPost(id);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling DigitalSignatureTransactionsApi.DSTIdModifyPost: " + e.Message );
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
| **200** | The modified DST in DRAFT state. |  -  |
| **401** | User authentication was not effective (e.g. not provided, invalid or expired). |  -  |
| **403** | User is not allowed to perform the request. |  -  |
| **404** | The resource was not found. |  -  |
| **409** | Cannot satisfy the request because the resource is in an illegal status. |  -  |
| **500** | Internal failure of the service. |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## DSTIdNotifyPost

> void DSTIdNotifyPost (Guid id)

Send notifications for a DST

This API allows to send notifications to pending users for an active _DST_.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class DSTIdNotifyPostExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DigitalSignatureTransactionsApi(Configuration.Default);
            var id = new Guid(); // Guid | The value of _the unique id_

            try
            {
                // Send notifications for a DST
                apiInstance.DSTIdNotifyPost(id);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling DigitalSignatureTransactionsApi.DSTIdNotifyPost: " + e.Message );
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


## DSTIdPublishPost

> DigitalSignatureTransaction DSTIdPublishPost (Guid id)

Publish a DST

This API allows to publish a DST, the new state becomes published. It will automatically evolve to a new state where it will be filled or signed.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class DSTIdPublishPostExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DigitalSignatureTransactionsApi(Configuration.Default);
            var id = new Guid(); // Guid | The value of _the unique id_

            try
            {
                // Publish a DST
                DigitalSignatureTransaction result = apiInstance.DSTIdPublishPost(id);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling DigitalSignatureTransactionsApi.DSTIdPublishPost: " + e.Message );
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
| **200** | The DST has been modified according to the operation. |  -  |
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


## DSTIdPut

> DigitalSignatureTransaction DSTIdPut (Guid id, DigitalSignatureTransaction digitalSignatureTransaction)

Update a DST

This API allows to update a DST.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class DSTIdPutExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DigitalSignatureTransactionsApi(Configuration.Default);
            var id = new Guid(); // Guid | The value of _the unique id_
            var digitalSignatureTransaction = new DigitalSignatureTransaction(); // DigitalSignatureTransaction | DST replacing current object.

            try
            {
                // Update a DST
                DigitalSignatureTransaction result = apiInstance.DSTIdPut(id, digitalSignatureTransaction);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling DigitalSignatureTransactionsApi.DSTIdPut: " + e.Message );
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
 **digitalSignatureTransaction** | [**DigitalSignatureTransaction**](DigitalSignatureTransaction.md)| DST replacing current object. | 

### Return type

[**DigitalSignatureTransaction**](DigitalSignatureTransaction.md)

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

- **Content-Type**: application/json
- **Accept**: application/json, */*

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The updated DST. |  -  |
| **400** | Result of a client passing incorrect or invalid data. |  -  |
| **401** | User authentication was not effective (e.g. not provided, invalid or expired). |  -  |
| **403** | User is not allowed to perform the request. |  -  |
| **404** | The resource was not found. |  -  |
| **500** | Internal failure of the service. |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## DSTIdReplacePost

> DigitalSignatureTransaction DSTIdReplacePost (Guid id)

Replace a rejected DST

This API allows to replace a rejected DST instantiating a new one. The replacing DST is created in DRAFT state.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class DSTIdReplacePostExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DigitalSignatureTransactionsApi(Configuration.Default);
            var id = new Guid(); // Guid | The value of _the unique id_

            try
            {
                // Replace a rejected DST
                DigitalSignatureTransaction result = apiInstance.DSTIdReplacePost(id);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling DigitalSignatureTransactionsApi.DSTIdReplacePost: " + e.Message );
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
| **200** | The new DST that has been generated as a replace of the referred DST. |  -  |
| **401** | User authentication was not effective (e.g. not provided, invalid or expired). |  -  |
| **403** | User is not allowed to perform the request. |  -  |
| **404** | The resource was not found. |  -  |
| **409** | Cannot satisfy the request because the resource is in an illegal status. |  -  |
| **500** | Internal failure of the service. |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## DSTIdSignDocIdSignIdGet

> DSTSigningAddressResponse DSTIdSignDocIdSignIdGet (Guid id, int docId, int signId)

Return the address for signing

This API returns the address to perform the signature.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class DSTIdSignDocIdSignIdGetExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DigitalSignatureTransactionsApi(Configuration.Default);
            var id = new Guid(); // Guid | The value of _the unique id_
            var docId = 3;  // int | Reference to _docId_ has to be signed
            var signId = 2;  // int | Reference to the signature request id

            try
            {
                // Return the address for signing
                DSTSigningAddressResponse result = apiInstance.DSTIdSignDocIdSignIdGet(id, docId, signId);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling DigitalSignatureTransactionsApi.DSTIdSignDocIdSignIdGet: " + e.Message );
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
 **docId** | **int**| Reference to _docId_ has to be signed | 
 **signId** | **int**| Reference to the signature request id | 

### Return type

[**DSTSigningAddressResponse**](DSTSigningAddressResponse.md)

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json, */*

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The URL where to sign. |  -  |
| **401** | User authentication was not effective (e.g. not provided, invalid or expired). |  -  |
| **403** | User is not allowed to perform the request. |  -  |
| **404** | The resource was not found. |  -  |
| **500** | Internal failure of the service. |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## DSTIdTemplatizePost

> DigitalSignatureTransaction DSTIdTemplatizePost (Guid id)

Create a template from a DST

This API allows to creates a new template starting from a DST. Currently implemented only for published DST templates.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class DSTIdTemplatizePostExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DigitalSignatureTransactionsApi(Configuration.Default);
            var id = new Guid(); // Guid | The value of _the unique id_

            try
            {
                // Create a template from a DST
                DigitalSignatureTransaction result = apiInstance.DSTIdTemplatizePost(id);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling DigitalSignatureTransactionsApi.DSTIdTemplatizePost: " + e.Message );
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
| **200** | The new DST that has been generated as a template of the referred DST. |  -  |
| **401** | User authentication was not effective (e.g. not provided, invalid or expired). |  -  |
| **403** | User is not allowed to perform the request. |  -  |
| **404** | The resource was not found. |  -  |
| **409** | Cannot satisfy the request because the resource is in an illegal status. |  -  |
| **500** | Internal failure of the service. |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## DSTsGet

> DSTsGetResponse DSTsGet (bool template = null, Guid userId = null, int top = null, long skip = null, bool count = null, string orderBy = null, string filter = null)

Retrieve DSTs

This API allows to list the DSTs of an organization.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class DSTsGetExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DigitalSignatureTransactionsApi(Configuration.Default);
            var template = false;  // bool | Select templates or instances (optional)  (default to false)
            var userId = new Guid(); // Guid | Select the objects relative to the user specified by the parameter. If not specified will be used the id of the current authenticated user (optional) 
            var top = 32;  // int | A number of results to return. Applied after **$skip**  (optional) 
            var skip = 64;  // long | An offset into the collection of results (optional) 
            var count = true;  // bool | If true, the server includes the count of all the items in the response  (optional) 
            var orderBy = $orderBy=updatedAt;  // string | An ordering definition (eg. $orderBy=updatedAt,desc) (optional) 
            var filter = $filter=name=="Milk";  // string | A filter definition (eg. $filter=name == \"Milk\" or surname == \"Bread\") (optional) 

            try
            {
                // Retrieve DSTs
                DSTsGetResponse result = apiInstance.DSTsGet(template, userId, top, skip, count, orderBy, filter);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling DigitalSignatureTransactionsApi.DSTsGet: " + e.Message );
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
 **template** | **bool**| Select templates or instances | [optional] [default to false]
 **userId** | [**Guid**](Guid.md)| Select the objects relative to the user specified by the parameter. If not specified will be used the id of the current authenticated user | [optional] 
 **top** | **int**| A number of results to return. Applied after **$skip**  | [optional] 
 **skip** | **long**| An offset into the collection of results | [optional] 
 **count** | **bool**| If true, the server includes the count of all the items in the response  | [optional] 
 **orderBy** | **string**| An ordering definition (eg. $orderBy&#x3D;updatedAt,desc) | [optional] 
 **filter** | **string**| A filter definition (eg. $filter&#x3D;name &#x3D;&#x3D; \&quot;Milk\&quot; or surname &#x3D;&#x3D; \&quot;Bread\&quot;) | [optional] 

### Return type

[**DSTsGetResponse**](DSTsGetResponse.md)

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
| **403** | User is not allowed to perform the request. |  -  |
| **500** | Internal failure of the service. |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## DSTsPost

> DigitalSignatureTransaction DSTsPost (DigitalSignatureTransaction digitalSignatureTransaction)

Create a new DST

This API allows to creates a new DST. A DST is created in the Draft state and then updated using PUT. Example of creation request:  ``` {   status: \"draft\",   publishedAt: null,   tags: [],   urgent: false,   template: false } ```  To add documents use the Resources Patch endpoint `/DST/{id}/resources`.  If the *template* flag is set true the DST is a Template. If the *publicTemplate* flag is set true the Template is visible to all users with rights to create a DST.  A DST is made made available to users using *publish* end point. A template generates a DST with the *instantiate* endpoint. 

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class DSTsPostExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://web.sandbox.signingtoday.com/api";
            // Configure OAuth2 access token for authorization: OAuth2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DigitalSignatureTransactionsApi(Configuration.Default);
            var digitalSignatureTransaction = new DigitalSignatureTransaction(); // DigitalSignatureTransaction | DST to append to the current resources.

            try
            {
                // Create a new DST
                DigitalSignatureTransaction result = apiInstance.DSTsPost(digitalSignatureTransaction);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling DigitalSignatureTransactionsApi.DSTsPost: " + e.Message );
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
 **digitalSignatureTransaction** | [**DigitalSignatureTransaction**](DigitalSignatureTransaction.md)| DST to append to the current resources. | 

### Return type

[**DigitalSignatureTransaction**](DigitalSignatureTransaction.md)

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

- **Content-Type**: application/json
- **Accept**: application/json, */*

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | The new DST added to the list. |  -  |
| **400** | Result of a client passing incorrect or invalid data. |  -  |
| **401** | User authentication was not effective (e.g. not provided, invalid or expired). |  -  |
| **403** | User is not allowed to perform the request. |  -  |
| **500** | Internal failure of the service. |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)

