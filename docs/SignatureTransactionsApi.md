# SigningToday.Api.SignatureTransactionsApi

All URIs are relative to *https://sandbox.signingtoday.com/api/v1*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CancelDST**](SignatureTransactionsApi.md#canceldst) | **POST** /{organization-id}/signature-transactions/{dst-id}/cancel | Mark a DST as canceled
[**CreateDST**](SignatureTransactionsApi.md#createdst) | **POST** /{organization-id}/signature-transactions | Create a Digital Signature Transaction
[**DeleteDST**](SignatureTransactionsApi.md#deletedst) | **DELETE** /{organization-id}/signature-transactions/{dst-id} | Delete a Digital Signature Transaction
[**DeleteDSTResources**](SignatureTransactionsApi.md#deletedstresources) | **DELETE** /{organization-id}/signature-transactions/{dst-id}/resources | Delete the resources of a DST
[**GetDST**](SignatureTransactionsApi.md#getdst) | **GET** /{organization-id}/signature-transactions/{dst-id} | Get information about a DST
[**GetDocument**](SignatureTransactionsApi.md#getdocument) | **GET** /{organization-id}/documents/{document-id}/download | Download a document from a DST
[**ListDSTs**](SignatureTransactionsApi.md#listdsts) | **GET** /{organization-id}/signature-transactions | List the DSTs of an organization



## CancelDST

> InlineResponse2013 CancelDST (string organizationId, Id dstId, InlineObject2 inlineObject2)

Mark a DST as canceled

This API allows to mark a Digital Signature Transaction as canceled providing a reason. 

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class CancelDSTExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://sandbox.signingtoday.com/api/v1";
            // Configure API key authorization: ApiKeyAuth
            Configuration.Default.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new SignatureTransactionsApi(Configuration.Default);
            var organizationId = api-demo;  // string | The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization  (default to "api-demo")
            var dstId = new Id(); // Id | The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** 
            var inlineObject2 = new InlineObject2(); // InlineObject2 | 

            try
            {
                // Mark a DST as canceled
                InlineResponse2013 result = apiInstance.CancelDST(organizationId, dstId, inlineObject2);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling SignatureTransactionsApi.CancelDST: " + e.Message );
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
 **dstId** | [**Id**](Id.md)| The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst**  | 
 **inlineObject2** | [**InlineObject2**](InlineObject2.md)|  | 

### Return type

[**InlineResponse2013**](InlineResponse2013.md)

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


## CreateDST

> InlineResponse2013 CreateDST (string organizationId, CreateSignatureTransaction createSignatureTransaction)

Create a Digital Signature Transaction

This API allows to create a Digital Signature Transaction. 

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class CreateDSTExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://sandbox.signingtoday.com/api/v1";
            // Configure API key authorization: ApiKeyAuth
            Configuration.Default.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new SignatureTransactionsApi(Configuration.Default);
            var organizationId = api-demo;  // string | The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization  (default to "api-demo")
            var createSignatureTransaction = new CreateSignatureTransaction(); // CreateSignatureTransaction | The new DST to create

            try
            {
                // Create a Digital Signature Transaction
                InlineResponse2013 result = apiInstance.CreateDST(organizationId, createSignatureTransaction);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling SignatureTransactionsApi.CreateDST: " + e.Message );
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
 **createSignatureTransaction** | [**CreateSignatureTransaction**](CreateSignatureTransaction.md)| The new DST to create | 

### Return type

[**InlineResponse2013**](InlineResponse2013.md)

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


## DeleteDST

> InlineResponse2009 DeleteDST (string organizationId, Id dstId)

Delete a Digital Signature Transaction

This API allows to delete a Digital Signature Transaction. 

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class DeleteDSTExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://sandbox.signingtoday.com/api/v1";
            // Configure API key authorization: ApiKeyAuth
            Configuration.Default.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new SignatureTransactionsApi(Configuration.Default);
            var organizationId = api-demo;  // string | The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization  (default to "api-demo")
            var dstId = new Id(); // Id | The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** 

            try
            {
                // Delete a Digital Signature Transaction
                InlineResponse2009 result = apiInstance.DeleteDST(organizationId, dstId);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling SignatureTransactionsApi.DeleteDST: " + e.Message );
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
 **dstId** | [**Id**](Id.md)| The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst**  | 

### Return type

[**InlineResponse2009**](InlineResponse2009.md)

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


## DeleteDSTResources

> InlineResponse20010 DeleteDSTResources (string organizationId, Id dstId)

Delete the resources of a DST

This API allows to delete the resources of a Digital Signature Transaction. 

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class DeleteDSTResourcesExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://sandbox.signingtoday.com/api/v1";
            // Configure API key authorization: ApiKeyAuth
            Configuration.Default.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new SignatureTransactionsApi(Configuration.Default);
            var organizationId = api-demo;  // string | The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization  (default to "api-demo")
            var dstId = new Id(); // Id | The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** 

            try
            {
                // Delete the resources of a DST
                InlineResponse20010 result = apiInstance.DeleteDSTResources(organizationId, dstId);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling SignatureTransactionsApi.DeleteDSTResources: " + e.Message );
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
 **dstId** | [**Id**](Id.md)| The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst**  | 

### Return type

[**InlineResponse20010**](InlineResponse20010.md)

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


## GetDST

> InlineResponse2013 GetDST (string organizationId, Id dstId)

Get information about a DST

This API allows to get information about a Digital Signature Transaction. 

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class GetDSTExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://sandbox.signingtoday.com/api/v1";
            // Configure API key authorization: ApiKeyAuth
            Configuration.Default.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new SignatureTransactionsApi(Configuration.Default);
            var organizationId = api-demo;  // string | The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization  (default to "api-demo")
            var dstId = new Id(); // Id | The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** 

            try
            {
                // Get information about a DST
                InlineResponse2013 result = apiInstance.GetDST(organizationId, dstId);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling SignatureTransactionsApi.GetDST: " + e.Message );
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
 **dstId** | [**Id**](Id.md)| The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst**  | 

### Return type

[**InlineResponse2013**](InlineResponse2013.md)

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


## GetDocument

> System.IO.Stream GetDocument (string organizationId, Id documentId)

Download a document from a DST

This API allows to download a document from a digital signature transaction. The document can be downloaded before or after one or every signature have been performed. 

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class GetDocumentExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://sandbox.signingtoday.com/api/v1";
            // Configure API key authorization: ApiKeyAuth
            Configuration.Default.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new SignatureTransactionsApi(Configuration.Default);
            var organizationId = api-demo;  // string | The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization  (default to "api-demo")
            var documentId = new Id(); // Id | The **document-id** is the uuid code that identifies a document of a digital signature transaction. This parameter is usually used in order to download a document from a digital signature transaction 

            try
            {
                // Download a document from a DST
                System.IO.Stream result = apiInstance.GetDocument(organizationId, documentId);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling SignatureTransactionsApi.GetDocument: " + e.Message );
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
 **documentId** | [**Id**](Id.md)| The **document-id** is the uuid code that identifies a document of a digital signature transaction. This parameter is usually used in order to download a document from a digital signature transaction  | 

### Return type

**System.IO.Stream**

### Authorization

[ApiKeyAuth](../README.md#ApiKeyAuth)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/pdf, application/json

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


## ListDSTs

> InlineResponse2008 ListDSTs (string organizationId, string whereSigner = null, string whereStatus = null, string whereTitle = null, string whereCreatedBy = null, string whereCreated = null, string whereSignatureStatus = null, string whereDocumentName = null, string whereReason = null, string whereSignatureName = null, string whereSignerGroup = null, int page = null, int count = null, string whereOrder = null)

List the DSTs of an organization

This API allows to list the Digital Signature Transactions of an organization. 

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;

namespace Example
{
    public class ListDSTsExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://sandbox.signingtoday.com/api/v1";
            // Configure API key authorization: ApiKeyAuth
            Configuration.Default.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new SignatureTransactionsApi(Configuration.Default);
            var organizationId = api-demo;  // string | The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization  (default to "api-demo")
            var whereSigner = jdo;  // string | Returns the Digital Signature Transactions where the specified user is a signer, searched by its id (optional) 
            var whereStatus = performed;  // string | Returns the Digital Signature Transactions with the specified status (optional) 
            var whereTitle = Signature of a document;  // string | Returns the Digital Signature Transactions that have the specified title (optional) 
            var whereCreatedBy = jdo@example;  // string | Returns the Digital Signature Transactions created by the specified user (optional) 
            var whereCreated = 2019-11-24T12:24:17.430Z;  // string | Returns the Digital Signature Transactions created before, after or in the declared range (optional) 
            var whereSignatureStatus = pending;  // string | Returns the Digital Signature Transactions where at least one of the signers has the queried status (optional) 
            var whereDocumentName = Document of example;  // string | Returns the Digital Signature Transactions that have into its documents the queried one (optional) 
            var whereReason = whereReason_example;  // string | Returns the Digital Signature Transactions with the specified reason (optional) 
            var whereSignatureName = John Doe;  // string | Returns the Digital Signature Transactions where the specified user is a signer, searched by its name (optional) 
            var whereSignerGroup = @administrators;  // string | Returns the Digital Signature Transactions that have the specified group of signers (optional) 
            var page = 1;  // int | Restricts the search to the chosen page (optional) 
            var count = 56;  // int | Sets the number of users per page to display (optional)  (default to 100)
            var whereOrder = where_first_name;  // string | The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \"**-**\" in front of the value indicates descending order), then the second value and so on (optional) 

            try
            {
                // List the DSTs of an organization
                InlineResponse2008 result = apiInstance.ListDSTs(organizationId, whereSigner, whereStatus, whereTitle, whereCreatedBy, whereCreated, whereSignatureStatus, whereDocumentName, whereReason, whereSignatureName, whereSignerGroup, page, count, whereOrder);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling SignatureTransactionsApi.ListDSTs: " + e.Message );
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
 **whereSigner** | **string**| Returns the Digital Signature Transactions where the specified user is a signer, searched by its id | [optional] 
 **whereStatus** | **string**| Returns the Digital Signature Transactions with the specified status | [optional] 
 **whereTitle** | **string**| Returns the Digital Signature Transactions that have the specified title | [optional] 
 **whereCreatedBy** | **string**| Returns the Digital Signature Transactions created by the specified user | [optional] 
 **whereCreated** | **string**| Returns the Digital Signature Transactions created before, after or in the declared range | [optional] 
 **whereSignatureStatus** | **string**| Returns the Digital Signature Transactions where at least one of the signers has the queried status | [optional] 
 **whereDocumentName** | **string**| Returns the Digital Signature Transactions that have into its documents the queried one | [optional] 
 **whereReason** | **string**| Returns the Digital Signature Transactions with the specified reason | [optional] 
 **whereSignatureName** | **string**| Returns the Digital Signature Transactions where the specified user is a signer, searched by its name | [optional] 
 **whereSignerGroup** | **string**| Returns the Digital Signature Transactions that have the specified group of signers | [optional] 
 **page** | **int**| Restricts the search to the chosen page | [optional] 
 **count** | **int**| Sets the number of users per page to display | [optional] [default to 100]
 **whereOrder** | **string**| The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on | [optional] 

### Return type

[**InlineResponse2008**](InlineResponse2008.md)

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

