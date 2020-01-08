# SigningToday - the C# library for the Signing Today API
*Signing Today* enables seamless integration of digital signatures into any
website by the use of easy requests to our API. This is the smart way of
adding digital signature support with a great user experience.


*Signing Today APIs* use HTTP methods and are RESTful based, moreover they
are protected by a *server to server authentication* standard by the use of
tokens.


*Signing Today APIs* can be used in these environments:


| Environment | Description | Endpoint |
| ----------- | ----------- | -------- |
| Sandbox     | Test environment | `https://sandbox.signingtoday.com` |
| Live        | Production environment | `https://api.signingtoday.com` |


For every single request to Signing Today has to be defined the following
*HTTP* header:
- `Authorization`, which contains the authentication token.

If the request has a body than another *HTTP* header is requested:
- `Content-Type`, with `application/json` value.


Follows an example of usage to enumerate all the user of *my-org*
organization.

**Example**

```json
$ curl https://sandbox.signingtoday.com/api/v1/my-org/users \
    -H 'Authorization: Token <access-token>'
```

## HTTP methods used

APIs use the right HTTP verb in every situation.

| Method   | Description                    |
| -------- | ------------------------------ |
| `GET`    | Request data from a resource   |
| `POST`   | Send data to create a resource |
| `PUT`    | Update a resource              |
| `PATCH`  | Partially update a resource    |
| `DELETE` | Delete a resourse              |


## Response definition

All the response are in JSON format.
As response to a request of all users of an organization you will have a
result like this:

```json
{
    "pagination": {
      "count": 75,
      "previous": "https://sandbox.signingtoday.com/api/v1/my-org/users?page=1",
      "next": "https://sandbox.signingtoday.com/api/v1/my-org/users?page=3",
      "pages": 8,
      "page": 2
    },
    "meta": {
      "code": 200
    },
    "data": [
      {
        "id": "jdo",
        "status": "enabled",
        "type": "Basic user account",
        "email": johndoe@dummyemail.com,
        "first_name": "John",
        "last_name": "Doe",
        "wallet": [],
        "created_by": "system",
        "owner": false,
        "automatic": false,
        "rao": false
      },
      ...
    ]
  }
```

The JSON of the response is made of three parts:
- Pagination
- Meta
- Data

### Pagination

*Pagination* object allows to split the response into parts and then to
rebuild it sequentially by the use of `next` and `previous` parameters, by
which you get previous and following blocks. The *Pagination* is present
only if the response is a list of objects.

The general structure of *Pagination* object is the following:

```json
{
    "pagination": {
      "count": 75,
      "previous": "https://sandbox.signingtoday.com/api/v1/my-org/users?page=1",
      "next": "https://sandbox.signingtoday.com/api/v1/my-org/users?page=3",
      "pages": 8,
      "page": 2
    },
    ...
  }
```

### Meta

*Meta* object is used to enrich the information about the response. In the
previous example, a successful case of response, *Meta* will have value
`status: 2XX`. In case of unsuccessful response, *Meta* will have further
information, as follows:

```json
{
    "meta": {
      "code": <HTTP STATUS CODE>,
      "error_type": <STATUS CODE DESCRIPTION>,
      "error_message": <ERROR DESCRIPTION>
    }
  }
```

### Data

*Data* object outputs as object or list of them. Contains the expected data
as requested to the API.

## Search filters

Search filters of the API have the following structure:

`where_ATTRIBUTENAME`=`VALUE`

In this way you make a case-sensitive search of *VALUE*. You can extend it
through the Django lookup, obtaining more specific filters. For example:

`where_ATTRIBUTENAME__LOOKUP`=`VALUE`

where *LOOKUP* can be replaced with `icontains` to have a partial insensitive
research, where

`where_first_name__icontains`=`CHa`

matches with every user that have the *cha* string in their name, with
no differences between capital and lower cases.

