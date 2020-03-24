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
    public interface IOrganizationsApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Get the settings of an oraganization
        /// </summary>
        /// <remarks>
        /// This API allows to obtain the settings of an organization, such as:   - _default_rao_ : the default rao user of the organization   - _dst_default_days_ : default deadline of a dst before its expiration   - _logo_ : the logo of the organization 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <returns>InlineResponse200</returns>
        InlineResponse200 GetOrganization (string organizationId);

        /// <summary>
        /// Get the settings of an oraganization
        /// </summary>
        /// <remarks>
        /// This API allows to obtain the settings of an organization, such as:   - _default_rao_ : the default rao user of the organization   - _dst_default_days_ : default deadline of a dst before its expiration   - _logo_ : the logo of the organization 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <returns>ApiResponse of InlineResponse200</returns>
        ApiResponse<InlineResponse200> GetOrganizationWithHttpInfo (string organizationId);
        /// <summary>
        /// Edit the settings of an organization
        /// </summary>
        /// <remarks>
        /// This API allows to edit every single setting of an organization except the **slug** field. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="updateOrganization">The settings of the organization to edit</param>
        /// <returns>InlineResponse200</returns>
        InlineResponse200 PatchOrganization (string organizationId, UpdateOrganization updateOrganization);

        /// <summary>
        /// Edit the settings of an organization
        /// </summary>
        /// <remarks>
        /// This API allows to edit every single setting of an organization except the **slug** field. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="updateOrganization">The settings of the organization to edit</param>
        /// <returns>ApiResponse of InlineResponse200</returns>
        ApiResponse<InlineResponse200> PatchOrganizationWithHttpInfo (string organizationId, UpdateOrganization updateOrganization);
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// Get the settings of an oraganization
        /// </summary>
        /// <remarks>
        /// This API allows to obtain the settings of an organization, such as:   - _default_rao_ : the default rao user of the organization   - _dst_default_days_ : default deadline of a dst before its expiration   - _logo_ : the logo of the organization 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <returns>Task of InlineResponse200</returns>
        System.Threading.Tasks.Task<InlineResponse200> GetOrganizationAsync (string organizationId);

        /// <summary>
        /// Get the settings of an oraganization
        /// </summary>
        /// <remarks>
        /// This API allows to obtain the settings of an organization, such as:   - _default_rao_ : the default rao user of the organization   - _dst_default_days_ : default deadline of a dst before its expiration   - _logo_ : the logo of the organization 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <returns>Task of ApiResponse (InlineResponse200)</returns>
        System.Threading.Tasks.Task<ApiResponse<InlineResponse200>> GetOrganizationAsyncWithHttpInfo (string organizationId);
        /// <summary>
        /// Edit the settings of an organization
        /// </summary>
        /// <remarks>
        /// This API allows to edit every single setting of an organization except the **slug** field. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="updateOrganization">The settings of the organization to edit</param>
        /// <returns>Task of InlineResponse200</returns>
        System.Threading.Tasks.Task<InlineResponse200> PatchOrganizationAsync (string organizationId, UpdateOrganization updateOrganization);

        /// <summary>
        /// Edit the settings of an organization
        /// </summary>
        /// <remarks>
        /// This API allows to edit every single setting of an organization except the **slug** field. 
        /// </remarks>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="updateOrganization">The settings of the organization to edit</param>
        /// <returns>Task of ApiResponse (InlineResponse200)</returns>
        System.Threading.Tasks.Task<ApiResponse<InlineResponse200>> PatchOrganizationAsyncWithHttpInfo (string organizationId, UpdateOrganization updateOrganization);
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class OrganizationsApi : IOrganizationsApi
    {
        private SigningToday.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrganizationsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public OrganizationsApi(String basePath)
        {
            this.Configuration = new SigningToday.Client.Configuration { BasePath = basePath };

            ExceptionFactory = SigningToday.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrganizationsApi"/> class
        /// </summary>
        /// <returns></returns>
        public OrganizationsApi()
        {
            this.Configuration = SigningToday.Client.Configuration.Default;

            ExceptionFactory = SigningToday.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrganizationsApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public OrganizationsApi(SigningToday.Client.Configuration configuration = null)
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
        /// Get the settings of an oraganization This API allows to obtain the settings of an organization, such as:   - _default_rao_ : the default rao user of the organization   - _dst_default_days_ : default deadline of a dst before its expiration   - _logo_ : the logo of the organization 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <returns>InlineResponse200</returns>
        public InlineResponse200 GetOrganization (string organizationId)
        {
             ApiResponse<InlineResponse200> localVarResponse = GetOrganizationWithHttpInfo(organizationId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get the settings of an oraganization This API allows to obtain the settings of an organization, such as:   - _default_rao_ : the default rao user of the organization   - _dst_default_days_ : default deadline of a dst before its expiration   - _logo_ : the logo of the organization 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <returns>ApiResponse of InlineResponse200</returns>
        public ApiResponse<InlineResponse200> GetOrganizationWithHttpInfo (string organizationId)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling OrganizationsApi->GetOrganization");

            var localVarPath = "/organizations/{organization-id}";
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
                Exception exception = ExceptionFactory("GetOrganization", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse200>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse200) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse200)));
        }

        /// <summary>
        /// Get the settings of an oraganization This API allows to obtain the settings of an organization, such as:   - _default_rao_ : the default rao user of the organization   - _dst_default_days_ : default deadline of a dst before its expiration   - _logo_ : the logo of the organization 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <returns>Task of InlineResponse200</returns>
        public async System.Threading.Tasks.Task<InlineResponse200> GetOrganizationAsync (string organizationId)
        {
             ApiResponse<InlineResponse200> localVarResponse = await GetOrganizationAsyncWithHttpInfo(organizationId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Get the settings of an oraganization This API allows to obtain the settings of an organization, such as:   - _default_rao_ : the default rao user of the organization   - _dst_default_days_ : default deadline of a dst before its expiration   - _logo_ : the logo of the organization 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <returns>Task of ApiResponse (InlineResponse200)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<InlineResponse200>> GetOrganizationAsyncWithHttpInfo (string organizationId)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling OrganizationsApi->GetOrganization");

            var localVarPath = "/organizations/{organization-id}";
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
                Exception exception = ExceptionFactory("GetOrganization", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse200>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse200) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse200)));
        }

        /// <summary>
        /// Edit the settings of an organization This API allows to edit every single setting of an organization except the **slug** field. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="updateOrganization">The settings of the organization to edit</param>
        /// <returns>InlineResponse200</returns>
        public InlineResponse200 PatchOrganization (string organizationId, UpdateOrganization updateOrganization)
        {
             ApiResponse<InlineResponse200> localVarResponse = PatchOrganizationWithHttpInfo(organizationId, updateOrganization);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Edit the settings of an organization This API allows to edit every single setting of an organization except the **slug** field. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="updateOrganization">The settings of the organization to edit</param>
        /// <returns>ApiResponse of InlineResponse200</returns>
        public ApiResponse<InlineResponse200> PatchOrganizationWithHttpInfo (string organizationId, UpdateOrganization updateOrganization)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling OrganizationsApi->PatchOrganization");
            // verify the required parameter 'updateOrganization' is set
            if (updateOrganization == null)
                throw new ApiException(400, "Missing required parameter 'updateOrganization' when calling OrganizationsApi->PatchOrganization");

            var localVarPath = "/organizations/{organization-id}";
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
            if (updateOrganization != null && updateOrganization.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(updateOrganization); // http body (model) parameter
            }
            else
            {
                localVarPostBody = updateOrganization; // byte array
            }

            // authentication (ApiKeyAuth) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = this.Configuration.GetApiKeyWithPrefix("Authorization");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.PATCH, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("PatchOrganization", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse200>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse200) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse200)));
        }

        /// <summary>
        /// Edit the settings of an organization This API allows to edit every single setting of an organization except the **slug** field. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="updateOrganization">The settings of the organization to edit</param>
        /// <returns>Task of InlineResponse200</returns>
        public async System.Threading.Tasks.Task<InlineResponse200> PatchOrganizationAsync (string organizationId, UpdateOrganization updateOrganization)
        {
             ApiResponse<InlineResponse200> localVarResponse = await PatchOrganizationAsyncWithHttpInfo(organizationId, updateOrganization);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Edit the settings of an organization This API allows to edit every single setting of an organization except the **slug** field. 
        /// </summary>
        /// <exception cref="SigningToday.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="organizationId">The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization </param>
        /// <param name="updateOrganization">The settings of the organization to edit</param>
        /// <returns>Task of ApiResponse (InlineResponse200)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<InlineResponse200>> PatchOrganizationAsyncWithHttpInfo (string organizationId, UpdateOrganization updateOrganization)
        {
            // verify the required parameter 'organizationId' is set
            if (organizationId == null)
                throw new ApiException(400, "Missing required parameter 'organizationId' when calling OrganizationsApi->PatchOrganization");
            // verify the required parameter 'updateOrganization' is set
            if (updateOrganization == null)
                throw new ApiException(400, "Missing required parameter 'updateOrganization' when calling OrganizationsApi->PatchOrganization");

            var localVarPath = "/organizations/{organization-id}";
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
            if (updateOrganization != null && updateOrganization.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(updateOrganization); // http body (model) parameter
            }
            else
            {
                localVarPostBody = updateOrganization; // byte array
            }

            // authentication (ApiKeyAuth) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = this.Configuration.GetApiKeyWithPrefix("Authorization");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.PATCH, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("PatchOrganization", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<InlineResponse200>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (InlineResponse200) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse200)));
        }

    }
}
