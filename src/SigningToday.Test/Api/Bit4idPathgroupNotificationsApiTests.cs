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
    ///  Class for testing Bit4idPathgroupNotificationsApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    public class Bit4idPathgroupNotificationsApiTests
    {
        private Bit4idPathgroupNotificationsApi instance;

        /// <summary>
        /// Setup before each unit test
        /// </summary>
        [SetUp]
        public void Init()
        {
            instance = new Bit4idPathgroupNotificationsApi();
        }

        /// <summary>
        /// Clean up after each unit test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {

        }

        /// <summary>
        /// Test an instance of Bit4idPathgroupNotificationsApi
        /// </summary>
        [Test]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsInstanceOf' Bit4idPathgroupNotificationsApi
            //Assert.IsInstanceOf(typeof(Bit4idPathgroupNotificationsApi), instance);
        }

        
        /// <summary>
        /// Test NotificationsDstIdDelete
        /// </summary>
        [Test]
        public void NotificationsDstIdDeleteTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //Guid id = null;
            //instance.NotificationsDstIdDelete(id);
            
        }
        
        /// <summary>
        /// Test NotificationsDstsGet
        /// </summary>
        [Test]
        public void NotificationsDstsGetTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int top = null;
            //long skip = null;
            //bool count = null;
            //var response = instance.NotificationsDstsGet(top, skip, count);
            //Assert.IsInstanceOf(typeof(NotificationsResponse), response, "response is NotificationsResponse");
        }
        
        /// <summary>
        /// Test NotificationsPushTokenDelete
        /// </summary>
        [Test]
        public void NotificationsPushTokenDeleteTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string deviceId = null;
            //instance.NotificationsPushTokenDelete(deviceId);
            
        }
        
        /// <summary>
        /// Test NotificationsPushTokenPost
        /// </summary>
        [Test]
        public void NotificationsPushTokenPostTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //InlineObject6 inlineObject6 = null;
            //instance.NotificationsPushTokenPost(inlineObject6);
            
        }
        
    }

}
