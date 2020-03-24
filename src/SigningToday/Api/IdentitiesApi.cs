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
    public interface IIdentitiesApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Associate an appearance to an identity
        /// </summary>
        /// <remarks>
        /// Associate a signature appearance to an already existing identity through an url to an image. This appearance will be displayed on the document after the signature. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <param name="inlineObject"></param>
        /// <returns>InlineResponse2011</returns>
        InlineResponse2011 AssociateAppearance (string organizationId, Id identityId, InlineObject inlineObject);

        /// <summary>
        /// Associate an appearance to an identity
        /// </summary>
        /// <remarks>
        /// Associate a signature appearance to an already existing identity through an url to an image. This appearance will be displayed on the document after the signature. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <param name="inlineObject"></param>
        /// <returns>ApiResponse of InlineResponse2011</returns>
        ApiResponse<InlineResponse2011> AssociateAppearanceWithHttpInfo (string organizationId, Id identityId, InlineObject inlineObject);
        /// <summary>
        /// Associate to an user an already existing identity
        /// </summary>
        /// <remarks>
        /// Associate to an user of the organization an already existing identity of a provider. The _provider_data_ field is an object and is different for each provider. The minimum set of information to provide as provider_data is the following:   - **aruba**     - _auth_domain_ : string     - _username_ : string     - _password_ : string   - **aruba-auto**     - _auth_domain_ : string     - _username_ : string     - _password_ : string   - **infocert**     - _username_ : string     - _password_ : string   - **namirial**     - _id_titolare_ : string     - _id_otp_ : string     - _username_ : string     - _password_ : string 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="userId">The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user </param>
        /// <param name="identityAssociation">Provider data to associate</param>
        /// <returns>InlineResponse2011</returns>
        InlineResponse2011 AssociateIdentity (string organizationId, Id userId, IdentityAssociation identityAssociation);

        /// <summary>
        /// Associate to an user an already existing identity
        /// </summary>
        /// <remarks>
        /// Associate to an user of the organization an already existing identity of a provider. The _provider_data_ field is an object and is different for each provider. The minimum set of information to provide as provider_data is the following:   - **aruba**     - _auth_domain_ : string     - _username_ : string     - _password_ : string   - **aruba-auto**     - _auth_domain_ : string     - _username_ : string     - _password_ : string   - **infocert**     - _username_ : string     - _password_ : string   - **namirial**     - _id_titolare_ : string     - _id_otp_ : string     - _username_ : string     - _password_ : string 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="userId">The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user </param>
        /// <param name="identityAssociation">Provider data to associate</param>
        /// <returns>ApiResponse of InlineResponse2011</returns>
        ApiResponse<InlineResponse2011> AssociateIdentityWithHttpInfo (string organizationId, Id userId, IdentityAssociation identityAssociation);
        /// <summary>
        /// Create an identity from token
        /// </summary>
        /// <remarks>
        /// This API allows to create an identity from a token. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="createIdentitybyToken">Body of the request to create an identity from a token</param>
        /// <returns>InlineResponse2012</returns>
        InlineResponse2012 CreateTokenFromIdentity (string organizationId, CreateIdentitybyToken createIdentitybyToken);

        /// <summary>
        /// Create an identity from token
        /// </summary>
        /// <remarks>
        /// This API allows to create an identity from a token. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="createIdentitybyToken">Body of the request to create an identity from a token</param>
        /// <returns>ApiResponse of InlineResponse2012</returns>
        ApiResponse<InlineResponse2012> CreateTokenFromIdentityWithHttpInfo (string organizationId, CreateIdentitybyToken createIdentitybyToken);
        /// <summary>
        /// Delete the appearance of an identity
        /// </summary>
        /// <remarks>
        /// This API allows to delete the appearance associated to an identity. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <returns>InlineResponse2011</returns>
        InlineResponse2011 DeleteAppearance (string organizationId, Id identityId);

        /// <summary>
        /// Delete the appearance of an identity
        /// </summary>
        /// <remarks>
        /// This API allows to delete the appearance associated to an identity. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <returns>ApiResponse of InlineResponse2011</returns>
        ApiResponse<InlineResponse2011> DeleteAppearanceWithHttpInfo (string organizationId, Id identityId);
        /// <summary>
        /// Delete an enrollment request
        /// </summary>
        /// <remarks>
        /// This API allows to delete an enrollment request. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="enrollmentId">The **enrollment-id** is the uuid code that identifies a specific enrollment request </param>
        /// <returns>InlineResponse2012</returns>
        InlineResponse2012 DeleteEnrollmentRequest (string organizationId, Id enrollmentId);

        /// <summary>
        /// Delete an enrollment request
        /// </summary>
        /// <remarks>
        /// This API allows to delete an enrollment request. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="enrollmentId">The **enrollment-id** is the uuid code that identifies a specific enrollment request </param>
        /// <returns>ApiResponse of InlineResponse2012</returns>
        ApiResponse<InlineResponse2012> DeleteEnrollmentRequestWithHttpInfo (string organizationId, Id enrollmentId);
        /// <summary>
        /// Delete an identity
        /// </summary>
        /// <remarks>
        /// This API allows to delete an identity of an user. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <returns>InlineResponse2006</returns>
        InlineResponse2006 DeleteIdentity (string organizationId, Id identityId);

        /// <summary>
        /// Delete an identity
        /// </summary>
        /// <remarks>
        /// This API allows to delete an identity of an user. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <returns>ApiResponse of InlineResponse2006</returns>
        ApiResponse<InlineResponse2006> DeleteIdentityWithHttpInfo (string organizationId, Id identityId);
        /// <summary>
        /// Get information about an enrollment request
        /// </summary>
        /// <remarks>
        /// This API allows to get information about an enrollment request. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="enrollmentId">The **enrollment-id** is the uuid code that identifies a specific enrollment request </param>
        /// <returns>InlineResponse2007</returns>
        InlineResponse2007 GetEnrollmentRequest (string organizationId, Id enrollmentId);

        /// <summary>
        /// Get information about an enrollment request
        /// </summary>
        /// <remarks>
        /// This API allows to get information about an enrollment request. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="enrollmentId">The **enrollment-id** is the uuid code that identifies a specific enrollment request </param>
        /// <returns>ApiResponse of InlineResponse2007</returns>
        ApiResponse<InlineResponse2007> GetEnrollmentRequestWithHttpInfo (string organizationId, Id enrollmentId);
        /// <summary>
        /// Get information about an identity
        /// </summary>
        /// <remarks>
        /// This API allows to get all the information of an identity. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>InlineResponse2005</returns>
        InlineResponse2005 GetIdentity (string organizationId, Id identityId, string whereOrder = default(string));

        /// <summary>
        /// Get information about an identity
        /// </summary>
        /// <remarks>
        /// This API allows to get all the information of an identity. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>ApiResponse of InlineResponse2005</returns>
        ApiResponse<InlineResponse2005> GetIdentityWithHttpInfo (string organizationId, Id identityId, string whereOrder = default(string));
        /// <summary>
        /// Enumerate the enrollment requests of an organization
        /// </summary>
        /// <remarks>
        /// This API allows to enumerate the enrollment requests of an organization. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="whereProvider">Returns the identity requests that have been issued by the specified provider (optional)</param>
        /// <param name="whereUser">Returns the identity requests of the specified user, searched by its id (optional)</param>
        /// <param name="whereFirstName">Returns the identity requests of the users that have the specified first name (optional)</param>
        /// <param name="whereLastName">Returns the identity requests of the users that have the specified last name (optional)</param>
        /// <param name="whereRegisteredBy">Returns the identity requests registered by this user (optional)</param>
        /// <param name="whereFiscalCode">Returns the identity requests have the specified fiscal code (optional)</param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>InlineResponse2003</returns>
        InlineResponse2003 ListEnrollmentRequests (string organizationId, string whereProvider = default(string), string whereUser = default(string), string whereFirstName = default(string), string whereLastName = default(string), string whereRegisteredBy = default(string), string whereFiscalCode = default(string), int page = default(int), int count = default(int), string whereOrder = default(string));

        /// <summary>
        /// Enumerate the enrollment requests of an organization
        /// </summary>
        /// <remarks>
        /// This API allows to enumerate the enrollment requests of an organization. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="whereProvider">Returns the identity requests that have been issued by the specified provider (optional)</param>
        /// <param name="whereUser">Returns the identity requests of the specified user, searched by its id (optional)</param>
        /// <param name="whereFirstName">Returns the identity requests of the users that have the specified first name (optional)</param>
        /// <param name="whereLastName">Returns the identity requests of the users that have the specified last name (optional)</param>
        /// <param name="whereRegisteredBy">Returns the identity requests registered by this user (optional)</param>
        /// <param name="whereFiscalCode">Returns the identity requests have the specified fiscal code (optional)</param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>ApiResponse of InlineResponse2003</returns>
        ApiResponse<InlineResponse2003> ListEnrollmentRequestsWithHttpInfo (string organizationId, string whereProvider = default(string), string whereUser = default(string), string whereFirstName = default(string), string whereLastName = default(string), string whereRegisteredBy = default(string), string whereFiscalCode = default(string), int page = default(int), int count = default(int), string whereOrder = default(string));
        /// <summary>
        /// Enumerate the identities of an organization
        /// </summary>
        /// <remarks>
        /// This API allows to enumerate all the users of an organization. It is possible to filter the data using the supported _django lookups_. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="whereProvider">Returns the identities that have been issued by the specified provider (optional)</param>
        /// <param name="whereUser">Returns the identities of the specified user, searched by its id (optional)</param>
        /// <param name="whereFirstName">Returns the identities of the users that have the specified first name (optional)</param>
        /// <param name="whereLastName">Returns the identities of the users that have the specified last name (optional)</param>
        /// <param name="whereRegisteredBy">Returns the identities registered by this user (optional)</param>
        /// <param name="whereFiscalCode">Returns the identities that have the specified fiscal code (optional)</param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>InlineResponse2002</returns>
        InlineResponse2002 ListIdentities (string organizationId, string whereProvider = default(string), string whereUser = default(string), string whereFirstName = default(string), string whereLastName = default(string), string whereRegisteredBy = default(string), string whereFiscalCode = default(string), int page = default(int), int count = default(int), string whereOrder = default(string));

        /// <summary>
        /// Enumerate the identities of an organization
        /// </summary>
        /// <remarks>
        /// This API allows to enumerate all the users of an organization. It is possible to filter the data using the supported _django lookups_. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="whereProvider">Returns the identities that have been issued by the specified provider (optional)</param>
        /// <param name="whereUser">Returns the identities of the specified user, searched by its id (optional)</param>
        /// <param name="whereFirstName">Returns the identities of the users that have the specified first name (optional)</param>
        /// <param name="whereLastName">Returns the identities of the users that have the specified last name (optional)</param>
        /// <param name="whereRegisteredBy">Returns the identities registered by this user (optional)</param>
        /// <param name="whereFiscalCode">Returns the identities that have the specified fiscal code (optional)</param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>ApiResponse of InlineResponse2002</returns>
        ApiResponse<InlineResponse2002> ListIdentitiesWithHttpInfo (string organizationId, string whereProvider = default(string), string whereUser = default(string), string whereFirstName = default(string), string whereLastName = default(string), string whereRegisteredBy = default(string), string whereFiscalCode = default(string), int page = default(int), int count = default(int), string whereOrder = default(string));
        /// <summary>
        /// List the enrollments of an user
        /// </summary>
        /// <remarks>
        /// This API allows to list all the enrollments of an user. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="userId">The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user </param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>InlineResponse2003</returns>
        InlineResponse2003 ListUserEnrollments (string organizationId, Id userId, int page = default(int), int count = default(int), string whereOrder = default(string));

        /// <summary>
        /// List the enrollments of an user
        /// </summary>
        /// <remarks>
        /// This API allows to list all the enrollments of an user. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="userId">The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user </param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>ApiResponse of InlineResponse2003</returns>
        ApiResponse<InlineResponse2003> ListUserEnrollmentsWithHttpInfo (string organizationId, Id userId, int page = default(int), int count = default(int), string whereOrder = default(string));
        /// <summary>
        /// Enumerate the identities of an user
        /// </summary>
        /// <remarks>
        /// This API allows to enumerate all the identities of an user, which are located in its wallet. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="userId">The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user </param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>InlineResponse2002</returns>
        InlineResponse2002 ListUserIdentities (string organizationId, Id userId, int page = default(int), int count = default(int), string whereOrder = default(string));

        /// <summary>
        /// Enumerate the identities of an user
        /// </summary>
        /// <remarks>
        /// This API allows to enumerate all the identities of an user, which are located in its wallet. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="userId">The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user </param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>ApiResponse of InlineResponse2002</returns>
        ApiResponse<InlineResponse2002> ListUserIdentitiesWithHttpInfo (string organizationId, Id userId, int page = default(int), int count = default(int), string whereOrder = default(string));
        /// <summary>
        /// Renew an Identity
        /// </summary>
        /// <remarks>
        /// This API allows to renew an Identity of a user. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="enrollmentId">The **enrollment-id** is the uuid code that identifies a specific enrollment request </param>
        /// <param name="inlineObject1"></param>
        /// <returns>InlineResponse2007</returns>
        InlineResponse2007 RenewIdentity (string organizationId, Id enrollmentId, InlineObject1 inlineObject1);

        /// <summary>
        /// Renew an Identity
        /// </summary>
        /// <remarks>
        /// This API allows to renew an Identity of a user. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="enrollmentId">The **enrollment-id** is the uuid code that identifies a specific enrollment request </param>
        /// <param name="inlineObject1"></param>
        /// <returns>ApiResponse of InlineResponse2007</returns>
        ApiResponse<InlineResponse2007> RenewIdentityWithHttpInfo (string organizationId, Id enrollmentId, InlineObject1 inlineObject1);
        /// <summary>
        /// Submit an enrollment request
        /// </summary>
        /// <remarks>
        /// This API allows to submit an enrollment request. The user of the request will be created if it does not exists already. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityRequest">The enrollment request to submit</param>
        /// <returns>InlineResponse2007</returns>
        InlineResponse2007 RequestEnrollment (string organizationId, IdentityRequest identityRequest);

        /// <summary>
        /// Submit an enrollment request
        /// </summary>
        /// <remarks>
        /// This API allows to submit an enrollment request. The user of the request will be created if it does not exists already. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityRequest">The enrollment request to submit</param>
        /// <returns>ApiResponse of InlineResponse2007</returns>
        ApiResponse<InlineResponse2007> RequestEnrollmentWithHttpInfo (string organizationId, IdentityRequest identityRequest);
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// Associate an appearance to an identity
        /// </summary>
        /// <remarks>
        /// Associate a signature appearance to an already existing identity through an url to an image. This appearance will be displayed on the document after the signature. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <param name="inlineObject"></param>
        /// <returns>Task of InlineResponse2011</returns>
        System.Threading.Tasks.Task<InlineResponse2011> AssociateAppearanceAsync (string organizationId, Id identityId, InlineObject inlineObject);

        /// <summary>
        /// Associate an appearance to an identity
        /// </summary>
        /// <remarks>
        /// Associate a signature appearance to an already existing identity through an url to an image. This appearance will be displayed on the document after the signature. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <param name="inlineObject"></param>
        /// <returns>Task of ApiResponse (InlineResponse2011)</returns>
        System.Threading.Tasks.Task<ApiResponse<InlineResponse2011>> AssociateAppearanceAsyncWithHttpInfo (string organizationId, Id identityId, InlineObject inlineObject);
        /// <summary>
        /// Associate to an user an already existing identity
        /// </summary>
        /// <remarks>
        /// Associate to an user of the organization an already existing identity of a provider. The _provider_data_ field is an object and is different for each provider. The minimum set of information to provide as provider_data is the following:   - **aruba**     - _auth_domain_ : string     - _username_ : string     - _password_ : string   - **aruba-auto**     - _auth_domain_ : string     - _username_ : string     - _password_ : string   - **infocert**     - _username_ : string     - _password_ : string   - **namirial**     - _id_titolare_ : string     - _id_otp_ : string     - _username_ : string     - _password_ : string 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="userId">The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user </param>
        /// <param name="identityAssociation">Provider data to associate</param>
        /// <returns>Task of InlineResponse2011</returns>
        System.Threading.Tasks.Task<InlineResponse2011> AssociateIdentityAsync (string organizationId, Id userId, IdentityAssociation identityAssociation);

        /// <summary>
        /// Associate to an user an already existing identity
        /// </summary>
        /// <remarks>
        /// Associate to an user of the organization an already existing identity of a provider. The _provider_data_ field is an object and is different for each provider. The minimum set of information to provide as provider_data is the following:   - **aruba**     - _auth_domain_ : string     - _username_ : string     - _password_ : string   - **aruba-auto**     - _auth_domain_ : string     - _username_ : string     - _password_ : string   - **infocert**     - _username_ : string     - _password_ : string   - **namirial**     - _id_titolare_ : string     - _id_otp_ : string     - _username_ : string     - _password_ : string 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="userId">The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user </param>
        /// <param name="identityAssociation">Provider data to associate</param>
        /// <returns>Task of ApiResponse (InlineResponse2011)</returns>
        System.Threading.Tasks.Task<ApiResponse<InlineResponse2011>> AssociateIdentityAsyncWithHttpInfo (string organizationId, Id userId, IdentityAssociation identityAssociation);
        /// <summary>
        /// Create an identity from token
        /// </summary>
        /// <remarks>
        /// This API allows to create an identity from a token. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="createIdentitybyToken">Body of the request to create an identity from a token</param>
        /// <returns>Task of InlineResponse2012</returns>
        System.Threading.Tasks.Task<InlineResponse2012> CreateTokenFromIdentityAsync (string organizationId, CreateIdentitybyToken createIdentitybyToken);

        /// <summary>
        /// Create an identity from token
        /// </summary>
        /// <remarks>
        /// This API allows to create an identity from a token. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="createIdentitybyToken">Body of the request to create an identity from a token</param>
        /// <returns>Task of ApiResponse (InlineResponse2012)</returns>
        System.Threading.Tasks.Task<ApiResponse<InlineResponse2012>> CreateTokenFromIdentityAsyncWithHttpInfo (string organizationId, CreateIdentitybyToken createIdentitybyToken);
        /// <summary>
        /// Delete the appearance of an identity
        /// </summary>
        /// <remarks>
        /// This API allows to delete the appearance associated to an identity. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <returns>Task of InlineResponse2011</returns>
        System.Threading.Tasks.Task<InlineResponse2011> DeleteAppearanceAsync (string organizationId, Id identityId);

        /// <summary>
        /// Delete the appearance of an identity
        /// </summary>
        /// <remarks>
        /// This API allows to delete the appearance associated to an identity. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <returns>Task of ApiResponse (InlineResponse2011)</returns>
        System.Threading.Tasks.Task<ApiResponse<InlineResponse2011>> DeleteAppearanceAsyncWithHttpInfo (string organizationId, Id identityId);
        /// <summary>
        /// Delete an enrollment request
        /// </summary>
        /// <remarks>
        /// This API allows to delete an enrollment request. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="enrollmentId">The **enrollment-id** is the uuid code that identifies a specific enrollment request </param>
        /// <returns>Task of InlineResponse2012</returns>
        System.Threading.Tasks.Task<InlineResponse2012> DeleteEnrollmentRequestAsync (string organizationId, Id enrollmentId);

        /// <summary>
        /// Delete an enrollment request
        /// </summary>
        /// <remarks>
        /// This API allows to delete an enrollment request. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="enrollmentId">The **enrollment-id** is the uuid code that identifies a specific enrollment request </param>
        /// <returns>Task of ApiResponse (InlineResponse2012)</returns>
        System.Threading.Tasks.Task<ApiResponse<InlineResponse2012>> DeleteEnrollmentRequestAsyncWithHttpInfo (string organizationId, Id enrollmentId);
        /// <summary>
        /// Delete an identity
        /// </summary>
        /// <remarks>
        /// This API allows to delete an identity of an user. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <returns>Task of InlineResponse2006</returns>
        System.Threading.Tasks.Task<InlineResponse2006> DeleteIdentityAsync (string organizationId, Id identityId);

        /// <summary>
        /// Delete an identity
        /// </summary>
        /// <remarks>
        /// This API allows to delete an identity of an user. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <returns>Task of ApiResponse (InlineResponse2006)</returns>
        System.Threading.Tasks.Task<ApiResponse<InlineResponse2006>> DeleteIdentityAsyncWithHttpInfo (string organizationId, Id identityId);
        /// <summary>
        /// Get information about an enrollment request
        /// </summary>
        /// <remarks>
        /// This API allows to get information about an enrollment request. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="enrollmentId">The **enrollment-id** is the uuid code that identifies a specific enrollment request </param>
        /// <returns>Task of InlineResponse2007</returns>
        System.Threading.Tasks.Task<InlineResponse2007> GetEnrollmentRequestAsync (string organizationId, Id enrollmentId);

        /// <summary>
        /// Get information about an enrollment request
        /// </summary>
        /// <remarks>
        /// This API allows to get information about an enrollment request. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="enrollmentId">The **enrollment-id** is the uuid code that identifies a specific enrollment request </param>
        /// <returns>Task of ApiResponse (InlineResponse2007)</returns>
        System.Threading.Tasks.Task<ApiResponse<InlineResponse2007>> GetEnrollmentRequestAsyncWithHttpInfo (string organizationId, Id enrollmentId);
        /// <summary>
        /// Get information about an identity
        /// </summary>
        /// <remarks>
        /// This API allows to get all the information of an identity. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>Task of InlineResponse2005</returns>
        System.Threading.Tasks.Task<InlineResponse2005> GetIdentityAsync (string organizationId, Id identityId, string whereOrder = default(string));

        /// <summary>
        /// Get information about an identity
        /// </summary>
        /// <remarks>
        /// This API allows to get all the information of an identity. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>Task of ApiResponse (InlineResponse2005)</returns>
        System.Threading.Tasks.Task<ApiResponse<InlineResponse2005>> GetIdentityAsyncWithHttpInfo (string organizationId, Id identityId, string whereOrder = default(string));
        /// <summary>
        /// Enumerate the enrollment requests of an organization
        /// </summary>
        /// <remarks>
        /// This API allows to enumerate the enrollment requests of an organization. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="whereProvider">Returns the identity requests that have been issued by the specified provider (optional)</param>
        /// <param name="whereUser">Returns the identity requests of the specified user, searched by its id (optional)</param>
        /// <param name="whereFirstName">Returns the identity requests of the users that have the specified first name (optional)</param>
        /// <param name="whereLastName">Returns the identity requests of the users that have the specified last name (optional)</param>
        /// <param name="whereRegisteredBy">Returns the identity requests registered by this user (optional)</param>
        /// <param name="whereFiscalCode">Returns the identity requests have the specified fiscal code (optional)</param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>Task of InlineResponse2003</returns>
        System.Threading.Tasks.Task<InlineResponse2003> ListEnrollmentRequestsAsync (string organizationId, string whereProvider = default(string), string whereUser = default(string), string whereFirstName = default(string), string whereLastName = default(string), string whereRegisteredBy = default(string), string whereFiscalCode = default(string), int page = default(int), int count = default(int), string whereOrder = default(string));

        /// <summary>
        /// Enumerate the enrollment requests of an organization
        /// </summary>
        /// <remarks>
        /// This API allows to enumerate the enrollment requests of an organization. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="whereProvider">Returns the identity requests that have been issued by the specified provider (optional)</param>
        /// <param name="whereUser">Returns the identity requests of the specified user, searched by its id (optional)</param>
        /// <param name="whereFirstName">Returns the identity requests of the users that have the specified first name (optional)</param>
        /// <param name="whereLastName">Returns the identity requests of the users that have the specified last name (optional)</param>
        /// <param name="whereRegisteredBy">Returns the identity requests registered by this user (optional)</param>
        /// <param name="whereFiscalCode">Returns the identity requests have the specified fiscal code (optional)</param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>Task of ApiResponse (InlineResponse2003)</returns>
        System.Threading.Tasks.Task<ApiResponse<InlineResponse2003>> ListEnrollmentRequestsAsyncWithHttpInfo (string organizationId, string whereProvider = default(string), string whereUser = default(string), string whereFirstName = default(string), string whereLastName = default(string), string whereRegisteredBy = default(string), string whereFiscalCode = default(string), int page = default(int), int count = default(int), string whereOrder = default(string));
        /// <summary>
        /// Enumerate the identities of an organization
        /// </summary>
        /// <remarks>
        /// This API allows to enumerate all the users of an organization. It is possible to filter the data using the supported _django lookups_. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="whereProvider">Returns the identities that have been issued by the specified provider (optional)</param>
        /// <param name="whereUser">Returns the identities of the specified user, searched by its id (optional)</param>
        /// <param name="whereFirstName">Returns the identities of the users that have the specified first name (optional)</param>
        /// <param name="whereLastName">Returns the identities of the users that have the specified last name (optional)</param>
        /// <param name="whereRegisteredBy">Returns the identities registered by this user (optional)</param>
        /// <param name="whereFiscalCode">Returns the identities that have the specified fiscal code (optional)</param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>Task of InlineResponse2002</returns>
        System.Threading.Tasks.Task<InlineResponse2002> ListIdentitiesAsync (string organizationId, string whereProvider = default(string), string whereUser = default(string), string whereFirstName = default(string), string whereLastName = default(string), string whereRegisteredBy = default(string), string whereFiscalCode = default(string), int page = default(int), int count = default(int), string whereOrder = default(string));

        /// <summary>
        /// Enumerate the identities of an organization
        /// </summary>
        /// <remarks>
        /// This API allows to enumerate all the users of an organization. It is possible to filter the data using the supported _django lookups_. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="whereProvider">Returns the identities that have been issued by the specified provider (optional)</param>
        /// <param name="whereUser">Returns the identities of the specified user, searched by its id (optional)</param>
        /// <param name="whereFirstName">Returns the identities of the users that have the specified first name (optional)</param>
        /// <param name="whereLastName">Returns the identities of the users that have the specified last name (optional)</param>
        /// <param name="whereRegisteredBy">Returns the identities registered by this user (optional)</param>
        /// <param name="whereFiscalCode">Returns the identities that have the specified fiscal code (optional)</param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>Task of ApiResponse (InlineResponse2002)</returns>
        System.Threading.Tasks.Task<ApiResponse<InlineResponse2002>> ListIdentitiesAsyncWithHttpInfo (string organizationId, string whereProvider = default(string), string whereUser = default(string), string whereFirstName = default(string), string whereLastName = default(string), string whereRegisteredBy = default(string), string whereFiscalCode = default(string), int page = default(int), int count = default(int), string whereOrder = default(string));
        /// <summary>
        /// List the enrollments of an user
        /// </summary>
        /// <remarks>
        /// This API allows to list all the enrollments of an user. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="userId">The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user </param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>Task of InlineResponse2003</returns>
        System.Threading.Tasks.Task<InlineResponse2003> ListUserEnrollmentsAsync (string organizationId, Id userId, int page = default(int), int count = default(int), string whereOrder = default(string));

        /// <summary>
        /// List the enrollments of an user
        /// </summary>
        /// <remarks>
        /// This API allows to list all the enrollments of an user. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="userId">The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user </param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>Task of ApiResponse (InlineResponse2003)</returns>
        System.Threading.Tasks.Task<ApiResponse<InlineResponse2003>> ListUserEnrollmentsAsyncWithHttpInfo (string organizationId, Id userId, int page = default(int), int count = default(int), string whereOrder = default(string));
        /// <summary>
        /// Enumerate the identities of an user
        /// </summary>
        /// <remarks>
        /// This API allows to enumerate all the identities of an user, which are located in its wallet. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="userId">The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user </param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>Task of InlineResponse2002</returns>
        System.Threading.Tasks.Task<InlineResponse2002> ListUserIdentitiesAsync (string organizationId, Id userId, int page = default(int), int count = default(int), string whereOrder = default(string));

        /// <summary>
        /// Enumerate the identities of an user
        /// </summary>
        /// <remarks>
        /// This API allows to enumerate all the identities of an user, which are located in its wallet. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="userId">The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user </param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>Task of ApiResponse (InlineResponse2002)</returns>
        System.Threading.Tasks.Task<ApiResponse<InlineResponse2002>> ListUserIdentitiesAsyncWithHttpInfo (string organizationId, Id userId, int page = default(int), int count = default(int), string whereOrder = default(string));
        /// <summary>
        /// Renew an Identity
        /// </summary>
        /// <remarks>
        /// This API allows to renew an Identity of a user. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="enrollmentId">The **enrollment-id** is the uuid code that identifies a specific enrollment request </param>
        /// <param name="inlineObject1"></param>
        /// <returns>Task of InlineResponse2007</returns>
        System.Threading.Tasks.Task<InlineResponse2007> RenewIdentityAsync (string organizationId, Id enrollmentId, InlineObject1 inlineObject1);

        /// <summary>
        /// Renew an Identity
        /// </summary>
        /// <remarks>
        /// This API allows to renew an Identity of a user. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="enrollmentId">The **enrollment-id** is the uuid code that identifies a specific enrollment request </param>
        /// <param name="inlineObject1"></param>
        /// <returns>Task of ApiResponse (InlineResponse2007)</returns>
        System.Threading.Tasks.Task<ApiResponse<InlineResponse2007>> RenewIdentityAsyncWithHttpInfo (string organizationId, Id enrollmentId, InlineObject1 inlineObject1);
        /// <summary>
        /// Submit an enrollment request
        /// </summary>
        /// <remarks>
        /// This API allows to submit an enrollment request. The user of the request will be created if it does not exists already. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityRequest">The enrollment request to submit</param>
        /// <returns>Task of InlineResponse2007</returns>
        System.Threading.Tasks.Task<InlineResponse2007> RequestEnrollmentAsync (string organizationId, IdentityRequest identityRequest);

        /// <summary>
        /// Submit an enrollment request
        /// </summary>
        /// <remarks>
        /// This API allows to submit an enrollment request. The user of the request will be created if it does not exists already. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityRequest">The enrollment request to submit</param>
        /// <returns>Task of ApiResponse (InlineResponse2007)</returns>
        System.Threading.Tasks.Task<ApiResponse<InlineResponse2007>> RequestEnrollmentAsyncWithHttpInfo (string organizationId, IdentityRequest identityRequest);
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class IdentitiesApi : IIdentitiesApi
    {
        private SigningToday.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="IdentitiesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public IdentitiesApi(String basePath)
        {
            this.Configuration = new SigningToday.Client.Configuration { BasePath = basePath };

            ExceptionFactory = SigningToday.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IdentitiesApi"/> class
        /// </summary>
        /// <returns></returns>
        public IdentitiesApi()
        {
            this.Configuration = SigningToday.Client.Configuration.Default;

            ExceptionFactory = SigningToday.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IdentitiesApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public IdentitiesApi(SigningToday.Client.Configuration configuration = null)
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
        /// Associate an appearance to an identity Associate a signature appearance to an already existing identity through an url to an image. This appearance will be displayed on the document after the signature. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <param name="inlineObject"></param>
        /// <returns>InlineResponse2011</returns>
        public InlineResponse2011 AssociateAppearance (string organizationId, Id identityId, InlineObject inlineObject)
        {
             ApiResponse<InlineResponse2011> localVarResponse = AssociateAppearanceWithHttpInfo(organizationId, identityId, inlineObject);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Associate an appearance to an identity Associate a signature appearance to an already existing identity through an url to an image. This appearance will be displayed on the document after the signature. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <param name="inlineObject"></param>
        /// <returns>ApiResponse of InlineResponse2011</returns>
        public ApiResponse<InlineResponse2011> AssociateAppearanceWithHttpInfo (string organizationId, Id identityId, InlineObject inlineObject)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling IdentitiesApi->AssociateAppearance");
            // verify the required parameter 'identityId' is set
            if (identityId == null)
                throw new ApiException(400, "Missing required parameter 'identityId' when calling IdentitiesApi->AssociateAppearance");
            // verify the required parameter 'inlineObject' is set
            if (inlineObject == null)
                throw new ApiException(400, "Missing required parameter 'inlineObject' when calling IdentitiesApi->AssociateAppearance");

            var localVarPath = "/{organization-id}/identities/{identity-id}/appearance";
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
            if (identityId != null) localVarPathParams.Add("identity-id", this.Configuration.ApiClient.ParameterToString(identityId)); // path parameter
            if (inlineObject != null && inlineObject.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(inlineObject); // http body (model) parameter
            }
            else
            {
                localVarPostBody = inlineObject; // byte array
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
                Exception exception = ExceptionFactory("AssociateAppearance", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2011>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2011) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2011)));
        }

        /// <summary>
        /// Associate an appearance to an identity Associate a signature appearance to an already existing identity through an url to an image. This appearance will be displayed on the document after the signature. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <param name="inlineObject"></param>
        /// <returns>Task of InlineResponse2011</returns>
        public async System.Threading.Tasks.Task<InlineResponse2011> AssociateAppearanceAsync (string organizationId, Id identityId, InlineObject inlineObject)
        {
             ApiResponse<InlineResponse2011> localVarResponse = await AssociateAppearanceAsyncWithHttpInfo(organizationId, identityId, inlineObject);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Associate an appearance to an identity Associate a signature appearance to an already existing identity through an url to an image. This appearance will be displayed on the document after the signature. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <param name="inlineObject"></param>
        /// <returns>Task of ApiResponse (InlineResponse2011)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<InlineResponse2011>> AssociateAppearanceAsyncWithHttpInfo (string organizationId, Id identityId, InlineObject inlineObject)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling IdentitiesApi->AssociateAppearance");
            // verify the required parameter 'identityId' is set
            if (identityId == null)
                throw new ApiException(400, "Missing required parameter 'identityId' when calling IdentitiesApi->AssociateAppearance");
            // verify the required parameter 'inlineObject' is set
            if (inlineObject == null)
                throw new ApiException(400, "Missing required parameter 'inlineObject' when calling IdentitiesApi->AssociateAppearance");

            var localVarPath = "/{organization-id}/identities/{identity-id}/appearance";
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
            if (identityId != null) localVarPathParams.Add("identity-id", this.Configuration.ApiClient.ParameterToString(identityId)); // path parameter
            if (inlineObject != null && inlineObject.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(inlineObject); // http body (model) parameter
            }
            else
            {
                localVarPostBody = inlineObject; // byte array
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
                Exception exception = ExceptionFactory("AssociateAppearance", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2011>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2011) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2011)));
        }

        /// <summary>
        /// Associate to an user an already existing identity Associate to an user of the organization an already existing identity of a provider. The _provider_data_ field is an object and is different for each provider. The minimum set of information to provide as provider_data is the following:   - **aruba**     - _auth_domain_ : string     - _username_ : string     - _password_ : string   - **aruba-auto**     - _auth_domain_ : string     - _username_ : string     - _password_ : string   - **infocert**     - _username_ : string     - _password_ : string   - **namirial**     - _id_titolare_ : string     - _id_otp_ : string     - _username_ : string     - _password_ : string 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="userId">The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user </param>
        /// <param name="identityAssociation">Provider data to associate</param>
        /// <returns>InlineResponse2011</returns>
        public InlineResponse2011 AssociateIdentity (string organizationId, Id userId, IdentityAssociation identityAssociation)
        {
             ApiResponse<InlineResponse2011> localVarResponse = AssociateIdentityWithHttpInfo(organizationId, userId, identityAssociation);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Associate to an user an already existing identity Associate to an user of the organization an already existing identity of a provider. The _provider_data_ field is an object and is different for each provider. The minimum set of information to provide as provider_data is the following:   - **aruba**     - _auth_domain_ : string     - _username_ : string     - _password_ : string   - **aruba-auto**     - _auth_domain_ : string     - _username_ : string     - _password_ : string   - **infocert**     - _username_ : string     - _password_ : string   - **namirial**     - _id_titolare_ : string     - _id_otp_ : string     - _username_ : string     - _password_ : string 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="userId">The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user </param>
        /// <param name="identityAssociation">Provider data to associate</param>
        /// <returns>ApiResponse of InlineResponse2011</returns>
        public ApiResponse<InlineResponse2011> AssociateIdentityWithHttpInfo (string organizationId, Id userId, IdentityAssociation identityAssociation)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling IdentitiesApi->AssociateIdentity");
            // verify the required parameter 'userId' is set
            if (userId == null)
                throw new ApiException(400, "Missing required parameter 'userId' when calling IdentitiesApi->AssociateIdentity");
            // verify the required parameter 'identityAssociation' is set
            if (identityAssociation == null)
                throw new ApiException(400, "Missing required parameter 'identityAssociation' when calling IdentitiesApi->AssociateIdentity");

            var localVarPath = "/{organization-id}/users/{user-id}/wallet";
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
            if (userId != null) localVarPathParams.Add("user-id", this.Configuration.ApiClient.ParameterToString(userId)); // path parameter
            if (identityAssociation != null && identityAssociation.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(identityAssociation); // http body (model) parameter
            }
            else
            {
                localVarPostBody = identityAssociation; // byte array
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
                Exception exception = ExceptionFactory("AssociateIdentity", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2011>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2011) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2011)));
        }

        /// <summary>
        /// Associate to an user an already existing identity Associate to an user of the organization an already existing identity of a provider. The _provider_data_ field is an object and is different for each provider. The minimum set of information to provide as provider_data is the following:   - **aruba**     - _auth_domain_ : string     - _username_ : string     - _password_ : string   - **aruba-auto**     - _auth_domain_ : string     - _username_ : string     - _password_ : string   - **infocert**     - _username_ : string     - _password_ : string   - **namirial**     - _id_titolare_ : string     - _id_otp_ : string     - _username_ : string     - _password_ : string 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="userId">The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user </param>
        /// <param name="identityAssociation">Provider data to associate</param>
        /// <returns>Task of InlineResponse2011</returns>
        public async System.Threading.Tasks.Task<InlineResponse2011> AssociateIdentityAsync (string organizationId, Id userId, IdentityAssociation identityAssociation)
        {
             ApiResponse<InlineResponse2011> localVarResponse = await AssociateIdentityAsyncWithHttpInfo(organizationId, userId, identityAssociation);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Associate to an user an already existing identity Associate to an user of the organization an already existing identity of a provider. The _provider_data_ field is an object and is different for each provider. The minimum set of information to provide as provider_data is the following:   - **aruba**     - _auth_domain_ : string     - _username_ : string     - _password_ : string   - **aruba-auto**     - _auth_domain_ : string     - _username_ : string     - _password_ : string   - **infocert**     - _username_ : string     - _password_ : string   - **namirial**     - _id_titolare_ : string     - _id_otp_ : string     - _username_ : string     - _password_ : string 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="userId">The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user </param>
        /// <param name="identityAssociation">Provider data to associate</param>
        /// <returns>Task of ApiResponse (InlineResponse2011)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<InlineResponse2011>> AssociateIdentityAsyncWithHttpInfo (string organizationId, Id userId, IdentityAssociation identityAssociation)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling IdentitiesApi->AssociateIdentity");
            // verify the required parameter 'userId' is set
            if (userId == null)
                throw new ApiException(400, "Missing required parameter 'userId' when calling IdentitiesApi->AssociateIdentity");
            // verify the required parameter 'identityAssociation' is set
            if (identityAssociation == null)
                throw new ApiException(400, "Missing required parameter 'identityAssociation' when calling IdentitiesApi->AssociateIdentity");

            var localVarPath = "/{organization-id}/users/{user-id}/wallet";
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
            if (userId != null) localVarPathParams.Add("user-id", this.Configuration.ApiClient.ParameterToString(userId)); // path parameter
            if (identityAssociation != null && identityAssociation.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(identityAssociation); // http body (model) parameter
            }
            else
            {
                localVarPostBody = identityAssociation; // byte array
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
                Exception exception = ExceptionFactory("AssociateIdentity", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2011>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2011) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2011)));
        }

        /// <summary>
        /// Create an identity from token This API allows to create an identity from a token. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="createIdentitybyToken">Body of the request to create an identity from a token</param>
        /// <returns>InlineResponse2012</returns>
        public InlineResponse2012 CreateTokenFromIdentity (string organizationId, CreateIdentitybyToken createIdentitybyToken)
        {
             ApiResponse<InlineResponse2012> localVarResponse = CreateTokenFromIdentityWithHttpInfo(organizationId, createIdentitybyToken);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Create an identity from token This API allows to create an identity from a token. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="createIdentitybyToken">Body of the request to create an identity from a token</param>
        /// <returns>ApiResponse of InlineResponse2012</returns>
        public ApiResponse<InlineResponse2012> CreateTokenFromIdentityWithHttpInfo (string organizationId, CreateIdentitybyToken createIdentitybyToken)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling IdentitiesApi->CreateTokenFromIdentity");
            // verify the required parameter 'createIdentitybyToken' is set
            if (createIdentitybyToken == null)
                throw new ApiException(400, "Missing required parameter 'createIdentitybyToken' when calling IdentitiesApi->CreateTokenFromIdentity");

            var localVarPath = "/{organization-id}/identities/create/token";
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
            if (createIdentitybyToken != null && createIdentitybyToken.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(createIdentitybyToken); // http body (model) parameter
            }
            else
            {
                localVarPostBody = createIdentitybyToken; // byte array
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
                Exception exception = ExceptionFactory("CreateTokenFromIdentity", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2012>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2012) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2012)));
        }

        /// <summary>
        /// Create an identity from token This API allows to create an identity from a token. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="createIdentitybyToken">Body of the request to create an identity from a token</param>
        /// <returns>Task of InlineResponse2012</returns>
        public async System.Threading.Tasks.Task<InlineResponse2012> CreateTokenFromIdentityAsync (string organizationId, CreateIdentitybyToken createIdentitybyToken)
        {
             ApiResponse<InlineResponse2012> localVarResponse = await CreateTokenFromIdentityAsyncWithHttpInfo(organizationId, createIdentitybyToken);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Create an identity from token This API allows to create an identity from a token. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="createIdentitybyToken">Body of the request to create an identity from a token</param>
        /// <returns>Task of ApiResponse (InlineResponse2012)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<InlineResponse2012>> CreateTokenFromIdentityAsyncWithHttpInfo (string organizationId, CreateIdentitybyToken createIdentitybyToken)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling IdentitiesApi->CreateTokenFromIdentity");
            // verify the required parameter 'createIdentitybyToken' is set
            if (createIdentitybyToken == null)
                throw new ApiException(400, "Missing required parameter 'createIdentitybyToken' when calling IdentitiesApi->CreateTokenFromIdentity");

            var localVarPath = "/{organization-id}/identities/create/token";
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
            if (createIdentitybyToken != null && createIdentitybyToken.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(createIdentitybyToken); // http body (model) parameter
            }
            else
            {
                localVarPostBody = createIdentitybyToken; // byte array
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
                Exception exception = ExceptionFactory("CreateTokenFromIdentity", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2012>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2012) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2012)));
        }

        /// <summary>
        /// Delete the appearance of an identity This API allows to delete the appearance associated to an identity. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <returns>InlineResponse2011</returns>
        public InlineResponse2011 DeleteAppearance (string organizationId, Id identityId)
        {
             ApiResponse<InlineResponse2011> localVarResponse = DeleteAppearanceWithHttpInfo(organizationId, identityId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Delete the appearance of an identity This API allows to delete the appearance associated to an identity. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <returns>ApiResponse of InlineResponse2011</returns>
        public ApiResponse<InlineResponse2011> DeleteAppearanceWithHttpInfo (string organizationId, Id identityId)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling IdentitiesApi->DeleteAppearance");
            // verify the required parameter 'identityId' is set
            if (identityId == null)
                throw new ApiException(400, "Missing required parameter 'identityId' when calling IdentitiesApi->DeleteAppearance");

            var localVarPath = "/{organization-id}/identities/{identity-id}/appearance";
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
            if (identityId != null) localVarPathParams.Add("identity-id", this.Configuration.ApiClient.ParameterToString(identityId)); // path parameter

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
                Exception exception = ExceptionFactory("DeleteAppearance", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2011>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2011) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2011)));
        }

        /// <summary>
        /// Delete the appearance of an identity This API allows to delete the appearance associated to an identity. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <returns>Task of InlineResponse2011</returns>
        public async System.Threading.Tasks.Task<InlineResponse2011> DeleteAppearanceAsync (string organizationId, Id identityId)
        {
             ApiResponse<InlineResponse2011> localVarResponse = await DeleteAppearanceAsyncWithHttpInfo(organizationId, identityId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Delete the appearance of an identity This API allows to delete the appearance associated to an identity. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <returns>Task of ApiResponse (InlineResponse2011)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<InlineResponse2011>> DeleteAppearanceAsyncWithHttpInfo (string organizationId, Id identityId)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling IdentitiesApi->DeleteAppearance");
            // verify the required parameter 'identityId' is set
            if (identityId == null)
                throw new ApiException(400, "Missing required parameter 'identityId' when calling IdentitiesApi->DeleteAppearance");

            var localVarPath = "/{organization-id}/identities/{identity-id}/appearance";
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
            if (identityId != null) localVarPathParams.Add("identity-id", this.Configuration.ApiClient.ParameterToString(identityId)); // path parameter

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
                Exception exception = ExceptionFactory("DeleteAppearance", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2011>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2011) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2011)));
        }

        /// <summary>
        /// Delete an enrollment request This API allows to delete an enrollment request. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="enrollmentId">The **enrollment-id** is the uuid code that identifies a specific enrollment request </param>
        /// <returns>InlineResponse2012</returns>
        public InlineResponse2012 DeleteEnrollmentRequest (string organizationId, Id enrollmentId)
        {
             ApiResponse<InlineResponse2012> localVarResponse = DeleteEnrollmentRequestWithHttpInfo(organizationId, enrollmentId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Delete an enrollment request This API allows to delete an enrollment request. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="enrollmentId">The **enrollment-id** is the uuid code that identifies a specific enrollment request </param>
        /// <returns>ApiResponse of InlineResponse2012</returns>
        public ApiResponse<InlineResponse2012> DeleteEnrollmentRequestWithHttpInfo (string organizationId, Id enrollmentId)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling IdentitiesApi->DeleteEnrollmentRequest");
            // verify the required parameter 'enrollmentId' is set
            if (enrollmentId == null)
                throw new ApiException(400, "Missing required parameter 'enrollmentId' when calling IdentitiesApi->DeleteEnrollmentRequest");

            var localVarPath = "/{organization-id}/identity-requests/{enrollment-id}";
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
            if (enrollmentId != null) localVarPathParams.Add("enrollment-id", this.Configuration.ApiClient.ParameterToString(enrollmentId)); // path parameter

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
                Exception exception = ExceptionFactory("DeleteEnrollmentRequest", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2012>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2012) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2012)));
        }

        /// <summary>
        /// Delete an enrollment request This API allows to delete an enrollment request. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="enrollmentId">The **enrollment-id** is the uuid code that identifies a specific enrollment request </param>
        /// <returns>Task of InlineResponse2012</returns>
        public async System.Threading.Tasks.Task<InlineResponse2012> DeleteEnrollmentRequestAsync (string organizationId, Id enrollmentId)
        {
             ApiResponse<InlineResponse2012> localVarResponse = await DeleteEnrollmentRequestAsyncWithHttpInfo(organizationId, enrollmentId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Delete an enrollment request This API allows to delete an enrollment request. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="enrollmentId">The **enrollment-id** is the uuid code that identifies a specific enrollment request </param>
        /// <returns>Task of ApiResponse (InlineResponse2012)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<InlineResponse2012>> DeleteEnrollmentRequestAsyncWithHttpInfo (string organizationId, Id enrollmentId)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling IdentitiesApi->DeleteEnrollmentRequest");
            // verify the required parameter 'enrollmentId' is set
            if (enrollmentId == null)
                throw new ApiException(400, "Missing required parameter 'enrollmentId' when calling IdentitiesApi->DeleteEnrollmentRequest");

            var localVarPath = "/{organization-id}/identity-requests/{enrollment-id}";
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
            if (enrollmentId != null) localVarPathParams.Add("enrollment-id", this.Configuration.ApiClient.ParameterToString(enrollmentId)); // path parameter

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
                Exception exception = ExceptionFactory("DeleteEnrollmentRequest", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2012>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2012) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2012)));
        }

        /// <summary>
        /// Delete an identity This API allows to delete an identity of an user. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <returns>InlineResponse2006</returns>
        public InlineResponse2006 DeleteIdentity (string organizationId, Id identityId)
        {
             ApiResponse<InlineResponse2006> localVarResponse = DeleteIdentityWithHttpInfo(organizationId, identityId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Delete an identity This API allows to delete an identity of an user. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <returns>ApiResponse of InlineResponse2006</returns>
        public ApiResponse<InlineResponse2006> DeleteIdentityWithHttpInfo (string organizationId, Id identityId)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling IdentitiesApi->DeleteIdentity");
            // verify the required parameter 'identityId' is set
            if (identityId == null)
                throw new ApiException(400, "Missing required parameter 'identityId' when calling IdentitiesApi->DeleteIdentity");

            var localVarPath = "/{organization-id}/identities/{identity-id}";
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
            if (identityId != null) localVarPathParams.Add("identity-id", this.Configuration.ApiClient.ParameterToString(identityId)); // path parameter

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
                Exception exception = ExceptionFactory("DeleteIdentity", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2006>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2006) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2006)));
        }

        /// <summary>
        /// Delete an identity This API allows to delete an identity of an user. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <returns>Task of InlineResponse2006</returns>
        public async System.Threading.Tasks.Task<InlineResponse2006> DeleteIdentityAsync (string organizationId, Id identityId)
        {
             ApiResponse<InlineResponse2006> localVarResponse = await DeleteIdentityAsyncWithHttpInfo(organizationId, identityId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Delete an identity This API allows to delete an identity of an user. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <returns>Task of ApiResponse (InlineResponse2006)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<InlineResponse2006>> DeleteIdentityAsyncWithHttpInfo (string organizationId, Id identityId)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling IdentitiesApi->DeleteIdentity");
            // verify the required parameter 'identityId' is set
            if (identityId == null)
                throw new ApiException(400, "Missing required parameter 'identityId' when calling IdentitiesApi->DeleteIdentity");

            var localVarPath = "/{organization-id}/identities/{identity-id}";
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
            if (identityId != null) localVarPathParams.Add("identity-id", this.Configuration.ApiClient.ParameterToString(identityId)); // path parameter

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
                Exception exception = ExceptionFactory("DeleteIdentity", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2006>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2006) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2006)));
        }

        /// <summary>
        /// Get information about an enrollment request This API allows to get information about an enrollment request. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="enrollmentId">The **enrollment-id** is the uuid code that identifies a specific enrollment request </param>
        /// <returns>InlineResponse2007</returns>
        public InlineResponse2007 GetEnrollmentRequest (string organizationId, Id enrollmentId)
        {
             ApiResponse<InlineResponse2007> localVarResponse = GetEnrollmentRequestWithHttpInfo(organizationId, enrollmentId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get information about an enrollment request This API allows to get information about an enrollment request. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="enrollmentId">The **enrollment-id** is the uuid code that identifies a specific enrollment request </param>
        /// <returns>ApiResponse of InlineResponse2007</returns>
        public ApiResponse<InlineResponse2007> GetEnrollmentRequestWithHttpInfo (string organizationId, Id enrollmentId)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling IdentitiesApi->GetEnrollmentRequest");
            // verify the required parameter 'enrollmentId' is set
            if (enrollmentId == null)
                throw new ApiException(400, "Missing required parameter 'enrollmentId' when calling IdentitiesApi->GetEnrollmentRequest");

            var localVarPath = "/{organization-id}/identity-requests/{enrollment-id}";
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
            if (enrollmentId != null) localVarPathParams.Add("enrollment-id", this.Configuration.ApiClient.ParameterToString(enrollmentId)); // path parameter

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
                Exception exception = ExceptionFactory("GetEnrollmentRequest", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2007>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2007) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2007)));
        }

        /// <summary>
        /// Get information about an enrollment request This API allows to get information about an enrollment request. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="enrollmentId">The **enrollment-id** is the uuid code that identifies a specific enrollment request </param>
        /// <returns>Task of InlineResponse2007</returns>
        public async System.Threading.Tasks.Task<InlineResponse2007> GetEnrollmentRequestAsync (string organizationId, Id enrollmentId)
        {
             ApiResponse<InlineResponse2007> localVarResponse = await GetEnrollmentRequestAsyncWithHttpInfo(organizationId, enrollmentId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Get information about an enrollment request This API allows to get information about an enrollment request. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="enrollmentId">The **enrollment-id** is the uuid code that identifies a specific enrollment request </param>
        /// <returns>Task of ApiResponse (InlineResponse2007)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<InlineResponse2007>> GetEnrollmentRequestAsyncWithHttpInfo (string organizationId, Id enrollmentId)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling IdentitiesApi->GetEnrollmentRequest");
            // verify the required parameter 'enrollmentId' is set
            if (enrollmentId == null)
                throw new ApiException(400, "Missing required parameter 'enrollmentId' when calling IdentitiesApi->GetEnrollmentRequest");

            var localVarPath = "/{organization-id}/identity-requests/{enrollment-id}";
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
            if (enrollmentId != null) localVarPathParams.Add("enrollment-id", this.Configuration.ApiClient.ParameterToString(enrollmentId)); // path parameter

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
                Exception exception = ExceptionFactory("GetEnrollmentRequest", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2007>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2007) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2007)));
        }

        /// <summary>
        /// Get information about an identity This API allows to get all the information of an identity. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>InlineResponse2005</returns>
        public InlineResponse2005 GetIdentity (string organizationId, Id identityId, string whereOrder = default(string))
        {
             ApiResponse<InlineResponse2005> localVarResponse = GetIdentityWithHttpInfo(organizationId, identityId, whereOrder);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get information about an identity This API allows to get all the information of an identity. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>ApiResponse of InlineResponse2005</returns>
        public ApiResponse<InlineResponse2005> GetIdentityWithHttpInfo (string organizationId, Id identityId, string whereOrder = default(string))
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling IdentitiesApi->GetIdentity");
            // verify the required parameter 'identityId' is set
            if (identityId == null)
                throw new ApiException(400, "Missing required parameter 'identityId' when calling IdentitiesApi->GetIdentity");

            var localVarPath = "/{organization-id}/identities/{identity-id}";
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
            if (identityId != null) localVarPathParams.Add("identity-id", this.Configuration.ApiClient.ParameterToString(identityId)); // path parameter
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
                Exception exception = ExceptionFactory("GetIdentity", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2005>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2005) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2005)));
        }

        /// <summary>
        /// Get information about an identity This API allows to get all the information of an identity. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>Task of InlineResponse2005</returns>
        public async System.Threading.Tasks.Task<InlineResponse2005> GetIdentityAsync (string organizationId, Id identityId, string whereOrder = default(string))
        {
             ApiResponse<InlineResponse2005> localVarResponse = await GetIdentityAsyncWithHttpInfo(organizationId, identityId, whereOrder);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Get information about an identity This API allows to get all the information of an identity. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>Task of ApiResponse (InlineResponse2005)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<InlineResponse2005>> GetIdentityAsyncWithHttpInfo (string organizationId, Id identityId, string whereOrder = default(string))
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling IdentitiesApi->GetIdentity");
            // verify the required parameter 'identityId' is set
            if (identityId == null)
                throw new ApiException(400, "Missing required parameter 'identityId' when calling IdentitiesApi->GetIdentity");

            var localVarPath = "/{organization-id}/identities/{identity-id}";
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
            if (identityId != null) localVarPathParams.Add("identity-id", this.Configuration.ApiClient.ParameterToString(identityId)); // path parameter
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
                Exception exception = ExceptionFactory("GetIdentity", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2005>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2005) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2005)));
        }

        /// <summary>
        /// Enumerate the enrollment requests of an organization This API allows to enumerate the enrollment requests of an organization. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="whereProvider">Returns the identity requests that have been issued by the specified provider (optional)</param>
        /// <param name="whereUser">Returns the identity requests of the specified user, searched by its id (optional)</param>
        /// <param name="whereFirstName">Returns the identity requests of the users that have the specified first name (optional)</param>
        /// <param name="whereLastName">Returns the identity requests of the users that have the specified last name (optional)</param>
        /// <param name="whereRegisteredBy">Returns the identity requests registered by this user (optional)</param>
        /// <param name="whereFiscalCode">Returns the identity requests have the specified fiscal code (optional)</param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>InlineResponse2003</returns>
        public InlineResponse2003 ListEnrollmentRequests (string organizationId, string whereProvider = default(string), string whereUser = default(string), string whereFirstName = default(string), string whereLastName = default(string), string whereRegisteredBy = default(string), string whereFiscalCode = default(string), int page = default(int), int count = default(int), string whereOrder = default(string))
        {
             ApiResponse<InlineResponse2003> localVarResponse = ListEnrollmentRequestsWithHttpInfo(organizationId, whereProvider, whereUser, whereFirstName, whereLastName, whereRegisteredBy, whereFiscalCode, page, count, whereOrder);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Enumerate the enrollment requests of an organization This API allows to enumerate the enrollment requests of an organization. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="whereProvider">Returns the identity requests that have been issued by the specified provider (optional)</param>
        /// <param name="whereUser">Returns the identity requests of the specified user, searched by its id (optional)</param>
        /// <param name="whereFirstName">Returns the identity requests of the users that have the specified first name (optional)</param>
        /// <param name="whereLastName">Returns the identity requests of the users that have the specified last name (optional)</param>
        /// <param name="whereRegisteredBy">Returns the identity requests registered by this user (optional)</param>
        /// <param name="whereFiscalCode">Returns the identity requests have the specified fiscal code (optional)</param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>ApiResponse of InlineResponse2003</returns>
        public ApiResponse<InlineResponse2003> ListEnrollmentRequestsWithHttpInfo (string organizationId, string whereProvider = default(string), string whereUser = default(string), string whereFirstName = default(string), string whereLastName = default(string), string whereRegisteredBy = default(string), string whereFiscalCode = default(string), int page = default(int), int count = default(int), string whereOrder = default(string))
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling IdentitiesApi->ListEnrollmentRequests");

            var localVarPath = "/{organization-id}/identity-requests";
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
            if (whereProvider != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_provider", whereProvider)); // query parameter
            if (whereUser != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_user", whereUser)); // query parameter
            if (whereFirstName != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_first_name", whereFirstName)); // query parameter
            if (whereLastName != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_last_name", whereLastName)); // query parameter
            if (whereRegisteredBy != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_registered_by", whereRegisteredBy)); // query parameter
            if (whereFiscalCode != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_fiscal_code", whereFiscalCode)); // query parameter
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
                Exception exception = ExceptionFactory("ListEnrollmentRequests", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2003>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2003) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2003)));
        }

        /// <summary>
        /// Enumerate the enrollment requests of an organization This API allows to enumerate the enrollment requests of an organization. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="whereProvider">Returns the identity requests that have been issued by the specified provider (optional)</param>
        /// <param name="whereUser">Returns the identity requests of the specified user, searched by its id (optional)</param>
        /// <param name="whereFirstName">Returns the identity requests of the users that have the specified first name (optional)</param>
        /// <param name="whereLastName">Returns the identity requests of the users that have the specified last name (optional)</param>
        /// <param name="whereRegisteredBy">Returns the identity requests registered by this user (optional)</param>
        /// <param name="whereFiscalCode">Returns the identity requests have the specified fiscal code (optional)</param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>Task of InlineResponse2003</returns>
        public async System.Threading.Tasks.Task<InlineResponse2003> ListEnrollmentRequestsAsync (string organizationId, string whereProvider = default(string), string whereUser = default(string), string whereFirstName = default(string), string whereLastName = default(string), string whereRegisteredBy = default(string), string whereFiscalCode = default(string), int page = default(int), int count = default(int), string whereOrder = default(string))
        {
             ApiResponse<InlineResponse2003> localVarResponse = await ListEnrollmentRequestsAsyncWithHttpInfo(organizationId, whereProvider, whereUser, whereFirstName, whereLastName, whereRegisteredBy, whereFiscalCode, page, count, whereOrder);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Enumerate the enrollment requests of an organization This API allows to enumerate the enrollment requests of an organization. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="whereProvider">Returns the identity requests that have been issued by the specified provider (optional)</param>
        /// <param name="whereUser">Returns the identity requests of the specified user, searched by its id (optional)</param>
        /// <param name="whereFirstName">Returns the identity requests of the users that have the specified first name (optional)</param>
        /// <param name="whereLastName">Returns the identity requests of the users that have the specified last name (optional)</param>
        /// <param name="whereRegisteredBy">Returns the identity requests registered by this user (optional)</param>
        /// <param name="whereFiscalCode">Returns the identity requests have the specified fiscal code (optional)</param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>Task of ApiResponse (InlineResponse2003)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<InlineResponse2003>> ListEnrollmentRequestsAsyncWithHttpInfo (string organizationId, string whereProvider = default(string), string whereUser = default(string), string whereFirstName = default(string), string whereLastName = default(string), string whereRegisteredBy = default(string), string whereFiscalCode = default(string), int page = default(int), int count = default(int), string whereOrder = default(string))
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling IdentitiesApi->ListEnrollmentRequests");

            var localVarPath = "/{organization-id}/identity-requests";
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
            if (whereProvider != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_provider", whereProvider)); // query parameter
            if (whereUser != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_user", whereUser)); // query parameter
            if (whereFirstName != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_first_name", whereFirstName)); // query parameter
            if (whereLastName != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_last_name", whereLastName)); // query parameter
            if (whereRegisteredBy != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_registered_by", whereRegisteredBy)); // query parameter
            if (whereFiscalCode != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_fiscal_code", whereFiscalCode)); // query parameter
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
                Exception exception = ExceptionFactory("ListEnrollmentRequests", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2003>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2003) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2003)));
        }

        /// <summary>
        /// Enumerate the identities of an organization This API allows to enumerate all the users of an organization. It is possible to filter the data using the supported _django lookups_. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="whereProvider">Returns the identities that have been issued by the specified provider (optional)</param>
        /// <param name="whereUser">Returns the identities of the specified user, searched by its id (optional)</param>
        /// <param name="whereFirstName">Returns the identities of the users that have the specified first name (optional)</param>
        /// <param name="whereLastName">Returns the identities of the users that have the specified last name (optional)</param>
        /// <param name="whereRegisteredBy">Returns the identities registered by this user (optional)</param>
        /// <param name="whereFiscalCode">Returns the identities that have the specified fiscal code (optional)</param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>InlineResponse2002</returns>
        public InlineResponse2002 ListIdentities (string organizationId, string whereProvider = default(string), string whereUser = default(string), string whereFirstName = default(string), string whereLastName = default(string), string whereRegisteredBy = default(string), string whereFiscalCode = default(string), int page = default(int), int count = default(int), string whereOrder = default(string))
        {
             ApiResponse<InlineResponse2002> localVarResponse = ListIdentitiesWithHttpInfo(organizationId, whereProvider, whereUser, whereFirstName, whereLastName, whereRegisteredBy, whereFiscalCode, page, count, whereOrder);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Enumerate the identities of an organization This API allows to enumerate all the users of an organization. It is possible to filter the data using the supported _django lookups_. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="whereProvider">Returns the identities that have been issued by the specified provider (optional)</param>
        /// <param name="whereUser">Returns the identities of the specified user, searched by its id (optional)</param>
        /// <param name="whereFirstName">Returns the identities of the users that have the specified first name (optional)</param>
        /// <param name="whereLastName">Returns the identities of the users that have the specified last name (optional)</param>
        /// <param name="whereRegisteredBy">Returns the identities registered by this user (optional)</param>
        /// <param name="whereFiscalCode">Returns the identities that have the specified fiscal code (optional)</param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>ApiResponse of InlineResponse2002</returns>
        public ApiResponse<InlineResponse2002> ListIdentitiesWithHttpInfo (string organizationId, string whereProvider = default(string), string whereUser = default(string), string whereFirstName = default(string), string whereLastName = default(string), string whereRegisteredBy = default(string), string whereFiscalCode = default(string), int page = default(int), int count = default(int), string whereOrder = default(string))
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling IdentitiesApi->ListIdentities");

            var localVarPath = "/{organization-id}/identities";
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
            if (whereProvider != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_provider", whereProvider)); // query parameter
            if (whereUser != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_user", whereUser)); // query parameter
            if (whereFirstName != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_first_name", whereFirstName)); // query parameter
            if (whereLastName != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_last_name", whereLastName)); // query parameter
            if (whereRegisteredBy != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_registered_by", whereRegisteredBy)); // query parameter
            if (whereFiscalCode != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_fiscal_code", whereFiscalCode)); // query parameter
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
                Exception exception = ExceptionFactory("ListIdentities", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2002>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2002) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2002)));
        }

        /// <summary>
        /// Enumerate the identities of an organization This API allows to enumerate all the users of an organization. It is possible to filter the data using the supported _django lookups_. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="whereProvider">Returns the identities that have been issued by the specified provider (optional)</param>
        /// <param name="whereUser">Returns the identities of the specified user, searched by its id (optional)</param>
        /// <param name="whereFirstName">Returns the identities of the users that have the specified first name (optional)</param>
        /// <param name="whereLastName">Returns the identities of the users that have the specified last name (optional)</param>
        /// <param name="whereRegisteredBy">Returns the identities registered by this user (optional)</param>
        /// <param name="whereFiscalCode">Returns the identities that have the specified fiscal code (optional)</param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>Task of InlineResponse2002</returns>
        public async System.Threading.Tasks.Task<InlineResponse2002> ListIdentitiesAsync (string organizationId, string whereProvider = default(string), string whereUser = default(string), string whereFirstName = default(string), string whereLastName = default(string), string whereRegisteredBy = default(string), string whereFiscalCode = default(string), int page = default(int), int count = default(int), string whereOrder = default(string))
        {
             ApiResponse<InlineResponse2002> localVarResponse = await ListIdentitiesAsyncWithHttpInfo(organizationId, whereProvider, whereUser, whereFirstName, whereLastName, whereRegisteredBy, whereFiscalCode, page, count, whereOrder);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Enumerate the identities of an organization This API allows to enumerate all the users of an organization. It is possible to filter the data using the supported _django lookups_. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="whereProvider">Returns the identities that have been issued by the specified provider (optional)</param>
        /// <param name="whereUser">Returns the identities of the specified user, searched by its id (optional)</param>
        /// <param name="whereFirstName">Returns the identities of the users that have the specified first name (optional)</param>
        /// <param name="whereLastName">Returns the identities of the users that have the specified last name (optional)</param>
        /// <param name="whereRegisteredBy">Returns the identities registered by this user (optional)</param>
        /// <param name="whereFiscalCode">Returns the identities that have the specified fiscal code (optional)</param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>Task of ApiResponse (InlineResponse2002)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<InlineResponse2002>> ListIdentitiesAsyncWithHttpInfo (string organizationId, string whereProvider = default(string), string whereUser = default(string), string whereFirstName = default(string), string whereLastName = default(string), string whereRegisteredBy = default(string), string whereFiscalCode = default(string), int page = default(int), int count = default(int), string whereOrder = default(string))
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling IdentitiesApi->ListIdentities");

            var localVarPath = "/{organization-id}/identities";
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
            if (whereProvider != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_provider", whereProvider)); // query parameter
            if (whereUser != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_user", whereUser)); // query parameter
            if (whereFirstName != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_first_name", whereFirstName)); // query parameter
            if (whereLastName != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_last_name", whereLastName)); // query parameter
            if (whereRegisteredBy != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_registered_by", whereRegisteredBy)); // query parameter
            if (whereFiscalCode != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "where_fiscal_code", whereFiscalCode)); // query parameter
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
                Exception exception = ExceptionFactory("ListIdentities", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2002>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2002) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2002)));
        }

        /// <summary>
        /// List the enrollments of an user This API allows to list all the enrollments of an user. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="userId">The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user </param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>InlineResponse2003</returns>
        public InlineResponse2003 ListUserEnrollments (string organizationId, Id userId, int page = default(int), int count = default(int), string whereOrder = default(string))
        {
             ApiResponse<InlineResponse2003> localVarResponse = ListUserEnrollmentsWithHttpInfo(organizationId, userId, page, count, whereOrder);
             return localVarResponse.Data;
        }

        /// <summary>
        /// List the enrollments of an user This API allows to list all the enrollments of an user. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="userId">The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user </param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>ApiResponse of InlineResponse2003</returns>
        public ApiResponse<InlineResponse2003> ListUserEnrollmentsWithHttpInfo (string organizationId, Id userId, int page = default(int), int count = default(int), string whereOrder = default(string))
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling IdentitiesApi->ListUserEnrollments");
            // verify the required parameter 'userId' is set
            if (userId == null)
                throw new ApiException(400, "Missing required parameter 'userId' when calling IdentitiesApi->ListUserEnrollments");

            var localVarPath = "/{organization-id}/users/{user-id}/identity-requests";
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
                Exception exception = ExceptionFactory("ListUserEnrollments", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2003>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2003) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2003)));
        }

        /// <summary>
        /// List the enrollments of an user This API allows to list all the enrollments of an user. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="userId">The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user </param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>Task of InlineResponse2003</returns>
        public async System.Threading.Tasks.Task<InlineResponse2003> ListUserEnrollmentsAsync (string organizationId, Id userId, int page = default(int), int count = default(int), string whereOrder = default(string))
        {
             ApiResponse<InlineResponse2003> localVarResponse = await ListUserEnrollmentsAsyncWithHttpInfo(organizationId, userId, page, count, whereOrder);
             return localVarResponse.Data;

        }

        /// <summary>
        /// List the enrollments of an user This API allows to list all the enrollments of an user. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="userId">The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user </param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>Task of ApiResponse (InlineResponse2003)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<InlineResponse2003>> ListUserEnrollmentsAsyncWithHttpInfo (string organizationId, Id userId, int page = default(int), int count = default(int), string whereOrder = default(string))
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling IdentitiesApi->ListUserEnrollments");
            // verify the required parameter 'userId' is set
            if (userId == null)
                throw new ApiException(400, "Missing required parameter 'userId' when calling IdentitiesApi->ListUserEnrollments");

            var localVarPath = "/{organization-id}/users/{user-id}/identity-requests";
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
                Exception exception = ExceptionFactory("ListUserEnrollments", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2003>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2003) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2003)));
        }

        /// <summary>
        /// Enumerate the identities of an user This API allows to enumerate all the identities of an user, which are located in its wallet. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="userId">The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user </param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>InlineResponse2002</returns>
        public InlineResponse2002 ListUserIdentities (string organizationId, Id userId, int page = default(int), int count = default(int), string whereOrder = default(string))
        {
             ApiResponse<InlineResponse2002> localVarResponse = ListUserIdentitiesWithHttpInfo(organizationId, userId, page, count, whereOrder);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Enumerate the identities of an user This API allows to enumerate all the identities of an user, which are located in its wallet. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="userId">The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user </param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>ApiResponse of InlineResponse2002</returns>
        public ApiResponse<InlineResponse2002> ListUserIdentitiesWithHttpInfo (string organizationId, Id userId, int page = default(int), int count = default(int), string whereOrder = default(string))
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling IdentitiesApi->ListUserIdentities");
            // verify the required parameter 'userId' is set
            if (userId == null)
                throw new ApiException(400, "Missing required parameter 'userId' when calling IdentitiesApi->ListUserIdentities");

            var localVarPath = "/{organization-id}/users/{user-id}/wallet";
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
                Exception exception = ExceptionFactory("ListUserIdentities", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2002>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2002) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2002)));
        }

        /// <summary>
        /// Enumerate the identities of an user This API allows to enumerate all the identities of an user, which are located in its wallet. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="userId">The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user </param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>Task of InlineResponse2002</returns>
        public async System.Threading.Tasks.Task<InlineResponse2002> ListUserIdentitiesAsync (string organizationId, Id userId, int page = default(int), int count = default(int), string whereOrder = default(string))
        {
             ApiResponse<InlineResponse2002> localVarResponse = await ListUserIdentitiesAsyncWithHttpInfo(organizationId, userId, page, count, whereOrder);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Enumerate the identities of an user This API allows to enumerate all the identities of an user, which are located in its wallet. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="userId">The **user-id** is the uuid code that identifies a user of an organization. It is used as a path parameter to restrict the requested operation to the scope of that user </param>
        /// <param name="page">Restricts the search to the chosen page (optional)</param>
        /// <param name="count">Sets the number of users per page to display (optional, default to 100)</param>
        /// <param name="whereOrder">The **where_order** query parameter takes one or more values separated by a comma and a space. The result will be ordered by the first value (ascending order is implied; a \&quot;**-**\&quot; in front of the value indicates descending order), then the second value and so on (optional)</param>
        /// <returns>Task of ApiResponse (InlineResponse2002)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<InlineResponse2002>> ListUserIdentitiesAsyncWithHttpInfo (string organizationId, Id userId, int page = default(int), int count = default(int), string whereOrder = default(string))
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling IdentitiesApi->ListUserIdentities");
            // verify the required parameter 'userId' is set
            if (userId == null)
                throw new ApiException(400, "Missing required parameter 'userId' when calling IdentitiesApi->ListUserIdentities");

            var localVarPath = "/{organization-id}/users/{user-id}/wallet";
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
                Exception exception = ExceptionFactory("ListUserIdentities", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2002>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2002) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2002)));
        }

        /// <summary>
        /// Renew an Identity This API allows to renew an Identity of a user. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="enrollmentId">The **enrollment-id** is the uuid code that identifies a specific enrollment request </param>
        /// <param name="inlineObject1"></param>
        /// <returns>InlineResponse2007</returns>
        public InlineResponse2007 RenewIdentity (string organizationId, Id enrollmentId, InlineObject1 inlineObject1)
        {
             ApiResponse<InlineResponse2007> localVarResponse = RenewIdentityWithHttpInfo(organizationId, enrollmentId, inlineObject1);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Renew an Identity This API allows to renew an Identity of a user. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="enrollmentId">The **enrollment-id** is the uuid code that identifies a specific enrollment request </param>
        /// <param name="inlineObject1"></param>
        /// <returns>ApiResponse of InlineResponse2007</returns>
        public ApiResponse<InlineResponse2007> RenewIdentityWithHttpInfo (string organizationId, Id enrollmentId, InlineObject1 inlineObject1)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling IdentitiesApi->RenewIdentity");
            // verify the required parameter 'enrollmentId' is set
            if (enrollmentId == null)
                throw new ApiException(400, "Missing required parameter 'enrollmentId' when calling IdentitiesApi->RenewIdentity");
            // verify the required parameter 'inlineObject1' is set
            if (inlineObject1 == null)
                throw new ApiException(400, "Missing required parameter 'inlineObject1' when calling IdentitiesApi->RenewIdentity");

            var localVarPath = "/{organization-id}/identity-requests/{enrollment-id}/renew";
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
            if (enrollmentId != null) localVarPathParams.Add("enrollment-id", this.Configuration.ApiClient.ParameterToString(enrollmentId)); // path parameter
            if (inlineObject1 != null && inlineObject1.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(inlineObject1); // http body (model) parameter
            }
            else
            {
                localVarPostBody = inlineObject1; // byte array
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
                Exception exception = ExceptionFactory("RenewIdentity", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2007>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2007) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2007)));
        }

        /// <summary>
        /// Renew an Identity This API allows to renew an Identity of a user. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="enrollmentId">The **enrollment-id** is the uuid code that identifies a specific enrollment request </param>
        /// <param name="inlineObject1"></param>
        /// <returns>Task of InlineResponse2007</returns>
        public async System.Threading.Tasks.Task<InlineResponse2007> RenewIdentityAsync (string organizationId, Id enrollmentId, InlineObject1 inlineObject1)
        {
             ApiResponse<InlineResponse2007> localVarResponse = await RenewIdentityAsyncWithHttpInfo(organizationId, enrollmentId, inlineObject1);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Renew an Identity This API allows to renew an Identity of a user. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="enrollmentId">The **enrollment-id** is the uuid code that identifies a specific enrollment request </param>
        /// <param name="inlineObject1"></param>
        /// <returns>Task of ApiResponse (InlineResponse2007)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<InlineResponse2007>> RenewIdentityAsyncWithHttpInfo (string organizationId, Id enrollmentId, InlineObject1 inlineObject1)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling IdentitiesApi->RenewIdentity");
            // verify the required parameter 'enrollmentId' is set
            if (enrollmentId == null)
                throw new ApiException(400, "Missing required parameter 'enrollmentId' when calling IdentitiesApi->RenewIdentity");
            // verify the required parameter 'inlineObject1' is set
            if (inlineObject1 == null)
                throw new ApiException(400, "Missing required parameter 'inlineObject1' when calling IdentitiesApi->RenewIdentity");

            var localVarPath = "/{organization-id}/identity-requests/{enrollment-id}/renew";
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
            if (enrollmentId != null) localVarPathParams.Add("enrollment-id", this.Configuration.ApiClient.ParameterToString(enrollmentId)); // path parameter
            if (inlineObject1 != null && inlineObject1.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(inlineObject1); // http body (model) parameter
            }
            else
            {
                localVarPostBody = inlineObject1; // byte array
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
                Exception exception = ExceptionFactory("RenewIdentity", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2007>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2007) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2007)));
        }

        /// <summary>
        /// Submit an enrollment request This API allows to submit an enrollment request. The user of the request will be created if it does not exists already. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityRequest">The enrollment request to submit</param>
        /// <returns>InlineResponse2007</returns>
        public InlineResponse2007 RequestEnrollment (string organizationId, IdentityRequest identityRequest)
        {
             ApiResponse<InlineResponse2007> localVarResponse = RequestEnrollmentWithHttpInfo(organizationId, identityRequest);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Submit an enrollment request This API allows to submit an enrollment request. The user of the request will be created if it does not exists already. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityRequest">The enrollment request to submit</param>
        /// <returns>ApiResponse of InlineResponse2007</returns>
        public ApiResponse<InlineResponse2007> RequestEnrollmentWithHttpInfo (string organizationId, IdentityRequest identityRequest)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling IdentitiesApi->RequestEnrollment");
            // verify the required parameter 'identityRequest' is set
            if (identityRequest == null)
                throw new ApiException(400, "Missing required parameter 'identityRequest' when calling IdentitiesApi->RequestEnrollment");

            var localVarPath = "/{organization-id}/enroll";
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
            if (identityRequest != null && identityRequest.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(identityRequest); // http body (model) parameter
            }
            else
            {
                localVarPostBody = identityRequest; // byte array
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
                Exception exception = ExceptionFactory("RequestEnrollment", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2007>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2007) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2007)));
        }

        /// <summary>
        /// Submit an enrollment request This API allows to submit an enrollment request. The user of the request will be created if it does not exists already. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityRequest">The enrollment request to submit</param>
        /// <returns>Task of InlineResponse2007</returns>
        public async System.Threading.Tasks.Task<InlineResponse2007> RequestEnrollmentAsync (string organizationId, IdentityRequest identityRequest)
        {
             ApiResponse<InlineResponse2007> localVarResponse = await RequestEnrollmentAsyncWithHttpInfo(organizationId, identityRequest);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Submit an enrollment request This API allows to submit an enrollment request. The user of the request will be created if it does not exists already. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="identityRequest">The enrollment request to submit</param>
        /// <returns>Task of ApiResponse (InlineResponse2007)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<InlineResponse2007>> RequestEnrollmentAsyncWithHttpInfo (string organizationId, IdentityRequest identityRequest)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling IdentitiesApi->RequestEnrollment");
            // verify the required parameter 'identityRequest' is set
            if (identityRequest == null)
                throw new ApiException(400, "Missing required parameter 'identityRequest' when calling IdentitiesApi->RequestEnrollment");

            var localVarPath = "/{organization-id}/enroll";
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
            if (identityRequest != null && identityRequest.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(identityRequest); // http body (model) parameter
            }
            else
            {
                localVarPostBody = identityRequest; // byte array
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
                Exception exception = ExceptionFactory("RequestEnrollment", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2007>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2007) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2007)));
        }

    }
}
