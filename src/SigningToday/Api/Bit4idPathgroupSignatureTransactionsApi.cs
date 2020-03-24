/* 
 * Signing Today API
 *
 * *Signing Today* enables seamless integration of digital signatures into any website by the use of easy requests to our API. This is the smart way of adding digital signature support with a great user experience.   *Signing Today APIs* use HTTP methods and are RESTful based, moreover they are protected by a *server to server authentication* standard by the use of tokens.   *Signing Today APIs* can be used in these environments:   | Environment | Description | Endpoint | | - -- -- -- -- -- | - -- -- -- -- -- | - -- -- -- - | | Sandbox     | Test environment | `https://sandbox.signingtoday.com` | | Live        | Production environment | `https://api.signingtoday.com` |   For every single request to Signing Today has to be defined the following *HTTP* header: - `Authorization`, which contains the authentication token.  If the request has a body than another *HTTP* header is requested: - `Content-Type`, with `application/json` value.   Follows an example of usage to enumerate all the user of *my-org* organization.  **Example**  ```json $ curl https://sandbox.signingtoday.com/api/v1/my-org/users \\     -H 'Authorization: Token <access-token>' ```  ## HTTP methods used  APIs use the right HTTP verb in every situation.  | Method   | Description                    | | - -- -- -- - | - -- -- -- -- -- -- -- -- -- -- -- -- -- -- - | | `GET`    | Request data from a resource   | | `POST`   | Send data to create a resource | | `PUT`    | Update a resource              | | `PATCH`  | Partially update a resource    | | `DELETE` | Delete a resourse              |   ## Response definition  All the response are in JSON format. As response to a request of all users of an organization you will have a result like this:  ```json {     \"pagination\": {       \"count\": 75,       \"previous\": \"https://sandbox.signingtoday.com/api/v1/my-org/users?page=1\",       \"next\": \"https://sandbox.signingtoday.com/api/v1/my-org/users?page=3\",       \"pages\": 8,       \"page\": 2     },     \"meta\": {       \"code\": 200     },     \"data\": [       {         \"id\": \"jdo\",         \"status\": \"enabled\",         \"type\": \"Basic user account\",         \"email\": johndoe@dummyemail.com,         \"first_name\": \"John\",         \"last_name\": \"Doe\",         \"wallet\": [],         \"created_by\": \"system\",         \"owner\": false,         \"automatic\": false,         \"rao\": false       },       ...     ]   } ```  The JSON of the response is made of three parts: - Pagination - Meta - Data  ### Pagination  *Pagination* object allows to split the response into parts and then to rebuild it sequentially by the use of `next` and `previous` parameters, by which you get previous and following blocks. The *Pagination* is present only if the response is a list of objects.  The general structure of *Pagination* object is the following:  ```json {     \"pagination\": {       \"count\": 75,       \"previous\": \"https://sandbox.signingtoday.com/api/v1/my-org/users?page=1\",       \"next\": \"https://sandbox.signingtoday.com/api/v1/my-org/users?page=3\",       \"pages\": 8,       \"page\": 2     },     ...   } ```  ### Meta  *Meta* object is used to enrich the information about the response. In the previous example, a successful case of response, *Meta* will have value `status: 2XX`. In case of unsuccessful response, *Meta* will have further information, as follows:  ```json {     \"meta\": {       \"code\": <HTTP STATUS CODE>,       \"error_type\": <STATUS CODE DESCRIPTION>,       \"error_message\": <ERROR DESCRIPTION>     }   } ```  ### Data  *Data* object outputs as object or list of them. Contains the expected data as requested to the API.  ## Search filters  Search filters of the API have the following structure:  `where_ATTRIBUTENAME`=`VALUE`  In this way you make a case-sensitive search of *VALUE*. You can extend it through the Django lookup, obtaining more specific filters. For example:  `where_ATTRIBUTENAME__LOOKUP`=`VALUE`  where *LOOKUP* can be replaced with `icontains` to have a partial insensitive research, where  `where_first_name__icontains`=`CHa`  matches with every user that have the *cha* string in their name, with no differences between capital and lower cases.  [Here](https://docs.djangoproject.com/en/1.11/ref/models/querysets/#field-lookups) the list of the lookups.  ## Webhooks  Signing Today supports webhooks for the update of DSTs and identities status. You can choose if to use or not webhooks and if you want to receive updates about DSTs and/or identities. You can configurate it on application token level, in the *webhook* field, as follows:  ```json \"webhooks\": {   \"dst\": \"URL\",   \"identity\": \"URL\"   } ```  ### DSTs status update  DSTs send the following status updates: - **DST_STATUS_CHANGED**: whenever the DST changes its status - **SIGNATURE_STATUS_CHANGED**: whenever one of the signatures changes its status  #### DST_STATUS_CHANGED  Sends the following information:  ```json {     \"message\": \"DST_STATUS_CHANGED\",     \"data\": {       \"status\": \"<DST_STATUS>\",       \"dst\": \"<DST_ID>\",       \"reason\": \"<DST_REASON>\"     }   } ```  #### SIGNATURE_STATUS_CHANGED  Sends the following information:  ```json {     \"message\": \"SIGNATURE_STATUS_CHANGED\",     \"data\": {       \"status\": \"<SIGNATURE_STATUS>\",       \"group\": <MEMBERSHIP_GROUP_INDEX>,       \"dst\": {         \"id\": \"<DST_ID>\",         \"title\": \"<DST_TITLE>\"       },       \"signature\": \"<SIGNATURE_ID>\",       \"signer\": \"<SIGNER_USERNAME>\",       \"position\": \"<SIGNATURE_POSITION>\",       \"document\": {         \"display_name\": \"<DOCUMENT_TITLE>\",         \"id\": \"<DOCUMENT_ID>\",         \"order\": <DOCUMENT_INDEX>       },       \"automatic\": <DECLARES_IF_THE_SIGNER_IS_AUTOMATIC>,       \"page\": \"<SIGNATURE_PAGE>\"     }   } ```  ### Identities status update  Identities send the following status updates: - **IDENTITY_REQUEST_ENROLLED**: whenever an identity request is activated  #### IDENTITY_REQUEST_ENROLLED  Sends the following information:  ```json {     \"message\": \"IDENTITY_REQUEST_ENROLLED\",     \"data\": {       \"status\": \"<REQUEST_STATUS>\",       \"request\": \"<REQUEST_ID>\",       \"user\": \"<APPLICANT_USERNAME>\"     }   } ```  ### Urlback  Sometimes may be necessary to make a redirect after an user, from the signature tray, has completed his operations or activated a certificate.  If set, redirects could happen in 3 cases: - after a signature or decline - after a DST has been signed by all the signers or canceled - after the activation of a certificate  In the first two cases the urlback returns the following information through a data form: - **dst-id**: id of the DST - **dst-url**: signature_ticket of the signature - **dst-status**: current status of the DST - **dst-signature-id**: id of the signature - **dst-signature-status**: current status of the signature - **user**: username of the signer - **decline-reason**: in case of a refused DST contains the reason of the decline  In the last case the urlback returns the following information through a data form: - **user**: username of the user activated the certificate - **identity-provider**: the provider has been used to issue the certificate - **identity-request-id**: id of the enrollment request - **identity-id**: id of the new identity - **identity-label**: the label assigned to the identity - **identity-certificate**: public key of the certificate   
 *
 * The version of the OpenAPI document: 1.5.0
 * Contact: smartcloud@bit4id.com
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using RestSharp;
using SigningToday.Client;
using SigningToday.Model;

namespace SigningToday.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IBit4idPathgroupSignatureTransactionsApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Mark a DST as canceled
        /// </summary>
        /// <remarks>
        /// This API allows to mark a Digital Signature Transaction as canceled providing a reason. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <param name="inlineObject2"></param>
        /// <returns>InlineResponse2013</returns>
        InlineResponse2013 CancelDST (string organizationId, Id dstId, InlineObject2 inlineObject2);

        /// <summary>
        /// Mark a DST as canceled
        /// </summary>
        /// <remarks>
        /// This API allows to mark a Digital Signature Transaction as canceled providing a reason. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <param name="inlineObject2"></param>
        /// <returns>ApiResponse of InlineResponse2013</returns>
        ApiResponse<InlineResponse2013> CancelDSTWithHttpInfo (string organizationId, Id dstId, InlineObject2 inlineObject2);
        /// <summary>
        /// Create a Digital Signature Transaction
        /// </summary>
        /// <remarks>
        /// This API allows to create a Digital Signature Transaction. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="createSignatureTransaction">The new DST to create</param>
        /// <returns>InlineResponse2013</returns>
        InlineResponse2013 CreateDST (string organizationId, CreateSignatureTransaction createSignatureTransaction);

        /// <summary>
        /// Create a Digital Signature Transaction
        /// </summary>
        /// <remarks>
        /// This API allows to create a Digital Signature Transaction. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="createSignatureTransaction">The new DST to create</param>
        /// <returns>ApiResponse of InlineResponse2013</returns>
        ApiResponse<InlineResponse2013> CreateDSTWithHttpInfo (string organizationId, CreateSignatureTransaction createSignatureTransaction);
        /// <summary>
        /// Delete a Digital Signature Transaction
        /// </summary>
        /// <remarks>
        /// This API allows to delete a Digital Signature Transaction. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <returns>InlineResponse2009</returns>
        InlineResponse2009 DeleteDST (string organizationId, Id dstId);

        /// <summary>
        /// Delete a Digital Signature Transaction
        /// </summary>
        /// <remarks>
        /// This API allows to delete a Digital Signature Transaction. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <returns>ApiResponse of InlineResponse2009</returns>
        ApiResponse<InlineResponse2009> DeleteDSTWithHttpInfo (string organizationId, Id dstId);
        /// <summary>
        /// Delete the resources of a DST
        /// </summary>
        /// <remarks>
        /// This API allows to delete the resources of a Digital Signature Transaction. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <returns>InlineResponse20010</returns>
        InlineResponse20010 DeleteDSTResources (string organizationId, Id dstId);

        /// <summary>
        /// Delete the resources of a DST
        /// </summary>
        /// <remarks>
        /// This API allows to delete the resources of a Digital Signature Transaction. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <returns>ApiResponse of InlineResponse20010</returns>
        ApiResponse<InlineResponse20010> DeleteDSTResourcesWithHttpInfo (string organizationId, Id dstId);
        /// <summary>
        /// Get information about a DST
        /// </summary>
        /// <remarks>
        /// This API allows to get information about a Digital Signature Transaction. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <returns>InlineResponse2013</returns>
        InlineResponse2013 GetDST (string organizationId, Id dstId);

        /// <summary>
        /// Get information about a DST
        /// </summary>
        /// <remarks>
        /// This API allows to get information about a Digital Signature Transaction. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <returns>ApiResponse of InlineResponse2013</returns>
        ApiResponse<InlineResponse2013> GetDSTWithHttpInfo (string organizationId, Id dstId);
        /// <summary>
        /// Download a document from a DST
        /// </summary>
        /// <remarks>
        /// This API allows to download a document from a digital signature transaction. The document can be downloaded before or after one or every signature have been performed. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="documentId">The **document-id** is the uuid code that identifies a document of a digital signature transaction. This parameter is usually used in order to download a document from a digital signature transaction </param>
        /// <returns>System.IO.Stream</returns>
        System.IO.Stream GetDocument (string organizationId, Id documentId);

        /// <summary>
        /// Download a document from a DST
        /// </summary>
        /// <remarks>
        /// This API allows to download a document from a digital signature transaction. The document can be downloaded before or after one or every signature have been performed. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="documentId">The **document-id** is the uuid code that identifies a document of a digital signature transaction. This parameter is usually used in order to download a document from a digital signature transaction </param>
        /// <returns>ApiResponse of System.IO.Stream</returns>
        ApiResponse<System.IO.Stream> GetDocumentWithHttpInfo (string organizationId, Id documentId);
        /// <summary>
        /// List the DSTs of an organization
        /// </summary>
        /// <remarks>
        /// This API allows to list the Digital Signature Transactions of an organization. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="whereSigner">Returns the Digital Signature Transactions where the specified user is a signer, searched by its id (optional)</param>
        /// <param name="whereStatus">Returns the Digital Signature Transactions with the specified status (optional)</param>
        /// <param name="whereTitle">Returns the Digital Signature Transactions that have the specified title (optional)</param>
        /// <param name="whereCreatedBy">Returns the Digital Signature Transactions created by the specified user (optional)</param>
        /// <param name="whereCreated">Returns the Digital Signature Transactions created before, after or in the declared range (optional)</param>
        /// <param name="whereSignatureStatus">Returns the Digital Signature Transactions where at least one of the signers has the queried status (optional)</param>
        /// <param name="whereDocumentName">Returns the Digital Signature Transactions that have into its documents the queried one (optional)</param>
        /// <param name="whereReason">Returns the Digital Signature Transactions with the specified reason (optional)</param>
        /// <param name="whereSignatureName">Returns the Digital Signature Transactions where the specified user is a signer, searched by its name (optional)</param>
        /// <param name="whereSignerGroup">Returns the Digital Signature Transactions that have the specified group of signers (optional)</param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>InlineResponse2008</returns>
        InlineResponse2008 ListDSTs (string organizationId, string whereSigner = default(string), string whereStatus = default(string), string whereTitle = default(string), string whereCreatedBy = default(string), string whereCreated = default(string), string whereSignatureStatus = default(string), string whereDocumentName = default(string), string whereReason = default(string), string whereSignatureName = default(string), string whereSignerGroup = default(string), int page = default(int), int count = default(int), string whereOrder = default(string));

        /// <summary>
        /// List the DSTs of an organization
        /// </summary>
        /// <remarks>
        /// This API allows to list the Digital Signature Transactions of an organization. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="whereSigner">Returns the Digital Signature Transactions where the specified user is a signer, searched by its id (optional)</param>
        /// <param name="whereStatus">Returns the Digital Signature Transactions with the specified status (optional)</param>
        /// <param name="whereTitle">Returns the Digital Signature Transactions that have the specified title (optional)</param>
        /// <param name="whereCreatedBy">Returns the Digital Signature Transactions created by the specified user (optional)</param>
        /// <param name="whereCreated">Returns the Digital Signature Transactions created before, after or in the declared range (optional)</param>
        /// <param name="whereSignatureStatus">Returns the Digital Signature Transactions where at least one of the signers has the queried status (optional)</param>
        /// <param name="whereDocumentName">Returns the Digital Signature Transactions that have into its documents the queried one (optional)</param>
        /// <param name="whereReason">Returns the Digital Signature Transactions with the specified reason (optional)</param>
        /// <param name="whereSignatureName">Returns the Digital Signature Transactions where the specified user is a signer, searched by its name (optional)</param>
        /// <param name="whereSignerGroup">Returns the Digital Signature Transactions that have the specified group of signers (optional)</param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>ApiResponse of InlineResponse2008</returns>
        ApiResponse<InlineResponse2008> ListDSTsWithHttpInfo (string organizationId, string whereSigner = default(string), string whereStatus = default(string), string whereTitle = default(string), string whereCreatedBy = default(string), string whereCreated = default(string), string whereSignatureStatus = default(string), string whereDocumentName = default(string), string whereReason = default(string), string whereSignatureName = default(string), string whereSignerGroup = default(string), int page = default(int), int count = default(int), string whereOrder = default(string));
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// Mark a DST as canceled
        /// </summary>
        /// <remarks>
        /// This API allows to mark a Digital Signature Transaction as canceled providing a reason. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <param name="inlineObject2"></param>
        /// <returns>Task of InlineResponse2013</returns>
        System.Threading.Tasks.Task<InlineResponse2013> CancelDSTAsync (string organizationId, Id dstId, InlineObject2 inlineObject2);

        /// <summary>
        /// Mark a DST as canceled
        /// </summary>
        /// <remarks>
        /// This API allows to mark a Digital Signature Transaction as canceled providing a reason. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <param name="inlineObject2"></param>
        /// <returns>Task of ApiResponse (InlineResponse2013)</returns>
        System.Threading.Tasks.Task<ApiResponse<InlineResponse2013>> CancelDSTAsyncWithHttpInfo (string organizationId, Id dstId, InlineObject2 inlineObject2);
        /// <summary>
        /// Create a Digital Signature Transaction
        /// </summary>
        /// <remarks>
        /// This API allows to create a Digital Signature Transaction. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="createSignatureTransaction">The new DST to create</param>
        /// <returns>Task of InlineResponse2013</returns>
        System.Threading.Tasks.Task<InlineResponse2013> CreateDSTAsync (string organizationId, CreateSignatureTransaction createSignatureTransaction);

        /// <summary>
        /// Create a Digital Signature Transaction
        /// </summary>
        /// <remarks>
        /// This API allows to create a Digital Signature Transaction. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="createSignatureTransaction">The new DST to create</param>
        /// <returns>Task of ApiResponse (InlineResponse2013)</returns>
        System.Threading.Tasks.Task<ApiResponse<InlineResponse2013>> CreateDSTAsyncWithHttpInfo (string organizationId, CreateSignatureTransaction createSignatureTransaction);
        /// <summary>
        /// Delete a Digital Signature Transaction
        /// </summary>
        /// <remarks>
        /// This API allows to delete a Digital Signature Transaction. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <returns>Task of InlineResponse2009</returns>
        System.Threading.Tasks.Task<InlineResponse2009> DeleteDSTAsync (string organizationId, Id dstId);

        /// <summary>
        /// Delete a Digital Signature Transaction
        /// </summary>
        /// <remarks>
        /// This API allows to delete a Digital Signature Transaction. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <returns>Task of ApiResponse (InlineResponse2009)</returns>
        System.Threading.Tasks.Task<ApiResponse<InlineResponse2009>> DeleteDSTAsyncWithHttpInfo (string organizationId, Id dstId);
        /// <summary>
        /// Delete the resources of a DST
        /// </summary>
        /// <remarks>
        /// This API allows to delete the resources of a Digital Signature Transaction. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <returns>Task of InlineResponse20010</returns>
        System.Threading.Tasks.Task<InlineResponse20010> DeleteDSTResourcesAsync (string organizationId, Id dstId);

        /// <summary>
        /// Delete the resources of a DST
        /// </summary>
        /// <remarks>
        /// This API allows to delete the resources of a Digital Signature Transaction. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <returns>Task of ApiResponse (InlineResponse20010)</returns>
        System.Threading.Tasks.Task<ApiResponse<InlineResponse20010>> DeleteDSTResourcesAsyncWithHttpInfo (string organizationId, Id dstId);
        /// <summary>
        /// Get information about a DST
        /// </summary>
        /// <remarks>
        /// This API allows to get information about a Digital Signature Transaction. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <returns>Task of InlineResponse2013</returns>
        System.Threading.Tasks.Task<InlineResponse2013> GetDSTAsync (string organizationId, Id dstId);

        /// <summary>
        /// Get information about a DST
        /// </summary>
        /// <remarks>
        /// This API allows to get information about a Digital Signature Transaction. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <returns>Task of ApiResponse (InlineResponse2013)</returns>
        System.Threading.Tasks.Task<ApiResponse<InlineResponse2013>> GetDSTAsyncWithHttpInfo (string organizationId, Id dstId);
        /// <summary>
        /// Download a document from a DST
        /// </summary>
        /// <remarks>
        /// This API allows to download a document from a digital signature transaction. The document can be downloaded before or after one or every signature have been performed. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="documentId">The **document-id** is the uuid code that identifies a document of a digital signature transaction. This parameter is usually used in order to download a document from a digital signature transaction </param>
        /// <returns>Task of System.IO.Stream</returns>
        System.Threading.Tasks.Task<System.IO.Stream> GetDocumentAsync (string organizationId, Id documentId);

        /// <summary>
        /// Download a document from a DST
        /// </summary>
        /// <remarks>
        /// This API allows to download a document from a digital signature transaction. The document can be downloaded before or after one or every signature have been performed. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="documentId">The **document-id** is the uuid code that identifies a document of a digital signature transaction. This parameter is usually used in order to download a document from a digital signature transaction </param>
        /// <returns>Task of ApiResponse (System.IO.Stream)</returns>
        System.Threading.Tasks.Task<ApiResponse<System.IO.Stream>> GetDocumentAsyncWithHttpInfo (string organizationId, Id documentId);
        /// <summary>
        /// List the DSTs of an organization
        /// </summary>
        /// <remarks>
        /// This API allows to list the Digital Signature Transactions of an organization. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="whereSigner">Returns the Digital Signature Transactions where the specified user is a signer, searched by its id (optional)</param>
        /// <param name="whereStatus">Returns the Digital Signature Transactions with the specified status (optional)</param>
        /// <param name="whereTitle">Returns the Digital Signature Transactions that have the specified title (optional)</param>
        /// <param name="whereCreatedBy">Returns the Digital Signature Transactions created by the specified user (optional)</param>
        /// <param name="whereCreated">Returns the Digital Signature Transactions created before, after or in the declared range (optional)</param>
        /// <param name="whereSignatureStatus">Returns the Digital Signature Transactions where at least one of the signers has the queried status (optional)</param>
        /// <param name="whereDocumentName">Returns the Digital Signature Transactions that have into its documents the queried one (optional)</param>
        /// <param name="whereReason">Returns the Digital Signature Transactions with the specified reason (optional)</param>
        /// <param name="whereSignatureName">Returns the Digital Signature Transactions where the specified user is a signer, searched by its name (optional)</param>
        /// <param name="whereSignerGroup">Returns the Digital Signature Transactions that have the specified group of signers (optional)</param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>Task of InlineResponse2008</returns>
        System.Threading.Tasks.Task<InlineResponse2008> ListDSTsAsync (string organizationId, string whereSigner = default(string), string whereStatus = default(string), string whereTitle = default(string), string whereCreatedBy = default(string), string whereCreated = default(string), string whereSignatureStatus = default(string), string whereDocumentName = default(string), string whereReason = default(string), string whereSignatureName = default(string), string whereSignerGroup = default(string), int page = default(int), int count = default(int), string whereOrder = default(string));

        /// <summary>
        /// List the DSTs of an organization
        /// </summary>
        /// <remarks>
        /// This API allows to list the Digital Signature Transactions of an organization. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="whereSigner">Returns the Digital Signature Transactions where the specified user is a signer, searched by its id (optional)</param>
        /// <param name="whereStatus">Returns the Digital Signature Transactions with the specified status (optional)</param>
        /// <param name="whereTitle">Returns the Digital Signature Transactions that have the specified title (optional)</param>
        /// <param name="whereCreatedBy">Returns the Digital Signature Transactions created by the specified user (optional)</param>
        /// <param name="whereCreated">Returns the Digital Signature Transactions created before, after or in the declared range (optional)</param>
        /// <param name="whereSignatureStatus">Returns the Digital Signature Transactions where at least one of the signers has the queried status (optional)</param>
        /// <param name="whereDocumentName">Returns the Digital Signature Transactions that have into its documents the queried one (optional)</param>
        /// <param name="whereReason">Returns the Digital Signature Transactions with the specified reason (optional)</param>
        /// <param name="whereSignatureName">Returns the Digital Signature Transactions where the specified user is a signer, searched by its name (optional)</param>
        /// <param name="whereSignerGroup">Returns the Digital Signature Transactions that have the specified group of signers (optional)</param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>Task of ApiResponse (InlineResponse2008)</returns>
        System.Threading.Tasks.Task<ApiResponse<InlineResponse2008>> ListDSTsAsyncWithHttpInfo (string organizationId, string whereSigner = default(string), string whereStatus = default(string), string whereTitle = default(string), string whereCreatedBy = default(string), string whereCreated = default(string), string whereSignatureStatus = default(string), string whereDocumentName = default(string), string whereReason = default(string), string whereSignatureName = default(string), string whereSignerGroup = default(string), int page = default(int), int count = default(int), string whereOrder = default(string));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class Bit4idPathgroupSignatureTransactionsApi : IBit4idPathgroupSignatureTransactionsApi
    {
        private SigningToday.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="Bit4idPathgroupSignatureTransactionsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public Bit4idPathgroupSignatureTransactionsApi(String basePath)
        {
            this.Configuration = new SigningToday.Client.Configuration { BasePath = basePath };

            ExceptionFactory = SigningToday.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Bit4idPathgroupSignatureTransactionsApi"/> class
        /// </summary>
        /// <returns></returns>
        public Bit4idPathgroupSignatureTransactionsApi()
        {
            this.Configuration = SigningToday.Client.Configuration.Default;

            ExceptionFactory = SigningToday.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Bit4idPathgroupSignatureTransactionsApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public Bit4idPathgroupSignatureTransactionsApi(SigningToday.Client.Configuration configuration = null)
        {
            if (configuration == null) // use the default one in Configuration
                this.Configuration = SigningToday.Client.Configuration.Default;
            else
                this.Configuration = configuration;

            ExceptionFactory = SigningToday.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public String GetBasePath()
        {
            return this.Configuration.ApiClient.RestClient.BaseUrl.ToString();
        }

        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        [Obsolete("SetBasePath is deprecated, please do 'Configuration.ApiClient = new ApiClient(\"http://new-path\")' instead.")]
        public void SetBasePath(String basePath)
        {
            // do nothing
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public SigningToday.Client.Configuration Configuration {get; set;}

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public SigningToday.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        /// Gets the default header.
        /// </summary>
        /// <returns>Dictionary of HTTP header</returns>
        [Obsolete("DefaultHeader is deprecated, please use Configuration.DefaultHeader instead.")]
        public IDictionary<String, String> DefaultHeader()
        {
            return new ReadOnlyDictionary<string, string>(this.Configuration.DefaultHeader);
        }

        /// <summary>
        /// Add default header.
        /// </summary>
        /// <param name="key">Header field name.</param>
        /// <param name="value">Header field value.</param>
        /// <returns></returns>
        [Obsolete("AddDefaultHeader is deprecated, please use Configuration.AddDefaultHeader instead.")]
        public void AddDefaultHeader(string key, string value)
        {
            this.Configuration.AddDefaultHeader(key, value);
        }

        /// <summary>
        /// Mark a DST as canceled This API allows to mark a Digital Signature Transaction as canceled providing a reason. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <param name="inlineObject2"></param>
        /// <returns>InlineResponse2013</returns>
        public InlineResponse2013 CancelDST (string organizationId, Id dstId, InlineObject2 inlineObject2)
        {
             ApiResponse<InlineResponse2013> localVarResponse = CancelDSTWithHttpInfo(organizationId, dstId, inlineObject2);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Mark a DST as canceled This API allows to mark a Digital Signature Transaction as canceled providing a reason. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <param name="inlineObject2"></param>
        /// <returns>ApiResponse of InlineResponse2013</returns>
        public ApiResponse<InlineResponse2013> CancelDSTWithHttpInfo (string organizationId, Id dstId, InlineObject2 inlineObject2)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling Bit4idPathgroupSignatureTransactionsApi->CancelDST");
            // verify the required parameter 'dstId' is set
            if (dstId == null)
                throw new ApiException(400, "Missing required parameter 'dstId' when calling Bit4idPathgroupSignatureTransactionsApi->CancelDST");
            // verify the required parameter 'inlineObject2' is set
            if (inlineObject2 == null)
                throw new ApiException(400, "Missing required parameter 'inlineObject2' when calling Bit4idPathgroupSignatureTransactionsApi->CancelDST");

            var localVarPath = "/{organization-id}/signature-transactions/{dst-id}/cancel";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (organizationId != null) localVarPathParams.Add("organization-id", this.Configuration.ApiClient.ParameterToString(organizationId)); // path parameter
            if (dstId != null) localVarPathParams.Add("dst-id", this.Configuration.ApiClient.ParameterToString(dstId)); // path parameter
            if (inlineObject2 != null && inlineObject2.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(inlineObject2); // http body (model) parameter
            }
            else
            {
                localVarPostBody = inlineObject2; // byte array
            }

            // authentication (ApiKeyAuth) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = this.Configuration.GetApiKeyWithPrefix("Authorization");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("CancelDST", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2013>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2013) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2013)));
        }

        /// <summary>
        /// Mark a DST as canceled This API allows to mark a Digital Signature Transaction as canceled providing a reason. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <param name="inlineObject2"></param>
        /// <returns>Task of InlineResponse2013</returns>
        public async System.Threading.Tasks.Task<InlineResponse2013> CancelDSTAsync (string organizationId, Id dstId, InlineObject2 inlineObject2)
        {
             ApiResponse<InlineResponse2013> localVarResponse = await CancelDSTAsyncWithHttpInfo(organizationId, dstId, inlineObject2);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Mark a DST as canceled This API allows to mark a Digital Signature Transaction as canceled providing a reason. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <param name="inlineObject2"></param>
        /// <returns>Task of ApiResponse (InlineResponse2013)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<InlineResponse2013>> CancelDSTAsyncWithHttpInfo (string organizationId, Id dstId, InlineObject2 inlineObject2)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling Bit4idPathgroupSignatureTransactionsApi->CancelDST");
            // verify the required parameter 'dstId' is set
            if (dstId == null)
                throw new ApiException(400, "Missing required parameter 'dstId' when calling Bit4idPathgroupSignatureTransactionsApi->CancelDST");
            // verify the required parameter 'inlineObject2' is set
            if (inlineObject2 == null)
                throw new ApiException(400, "Missing required parameter 'inlineObject2' when calling Bit4idPathgroupSignatureTransactionsApi->CancelDST");

            var localVarPath = "/{organization-id}/signature-transactions/{dst-id}/cancel";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (organizationId != null) localVarPathParams.Add("organization-id", this.Configuration.ApiClient.ParameterToString(organizationId)); // path parameter
            if (dstId != null) localVarPathParams.Add("dst-id", this.Configuration.ApiClient.ParameterToString(dstId)); // path parameter
            if (inlineObject2 != null && inlineObject2.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(inlineObject2); // http body (model) parameter
            }
            else
            {
                localVarPostBody = inlineObject2; // byte array
            }

            // authentication (ApiKeyAuth) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = this.Configuration.GetApiKeyWithPrefix("Authorization");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("CancelDST", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2013>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2013) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2013)));
        }

        /// <summary>
        /// Create a Digital Signature Transaction This API allows to create a Digital Signature Transaction. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="createSignatureTransaction">The new DST to create</param>
        /// <returns>InlineResponse2013</returns>
        public InlineResponse2013 CreateDST (string organizationId, CreateSignatureTransaction createSignatureTransaction)
        {
             ApiResponse<InlineResponse2013> localVarResponse = CreateDSTWithHttpInfo(organizationId, createSignatureTransaction);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Create a Digital Signature Transaction This API allows to create a Digital Signature Transaction. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="createSignatureTransaction">The new DST to create</param>
        /// <returns>ApiResponse of InlineResponse2013</returns>
        public ApiResponse<InlineResponse2013> CreateDSTWithHttpInfo (string organizationId, CreateSignatureTransaction createSignatureTransaction)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling Bit4idPathgroupSignatureTransactionsApi->CreateDST");
            // verify the required parameter 'createSignatureTransaction' is set
            if (createSignatureTransaction == null)
                throw new ApiException(400, "Missing required parameter 'createSignatureTransaction' when calling Bit4idPathgroupSignatureTransactionsApi->CreateDST");

            var localVarPath = "/{organization-id}/signature-transactions";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (organizationId != null) localVarPathParams.Add("organization-id", this.Configuration.ApiClient.ParameterToString(organizationId)); // path parameter
            if (createSignatureTransaction != null && createSignatureTransaction.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(createSignatureTransaction); // http body (model) parameter
            }
            else
            {
                localVarPostBody = createSignatureTransaction; // byte array
            }

            // authentication (ApiKeyAuth) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = this.Configuration.GetApiKeyWithPrefix("Authorization");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("CreateDST", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2013>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2013) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2013)));
        }

        /// <summary>
        /// Create a Digital Signature Transaction This API allows to create a Digital Signature Transaction. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="createSignatureTransaction">The new DST to create</param>
        /// <returns>Task of InlineResponse2013</returns>
        public async System.Threading.Tasks.Task<InlineResponse2013> CreateDSTAsync (string organizationId, CreateSignatureTransaction createSignatureTransaction)
        {
             ApiResponse<InlineResponse2013> localVarResponse = await CreateDSTAsyncWithHttpInfo(organizationId, createSignatureTransaction);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Create a Digital Signature Transaction This API allows to create a Digital Signature Transaction. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="createSignatureTransaction">The new DST to create</param>
        /// <returns>Task of ApiResponse (InlineResponse2013)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<InlineResponse2013>> CreateDSTAsyncWithHttpInfo (string organizationId, CreateSignatureTransaction createSignatureTransaction)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling Bit4idPathgroupSignatureTransactionsApi->CreateDST");
            // verify the required parameter 'createSignatureTransaction' is set
            if (createSignatureTransaction == null)
                throw new ApiException(400, "Missing required parameter 'createSignatureTransaction' when calling Bit4idPathgroupSignatureTransactionsApi->CreateDST");

            var localVarPath = "/{organization-id}/signature-transactions";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (organizationId != null) localVarPathParams.Add("organization-id", this.Configuration.ApiClient.ParameterToString(organizationId)); // path parameter
            if (createSignatureTransaction != null && createSignatureTransaction.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(createSignatureTransaction); // http body (model) parameter
            }
            else
            {
                localVarPostBody = createSignatureTransaction; // byte array
            }

            // authentication (ApiKeyAuth) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = this.Configuration.GetApiKeyWithPrefix("Authorization");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("CreateDST", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2013>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2013) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2013)));
        }

        /// <summary>
        /// Delete a Digital Signature Transaction This API allows to delete a Digital Signature Transaction. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <returns>InlineResponse2009</returns>
        public InlineResponse2009 DeleteDST (string organizationId, Id dstId)
        {
             ApiResponse<InlineResponse2009> localVarResponse = DeleteDSTWithHttpInfo(organizationId, dstId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Delete a Digital Signature Transaction This API allows to delete a Digital Signature Transaction. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <returns>ApiResponse of InlineResponse2009</returns>
        public ApiResponse<InlineResponse2009> DeleteDSTWithHttpInfo (string organizationId, Id dstId)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling Bit4idPathgroupSignatureTransactionsApi->DeleteDST");
            // verify the required parameter 'dstId' is set
            if (dstId == null)
                throw new ApiException(400, "Missing required parameter 'dstId' when calling Bit4idPathgroupSignatureTransactionsApi->DeleteDST");

            var localVarPath = "/{organization-id}/signature-transactions/{dst-id}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (organizationId != null) localVarPathParams.Add("organization-id", this.Configuration.ApiClient.ParameterToString(organizationId)); // path parameter
            if (dstId != null) localVarPathParams.Add("dst-id", this.Configuration.ApiClient.ParameterToString(dstId)); // path parameter

            // authentication (ApiKeyAuth) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = this.Configuration.GetApiKeyWithPrefix("Authorization");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.DELETE, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("DeleteDST", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2009>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2009) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2009)));
        }

        /// <summary>
        /// Delete a Digital Signature Transaction This API allows to delete a Digital Signature Transaction. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <returns>Task of InlineResponse2009</returns>
        public async System.Threading.Tasks.Task<InlineResponse2009> DeleteDSTAsync (string organizationId, Id dstId)
        {
             ApiResponse<InlineResponse2009> localVarResponse = await DeleteDSTAsyncWithHttpInfo(organizationId, dstId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Delete a Digital Signature Transaction This API allows to delete a Digital Signature Transaction. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <returns>Task of ApiResponse (InlineResponse2009)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<InlineResponse2009>> DeleteDSTAsyncWithHttpInfo (string organizationId, Id dstId)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling Bit4idPathgroupSignatureTransactionsApi->DeleteDST");
            // verify the required parameter 'dstId' is set
            if (dstId == null)
                throw new ApiException(400, "Missing required parameter 'dstId' when calling Bit4idPathgroupSignatureTransactionsApi->DeleteDST");

            var localVarPath = "/{organization-id}/signature-transactions/{dst-id}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (organizationId != null) localVarPathParams.Add("organization-id", this.Configuration.ApiClient.ParameterToString(organizationId)); // path parameter
            if (dstId != null) localVarPathParams.Add("dst-id", this.Configuration.ApiClient.ParameterToString(dstId)); // path parameter

            // authentication (ApiKeyAuth) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = this.Configuration.GetApiKeyWithPrefix("Authorization");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.DELETE, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("DeleteDST", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2009>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2009) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2009)));
        }

        /// <summary>
        /// Delete the resources of a DST This API allows to delete the resources of a Digital Signature Transaction. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <returns>InlineResponse20010</returns>
        public InlineResponse20010 DeleteDSTResources (string organizationId, Id dstId)
        {
             ApiResponse<InlineResponse20010> localVarResponse = DeleteDSTResourcesWithHttpInfo(organizationId, dstId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Delete the resources of a DST This API allows to delete the resources of a Digital Signature Transaction. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <returns>ApiResponse of InlineResponse20010</returns>
        public ApiResponse<InlineResponse20010> DeleteDSTResourcesWithHttpInfo (string organizationId, Id dstId)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling Bit4idPathgroupSignatureTransactionsApi->DeleteDSTResources");
            // verify the required parameter 'dstId' is set
            if (dstId == null)
                throw new ApiException(400, "Missing required parameter 'dstId' when calling Bit4idPathgroupSignatureTransactionsApi->DeleteDSTResources");

            var localVarPath = "/{organization-id}/signature-transactions/{dst-id}/resources";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (organizationId != null) localVarPathParams.Add("organization-id", this.Configuration.ApiClient.ParameterToString(organizationId)); // path parameter
            if (dstId != null) localVarPathParams.Add("dst-id", this.Configuration.ApiClient.ParameterToString(dstId)); // path parameter

            // authentication (ApiKeyAuth) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = this.Configuration.GetApiKeyWithPrefix("Authorization");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.DELETE, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("DeleteDSTResources", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse20010>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse20010) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse20010)));
        }

        /// <summary>
        /// Delete the resources of a DST This API allows to delete the resources of a Digital Signature Transaction. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <returns>Task of InlineResponse20010</returns>
        public async System.Threading.Tasks.Task<InlineResponse20010> DeleteDSTResourcesAsync (string organizationId, Id dstId)
        {
             ApiResponse<InlineResponse20010> localVarResponse = await DeleteDSTResourcesAsyncWithHttpInfo(organizationId, dstId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Delete the resources of a DST This API allows to delete the resources of a Digital Signature Transaction. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <returns>Task of ApiResponse (InlineResponse20010)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<InlineResponse20010>> DeleteDSTResourcesAsyncWithHttpInfo (string organizationId, Id dstId)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling Bit4idPathgroupSignatureTransactionsApi->DeleteDSTResources");
            // verify the required parameter 'dstId' is set
            if (dstId == null)
                throw new ApiException(400, "Missing required parameter 'dstId' when calling Bit4idPathgroupSignatureTransactionsApi->DeleteDSTResources");

            var localVarPath = "/{organization-id}/signature-transactions/{dst-id}/resources";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (organizationId != null) localVarPathParams.Add("organization-id", this.Configuration.ApiClient.ParameterToString(organizationId)); // path parameter
            if (dstId != null) localVarPathParams.Add("dst-id", this.Configuration.ApiClient.ParameterToString(dstId)); // path parameter

            // authentication (ApiKeyAuth) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = this.Configuration.GetApiKeyWithPrefix("Authorization");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.DELETE, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("DeleteDSTResources", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse20010>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse20010) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse20010)));
        }

        /// <summary>
        /// Get information about a DST This API allows to get information about a Digital Signature Transaction. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <returns>InlineResponse2013</returns>
        public InlineResponse2013 GetDST (string organizationId, Id dstId)
        {
             ApiResponse<InlineResponse2013> localVarResponse = GetDSTWithHttpInfo(organizationId, dstId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get information about a DST This API allows to get information about a Digital Signature Transaction. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <returns>ApiResponse of InlineResponse2013</returns>
        public ApiResponse<InlineResponse2013> GetDSTWithHttpInfo (string organizationId, Id dstId)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling Bit4idPathgroupSignatureTransactionsApi->GetDST");
            // verify the required parameter 'dstId' is set
            if (dstId == null)
                throw new ApiException(400, "Missing required parameter 'dstId' when calling Bit4idPathgroupSignatureTransactionsApi->GetDST");

            var localVarPath = "/{organization-id}/signature-transactions/{dst-id}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (organizationId != null) localVarPathParams.Add("organization-id", this.Configuration.ApiClient.ParameterToString(organizationId)); // path parameter
            if (dstId != null) localVarPathParams.Add("dst-id", this.Configuration.ApiClient.ParameterToString(dstId)); // path parameter

            // authentication (ApiKeyAuth) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = this.Configuration.GetApiKeyWithPrefix("Authorization");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetDST", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2013>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2013) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2013)));
        }

        /// <summary>
        /// Get information about a DST This API allows to get information about a Digital Signature Transaction. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <returns>Task of InlineResponse2013</returns>
        public async System.Threading.Tasks.Task<InlineResponse2013> GetDSTAsync (string organizationId, Id dstId)
        {
             ApiResponse<InlineResponse2013> localVarResponse = await GetDSTAsyncWithHttpInfo(organizationId, dstId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Get information about a DST This API allows to get information about a Digital Signature Transaction. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <returns>Task of ApiResponse (InlineResponse2013)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<InlineResponse2013>> GetDSTAsyncWithHttpInfo (string organizationId, Id dstId)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling Bit4idPathgroupSignatureTransactionsApi->GetDST");
            // verify the required parameter 'dstId' is set
            if (dstId == null)
                throw new ApiException(400, "Missing required parameter 'dstId' when calling Bit4idPathgroupSignatureTransactionsApi->GetDST");

            var localVarPath = "/{organization-id}/signature-transactions/{dst-id}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (organizationId != null) localVarPathParams.Add("organization-id", this.Configuration.ApiClient.ParameterToString(organizationId)); // path parameter
            if (dstId != null) localVarPathParams.Add("dst-id", this.Configuration.ApiClient.ParameterToString(dstId)); // path parameter

            // authentication (ApiKeyAuth) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = this.Configuration.GetApiKeyWithPrefix("Authorization");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetDST", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2013>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2013) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2013)));
        }

        /// <summary>
        /// Download a document from a DST This API allows to download a document from a digital signature transaction. The document can be downloaded before or after one or every signature have been performed. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="documentId">The **document-id** is the uuid code that identifies a document of a digital signature transaction. This parameter is usually used in order to download a document from a digital signature transaction </param>
        /// <returns>System.IO.Stream</returns>
        public System.IO.Stream GetDocument (string organizationId, Id documentId)
        {
             ApiResponse<System.IO.Stream> localVarResponse = GetDocumentWithHttpInfo(organizationId, documentId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Download a document from a DST This API allows to download a document from a digital signature transaction. The document can be downloaded before or after one or every signature have been performed. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="documentId">The **document-id** is the uuid code that identifies a document of a digital signature transaction. This parameter is usually used in order to download a document from a digital signature transaction </param>
        /// <returns>ApiResponse of System.IO.Stream</returns>
        public ApiResponse<System.IO.Stream> GetDocumentWithHttpInfo (string organizationId, Id documentId)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling Bit4idPathgroupSignatureTransactionsApi->GetDocument");
            // verify the required parameter 'documentId' is set
            if (documentId == null)
                throw new ApiException(400, "Missing required parameter 'documentId' when calling Bit4idPathgroupSignatureTransactionsApi->GetDocument");

            var localVarPath = "/{organization-id}/documents/{document-id}/download";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/pdf",
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (organizationId != null) localVarPathParams.Add("organization-id", this.Configuration.ApiClient.ParameterToString(organizationId)); // path parameter
            if (documentId != null) localVarPathParams.Add("document-id", this.Configuration.ApiClient.ParameterToString(documentId)); // path parameter

            // authentication (ApiKeyAuth) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = this.Configuration.GetApiKeyWithPrefix("Authorization");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetDocument", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<System.IO.Stream>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (System.IO.Stream) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(System.IO.Stream)));
        }

        /// <summary>
        /// Download a document from a DST This API allows to download a document from a digital signature transaction. The document can be downloaded before or after one or every signature have been performed. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="documentId">The **document-id** is the uuid code that identifies a document of a digital signature transaction. This parameter is usually used in order to download a document from a digital signature transaction </param>
        /// <returns>Task of System.IO.Stream</returns>
        public async System.Threading.Tasks.Task<System.IO.Stream> GetDocumentAsync (string organizationId, Id documentId)
        {
             ApiResponse<System.IO.Stream> localVarResponse = await GetDocumentAsyncWithHttpInfo(organizationId, documentId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Download a document from a DST This API allows to download a document from a digital signature transaction. The document can be downloaded before or after one or every signature have been performed. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="documentId">The **document-id** is the uuid code that identifies a document of a digital signature transaction. This parameter is usually used in order to download a document from a digital signature transaction </param>
        /// <returns>Task of ApiResponse (System.IO.Stream)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<System.IO.Stream>> GetDocumentAsyncWithHttpInfo (string organizationId, Id documentId)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling Bit4idPathgroupSignatureTransactionsApi->GetDocument");
            // verify the required parameter 'documentId' is set
            if (documentId == null)
                throw new ApiException(400, "Missing required parameter 'documentId' when calling Bit4idPathgroupSignatureTransactionsApi->GetDocument");

            var localVarPath = "/{organization-id}/documents/{document-id}/download";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/pdf",
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (organizationId != null) localVarPathParams.Add("organization-id", this.Configuration.ApiClient.ParameterToString(organizationId)); // path parameter
            if (documentId != null) localVarPathParams.Add("document-id", this.Configuration.ApiClient.ParameterToString(documentId)); // path parameter

            // authentication (ApiKeyAuth) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = this.Configuration.GetApiKeyWithPrefix("Authorization");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetDocument", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<System.IO.Stream>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (System.IO.Stream) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(System.IO.Stream)));
        }

        /// <summary>
        /// List the DSTs of an organization This API allows to list the Digital Signature Transactions of an organization. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="whereSigner">Returns the Digital Signature Transactions where the specified user is a signer, searched by its id (optional)</param>
        /// <param name="whereStatus">Returns the Digital Signature Transactions with the specified status (optional)</param>
        /// <param name="whereTitle">Returns the Digital Signature Transactions that have the specified title (optional)</param>
        /// <param name="whereCreatedBy">Returns the Digital Signature Transactions created by the specified user (optional)</param>
        /// <param name="whereCreated">Returns the Digital Signature Transactions created before, after or in the declared range (optional)</param>
        /// <param name="whereSignatureStatus">Returns the Digital Signature Transactions where at least one of the signers has the queried status (optional)</param>
        /// <param name="whereDocumentName">Returns the Digital Signature Transactions that have into its documents the queried one (optional)</param>
        /// <param name="whereReason">Returns the Digital Signature Transactions with the specified reason (optional)</param>
        /// <param name="whereSignatureName">Returns the Digital Signature Transactions where the specified user is a signer, searched by its name (optional)</param>
        /// <param name="whereSignerGroup">Returns the Digital Signature Transactions that have the specified group of signers (optional)</param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>InlineResponse2008</returns>
        public InlineResponse2008 ListDSTs (string organizationId, string whereSigner = default(string), string whereStatus = default(string), string whereTitle = default(string), string whereCreatedBy = default(string), string whereCreated = default(string), string whereSignatureStatus = default(string), string whereDocumentName = default(string), string whereReason = default(string), string whereSignatureName = default(string), string whereSignerGroup = default(string), int page = default(int), int count = default(int), string whereOrder = default(string))
        {
             ApiResponse<InlineResponse2008> localVarResponse = ListDSTsWithHttpInfo(organizationId, whereSigner, whereStatus, whereTitle, whereCreatedBy, whereCreated, whereSignatureStatus, whereDocumentName, whereReason, whereSignatureName, whereSignerGroup, page, count, whereOrder);
             return localVarResponse.Data;
        }

        /// <summary>
        /// List the DSTs of an organization This API allows to list the Digital Signature Transactions of an organization. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="whereSigner">Returns the Digital Signature Transactions where the specified user is a signer, searched by its id (optional)</param>
        /// <param name="whereStatus">Returns the Digital Signature Transactions with the specified status (optional)</param>
        /// <param name="whereTitle">Returns the Digital Signature Transactions that have the specified title (optional)</param>
        /// <param name="whereCreatedBy">Returns the Digital Signature Transactions created by the specified user (optional)</param>
        /// <param name="whereCreated">Returns the Digital Signature Transactions created before, after or in the declared range (optional)</param>
        /// <param name="whereSignatureStatus">Returns the Digital Signature Transactions where at least one of the signers has the queried status (optional)</param>
        /// <param name="whereDocumentName">Returns the Digital Signature Transactions that have into its documents the queried one (optional)</param>
        /// <param name="whereReason">Returns the Digital Signature Transactions with the specified reason (optional)</param>
        /// <param name="whereSignatureName">Returns the Digital Signature Transactions where the specified user is a signer, searched by its name (optional)</param>
        /// <param name="whereSignerGroup">Returns the Digital Signature Transactions that have the specified group of signers (optional)</param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>ApiResponse of InlineResponse2008</returns>
        public ApiResponse<InlineResponse2008> ListDSTsWithHttpInfo (string organizationId, string whereSigner = default(string), string whereStatus = default(string), string whereTitle = default(string), string whereCreatedBy = default(string), string whereCreated = default(string), string whereSignatureStatus = default(string), string whereDocumentName = default(string), string whereReason = default(string), string whereSignatureName = default(string), string whereSignerGroup = default(string), int page = default(int), int count = default(int), string whereOrder = default(string))
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling Bit4idPathgroupSignatureTransactionsApi->ListDSTs");

            var localVarPath = "/{organization-id}/signature-transactions";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (organizationId != null) localVarPathParams.Add("organization-id", this.Configuration.ApiClient.ParameterToString(organizationId)); // path parameter
            if (whereSigner != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_signer", whereSigner)); // query parameter
            if (whereStatus != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_status", whereStatus)); // query parameter
            if (whereTitle != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_title", whereTitle)); // query parameter
            if (whereCreatedBy != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_created_by", whereCreatedBy)); // query parameter
            if (whereCreated != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_created", whereCreated)); // query parameter
            if (whereSignatureStatus != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_signature_status", whereSignatureStatus)); // query parameter
            if (whereDocumentName != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_document_name", whereDocumentName)); // query parameter
            if (whereReason != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_reason", whereReason)); // query parameter
            if (whereSignatureName != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_signature_name", whereSignatureName)); // query parameter
            if (whereSignerGroup != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_signer_group", whereSignerGroup)); // query parameter
            if (page != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "page", page)); // query parameter
            if (count != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "count", count)); // query parameter
            if (whereOrder != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_order", whereOrder)); // query parameter

            // authentication (ApiKeyAuth) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = this.Configuration.GetApiKeyWithPrefix("Authorization");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("ListDSTs", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2008>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2008) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2008)));
        }

        /// <summary>
        /// List the DSTs of an organization This API allows to list the Digital Signature Transactions of an organization. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="whereSigner">Returns the Digital Signature Transactions where the specified user is a signer, searched by its id (optional)</param>
        /// <param name="whereStatus">Returns the Digital Signature Transactions with the specified status (optional)</param>
        /// <param name="whereTitle">Returns the Digital Signature Transactions that have the specified title (optional)</param>
        /// <param name="whereCreatedBy">Returns the Digital Signature Transactions created by the specified user (optional)</param>
        /// <param name="whereCreated">Returns the Digital Signature Transactions created before, after or in the declared range (optional)</param>
        /// <param name="whereSignatureStatus">Returns the Digital Signature Transactions where at least one of the signers has the queried status (optional)</param>
        /// <param name="whereDocumentName">Returns the Digital Signature Transactions that have into its documents the queried one (optional)</param>
        /// <param name="whereReason">Returns the Digital Signature Transactions with the specified reason (optional)</param>
        /// <param name="whereSignatureName">Returns the Digital Signature Transactions where the specified user is a signer, searched by its name (optional)</param>
        /// <param name="whereSignerGroup">Returns the Digital Signature Transactions that have the specified group of signers (optional)</param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>Task of InlineResponse2008</returns>
        public async System.Threading.Tasks.Task<InlineResponse2008> ListDSTsAsync (string organizationId, string whereSigner = default(string), string whereStatus = default(string), string whereTitle = default(string), string whereCreatedBy = default(string), string whereCreated = default(string), string whereSignatureStatus = default(string), string whereDocumentName = default(string), string whereReason = default(string), string whereSignatureName = default(string), string whereSignerGroup = default(string), int page = default(int), int count = default(int), string whereOrder = default(string))
        {
             ApiResponse<InlineResponse2008> localVarResponse = await ListDSTsAsyncWithHttpInfo(organizationId, whereSigner, whereStatus, whereTitle, whereCreatedBy, whereCreated, whereSignatureStatus, whereDocumentName, whereReason, whereSignatureName, whereSignerGroup, page, count, whereOrder);
             return localVarResponse.Data;

        }

        /// <summary>
        /// List the DSTs of an organization This API allows to list the Digital Signature Transactions of an organization. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="whereSigner">Returns the Digital Signature Transactions where the specified user is a signer, searched by its id (optional)</param>
        /// <param name="whereStatus">Returns the Digital Signature Transactions with the specified status (optional)</param>
        /// <param name="whereTitle">Returns the Digital Signature Transactions that have the specified title (optional)</param>
        /// <param name="whereCreatedBy">Returns the Digital Signature Transactions created by the specified user (optional)</param>
        /// <param name="whereCreated">Returns the Digital Signature Transactions created before, after or in the declared range (optional)</param>
        /// <param name="whereSignatureStatus">Returns the Digital Signature Transactions where at least one of the signers has the queried status (optional)</param>
        /// <param name="whereDocumentName">Returns the Digital Signature Transactions that have into its documents the queried one (optional)</param>
        /// <param name="whereReason">Returns the Digital Signature Transactions with the specified reason (optional)</param>
        /// <param name="whereSignatureName">Returns the Digital Signature Transactions where the specified user is a signer, searched by its name (optional)</param>
        /// <param name="whereSignerGroup">Returns the Digital Signature Transactions that have the specified group of signers (optional)</param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>Task of ApiResponse (InlineResponse2008)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<InlineResponse2008>> ListDSTsAsyncWithHttpInfo (string organizationId, string whereSigner = default(string), string whereStatus = default(string), string whereTitle = default(string), string whereCreatedBy = default(string), string whereCreated = default(string), string whereSignatureStatus = default(string), string whereDocumentName = default(string), string whereReason = default(string), string whereSignatureName = default(string), string whereSignerGroup = default(string), int page = default(int), int count = default(int), string whereOrder = default(string))
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling Bit4idPathgroupSignatureTransactionsApi->ListDSTs");

            var localVarPath = "/{organization-id}/signature-transactions";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (organizationId != null) localVarPathParams.Add("organization-id", this.Configuration.ApiClient.ParameterToString(organizationId)); // path parameter
            if (whereSigner != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_signer", whereSigner)); // query parameter
            if (whereStatus != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_status", whereStatus)); // query parameter
            if (whereTitle != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_title", whereTitle)); // query parameter
            if (whereCreatedBy != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_created_by", whereCreatedBy)); // query parameter
            if (whereCreated != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_created", whereCreated)); // query parameter
            if (whereSignatureStatus != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_signature_status", whereSignatureStatus)); // query parameter
            if (whereDocumentName != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_document_name", whereDocumentName)); // query parameter
            if (whereReason != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_reason", whereReason)); // query parameter
            if (whereSignatureName != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_signature_name", whereSignatureName)); // query parameter
            if (whereSignerGroup != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_signer_group", whereSignerGroup)); // query parameter
            if (page != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "page", page)); // query parameter
            if (count != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "count", count)); // query parameter
            if (whereOrder != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_order", whereOrder)); // query parameter

            // authentication (ApiKeyAuth) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = this.Configuration.GetApiKeyWithPrefix("Authorization");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("ListDSTs", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2008>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2008) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2008)));
        }

    }
}