[Here](https://docs.djangoproject.com/en/1.11/ref/models/querysets/#field-lookups)
the list of the lookups.

## Webhooks

Signing Today supports webhooks for the update of DSTs and identities status.
You can choose if to use or not webhooks and if you want to receive updates
about DSTs and/or identities. You can configurate it on application token
level, in the *webhook* field, as follows:

```json
"webhooks": {
  "dst": "URL",
  "identity": "URL"
  }
```

### DSTs status update

DSTs send the following status updates:
- **DST_STATUS_CHANGED**: whenever the DST changes its status
- **SIGNATURE_STATUS_CHANGED**: whenever one of the signatures changes its
status

#### DST_STATUS_CHANGED

Sends the following information:

```json
{
    "message": "DST_STATUS_CHANGED",
    "data": {
      "status": "<DST_STATUS>",
      "dst": "<DST_ID>",
      "reason": "<DST_REASON>"
    }
  }
```

#### SIGNATURE_STATUS_CHANGED

Sends the following information:

```json
{
    "message": "SIGNATURE_STATUS_CHANGED",
    "data": {
      "status": "<SIGNATURE_STATUS>",
      "group": <MEMBERSHIP_GROUP_INDEX>,
      "dst": {
        "id": "<DST_ID>",
        "title": "<DST_TITLE>"
      },
      "signature": "<SIGNATURE_ID>",
      "signer": "<SIGNER_USERNAME>",
      "position": "<SIGNATURE_POSITION>",
      "document": {
        "display_name": "<DOCUMENT_TITLE>",
        "id": "<DOCUMENT_ID>",
        "order": <DOCUMENT_INDEX>
      },
      "automatic": <DECLARES_IF_THE_SIGNER_IS_AUTOMATIC>,
      "page": "<SIGNATURE_PAGE>"
    }
  }
```

### Identities status update

Identities send the following status updates:
- **IDENTITY_REQUEST_ENROLLED**: whenever an identity request is activated

#### IDENTITY_REQUEST_ENROLLED

Sends the following information:

```json
{
    "message": "IDENTITY_REQUEST_ENROLLED",
    "data": {
      "status": "<REQUEST_STATUS>",
      "request": "<REQUEST_ID>",
      "user": "<APPLICANT_USERNAME>"
    }
  }
```

### Urlback

Sometimes may be necessary to make a redirect after an user, from the
signature tray, has completed his operations or activated a certificate.

If set, redirects could happen in 3 cases:
- after a signature or decline
- after a DST has been signed by all the signers or canceled
- after the activation of a certificate

In the first two cases the urlback returns the following information through
a data form:
- **dst-id**: id of the DST
- **dst-url**: signature_ticket of the signature
- **dst-status**: current status of the DST
- **dst-signature-id**: id of the signature
- **dst-signature-status**: current status of the signature
- **user**: username of the signer
- **decline-reason**: in case of a refused DST contains the reason of the
decline

In the last case the urlback returns the following information through a
data form:
- **user**: username of the user activated the certificate
- **identity-provider**: the provider has been used to issue the certificate
- **identity-request-id**: id of the enrollment request
- **identity-id**: id of the new identity
- **identity-label**: the label assigned to the identity
- **identity-certificate**: public key of the certificate


This C# SDK is automatically generated by the [OpenAPI Generator](https://openapi-generator.tech) project:
- API version: 1.5.0
- SDK version: 1.0.0
- Build package: org.openapitools.codegen.languages.CSharpClientCodegen
    For more information, please visit [https://signing.today/contacts/](https://signing.today/contacts/)
## Frameworks supported
- .NET 4.0 or later
- Windows Phone 7.1 (Mango)
## Dependencies
- [RestSharp](https://www.nuget.org/packages/RestSharp) - 105.1.0 or later
- [Json.NET](https://www.nuget.org/packages/Newtonsoft.Json/) - 7.0.0 or later
- [JsonSubTypes](https://www.nuget.org/packages/JsonSubTypes/) - 1.2.0 or later
The DLLs included in the package may not be the latest version. We recommend using [NuGet](https://docs.nuget.org/consume/installing-nuget) to obtain the latest version of the packages:
```
Install-Package RestSharp
Install-Package Newtonsoft.Json
Install-Package JsonSubTypes
```
NOTE: RestSharp versions greater than 105.1.0 have a bug which causes file uploads to fail. See [RestSharp#742](https://github.com/restsharp/RestSharp/issues/742)
## Installation
Run the following command to generate the DLL
- [Mac/Linux] `/bin/sh build.sh`
- [Windows] `build.bat`
Then include the DLL (under the `bin` folder) in the C# project, and use the namespaces:
```csharp
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;
```
## Packaging
A `.nuspec` is included with the project. You can follow the Nuget quickstart to [create](https://docs.microsoft.com/en-us/nuget/quickstart/create-and-publish-a-package#create-the-package) and [publish](https://docs.microsoft.com/en-us/nuget/quickstart/create-and-publish-a-package#publish-the-package) packages.
This `.nuspec` uses placeholders from the `.csproj`, so build the `.csproj` directly:
```
nuget pack -Build -OutputDirectory out SigningToday.csproj
```
Then, publish to a [local feed](https://docs.microsoft.com/en-us/nuget/hosting-packages/local-feeds) or [other host](https://docs.microsoft.com/en-us/nuget/hosting-packages/overview) and consume the new package via Nuget as usual.
## Getting Started
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using SigningToday.Api;
using SigningToday.Client;
using SigningToday.Model;
namespace Example
{
    public class Example
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://sandbox.signingtoday.com/api/v1";
            // Configure API key authorization: ApiKeyAuth
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");
            var apiInstance = new Bit4idPathgroupIdentitiesApi(Configuration.Default);
            var organizationId = api-demo;  // string | The **organization-id** represents an organization that is included in the SigninToday application, also know as **slug** and it is used as a path parameter to restrict the asked functionality to the specified organization  (default to "api-demo")
            var identityId = new Id(); // Id | The **identity-id** is the uuid code that identifies an identity in the wallet of an user. It is, as well, used to restrict the requested operation to the scope of that identity 
            var inlineObject = new InlineObject(); // InlineObject | 
            try
            {
                // Associate an appearance to an identity
                InlineResponse2004 result = apiInstance.AssociateAppearance(organizationId, identityId, inlineObject);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling Bit4idPathgroupIdentitiesApi.AssociateAppearance: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```
## Documentation for API Endpoints
All URIs are relative to *https://sandbox.signingtoday.com/api/v1*
Class | Method | HTTP request | Description
------------ | ------------- | ------------- | -------------
*Bit4idPathgroupIdentitiesApi* | [**AssociateAppearance**](docs/Bit4idPathgroupIdentitiesApi.md#associateappearance) | **POST** /{organization-id}/identities/{identity-id}/appearance | Associate an appearance to an identity
*Bit4idPathgroupIdentitiesApi* | [**AssociateIdentity**](docs/Bit4idPathgroupIdentitiesApi.md#associateidentity) | **POST** /{organization-id}/users/{user-id}/wallet | Associate to an user an already existing identity
*Bit4idPathgroupIdentitiesApi* | [**CreateTokenFromIdentity**](docs/Bit4idPathgroupIdentitiesApi.md#createtokenfromidentity) | **POST** /{organization-id}/identities/create/token | Create an identity from token
*Bit4idPathgroupIdentitiesApi* | [**DeleteAppearance**](docs/Bit4idPathgroupIdentitiesApi.md#deleteappearance) | **DELETE** /{organization-id}/identities/{identity-id}/appearance | Delete the appearance of an identity
*Bit4idPathgroupIdentitiesApi* | [**DeleteEnrollmentRequest**](docs/Bit4idPathgroupIdentitiesApi.md#deleteenrollmentrequest) | **DELETE** /{organization-id}/identity-requests/{enrollment-id} | Delete an enrollment request
*Bit4idPathgroupIdentitiesApi* | [**DeleteIdentity**](docs/Bit4idPathgroupIdentitiesApi.md#deleteidentity) | **DELETE** /{organization-id}/identities/{identity-id} | Delete an identity
*Bit4idPathgroupIdentitiesApi* | [**GetEnrollmentRequest**](docs/Bit4idPathgroupIdentitiesApi.md#getenrollmentrequest) | **GET** /{organization-id}/identity-requests/{enrollment-id} | Get information about an enrollment request
*Bit4idPathgroupIdentitiesApi* | [**GetIdentity**](docs/Bit4idPathgroupIdentitiesApi.md#getidentity) | **GET** /{organization-id}/identities/{identity-id} | Get information about an identity
*Bit4idPathgroupIdentitiesApi* | [**ListEnrollmentRequests**](docs/Bit4idPathgroupIdentitiesApi.md#listenrollmentrequests) | **GET** /{organization-id}/identity-requests | Enumerate the enrollment requests of an organization
*Bit4idPathgroupIdentitiesApi* | [**ListIdentities**](docs/Bit4idPathgroupIdentitiesApi.md#listidentities) | **GET** /{organization-id}/identities | Enumerate the identities of an organization
*Bit4idPathgroupIdentitiesApi* | [**ListUserEnrollments**](docs/Bit4idPathgroupIdentitiesApi.md#listuserenrollments) | **GET** /{organization-id}/users/{user-id}/identity-requests | List the enrollments of an user
*Bit4idPathgroupIdentitiesApi* | [**ListUserIdentities**](docs/Bit4idPathgroupIdentitiesApi.md#listuseridentities) | **GET** /{organization-id}/users/{user-id}/wallet | Enumerate the identities of an user
*Bit4idPathgroupIdentitiesApi* | [**RequestEnrollment**](docs/Bit4idPathgroupIdentitiesApi.md#requestenrollment) | **POST** /{organization-id}/enroll | Submit an enrollment request
*Bit4idPathgroupOrganizationsApi* | [**GetOrganization**](docs/Bit4idPathgroupOrganizationsApi.md#getorganization) | **GET** /organizations/{organization-id} | Get the settings of an oraganization
*Bit4idPathgroupOrganizationsApi* | [**PatchOrganization**](docs/Bit4idPathgroupOrganizationsApi.md#patchorganization) | **PATCH** /organizations/{organization-id} | Edit the settings of an organization
*Bit4idPathgroupSignatureTransactionsApi* | [**CancelDST**](docs/Bit4idPathgroupSignatureTransactionsApi.md#canceldst) | **POST** /{organization-id}/signature-transactions/{dst-id}/cancel | Mark a DST as canceled
*Bit4idPathgroupSignatureTransactionsApi* | [**CreateDST**](docs/Bit4idPathgroupSignatureTransactionsApi.md#createdst) | **POST** /{organization-id}/signature-transactions | Create a Digital Signature Transaction
*Bit4idPathgroupSignatureTransactionsApi* | [**DeleteDST**](docs/Bit4idPathgroupSignatureTransactionsApi.md#deletedst) | **DELETE** /{organization-id}/signature-transactions/{dst-id} | Delete a Digital Signature Transaction
*Bit4idPathgroupSignatureTransactionsApi* | [**GetDST**](docs/Bit4idPathgroupSignatureTransactionsApi.md#getdst) | **GET** /{organization-id}/signature-transactions/{dst-id} | Get information about a DST
*Bit4idPathgroupSignatureTransactionsApi* | [**GetDocument**](docs/Bit4idPathgroupSignatureTransactionsApi.md#getdocument) | **GET** /{organization-id}/documents/{document-id}/download | Download a document from a DST
*Bit4idPathgroupSignatureTransactionsApi* | [**ListDSTs**](docs/Bit4idPathgroupSignatureTransactionsApi.md#listdsts) | **GET** /{organization-id}/signature-transactions | List the DSTs of an organization
*Bit4idPathgroupSignaturesApi* | [**CreateChannel**](docs/Bit4idPathgroupSignaturesApi.md#createchannel) | **POST** /{organization-id}/channels/{dst-id} | Create a channel
*Bit4idPathgroupSignaturesApi* | [**DeclineDST**](docs/Bit4idPathgroupSignaturesApi.md#declinedst) | **POST** /{organization-id}/signatures/{signature-id}/decline | Decline a Digital Signature Transaction
*Bit4idPathgroupSignaturesApi* | [**PerformDST**](docs/Bit4idPathgroupSignaturesApi.md#performdst) | **POST** /{organization-id}/signatures/{signature-id}/perform | Sign a DST with an automatic signer
*Bit4idPathgroupSignaturesApi* | [**PerformSignature**](docs/Bit4idPathgroupSignaturesApi.md#performsignature) | **POST** /{organization-id}/signatures/{signature-id}/perform/{identity-id} | Perform a Signature
*Bit4idPathgroupSignaturesApi* | [**PerformSignatureWithSession**](docs/Bit4idPathgroupSignaturesApi.md#performsignaturewithsession) | **POST** /{organization-id}/signatures/{signature-id}/session-perform | Perform a Signature with session
*Bit4idPathgroupTokensApi* | [**CreateToken**](docs/Bit4idPathgroupTokensApi.md#createtoken) | **POST** /{organization-id}/tokens | Create an application token
*Bit4idPathgroupTokensApi* | [**DeleteToken**](docs/Bit4idPathgroupTokensApi.md#deletetoken) | **DELETE** /{organization-id}/tokens/{token-id} | Delete a token of the organization
*Bit4idPathgroupTokensApi* | [**GetToken**](docs/Bit4idPathgroupTokensApi.md#gettoken) | **GET** /{organization-id}/tokens/{token-id} | Get information about a token
*Bit4idPathgroupTokensApi* | [**ListTokens**](docs/Bit4idPathgroupTokensApi.md#listtokens) | **GET** /{organization-id}/tokens | Enumerate the tokens of an organization
*Bit4idPathgroupTokensApi* | [**ListUserTokens**](docs/Bit4idPathgroupTokensApi.md#listusertokens) | **GET** /{organization-id}/users/{user-id}/tokens | Enumerate the tokens of an user
*Bit4idPathgroupTokensApi* | [**UpdateToken**](docs/Bit4idPathgroupTokensApi.md#updatetoken) | **PUT** /{organization-id}/tokens/{token-id} | Update the properties of a token
*Bit4idPathgroupUsersApi* | [**CreateUser**](docs/Bit4idPathgroupUsersApi.md#createuser) | **POST** /{organization-id}/users | Create a user of the organization
*Bit4idPathgroupUsersApi* | [**GetUser**](docs/Bit4idPathgroupUsersApi.md#getuser) | **GET** /{organization-id}/users/{user-id} | Get information about an user
*Bit4idPathgroupUsersApi* | [**ListUsers**](docs/Bit4idPathgroupUsersApi.md#listusers) | **GET** /{organization-id}/users | Enumerate the users of an organization
*Bit4idPathgroupUsersApi* | [**UpdateUser**](docs/Bit4idPathgroupUsersApi.md#updateuser) | **PUT** /{organization-id}/users/{user-id} | Edit one or more user properties
*IdentitiesApi* | [**AssociateAppearance**](docs/IdentitiesApi.md#associateappearance) | **POST** /{organization-id}/identities/{identity-id}/appearance | Associate an appearance to an identity
*IdentitiesApi* | [**AssociateIdentity**](docs/IdentitiesApi.md#associateidentity) | **POST** /{organization-id}/users/{user-id}/wallet | Associate to an user an already existing identity
*IdentitiesApi* | [**CreateTokenFromIdentity**](docs/IdentitiesApi.md#createtokenfromidentity) | **POST** /{organization-id}/identities/create/token | Create an identity from token
*IdentitiesApi* | [**DeleteAppearance**](docs/IdentitiesApi.md#deleteappearance) | **DELETE** /{organization-id}/identities/{identity-id}/appearance | Delete the appearance of an identity
*IdentitiesApi* | [**DeleteEnrollmentRequest**](docs/IdentitiesApi.md#deleteenrollmentrequest) | **DELETE** /{organization-id}/identity-requests/{enrollment-id} | Delete an enrollment request
*IdentitiesApi* | [**DeleteIdentity**](docs/IdentitiesApi.md#deleteidentity) | **DELETE** /{organization-id}/identities/{identity-id} | Delete an identity
*IdentitiesApi* | [**GetEnrollmentRequest**](docs/IdentitiesApi.md#getenrollmentrequest) | **GET** /{organization-id}/identity-requests/{enrollment-id} | Get information about an enrollment request
*IdentitiesApi* | [**GetIdentity**](docs/IdentitiesApi.md#getidentity) | **GET** /{organization-id}/identities/{identity-id} | Get information about an identity
*IdentitiesApi* | [**ListEnrollmentRequests**](docs/IdentitiesApi.md#listenrollmentrequests) | **GET** /{organization-id}/identity-requests | Enumerate the enrollment requests of an organization
*IdentitiesApi* | [**ListIdentities**](docs/IdentitiesApi.md#listidentities) | **GET** /{organization-id}/identities | Enumerate the identities of an organization
*IdentitiesApi* | [**ListUserEnrollments**](docs/IdentitiesApi.md#listuserenrollments) | **GET** /{organization-id}/users/{user-id}/identity-requests | List the enrollments of an user
*IdentitiesApi* | [**ListUserIdentities**](docs/IdentitiesApi.md#listuseridentities) | **GET** /{organization-id}/users/{user-id}/wallet | Enumerate the identities of an user
*IdentitiesApi* | [**RequestEnrollment**](docs/IdentitiesApi.md#requestenrollment) | **POST** /{organization-id}/enroll | Submit an enrollment request
*OrganizationsApi* | [**GetOrganization**](docs/OrganizationsApi.md#getorganization) | **GET** /organizations/{organization-id} | Get the settings of an oraganization
*OrganizationsApi* | [**PatchOrganization**](docs/OrganizationsApi.md#patchorganization) | **PATCH** /organizations/{organization-id} | Edit the settings of an organization
*SignatureTransactionsApi* | [**CancelDST**](docs/SignatureTransactionsApi.md#canceldst) | **POST** /{organization-id}/signature-transactions/{dst-id}/cancel | Mark a DST as canceled
*SignatureTransactionsApi* | [**CreateDST**](docs/SignatureTransactionsApi.md#createdst) | **POST** /{organization-id}/signature-transactions | Create a Digital Signature Transaction
*SignatureTransactionsApi* | [**DeleteDST**](docs/SignatureTransactionsApi.md#deletedst) | **DELETE** /{organization-id}/signature-transactions/{dst-id} | Delete a Digital Signature Transaction
*SignatureTransactionsApi* | [**GetDST**](docs/SignatureTransactionsApi.md#getdst) | **GET** /{organization-id}/signature-transactions/{dst-id} | Get information about a DST
*SignatureTransactionsApi* | [**GetDocument**](docs/SignatureTransactionsApi.md#getdocument) | **GET** /{organization-id}/documents/{document-id}/download | Download a document from a DST
*SignatureTransactionsApi* | [**ListDSTs**](docs/SignatureTransactionsApi.md#listdsts) | **GET** /{organization-id}/signature-transactions | List the DSTs of an organization
*SignaturesApi* | [**CreateChannel**](docs/SignaturesApi.md#createchannel) | **POST** /{organization-id}/channels/{dst-id} | Create a channel
*SignaturesApi* | [**DeclineDST**](docs/SignaturesApi.md#declinedst) | **POST** /{organization-id}/signatures/{signature-id}/decline | Decline a Digital Signature Transaction
*SignaturesApi* | [**PerformDST**](docs/SignaturesApi.md#performdst) | **POST** /{organization-id}/signatures/{signature-id}/perform | Sign a DST with an automatic signer
*SignaturesApi* | [**PerformSignature**](docs/SignaturesApi.md#performsignature) | **POST** /{organization-id}/signatures/{signature-id}/perform/{identity-id} | Perform a Signature
*SignaturesApi* | [**PerformSignatureWithSession**](docs/SignaturesApi.md#performsignaturewithsession) | **POST** /{organization-id}/signatures/{signature-id}/session-perform | Perform a Signature with session
*TokensApi* | [**CreateToken**](docs/TokensApi.md#createtoken) | **POST** /{organization-id}/tokens | Create an application token
*TokensApi* | [**DeleteToken**](docs/TokensApi.md#deletetoken) | **DELETE** /{organization-id}/tokens/{token-id} | Delete a token of the organization
*TokensApi* | [**GetToken**](docs/TokensApi.md#gettoken) | **GET** /{organization-id}/tokens/{token-id} | Get information about a token
*TokensApi* | [**ListTokens**](docs/TokensApi.md#listtokens) | **GET** /{organization-id}/tokens | Enumerate the tokens of an organization
*TokensApi* | [**ListUserTokens**](docs/TokensApi.md#listusertokens) | **GET** /{organization-id}/users/{user-id}/tokens | Enumerate the tokens of an user
*TokensApi* | [**UpdateToken**](docs/TokensApi.md#updatetoken) | **PUT** /{organization-id}/tokens/{token-id} | Update the properties of a token
*UsersApi* | [**CreateUser**](docs/UsersApi.md#createuser) | **POST** /{organization-id}/users | Create a user of the organization
*UsersApi* | [**GetUser**](docs/UsersApi.md#getuser) | **GET** /{organization-id}/users/{user-id} | Get information about an user
*UsersApi* | [**ListUsers**](docs/UsersApi.md#listusers) | **GET** /{organization-id}/users | Enumerate the users of an organization
*UsersApi* | [**UpdateUser**](docs/UsersApi.md#updateuser) | **PUT** /{organization-id}/users/{user-id} | Edit one or more user properties
## Documentation for Models
 - [Model.AutomaticSignature](docs/AutomaticSignature.md)
 - [Model.CreateIdentitybyToken](docs/CreateIdentitybyToken.md)
 - [Model.CreateSignatureTransaction](docs/CreateSignatureTransaction.md)
 - [Model.CreateToken](docs/CreateToken.md)
 - [Model.CreateTokenHttpOptions](docs/CreateTokenHttpOptions.md)
 - [Model.CreateTokenWebhooks](docs/CreateTokenWebhooks.md)
 - [Model.CreateUser](docs/CreateUser.md)
 - [Model.Document](docs/Document.md)
 - [Model.Document1](docs/Document1.md)
 - [Model.Identity](docs/Identity.md)
 - [Model.IdentityActions](docs/IdentityActions.md)
 - [Model.IdentityAssociation](docs/IdentityAssociation.md)
 - [Model.IdentityEnroll](docs/IdentityEnroll.md)
 - [Model.IdentityEnrollActions](docs/IdentityEnrollActions.md)
 - [Model.IdentityRequest](docs/IdentityRequest.md)
 - [Model.InlineObject](docs/InlineObject.md)
 - [Model.InlineObject1](docs/InlineObject1.md)
 - [Model.InlineObject2](docs/InlineObject2.md)
 - [Model.InlineObject3](docs/InlineObject3.md)
 - [Model.InlineObject4](docs/InlineObject4.md)
 - [Model.InlineResponse200](docs/InlineResponse200.md)
 - [Model.InlineResponse2001](docs/InlineResponse2001.md)
 - [Model.InlineResponse20010](docs/InlineResponse20010.md)
 - [Model.InlineResponse20010Data](docs/InlineResponse20010Data.md)
 - [Model.InlineResponse20011](docs/InlineResponse20011.md)
 - [Model.InlineResponse20012](docs/InlineResponse20012.md)
 - [Model.InlineResponse2002](docs/InlineResponse2002.md)
 - [Model.InlineResponse2003](docs/InlineResponse2003.md)
 - [Model.InlineResponse2004](docs/InlineResponse2004.md)
 - [Model.InlineResponse2005](docs/InlineResponse2005.md)
 - [Model.InlineResponse2006](docs/InlineResponse2006.md)
 - [Model.InlineResponse2007](docs/InlineResponse2007.md)
 - [Model.InlineResponse2007Meta](docs/InlineResponse2007Meta.md)
 - [Model.InlineResponse2008](docs/InlineResponse2008.md)
 - [Model.InlineResponse2009](docs/InlineResponse2009.md)
 - [Model.InlineResponse201](docs/InlineResponse201.md)
 - [Model.InlineResponse2011](docs/InlineResponse2011.md)
 - [Model.InlineResponse2012](docs/InlineResponse2012.md)
 - [Model.InlineResponse2013](docs/InlineResponse2013.md)
 - [Model.InlineResponse2014](docs/InlineResponse2014.md)
 - [Model.InlineResponse2015](docs/InlineResponse2015.md)
 - [Model.InlineResponse201Data](docs/InlineResponse201Data.md)
 - [Model.InlineResponse401](docs/InlineResponse401.md)
 - [Model.InlineResponse403](docs/InlineResponse403.md)
 - [Model.InlineResponse404](docs/InlineResponse404.md)
 - [Model.MetaDataError](docs/MetaDataError.md)
 - [Model.MetaDataSuccess](docs/MetaDataSuccess.md)
 - [Model.Organization](docs/Organization.md)
 - [Model.OrganizationSettings](docs/OrganizationSettings.md)
 - [Model.PaginationData](docs/PaginationData.md)
 - [Model.SMS](docs/SMS.md)
 - [Model.Signature](docs/Signature.md)
 - [Model.SignatureDST](docs/SignatureDST.md)
 - [Model.SignatureDSTWhere](docs/SignatureDSTWhere.md)
 - [Model.SignatureImplementationResponse](docs/SignatureImplementationResponse.md)
 - [Model.SignatureImplementationResponseChannel](docs/SignatureImplementationResponseChannel.md)
 - [Model.SignatureTransaction](docs/SignatureTransaction.md)
 - [Model.SignatureWhere](docs/SignatureWhere.md)
 - [Model.Token](docs/Token.md)
 - [Model.UpdateOrganization](docs/UpdateOrganization.md)
 - [Model.UpdateToken](docs/UpdateToken.md)
 - [Model.UpdateUser](docs/UpdateUser.md)
 - [Model.User](docs/User.md)
## Documentation for Authorization
### ApiKeyAuth
- **Type**: API key
- **API key parameter name**: Authorization
- **Location**: HTTP header
