/* 
 * Signing Today Web
 *
 * *Signing Today* is the perfect Digital Signature Gateway. Whenever in Your workflow You need to add one or more Digital Signatures to Your document, *Signing Today* is the right choice. You prepare Your documents, *Signing Today* takes care of all the rest: send invitations (`signature tickets`) to signers, collects their signatures, send You back the signed document. Integrating *Signing Today* in Your existing applications is very easy. Just follow these API specifications and get inspired by the many examples presented hereafter. 
 *
 * The version of the OpenAPI document: 2.0.0
 * 
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using RestSharp;
using NUnit.Framework;

using SigningToday.Client;
using SigningToday.Api;
using SigningToday.Model;

namespace SigningToday.Test
{
    /// <summary>
    ///  Class for testing BackofficeApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    public class BackofficeApiTests
    {
        private BackofficeApi instance;

        /// <summary>
        /// Setup before each unit test
        /// </summary>
        [SetUp]
        public void Init()
        {
            instance = new BackofficeApi();
        }

        /// <summary>
        /// Clean up after each unit test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {

        }

        /// <summary>
        /// Test an instance of BackofficeApi
        /// </summary>
        [Test]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsInstanceOf' BackofficeApi
            //Assert.IsInstanceOf(typeof(BackofficeApi), instance);
        }

        
        /// <summary>
        /// Test OrganizationIdAlfrescoSyncGet
        /// </summary>
        [Test]
        public void OrganizationIdAlfrescoSyncGetTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string id = null;
            //var response = instance.OrganizationIdAlfrescoSyncGet(id);
            //Assert.IsInstanceOf(typeof(AlfrescoSync), response, "response is AlfrescoSync");
        }
        
        /// <summary>
        /// Test OrganizationIdAlfrescoSyncPost
        /// </summary>
        [Test]
        public void OrganizationIdAlfrescoSyncPostTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string id = null;
            //AlfrescoSync alfrescoSync = null;
            //instance.OrganizationIdAlfrescoSyncPost(id, alfrescoSync);
            
        }
        
        /// <summary>
        /// Test OrganizationIdDelete
        /// </summary>
        [Test]
        public void OrganizationIdDeleteTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string id = null;
            //bool enabled = null;
            //instance.OrganizationIdDelete(id, enabled);
            
        }
        
        /// <summary>
        /// Test OrganizationIdGet
        /// </summary>
        [Test]
        public void OrganizationIdGetTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string id = null;
            //var response = instance.OrganizationIdGet(id);
            //Assert.IsInstanceOf(typeof(Organization), response, "response is Organization");
        }
        
        /// <summary>
        /// Test OrganizationIdPublicGet
        /// </summary>
        [Test]
        public void OrganizationIdPublicGetTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string res = null;
            //string id = null;
            //var response = instance.OrganizationIdPublicGet(res, id);
            //Assert.IsInstanceOf(typeof(System.IO.Stream), response, "response is System.IO.Stream");
        }
        
        /// <summary>
        /// Test OrganizationIdPut
        /// </summary>
        [Test]
        public void OrganizationIdPutTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string id = null;
            //Organization organization = null;
            //instance.OrganizationIdPut(id, organization);
            
        }
        
        /// <summary>
        /// Test OrganizationIdResourceGet
        /// </summary>
        [Test]
        public void OrganizationIdResourceGetTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string id = null;
            //string resPath = null;
            //var response = instance.OrganizationIdResourceGet(id, resPath);
            //Assert.IsInstanceOf(typeof(System.IO.Stream), response, "response is System.IO.Stream");
        }
        
        /// <summary>
        /// Test OrganizationIdResourcePut
        /// </summary>
        [Test]
        public void OrganizationIdResourcePutTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string id = null;
            //string resPath = null;
            //System.IO.Stream file = null;
            //instance.OrganizationIdResourcePut(id, resPath, file);
            
        }
        
        /// <summary>
        /// Test OrganizationResourceIdDelete
        /// </summary>
        [Test]
        public void OrganizationResourceIdDeleteTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string id = null;
            //string resPath = null;
            //instance.OrganizationResourceIdDelete(id, resPath);
            
        }
        
        /// <summary>
        /// Test OrganizationResourcesGet
        /// </summary>
        [Test]
        public void OrganizationResourcesGetTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string id = null;
            //var response = instance.OrganizationResourcesGet(id);
            //Assert.IsInstanceOf(typeof(List<string>), response, "response is List<string>");
        }
        
        /// <summary>
        /// Test OrganizationTagsGet
        /// </summary>
        [Test]
        public void OrganizationTagsGetTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //var response = instance.OrganizationTagsGet();
            //Assert.IsInstanceOf(typeof(List<string>), response, "response is List<string>");
        }
        
        /// <summary>
        /// Test OrganizationsGet
        /// </summary>
        [Test]
        public void OrganizationsGetTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int top = null;
            //long skip = null;
            //bool count = null;
            //string filter = null;
            //var response = instance.OrganizationsGet(top, skip, count, filter);
            //Assert.IsInstanceOf(typeof(OrganizationsGetResponse), response, "response is OrganizationsGetResponse");
        }
        
        /// <summary>
        /// Test OrganizationsPost
        /// </summary>
        [Test]
        public void OrganizationsPostTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //Organization organization = null;
            //instance.OrganizationsPost(organization);
            
        }
        
    }

}