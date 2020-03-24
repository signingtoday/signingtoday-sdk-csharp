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
    public interface IBit4idPathgroupTokensApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Create an application token
        /// </summary>
        /// <remarks>
        /// This API allows to create an application token. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="createToken">Token data</param>
        /// <returns>InlineResponse2015</returns>
        InlineResponse2015 CreateToken (string organizationId, CreateToken createToken);

        /// <summary>
        /// Create an application token
        /// </summary>
        /// <remarks>
        /// This API allows to create an application token. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="createToken">Token data</param>
        /// <returns>ApiResponse of InlineResponse2015</returns>
        ApiResponse<InlineResponse2015> CreateTokenWithHttpInfo (string organizationId, CreateToken createToken);
        /// <summary>
        /// Delete a token of the organization
        /// </summary>
        /// <remarks>
        /// This API allows to delete a token of the organization. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="tokenId">The **token-id** is the uuid code that identifies a token. It is, as well, used to restrict the requested operation to the scope of that token </param>
        /// <returns>InlineResponse2012</returns>
        InlineResponse2012 DeleteToken (string organizationId, Id tokenId);

        /// <summary>
        /// Delete a token of the organization
        /// </summary>
        /// <remarks>
        /// This API allows to delete a token of the organization. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="tokenId">The **token-id** is the uuid code that identifies a token. It is, as well, used to restrict the requested operation to the scope of that token </param>
        /// <returns>ApiResponse of InlineResponse2012</returns>
        ApiResponse<InlineResponse2012> DeleteTokenWithHttpInfo (string organizationId, Id tokenId);
        /// <summary>
        /// Get information about a token
        /// </summary>
        /// <remarks>
        /// This API allows to get information about a token. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="tokenId">The **token-id** is the uuid code that identifies a token. It is, as well, used to restrict the requested operation to the scope of that token </param>
        /// <returns>InlineResponse2015</returns>
        InlineResponse2015 GetToken (string organizationId, Id tokenId);

        /// <summary>
        /// Get information about a token
        /// </summary>
        /// <remarks>
        /// This API allows to get information about a token. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="tokenId">The **token-id** is the uuid code that identifies a token. It is, as well, used to restrict the requested operation to the scope of that token </param>
        /// <returns>ApiResponse of InlineResponse2015</returns>
        ApiResponse<InlineResponse2015> GetTokenWithHttpInfo (string organizationId, Id tokenId);
        /// <summary>
        /// Enumerate the tokens of an organization
        /// </summary>
        /// <remarks>
        /// This API allows to enumerate the tokens of an organization. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="whereUser">Returns the tokens of the specified user, searched by its id (optional)</param>
        /// <param name="whereLabel">Returns the tokens with the specified label (optional)</param>
        /// <param name="count">Sets the number of tokens per page to display (optional, default to 100)</param>
        /// <param name="page">Restricts the search to chosen page (optional)</param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>InlineResponse2004</returns>
        InlineResponse2004 ListTokens (string organizationId, string whereUser = default(string), string whereLabel = default(string), int count = default(int), int page = default(int), string whereOrder = default(string));

        /// <summary>
        /// Enumerate the tokens of an organization
        /// </summary>
        /// <remarks>
        /// This API allows to enumerate the tokens of an organization. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="whereUser">Returns the tokens of the specified user, searched by its id (optional)</param>
        /// <param name="whereLabel">Returns the tokens with the specified label (optional)</param>
        /// <param name="count">Sets the number of tokens per page to display (optional, default to 100)</param>
        /// <param name="page">Restricts the search to chosen page (optional)</param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>ApiResponse of InlineResponse2004</returns>
        ApiResponse<InlineResponse2004> ListTokensWithHttpInfo (string organizationId, string whereUser = default(string), string whereLabel = default(string), int count = default(int), int page = default(int), string whereOrder = default(string));
        /// <summary>
        /// Enumerate the tokens of an user
        /// </summary>
        /// <remarks>
        /// This API allows to enumerate all the tokens of an user. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="userId">The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user </param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>InlineResponse2004</returns>
        InlineResponse2004 ListUserTokens (string organizationId, Id userId, int page = default(int), int count = default(int), string whereOrder = default(string));

        /// <summary>
        /// Enumerate the tokens of an user
        /// </summary>
        /// <remarks>
        /// This API allows to enumerate all the tokens of an user. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="userId">The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user </param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>ApiResponse of InlineResponse2004</returns>
        ApiResponse<InlineResponse2004> ListUserTokensWithHttpInfo (string organizationId, Id userId, int page = default(int), int count = default(int), string whereOrder = default(string));
        /// <summary>
        /// Update the properties of a token
        /// </summary>
        /// <remarks>
        /// This API allows to update the properties of a token. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="tokenId">The **token-id** is the uuid code that identifies a token. It is, as well, used to restrict the requested operation to the scope of that token </param>
        /// <param name="updateToken">Token data</param>
        /// <returns>InlineResponse2015</returns>
        InlineResponse2015 UpdateToken (string organizationId, Id tokenId, UpdateToken updateToken);

        /// <summary>
        /// Update the properties of a token
        /// </summary>
        /// <remarks>
        /// This API allows to update the properties of a token. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="tokenId">The **token-id** is the uuid code that identifies a token. It is, as well, used to restrict the requested operation to the scope of that token </param>
        /// <param name="updateToken">Token data</param>
        /// <returns>ApiResponse of InlineResponse2015</returns>
        ApiResponse<InlineResponse2015> UpdateTokenWithHttpInfo (string organizationId, Id tokenId, UpdateToken updateToken);
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// Create an application token
        /// </summary>
        /// <remarks>
        /// This API allows to create an application token. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="createToken">Token data</param>
        /// <returns>Task of InlineResponse2015</returns>
        System.Threading.Tasks.Task<InlineResponse2015> CreateTokenAsync (string organizationId, CreateToken createToken);

        /// <summary>
        /// Create an application token
        /// </summary>
        /// <remarks>
        /// This API allows to create an application token. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="createToken">Token data</param>
        /// <returns>Task of ApiResponse (InlineResponse2015)</returns>
        System.Threading.Tasks.Task<ApiResponse<InlineResponse2015>> CreateTokenAsyncWithHttpInfo (string organizationId, CreateToken createToken);
        /// <summary>
        /// Delete a token of the organization
        /// </summary>
        /// <remarks>
        /// This API allows to delete a token of the organization. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="tokenId">The **token-id** is the uuid code that identifies a token. It is, as well, used to restrict the requested operation to the scope of that token </param>
        /// <returns>Task of InlineResponse2012</returns>
        System.Threading.Tasks.Task<InlineResponse2012> DeleteTokenAsync (string organizationId, Id tokenId);

        /// <summary>
        /// Delete a token of the organization
        /// </summary>
        /// <remarks>
        /// This API allows to delete a token of the organization. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="tokenId">The **token-id** is the uuid code that identifies a token. It is, as well, used to restrict the requested operation to the scope of that token </param>
        /// <returns>Task of ApiResponse (InlineResponse2012)</returns>
        System.Threading.Tasks.Task<ApiResponse<InlineResponse2012>> DeleteTokenAsyncWithHttpInfo (string organizationId, Id tokenId);
        /// <summary>
        /// Get information about a token
        /// </summary>
        /// <remarks>
        /// This API allows to get information about a token. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="tokenId">The **token-id** is the uuid code that identifies a token. It is, as well, used to restrict the requested operation to the scope of that token </param>
        /// <returns>Task of InlineResponse2015</returns>
        System.Threading.Tasks.Task<InlineResponse2015> GetTokenAsync (string organizationId, Id tokenId);

        /// <summary>
        /// Get information about a token
        /// </summary>
        /// <remarks>
        /// This API allows to get information about a token. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="tokenId">The **token-id** is the uuid code that identifies a token. It is, as well, used to restrict the requested operation to the scope of that token </param>
        /// <returns>Task of ApiResponse (InlineResponse2015)</returns>
        System.Threading.Tasks.Task<ApiResponse<InlineResponse2015>> GetTokenAsyncWithHttpInfo (string organizationId, Id tokenId);
        /// <summary>
        /// Enumerate the tokens of an organization
        /// </summary>
        /// <remarks>
        /// This API allows to enumerate the tokens of an organization. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="whereUser">Returns the tokens of the specified user, searched by its id (optional)</param>
        /// <param name="whereLabel">Returns the tokens with the specified label (optional)</param>
        /// <param name="count">Sets the number of tokens per page to display (optional, default to 100)</param>
        /// <param name="page">Restricts the search to chosen page (optional)</param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>Task of InlineResponse2004</returns>
        System.Threading.Tasks.Task<InlineResponse2004> ListTokensAsync (string organizationId, string whereUser = default(string), string whereLabel = default(string), int count = default(int), int page = default(int), string whereOrder = default(string));

        /// <summary>
        /// Enumerate the tokens of an organization
        /// </summary>
        /// <remarks>
        /// This API allows to enumerate the tokens of an organization. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="whereUser">Returns the tokens of the specified user, searched by its id (optional)</param>
        /// <param name="whereLabel">Returns the tokens with the specified label (optional)</param>
        /// <param name="count">Sets the number of tokens per page to display (optional, default to 100)</param>
        /// <param name="page">Restricts the search to chosen page (optional)</param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>Task of ApiResponse (InlineResponse2004)</returns>
        System.Threading.Tasks.Task<ApiResponse<InlineResponse2004>> ListTokensAsyncWithHttpInfo (string organizationId, string whereUser = default(string), string whereLabel = default(string), int count = default(int), int page = default(int), string whereOrder = default(string));
        /// <summary>
        /// Enumerate the tokens of an user
        /// </summary>
        /// <remarks>
        /// This API allows to enumerate all the tokens of an user. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="userId">The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user </param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>Task of InlineResponse2004</returns>
        System.Threading.Tasks.Task<InlineResponse2004> ListUserTokensAsync (string organizationId, Id userId, int page = default(int), int count = default(int), string whereOrder = default(string));

        /// <summary>
        /// Enumerate the tokens of an user
        /// </summary>
        /// <remarks>
        /// This API allows to enumerate all the tokens of an user. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="userId">The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user </param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>Task of ApiResponse (InlineResponse2004)</returns>
        System.Threading.Tasks.Task<ApiResponse<InlineResponse2004>> ListUserTokensAsyncWithHttpInfo (string organizationId, Id userId, int page = default(int), int count = default(int), string whereOrder = default(string));
        /// <summary>
        /// Update the properties of a token
        /// </summary>
        /// <remarks>
        /// This API allows to update the properties of a token. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="tokenId">The **token-id** is the uuid code that identifies a token. It is, as well, used to restrict the requested operation to the scope of that token </param>
        /// <param name="updateToken">Token data</param>
        /// <returns>Task of InlineResponse2015</returns>
        System.Threading.Tasks.Task<InlineResponse2015> UpdateTokenAsync (string organizationId, Id tokenId, UpdateToken updateToken);

        /// <summary>
        /// Update the properties of a token
        /// </summary>
        /// <remarks>
        /// This API allows to update the properties of a token. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="tokenId">The **token-id** is the uuid code that identifies a token. It is, as well, used to restrict the requested operation to the scope of that token </param>
        /// <param name="updateToken">Token data</param>
        /// <returns>Task of ApiResponse (InlineResponse2015)</returns>
        System.Threading.Tasks.Task<ApiResponse<InlineResponse2015>> UpdateTokenAsyncWithHttpInfo (string organizationId, Id tokenId, UpdateToken updateToken);
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class Bit4idPathgroupTokensApi : IBit4idPathgroupTokensApi
    {
        private SigningToday.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="Bit4idPathgroupTokensApi"/> class.
        /// </summary>
        /// <returns></returns>
        public Bit4idPathgroupTokensApi(String basePath)
        {
            this.Configuration = new SigningToday.Client.Configuration { BasePath = basePath };

            ExceptionFactory = SigningToday.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Bit4idPathgroupTokensApi"/> class
        /// </summary>
        /// <returns></returns>
        public Bit4idPathgroupTokensApi()
        {
            this.Configuration = SigningToday.Client.Configuration.Default;

            ExceptionFactory = SigningToday.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Bit4idPathgroupTokensApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public Bit4idPathgroupTokensApi(SigningToday.Client.Configuration configuration = null)
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
        /// Create an application token This API allows to create an application token. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="createToken">Token data</param>
        /// <returns>InlineResponse2015</returns>
        public InlineResponse2015 CreateToken (string organizationId, CreateToken createToken)
        {
             ApiResponse<InlineResponse2015> localVarResponse = CreateTokenWithHttpInfo(organizationId, createToken);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Create an application token This API allows to create an application token. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="createToken">Token data</param>
        /// <returns>ApiResponse of InlineResponse2015</returns>
        public ApiResponse<InlineResponse2015> CreateTokenWithHttpInfo (string organizationId, CreateToken createToken)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling Bit4idPathgroupTokensApi->CreateToken");
            // verify the required parameter 'createToken' is set
            if (createToken == null)
                throw new ApiException(400, "Missing required parameter 'createToken' when calling Bit4idPathgroupTokensApi->CreateToken");

            var localVarPath = "/{organization-id}/tokens";
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
            if (createToken != null && createToken.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(createToken); // http body (model) parameter
            }
            else
            {
                localVarPostBody = createToken; // byte array
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
                Exception exception = ExceptionFactory("CreateToken", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2015>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2015) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2015)));
        }

        /// <summary>
        /// Create an application token This API allows to create an application token. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="createToken">Token data</param>
        /// <returns>Task of InlineResponse2015</returns>
        public async System.Threading.Tasks.Task<InlineResponse2015> CreateTokenAsync (string organizationId, CreateToken createToken)
        {
             ApiResponse<InlineResponse2015> localVarResponse = await CreateTokenAsyncWithHttpInfo(organizationId, createToken);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Create an application token This API allows to create an application token. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="createToken">Token data</param>
        /// <returns>Task of ApiResponse (InlineResponse2015)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<InlineResponse2015>> CreateTokenAsyncWithHttpInfo (string organizationId, CreateToken createToken)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling Bit4idPathgroupTokensApi->CreateToken");
            // verify the required parameter 'createToken' is set
            if (createToken == null)
                throw new ApiException(400, "Missing required parameter 'createToken' when calling Bit4idPathgroupTokensApi->CreateToken");

            var localVarPath = "/{organization-id}/tokens";
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
            if (createToken != null && createToken.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(createToken); // http body (model) parameter
            }
            else
            {
                localVarPostBody = createToken; // byte array
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
                Exception exception = ExceptionFactory("CreateToken", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2015>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2015) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2015)));
        }

        /// <summary>
        /// Delete a token of the organization This API allows to delete a token of the organization. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="tokenId">The **token-id** is the uuid code that identifies a token. It is, as well, used to restrict the requested operation to the scope of that token </param>
        /// <returns>InlineResponse2012</returns>
        public InlineResponse2012 DeleteToken (string organizationId, Id tokenId)
        {
             ApiResponse<InlineResponse2012> localVarResponse = DeleteTokenWithHttpInfo(organizationId, tokenId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Delete a token of the organization This API allows to delete a token of the organization. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="tokenId">The **token-id** is the uuid code that identifies a token. It is, as well, used to restrict the requested operation to the scope of that token </param>
        /// <returns>ApiResponse of InlineResponse2012</returns>
        public ApiResponse<InlineResponse2012> DeleteTokenWithHttpInfo (string organizationId, Id tokenId)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling Bit4idPathgroupTokensApi->DeleteToken");
            // verify the required parameter 'tokenId' is set
            if (tokenId == null)
                throw new ApiException(400, "Missing required parameter 'tokenId' when calling Bit4idPathgroupTokensApi->DeleteToken");

            var localVarPath = "/{organization-id}/tokens/{token-id}";
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
            if (tokenId != null) localVarPathParams.Add("token-id", this.Configuration.ApiClient.ParameterToString(tokenId)); // path parameter

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
                Exception exception = ExceptionFactory("DeleteToken", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2012>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2012) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2012)));
        }

        /// <summary>
        /// Delete a token of the organization This API allows to delete a token of the organization. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="tokenId">The **token-id** is the uuid code that identifies a token. It is, as well, used to restrict the requested operation to the scope of that token </param>
        /// <returns>Task of InlineResponse2012</returns>
        public async System.Threading.Tasks.Task<InlineResponse2012> DeleteTokenAsync (string organizationId, Id tokenId)
        {
             ApiResponse<InlineResponse2012> localVarResponse = await DeleteTokenAsyncWithHttpInfo(organizationId, tokenId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Delete a token of the organization This API allows to delete a token of the organization. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="tokenId">The **token-id** is the uuid code that identifies a token. It is, as well, used to restrict the requested operation to the scope of that token </param>
        /// <returns>Task of ApiResponse (InlineResponse2012)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<InlineResponse2012>> DeleteTokenAsyncWithHttpInfo (string organizationId, Id tokenId)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling Bit4idPathgroupTokensApi->DeleteToken");
            // verify the required parameter 'tokenId' is set
            if (tokenId == null)
                throw new ApiException(400, "Missing required parameter 'tokenId' when calling Bit4idPathgroupTokensApi->DeleteToken");

            var localVarPath = "/{organization-id}/tokens/{token-id}";
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
            if (tokenId != null) localVarPathParams.Add("token-id", this.Configuration.ApiClient.ParameterToString(tokenId)); // path parameter

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
                Exception exception = ExceptionFactory("DeleteToken", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2012>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2012) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2012)));
        }

        /// <summary>
        /// Get information about a token This API allows to get information about a token. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="tokenId">The **token-id** is the uuid code that identifies a token. It is, as well, used to restrict the requested operation to the scope of that token </param>
        /// <returns>InlineResponse2015</returns>
        public InlineResponse2015 GetToken (string organizationId, Id tokenId)
        {
             ApiResponse<InlineResponse2015> localVarResponse = GetTokenWithHttpInfo(organizationId, tokenId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get information about a token This API allows to get information about a token. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="tokenId">The **token-id** is the uuid code that identifies a token. It is, as well, used to restrict the requested operation to the scope of that token </param>
        /// <returns>ApiResponse of InlineResponse2015</returns>
        public ApiResponse<InlineResponse2015> GetTokenWithHttpInfo (string organizationId, Id tokenId)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling Bit4idPathgroupTokensApi->GetToken");
            // verify the required parameter 'tokenId' is set
            if (tokenId == null)
                throw new ApiException(400, "Missing required parameter 'tokenId' when calling Bit4idPathgroupTokensApi->GetToken");

            var localVarPath = "/{organization-id}/tokens/{token-id}";
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
            if (tokenId != null) localVarPathParams.Add("token-id", this.Configuration.ApiClient.ParameterToString(tokenId)); // path parameter

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
                Exception exception = ExceptionFactory("GetToken", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2015>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2015) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2015)));
        }

        /// <summary>
        /// Get information about a token This API allows to get information about a token. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="tokenId">The **token-id** is the uuid code that identifies a token. It is, as well, used to restrict the requested operation to the scope of that token </param>
        /// <returns>Task of InlineResponse2015</returns>
        public async System.Threading.Tasks.Task<InlineResponse2015> GetTokenAsync (string organizationId, Id tokenId)
        {
             ApiResponse<InlineResponse2015> localVarResponse = await GetTokenAsyncWithHttpInfo(organizationId, tokenId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Get information about a token This API allows to get information about a token. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="tokenId">The **token-id** is the uuid code that identifies a token. It is, as well, used to restrict the requested operation to the scope of that token </param>
        /// <returns>Task of ApiResponse (InlineResponse2015)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<InlineResponse2015>> GetTokenAsyncWithHttpInfo (string organizationId, Id tokenId)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling Bit4idPathgroupTokensApi->GetToken");
            // verify the required parameter 'tokenId' is set
            if (tokenId == null)
                throw new ApiException(400, "Missing required parameter 'tokenId' when calling Bit4idPathgroupTokensApi->GetToken");

            var localVarPath = "/{organization-id}/tokens/{token-id}";
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
            if (tokenId != null) localVarPathParams.Add("token-id", this.Configuration.ApiClient.ParameterToString(tokenId)); // path parameter

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
                Exception exception = ExceptionFactory("GetToken", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2015>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2015) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2015)));
        }

        /// <summary>
        /// Enumerate the tokens of an organization This API allows to enumerate the tokens of an organization. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="whereUser">Returns the tokens of the specified user, searched by its id (optional)</param>
        /// <param name="whereLabel">Returns the tokens with the specified label (optional)</param>
        /// <param name="count">Sets the number of tokens per page to display (optional, default to 100)</param>
        /// <param name="page">Restricts the search to chosen page (optional)</param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>InlineResponse2004</returns>
        public InlineResponse2004 ListTokens (string organizationId, string whereUser = default(string), string whereLabel = default(string), int count = default(int), int page = default(int), string whereOrder = default(string))
        {
             ApiResponse<InlineResponse2004> localVarResponse = ListTokensWithHttpInfo(organizationId, whereUser, whereLabel, count, page, whereOrder);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Enumerate the tokens of an organization This API allows to enumerate the tokens of an organization. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="whereUser">Returns the tokens of the specified user, searched by its id (optional)</param>
        /// <param name="whereLabel">Returns the tokens with the specified label (optional)</param>
        /// <param name="count">Sets the number of tokens per page to display (optional, default to 100)</param>
        /// <param name="page">Restricts the search to chosen page (optional)</param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>ApiResponse of InlineResponse2004</returns>
        public ApiResponse<InlineResponse2004> ListTokensWithHttpInfo (string organizationId, string whereUser = default(string), string whereLabel = default(string), int count = default(int), int page = default(int), string whereOrder = default(string))
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling Bit4idPathgroupTokensApi->ListTokens");

            var localVarPath = "/{organization-id}/tokens";
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
            if (whereUser != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_user", whereUser)); // query parameter
            if (whereLabel != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_label", whereLabel)); // query parameter
            if (count != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "count", count)); // query parameter
            if (page != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "page", page)); // query parameter
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
                Exception exception = ExceptionFactory("ListTokens", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2004>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2004) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2004)));
        }

        /// <summary>
        /// Enumerate the tokens of an organization This API allows to enumerate the tokens of an organization. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="whereUser">Returns the tokens of the specified user, searched by its id (optional)</param>
        /// <param name="whereLabel">Returns the tokens with the specified label (optional)</param>
        /// <param name="count">Sets the number of tokens per page to display (optional, default to 100)</param>
        /// <param name="page">Restricts the search to chosen page (optional)</param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>Task of InlineResponse2004</returns>
        public async System.Threading.Tasks.Task<InlineResponse2004> ListTokensAsync (string organizationId, string whereUser = default(string), string whereLabel = default(string), int count = default(int), int page = default(int), string whereOrder = default(string))
        {
             ApiResponse<InlineResponse2004> localVarResponse = await ListTokensAsyncWithHttpInfo(organizationId, whereUser, whereLabel, count, page, whereOrder);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Enumerate the tokens of an organization This API allows to enumerate the tokens of an organization. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="whereUser">Returns the tokens of the specified user, searched by its id (optional)</param>
        /// <param name="whereLabel">Returns the tokens with the specified label (optional)</param>
        /// <param name="count">Sets the number of tokens per page to display (optional, default to 100)</param>
        /// <param name="page">Restricts the search to chosen page (optional)</param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>Task of ApiResponse (InlineResponse2004)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<InlineResponse2004>> ListTokensAsyncWithHttpInfo (string organizationId, string whereUser = default(string), string whereLabel = default(string), int count = default(int), int page = default(int), string whereOrder = default(string))
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling Bit4idPathgroupTokensApi->ListTokens");

            var localVarPath = "/{organization-id}/tokens";
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
            if (whereUser != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_user", whereUser)); // query parameter
            if (whereLabel != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_label", whereLabel)); // query parameter
            if (count != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "count", count)); // query parameter
            if (page != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "page", page)); // query parameter
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
                Exception exception = ExceptionFactory("ListTokens", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2004>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2004) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2004)));
        }

        /// <summary>
        /// Enumerate the tokens of an user This API allows to enumerate all the tokens of an user. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="userId">The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user </param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>InlineResponse2004</returns>
        public InlineResponse2004 ListUserTokens (string organizationId, Id userId, int page = default(int), int count = default(int), string whereOrder = default(string))
        {
             ApiResponse<InlineResponse2004> localVarResponse = ListUserTokensWithHttpInfo(organizationId, userId, page, count, whereOrder);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Enumerate the tokens of an user This API allows to enumerate all the tokens of an user. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="userId">The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user </param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>ApiResponse of InlineResponse2004</returns>
        public ApiResponse<InlineResponse2004> ListUserTokensWithHttpInfo (string organizationId, Id userId, int page = default(int), int count = default(int), string whereOrder = default(string))
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling Bit4idPathgroupTokensApi->ListUserTokens");
            // verify the required parameter 'userId' is set
            if (userId == null)
                throw new ApiException(400, "Missing required parameter 'userId' when calling Bit4idPathgroupTokensApi->ListUserTokens");

            var localVarPath = "/{organization-id}/users/{user-id}/tokens";
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
            if (userId != null) localVarPathParams.Add("user-id", this.Configuration.ApiClient.ParameterToString(userId)); // path parameter
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
                Exception exception = ExceptionFactory("ListUserTokens", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2004>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2004) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2004)));
        }

        /// <summary>
        /// Enumerate the tokens of an user This API allows to enumerate all the tokens of an user. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="userId">The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user </param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>Task of InlineResponse2004</returns>
        public async System.Threading.Tasks.Task<InlineResponse2004> ListUserTokensAsync (string organizationId, Id userId, int page = default(int), int count = default(int), string whereOrder = default(string))
        {
             ApiResponse<InlineResponse2004> localVarResponse = await ListUserTokensAsyncWithHttpInfo(organizationId, userId, page, count, whereOrder);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Enumerate the tokens of an user This API allows to enumerate all the tokens of an user. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="userId">The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user </param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>Task of ApiResponse (InlineResponse2004)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<InlineResponse2004>> ListUserTokensAsyncWithHttpInfo (string organizationId, Id userId, int page = default(int), int count = default(int), string whereOrder = default(string))
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling Bit4idPathgroupTokensApi->ListUserTokens");
            // verify the required parameter 'userId' is set
            if (userId == null)
                throw new ApiException(400, "Missing required parameter 'userId' when calling Bit4idPathgroupTokensApi->ListUserTokens");

            var localVarPath = "/{organization-id}/users/{user-id}/tokens";
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
            if (userId != null) localVarPathParams.Add("user-id", this.Configuration.ApiClient.ParameterToString(userId)); // path parameter
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
                Exception exception = ExceptionFactory("ListUserTokens", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2004>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2004) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2004)));
        }

        /// <summary>
        /// Update the properties of a token This API allows to update the properties of a token. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="tokenId">The **token-id** is the uuid code that identifies a token. It is, as well, used to restrict the requested operation to the scope of that token </param>
        /// <param name="updateToken">Token data</param>
        /// <returns>InlineResponse2015</returns>
        public InlineResponse2015 UpdateToken (string organizationId, Id tokenId, UpdateToken updateToken)
        {
             ApiResponse<InlineResponse2015> localVarResponse = UpdateTokenWithHttpInfo(organizationId, tokenId, updateToken);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Update the properties of a token This API allows to update the properties of a token. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="tokenId">The **token-id** is the uuid code that identifies a token. It is, as well, used to restrict the requested operation to the scope of that token </param>
        /// <param name="updateToken">Token data</param>
        /// <returns>ApiResponse of InlineResponse2015</returns>
        public ApiResponse<InlineResponse2015> UpdateTokenWithHttpInfo (string organizationId, Id tokenId, UpdateToken updateToken)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling Bit4idPathgroupTokensApi->UpdateToken");
            // verify the required parameter 'tokenId' is set
            if (tokenId == null)
                throw new ApiException(400, "Missing required parameter 'tokenId' when calling Bit4idPathgroupTokensApi->UpdateToken");
            // verify the required parameter 'updateToken' is set
            if (updateToken == null)
                throw new ApiException(400, "Missing required parameter 'updateToken' when calling Bit4idPathgroupTokensApi->UpdateToken");

            var localVarPath = "/{organization-id}/tokens/{token-id}";
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
            if (tokenId != null) localVarPathParams.Add("token-id", this.Configuration.ApiClient.ParameterToString(tokenId)); // path parameter
            if (updateToken != null && updateToken.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(updateToken); // http body (model) parameter
            }
            else
            {
                localVarPostBody = updateToken; // byte array
            }

            // authentication (ApiKeyAuth) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = this.Configuration.GetApiKeyWithPrefix("Authorization");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("UpdateToken", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2015>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2015) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2015)));
        }

        /// <summary>
        /// Update the properties of a token This API allows to update the properties of a token. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="tokenId">The **token-id** is the uuid code that identifies a token. It is, as well, used to restrict the requested operation to the scope of that token </param>
        /// <param name="updateToken">Token data</param>
        /// <returns>Task of InlineResponse2015</returns>
        public async System.Threading.Tasks.Task<InlineResponse2015> UpdateTokenAsync (string organizationId, Id tokenId, UpdateToken updateToken)
        {
             ApiResponse<InlineResponse2015> localVarResponse = await UpdateTokenAsyncWithHttpInfo(organizationId, tokenId, updateToken);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Update the properties of a token This API allows to update the properties of a token. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="tokenId">The **token-id** is the uuid code that identifies a token. It is, as well, used to restrict the requested operation to the scope of that token </param>
        /// <param name="updateToken">Token data</param>
        /// <returns>Task of ApiResponse (InlineResponse2015)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<InlineResponse2015>> UpdateTokenAsyncWithHttpInfo (string organizationId, Id tokenId, UpdateToken updateToken)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling Bit4idPathgroupTokensApi->UpdateToken");
            // verify the required parameter 'tokenId' is set
            if (tokenId == null)
                throw new ApiException(400, "Missing required parameter 'tokenId' when calling Bit4idPathgroupTokensApi->UpdateToken");
            // verify the required parameter 'updateToken' is set
            if (updateToken == null)
                throw new ApiException(400, "Missing required parameter 'updateToken' when calling Bit4idPathgroupTokensApi->UpdateToken");

            var localVarPath = "/{organization-id}/tokens/{token-id}";
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
            if (tokenId != null) localVarPathParams.Add("token-id", this.Configuration.ApiClient.ParameterToString(tokenId)); // path parameter
            if (updateToken != null && updateToken.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(updateToken); // http body (model) parameter
            }
            else
            {
                localVarPostBody = updateToken; // byte array
            }

            // authentication (ApiKeyAuth) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = this.Configuration.GetApiKeyWithPrefix("Authorization");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("UpdateToken", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2015>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2015) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2015)));
        }

    }
}
