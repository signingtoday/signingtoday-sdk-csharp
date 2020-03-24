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
    public interface IBit4idPathgroupSignaturesApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Create a channel
        /// </summary>
        /// <remarks>
        /// This API allows to create a channel in order to dispose, by another API, the scheduling of a signature. These two APIs are used to integrate SigningToday into another application. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <returns>InlineResponse2014</returns>
        InlineResponse2014 CreateChannel (string organizationId, Id dstId);

        /// <summary>
        /// Create a channel
        /// </summary>
        /// <remarks>
        /// This API allows to create a channel in order to dispose, by another API, the scheduling of a signature. These two APIs are used to integrate SigningToday into another application. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <returns>ApiResponse of InlineResponse2014</returns>
        ApiResponse<InlineResponse2014> CreateChannelWithHttpInfo (string organizationId, Id dstId);
        /// <summary>
        /// Decline a Digital Signature Transaction
        /// </summary>
        /// <remarks>
        /// This API allows to decline the Signature of a digital signature transaction providing a reason. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="signatureId">The **signature-id** is the uuid code that identifies a signature that has to be performed into a digital signature transaction. It is usually used in the API endpoints to perform, decline or cancel a digital signature transaction </param>
        /// <param name="inlineObject5"></param>
        /// <returns>InlineResponse2013</returns>
        InlineResponse2013 DeclineDST (string organizationId, Id signatureId, InlineObject5 inlineObject5);

        /// <summary>
        /// Decline a Digital Signature Transaction
        /// </summary>
        /// <remarks>
        /// This API allows to decline the Signature of a digital signature transaction providing a reason. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="signatureId">The **signature-id** is the uuid code that identifies a signature that has to be performed into a digital signature transaction. It is usually used in the API endpoints to perform, decline or cancel a digital signature transaction </param>
        /// <param name="inlineObject5"></param>
        /// <returns>ApiResponse of InlineResponse2013</returns>
        ApiResponse<InlineResponse2013> DeclineDSTWithHttpInfo (string organizationId, Id signatureId, InlineObject5 inlineObject5);
        /// <summary>
        /// Sign a DST with an automatic signer
        /// </summary>
        /// <remarks>
        /// This API allows to sign a Digital Signature Transaction with an automatic signer certificate. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="signatureId">The **signature-id** is the uuid code that identifies a signature that has to be performed into a digital signature transaction. It is usually used in the API endpoints to perform, decline or cancel a digital signature transaction </param>
        /// <param name="automaticSignature">Automatic Signature description</param>
        /// <returns>InlineResponse20011</returns>
        InlineResponse20011 PerformDST (string organizationId, Id signatureId, AutomaticSignature automaticSignature);

        /// <summary>
        /// Sign a DST with an automatic signer
        /// </summary>
        /// <remarks>
        /// This API allows to sign a Digital Signature Transaction with an automatic signer certificate. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="signatureId">The **signature-id** is the uuid code that identifies a signature that has to be performed into a digital signature transaction. It is usually used in the API endpoints to perform, decline or cancel a digital signature transaction </param>
        /// <param name="automaticSignature">Automatic Signature description</param>
        /// <returns>ApiResponse of InlineResponse20011</returns>
        ApiResponse<InlineResponse20011> PerformDSTWithHttpInfo (string organizationId, Id signatureId, AutomaticSignature automaticSignature);
        /// <summary>
        /// Perform a Signature
        /// </summary>
        /// <remarks>
        /// This API allows to integrate SigningToday into another application. Through this endpoint it is possible to schedule a signature into engine. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="signatureId">The **signature-id** is the uuid code that identifies a signature that has to be performed into a digital signature transaction. It is usually used in the API endpoints to perform, decline or cancel a digital signature transaction </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <param name="inlineObject3"></param>
        /// <returns>InlineResponse20012</returns>
        InlineResponse20012 PerformSignature (string organizationId, Id signatureId, Id identityId, InlineObject3 inlineObject3);

        /// <summary>
        /// Perform a Signature
        /// </summary>
        /// <remarks>
        /// This API allows to integrate SigningToday into another application. Through this endpoint it is possible to schedule a signature into engine. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="signatureId">The **signature-id** is the uuid code that identifies a signature that has to be performed into a digital signature transaction. It is usually used in the API endpoints to perform, decline or cancel a digital signature transaction </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <param name="inlineObject3"></param>
        /// <returns>ApiResponse of InlineResponse20012</returns>
        ApiResponse<InlineResponse20012> PerformSignatureWithHttpInfo (string organizationId, Id signatureId, Id identityId, InlineObject3 inlineObject3);
        /// <summary>
        /// Perform a Signature with session
        /// </summary>
        /// <remarks>
        /// This API allows to perform one or more signatures within the same session. This way is possible, in the scenario of a simple signature for example, to perform multiple signatures using the same _one time password_. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="signatureId">The **signature-id** is the uuid code that identifies a signature that has to be performed into a digital signature transaction. It is usually used in the API endpoints to perform, decline or cancel a digital signature transaction </param>
        /// <param name="inlineObject4"></param>
        /// <returns>InlineResponse20013</returns>
        InlineResponse20013 PerformSignatureWithSession (string organizationId, Id signatureId, InlineObject4 inlineObject4);

        /// <summary>
        /// Perform a Signature with session
        /// </summary>
        /// <remarks>
        /// This API allows to perform one or more signatures within the same session. This way is possible, in the scenario of a simple signature for example, to perform multiple signatures using the same _one time password_. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="signatureId">The **signature-id** is the uuid code that identifies a signature that has to be performed into a digital signature transaction. It is usually used in the API endpoints to perform, decline or cancel a digital signature transaction </param>
        /// <param name="inlineObject4"></param>
        /// <returns>ApiResponse of InlineResponse20013</returns>
        ApiResponse<InlineResponse20013> PerformSignatureWithSessionWithHttpInfo (string organizationId, Id signatureId, InlineObject4 inlineObject4);
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// Create a channel
        /// </summary>
        /// <remarks>
        /// This API allows to create a channel in order to dispose, by another API, the scheduling of a signature. These two APIs are used to integrate SigningToday into another application. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <returns>Task of InlineResponse2014</returns>
        System.Threading.Tasks.Task<InlineResponse2014> CreateChannelAsync (string organizationId, Id dstId);

        /// <summary>
        /// Create a channel
        /// </summary>
        /// <remarks>
        /// This API allows to create a channel in order to dispose, by another API, the scheduling of a signature. These two APIs are used to integrate SigningToday into another application. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <returns>Task of ApiResponse (InlineResponse2014)</returns>
        System.Threading.Tasks.Task<ApiResponse<InlineResponse2014>> CreateChannelAsyncWithHttpInfo (string organizationId, Id dstId);
        /// <summary>
        /// Decline a Digital Signature Transaction
        /// </summary>
        /// <remarks>
        /// This API allows to decline the Signature of a digital signature transaction providing a reason. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="signatureId">The **signature-id** is the uuid code that identifies a signature that has to be performed into a digital signature transaction. It is usually used in the API endpoints to perform, decline or cancel a digital signature transaction </param>
        /// <param name="inlineObject5"></param>
        /// <returns>Task of InlineResponse2013</returns>
        System.Threading.Tasks.Task<InlineResponse2013> DeclineDSTAsync (string organizationId, Id signatureId, InlineObject5 inlineObject5);

        /// <summary>
        /// Decline a Digital Signature Transaction
        /// </summary>
        /// <remarks>
        /// This API allows to decline the Signature of a digital signature transaction providing a reason. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="signatureId">The **signature-id** is the uuid code that identifies a signature that has to be performed into a digital signature transaction. It is usually used in the API endpoints to perform, decline or cancel a digital signature transaction </param>
        /// <param name="inlineObject5"></param>
        /// <returns>Task of ApiResponse (InlineResponse2013)</returns>
        System.Threading.Tasks.Task<ApiResponse<InlineResponse2013>> DeclineDSTAsyncWithHttpInfo (string organizationId, Id signatureId, InlineObject5 inlineObject5);
        /// <summary>
        /// Sign a DST with an automatic signer
        /// </summary>
        /// <remarks>
        /// This API allows to sign a Digital Signature Transaction with an automatic signer certificate. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="signatureId">The **signature-id** is the uuid code that identifies a signature that has to be performed into a digital signature transaction. It is usually used in the API endpoints to perform, decline or cancel a digital signature transaction </param>
        /// <param name="automaticSignature">Automatic Signature description</param>
        /// <returns>Task of InlineResponse20011</returns>
        System.Threading.Tasks.Task<InlineResponse20011> PerformDSTAsync (string organizationId, Id signatureId, AutomaticSignature automaticSignature);

        /// <summary>
        /// Sign a DST with an automatic signer
        /// </summary>
        /// <remarks>
        /// This API allows to sign a Digital Signature Transaction with an automatic signer certificate. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="signatureId">The **signature-id** is the uuid code that identifies a signature that has to be performed into a digital signature transaction. It is usually used in the API endpoints to perform, decline or cancel a digital signature transaction </param>
        /// <param name="automaticSignature">Automatic Signature description</param>
        /// <returns>Task of ApiResponse (InlineResponse20011)</returns>
        System.Threading.Tasks.Task<ApiResponse<InlineResponse20011>> PerformDSTAsyncWithHttpInfo (string organizationId, Id signatureId, AutomaticSignature automaticSignature);
        /// <summary>
        /// Perform a Signature
        /// </summary>
        /// <remarks>
        /// This API allows to integrate SigningToday into another application. Through this endpoint it is possible to schedule a signature into engine. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="signatureId">The **signature-id** is the uuid code that identifies a signature that has to be performed into a digital signature transaction. It is usually used in the API endpoints to perform, decline or cancel a digital signature transaction </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <param name="inlineObject3"></param>
        /// <returns>Task of InlineResponse20012</returns>
        System.Threading.Tasks.Task<InlineResponse20012> PerformSignatureAsync (string organizationId, Id signatureId, Id identityId, InlineObject3 inlineObject3);

        /// <summary>
        /// Perform a Signature
        /// </summary>
        /// <remarks>
        /// This API allows to integrate SigningToday into another application. Through this endpoint it is possible to schedule a signature into engine. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="signatureId">The **signature-id** is the uuid code that identifies a signature that has to be performed into a digital signature transaction. It is usually used in the API endpoints to perform, decline or cancel a digital signature transaction </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <param name="inlineObject3"></param>
        /// <returns>Task of ApiResponse (InlineResponse20012)</returns>
        System.Threading.Tasks.Task<ApiResponse<InlineResponse20012>> PerformSignatureAsyncWithHttpInfo (string organizationId, Id signatureId, Id identityId, InlineObject3 inlineObject3);
        /// <summary>
        /// Perform a Signature with session
        /// </summary>
        /// <remarks>
        /// This API allows to perform one or more signatures within the same session. This way is possible, in the scenario of a simple signature for example, to perform multiple signatures using the same _one time password_. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="signatureId">The **signature-id** is the uuid code that identifies a signature that has to be performed into a digital signature transaction. It is usually used in the API endpoints to perform, decline or cancel a digital signature transaction </param>
        /// <param name="inlineObject4"></param>
        /// <returns>Task of InlineResponse20013</returns>
        System.Threading.Tasks.Task<InlineResponse20013> PerformSignatureWithSessionAsync (string organizationId, Id signatureId, InlineObject4 inlineObject4);

        /// <summary>
        /// Perform a Signature with session
        /// </summary>
        /// <remarks>
        /// This API allows to perform one or more signatures within the same session. This way is possible, in the scenario of a simple signature for example, to perform multiple signatures using the same _one time password_. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="signatureId">The **signature-id** is the uuid code that identifies a signature that has to be performed into a digital signature transaction. It is usually used in the API endpoints to perform, decline or cancel a digital signature transaction </param>
        /// <param name="inlineObject4"></param>
        /// <returns>Task of ApiResponse (InlineResponse20013)</returns>
        System.Threading.Tasks.Task<ApiResponse<InlineResponse20013>> PerformSignatureWithSessionAsyncWithHttpInfo (string organizationId, Id signatureId, InlineObject4 inlineObject4);
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class Bit4idPathgroupSignaturesApi : IBit4idPathgroupSignaturesApi
    {
        private SigningToday.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="Bit4idPathgroupSignaturesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public Bit4idPathgroupSignaturesApi(String basePath)
        {
            this.Configuration = new SigningToday.Client.Configuration { BasePath = basePath };

            ExceptionFactory = SigningToday.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Bit4idPathgroupSignaturesApi"/> class
        /// </summary>
        /// <returns></returns>
        public Bit4idPathgroupSignaturesApi()
        {
            this.Configuration = SigningToday.Client.Configuration.Default;

            ExceptionFactory = SigningToday.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Bit4idPathgroupSignaturesApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public Bit4idPathgroupSignaturesApi(SigningToday.Client.Configuration configuration = null)
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
        /// Create a channel This API allows to create a channel in order to dispose, by another API, the scheduling of a signature. These two APIs are used to integrate SigningToday into another application. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <returns>InlineResponse2014</returns>
        public InlineResponse2014 CreateChannel (string organizationId, Id dstId)
        {
             ApiResponse<InlineResponse2014> localVarResponse = CreateChannelWithHttpInfo(organizationId, dstId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Create a channel This API allows to create a channel in order to dispose, by another API, the scheduling of a signature. These two APIs are used to integrate SigningToday into another application. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <returns>ApiResponse of InlineResponse2014</returns>
        public ApiResponse<InlineResponse2014> CreateChannelWithHttpInfo (string organizationId, Id dstId)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling Bit4idPathgroupSignaturesApi->CreateChannel");
            // verify the required parameter 'dstId' is set
            if (dstId == null)
                throw new ApiException(400, "Missing required parameter 'dstId' when calling Bit4idPathgroupSignaturesApi->CreateChannel");

            var localVarPath = "/{organization-id}/channels/{dst-id}";
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
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("CreateChannel", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2014>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2014) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2014)));
        }

        /// <summary>
        /// Create a channel This API allows to create a channel in order to dispose, by another API, the scheduling of a signature. These two APIs are used to integrate SigningToday into another application. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <returns>Task of InlineResponse2014</returns>
        public async System.Threading.Tasks.Task<InlineResponse2014> CreateChannelAsync (string organizationId, Id dstId)
        {
             ApiResponse<InlineResponse2014> localVarResponse = await CreateChannelAsyncWithHttpInfo(organizationId, dstId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Create a channel This API allows to create a channel in order to dispose, by another API, the scheduling of a signature. These two APIs are used to integrate SigningToday into another application. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="dstId">The **dst-id** is the uuid code that identifies a digital signature transaction. It is used as a path parameter to filter the requested operation to the specified **dst** </param>
        /// <returns>Task of ApiResponse (InlineResponse2014)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<InlineResponse2014>> CreateChannelAsyncWithHttpInfo (string organizationId, Id dstId)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling Bit4idPathgroupSignaturesApi->CreateChannel");
            // verify the required parameter 'dstId' is set
            if (dstId == null)
                throw new ApiException(400, "Missing required parameter 'dstId' when calling Bit4idPathgroupSignaturesApi->CreateChannel");

            var localVarPath = "/{organization-id}/channels/{dst-id}";
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
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("CreateChannel", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2014>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2014) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2014)));
        }

        /// <summary>
        /// Decline a Digital Signature Transaction This API allows to decline the Signature of a digital signature transaction providing a reason. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="signatureId">The **signature-id** is the uuid code that identifies a signature that has to be performed into a digital signature transaction. It is usually used in the API endpoints to perform, decline or cancel a digital signature transaction </param>
        /// <param name="inlineObject5"></param>
        /// <returns>InlineResponse2013</returns>
        public InlineResponse2013 DeclineDST (string organizationId, Id signatureId, InlineObject5 inlineObject5)
        {
             ApiResponse<InlineResponse2013> localVarResponse = DeclineDSTWithHttpInfo(organizationId, signatureId, inlineObject5);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Decline a Digital Signature Transaction This API allows to decline the Signature of a digital signature transaction providing a reason. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="signatureId">The **signature-id** is the uuid code that identifies a signature that has to be performed into a digital signature transaction. It is usually used in the API endpoints to perform, decline or cancel a digital signature transaction </param>
        /// <param name="inlineObject5"></param>
        /// <returns>ApiResponse of InlineResponse2013</returns>
        public ApiResponse<InlineResponse2013> DeclineDSTWithHttpInfo (string organizationId, Id signatureId, InlineObject5 inlineObject5)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling Bit4idPathgroupSignaturesApi->DeclineDST");
            // verify the required parameter 'signatureId' is set
            if (signatureId == null)
                throw new ApiException(400, "Missing required parameter 'signatureId' when calling Bit4idPathgroupSignaturesApi->DeclineDST");
            // verify the required parameter 'inlineObject5' is set
            if (inlineObject5 == null)
                throw new ApiException(400, "Missing required parameter 'inlineObject5' when calling Bit4idPathgroupSignaturesApi->DeclineDST");

            var localVarPath = "/{organization-id}/signatures/{signature-id}/decline";
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
            if (signatureId != null) localVarPathParams.Add("signature-id", this.Configuration.ApiClient.ParameterToString(signatureId)); // path parameter
            if (inlineObject5 != null && inlineObject5.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(inlineObject5); // http body (model) parameter
            }
            else
            {
                localVarPostBody = inlineObject5; // byte array
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
                Exception exception = ExceptionFactory("DeclineDST", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2013>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2013) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2013)));
        }

        /// <summary>
        /// Decline a Digital Signature Transaction This API allows to decline the Signature of a digital signature transaction providing a reason. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="signatureId">The **signature-id** is the uuid code that identifies a signature that has to be performed into a digital signature transaction. It is usually used in the API endpoints to perform, decline or cancel a digital signature transaction </param>
        /// <param name="inlineObject5"></param>
        /// <returns>Task of InlineResponse2013</returns>
        public async System.Threading.Tasks.Task<InlineResponse2013> DeclineDSTAsync (string organizationId, Id signatureId, InlineObject5 inlineObject5)
        {
             ApiResponse<InlineResponse2013> localVarResponse = await DeclineDSTAsyncWithHttpInfo(organizationId, signatureId, inlineObject5);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Decline a Digital Signature Transaction This API allows to decline the Signature of a digital signature transaction providing a reason. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="signatureId">The **signature-id** is the uuid code that identifies a signature that has to be performed into a digital signature transaction. It is usually used in the API endpoints to perform, decline or cancel a digital signature transaction </param>
        /// <param name="inlineObject5"></param>
        /// <returns>Task of ApiResponse (InlineResponse2013)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<InlineResponse2013>> DeclineDSTAsyncWithHttpInfo (string organizationId, Id signatureId, InlineObject5 inlineObject5)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling Bit4idPathgroupSignaturesApi->DeclineDST");
            // verify the required parameter 'signatureId' is set
            if (signatureId == null)
                throw new ApiException(400, "Missing required parameter 'signatureId' when calling Bit4idPathgroupSignaturesApi->DeclineDST");
            // verify the required parameter 'inlineObject5' is set
            if (inlineObject5 == null)
                throw new ApiException(400, "Missing required parameter 'inlineObject5' when calling Bit4idPathgroupSignaturesApi->DeclineDST");

            var localVarPath = "/{organization-id}/signatures/{signature-id}/decline";
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
            if (signatureId != null) localVarPathParams.Add("signature-id", this.Configuration.ApiClient.ParameterToString(signatureId)); // path parameter
            if (inlineObject5 != null && inlineObject5.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(inlineObject5); // http body (model) parameter
            }
            else
            {
                localVarPostBody = inlineObject5; // byte array
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
                Exception exception = ExceptionFactory("DeclineDST", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse2013>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse2013) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse2013)));
        }

        /// <summary>
        /// Sign a DST with an automatic signer This API allows to sign a Digital Signature Transaction with an automatic signer certificate. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="signatureId">The **signature-id** is the uuid code that identifies a signature that has to be performed into a digital signature transaction. It is usually used in the API endpoints to perform, decline or cancel a digital signature transaction </param>
        /// <param name="automaticSignature">Automatic Signature description</param>
        /// <returns>InlineResponse20011</returns>
        public InlineResponse20011 PerformDST (string organizationId, Id signatureId, AutomaticSignature automaticSignature)
        {
             ApiResponse<InlineResponse20011> localVarResponse = PerformDSTWithHttpInfo(organizationId, signatureId, automaticSignature);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Sign a DST with an automatic signer This API allows to sign a Digital Signature Transaction with an automatic signer certificate. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="signatureId">The **signature-id** is the uuid code that identifies a signature that has to be performed into a digital signature transaction. It is usually used in the API endpoints to perform, decline or cancel a digital signature transaction </param>
        /// <param name="automaticSignature">Automatic Signature description</param>
        /// <returns>ApiResponse of InlineResponse20011</returns>
        public ApiResponse<InlineResponse20011> PerformDSTWithHttpInfo (string organizationId, Id signatureId, AutomaticSignature automaticSignature)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling Bit4idPathgroupSignaturesApi->PerformDST");
            // verify the required parameter 'signatureId' is set
            if (signatureId == null)
                throw new ApiException(400, "Missing required parameter 'signatureId' when calling Bit4idPathgroupSignaturesApi->PerformDST");
            // verify the required parameter 'automaticSignature' is set
            if (automaticSignature == null)
                throw new ApiException(400, "Missing required parameter 'automaticSignature' when calling Bit4idPathgroupSignaturesApi->PerformDST");

            var localVarPath = "/{organization-id}/signatures/{signature-id}/perform";
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
            if (signatureId != null) localVarPathParams.Add("signature-id", this.Configuration.ApiClient.ParameterToString(signatureId)); // path parameter
            if (automaticSignature != null && automaticSignature.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(automaticSignature); // http body (model) parameter
            }
            else
            {
                localVarPostBody = automaticSignature; // byte array
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
                Exception exception = ExceptionFactory("PerformDST", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse20011>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse20011) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse20011)));
        }

        /// <summary>
        /// Sign a DST with an automatic signer This API allows to sign a Digital Signature Transaction with an automatic signer certificate. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="signatureId">The **signature-id** is the uuid code that identifies a signature that has to be performed into a digital signature transaction. It is usually used in the API endpoints to perform, decline or cancel a digital signature transaction </param>
        /// <param name="automaticSignature">Automatic Signature description</param>
        /// <returns>Task of InlineResponse20011</returns>
        public async System.Threading.Tasks.Task<InlineResponse20011> PerformDSTAsync (string organizationId, Id signatureId, AutomaticSignature automaticSignature)
        {
             ApiResponse<InlineResponse20011> localVarResponse = await PerformDSTAsyncWithHttpInfo(organizationId, signatureId, automaticSignature);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Sign a DST with an automatic signer This API allows to sign a Digital Signature Transaction with an automatic signer certificate. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="signatureId">The **signature-id** is the uuid code that identifies a signature that has to be performed into a digital signature transaction. It is usually used in the API endpoints to perform, decline or cancel a digital signature transaction </param>
        /// <param name="automaticSignature">Automatic Signature description</param>
        /// <returns>Task of ApiResponse (InlineResponse20011)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<InlineResponse20011>> PerformDSTAsyncWithHttpInfo (string organizationId, Id signatureId, AutomaticSignature automaticSignature)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling Bit4idPathgroupSignaturesApi->PerformDST");
            // verify the required parameter 'signatureId' is set
            if (signatureId == null)
                throw new ApiException(400, "Missing required parameter 'signatureId' when calling Bit4idPathgroupSignaturesApi->PerformDST");
            // verify the required parameter 'automaticSignature' is set
            if (automaticSignature == null)
                throw new ApiException(400, "Missing required parameter 'automaticSignature' when calling Bit4idPathgroupSignaturesApi->PerformDST");

            var localVarPath = "/{organization-id}/signatures/{signature-id}/perform";
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
            if (signatureId != null) localVarPathParams.Add("signature-id", this.Configuration.ApiClient.ParameterToString(signatureId)); // path parameter
            if (automaticSignature != null && automaticSignature.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(automaticSignature); // http body (model) parameter
            }
            else
            {
                localVarPostBody = automaticSignature; // byte array
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
                Exception exception = ExceptionFactory("PerformDST", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse20011>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse20011) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse20011)));
        }

        /// <summary>
        /// Perform a Signature This API allows to integrate SigningToday into another application. Through this endpoint it is possible to schedule a signature into engine. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="signatureId">The **signature-id** is the uuid code that identifies a signature that has to be performed into a digital signature transaction. It is usually used in the API endpoints to perform, decline or cancel a digital signature transaction </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <param name="inlineObject3"></param>
        /// <returns>InlineResponse20012</returns>
        public InlineResponse20012 PerformSignature (string organizationId, Id signatureId, Id identityId, InlineObject3 inlineObject3)
        {
             ApiResponse<InlineResponse20012> localVarResponse = PerformSignatureWithHttpInfo(organizationId, signatureId, identityId, inlineObject3);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Perform a Signature This API allows to integrate SigningToday into another application. Through this endpoint it is possible to schedule a signature into engine. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="signatureId">The **signature-id** is the uuid code that identifies a signature that has to be performed into a digital signature transaction. It is usually used in the API endpoints to perform, decline or cancel a digital signature transaction </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <param name="inlineObject3"></param>
        /// <returns>ApiResponse of InlineResponse20012</returns>
        public ApiResponse<InlineResponse20012> PerformSignatureWithHttpInfo (string organizationId, Id signatureId, Id identityId, InlineObject3 inlineObject3)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling Bit4idPathgroupSignaturesApi->PerformSignature");
            // verify the required parameter 'signatureId' is set
            if (signatureId == null)
                throw new ApiException(400, "Missing required parameter 'signatureId' when calling Bit4idPathgroupSignaturesApi->PerformSignature");
            // verify the required parameter 'identityId' is set
            if (identityId == null)
                throw new ApiException(400, "Missing required parameter 'identityId' when calling Bit4idPathgroupSignaturesApi->PerformSignature");
            // verify the required parameter 'inlineObject3' is set
            if (inlineObject3 == null)
                throw new ApiException(400, "Missing required parameter 'inlineObject3' when calling Bit4idPathgroupSignaturesApi->PerformSignature");

            var localVarPath = "/{organization-id}/signatures/{signature-id}/perform/{identity-id}";
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
            if (signatureId != null) localVarPathParams.Add("signature-id", this.Configuration.ApiClient.ParameterToString(signatureId)); // path parameter
            if (identityId != null) localVarPathParams.Add("identity-id", this.Configuration.ApiClient.ParameterToString(identityId)); // path parameter
            if (inlineObject3 != null && inlineObject3.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(inlineObject3); // http body (model) parameter
            }
            else
            {
                localVarPostBody = inlineObject3; // byte array
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
                Exception exception = ExceptionFactory("PerformSignature", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse20012>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse20012) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse20012)));
        }

        /// <summary>
        /// Perform a Signature This API allows to integrate SigningToday into another application. Through this endpoint it is possible to schedule a signature into engine. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="signatureId">The **signature-id** is the uuid code that identifies a signature that has to be performed into a digital signature transaction. It is usually used in the API endpoints to perform, decline or cancel a digital signature transaction </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <param name="inlineObject3"></param>
        /// <returns>Task of InlineResponse20012</returns>
        public async System.Threading.Tasks.Task<InlineResponse20012> PerformSignatureAsync (string organizationId, Id signatureId, Id identityId, InlineObject3 inlineObject3)
        {
             ApiResponse<InlineResponse20012> localVarResponse = await PerformSignatureAsyncWithHttpInfo(organizationId, signatureId, identityId, inlineObject3);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Perform a Signature This API allows to integrate SigningToday into another application. Through this endpoint it is possible to schedule a signature into engine. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="signatureId">The **signature-id** is the uuid code that identifies a signature that has to be performed into a digital signature transaction. It is usually used in the API endpoints to perform, decline or cancel a digital signature transaction </param>
        /// <param name="identityId">The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity </param>
        /// <param name="inlineObject3"></param>
        /// <returns>Task of ApiResponse (InlineResponse20012)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<InlineResponse20012>> PerformSignatureAsyncWithHttpInfo (string organizationId, Id signatureId, Id identityId, InlineObject3 inlineObject3)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling Bit4idPathgroupSignaturesApi->PerformSignature");
            // verify the required parameter 'signatureId' is set
            if (signatureId == null)
                throw new ApiException(400, "Missing required parameter 'signatureId' when calling Bit4idPathgroupSignaturesApi->PerformSignature");
            // verify the required parameter 'identityId' is set
            if (identityId == null)
                throw new ApiException(400, "Missing required parameter 'identityId' when calling Bit4idPathgroupSignaturesApi->PerformSignature");
            // verify the required parameter 'inlineObject3' is set
            if (inlineObject3 == null)
                throw new ApiException(400, "Missing required parameter 'inlineObject3' when calling Bit4idPathgroupSignaturesApi->PerformSignature");

            var localVarPath = "/{organization-id}/signatures/{signature-id}/perform/{identity-id}";
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
            if (signatureId != null) localVarPathParams.Add("signature-id", this.Configuration.ApiClient.ParameterToString(signatureId)); // path parameter
            if (identityId != null) localVarPathParams.Add("identity-id", this.Configuration.ApiClient.ParameterToString(identityId)); // path parameter
            if (inlineObject3 != null && inlineObject3.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(inlineObject3); // http body (model) parameter
            }
            else
            {
                localVarPostBody = inlineObject3; // byte array
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
                Exception exception = ExceptionFactory("PerformSignature", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse20012>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse20012) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse20012)));
        }

        /// <summary>
        /// Perform a Signature with session This API allows to perform one or more signatures within the same session. This way is possible, in the scenario of a simple signature for example, to perform multiple signatures using the same _one time password_. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="signatureId">The **signature-id** is the uuid code that identifies a signature that has to be performed into a digital signature transaction. It is usually used in the API endpoints to perform, decline or cancel a digital signature transaction </param>
        /// <param name="inlineObject4"></param>
        /// <returns>InlineResponse20013</returns>
        public InlineResponse20013 PerformSignatureWithSession (string organizationId, Id signatureId, InlineObject4 inlineObject4)
        {
             ApiResponse<InlineResponse20013> localVarResponse = PerformSignatureWithSessionWithHttpInfo(organizationId, signatureId, inlineObject4);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Perform a Signature with session This API allows to perform one or more signatures within the same session. This way is possible, in the scenario of a simple signature for example, to perform multiple signatures using the same _one time password_. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="signatureId">The **signature-id** is the uuid code that identifies a signature that has to be performed into a digital signature transaction. It is usually used in the API endpoints to perform, decline or cancel a digital signature transaction </param>
        /// <param name="inlineObject4"></param>
        /// <returns>ApiResponse of InlineResponse20013</returns>
        public ApiResponse<InlineResponse20013> PerformSignatureWithSessionWithHttpInfo (string organizationId, Id signatureId, InlineObject4 inlineObject4)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling Bit4idPathgroupSignaturesApi->PerformSignatureWithSession");
            // verify the required parameter 'signatureId' is set
            if (signatureId == null)
                throw new ApiException(400, "Missing required parameter 'signatureId' when calling Bit4idPathgroupSignaturesApi->PerformSignatureWithSession");
            // verify the required parameter 'inlineObject4' is set
            if (inlineObject4 == null)
                throw new ApiException(400, "Missing required parameter 'inlineObject4' when calling Bit4idPathgroupSignaturesApi->PerformSignatureWithSession");

            var localVarPath = "/{organization-id}/signatures/{signature-id}/session-perform";
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
            if (signatureId != null) localVarPathParams.Add("signature-id", this.Configuration.ApiClient.ParameterToString(signatureId)); // path parameter
            if (inlineObject4 != null && inlineObject4.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(inlineObject4); // http body (model) parameter
            }
            else
            {
                localVarPostBody = inlineObject4; // byte array
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
                Exception exception = ExceptionFactory("PerformSignatureWithSession", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse20013>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse20013) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse20013)));
        }

        /// <summary>
        /// Perform a Signature with session This API allows to perform one or more signatures within the same session. This way is possible, in the scenario of a simple signature for example, to perform multiple signatures using the same _one time password_. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="signatureId">The **signature-id** is the uuid code that identifies a signature that has to be performed into a digital signature transaction. It is usually used in the API endpoints to perform, decline or cancel a digital signature transaction </param>
        /// <param name="inlineObject4"></param>
        /// <returns>Task of InlineResponse20013</returns>
        public async System.Threading.Tasks.Task<InlineResponse20013> PerformSignatureWithSessionAsync (string organizationId, Id signatureId, InlineObject4 inlineObject4)
        {
             ApiResponse<InlineResponse20013> localVarResponse = await PerformSignatureWithSessionAsyncWithHttpInfo(organizationId, signatureId, inlineObject4);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Perform a Signature with session This API allows to perform one or more signatures within the same session. This way is possible, in the scenario of a simple signature for example, to perform multiple signatures using the same _one time password_. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="signatureId">The **signature-id** is the uuid code that identifies a signature that has to be performed into a digital signature transaction. It is usually used in the API endpoints to perform, decline or cancel a digital signature transaction </param>
        /// <param name="inlineObject4"></param>
        /// <returns>Task of ApiResponse (InlineResponse20013)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<InlineResponse20013>> PerformSignatureWithSessionAsyncWithHttpInfo (string organizationId, Id signatureId, InlineObject4 inlineObject4)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling Bit4idPathgroupSignaturesApi->PerformSignatureWithSession");
            // verify the required parameter 'signatureId' is set
            if (signatureId == null)
                throw new ApiException(400, "Missing required parameter 'signatureId' when calling Bit4idPathgroupSignaturesApi->PerformSignatureWithSession");
            // verify the required parameter 'inlineObject4' is set
            if (inlineObject4 == null)
                throw new ApiException(400, "Missing required parameter 'inlineObject4' when calling Bit4idPathgroupSignaturesApi->PerformSignatureWithSession");

            var localVarPath = "/{organization-id}/signatures/{signature-id}/session-perform";
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
            if (signatureId != null) localVarPathParams.Add("signature-id", this.Configuration.ApiClient.ParameterToString(signatureId)); // path parameter
            if (inlineObject4 != null && inlineObject4.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(inlineObject4); // http body (model) parameter
            }
            else
            {
                localVarPostBody = inlineObject4; // byte array
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
                Exception exception = ExceptionFactory("PerformSignatureWithSession", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse20013>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse20013) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse20013)));
        }

    }
}
