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
    ///  Class for testing Bit4idPathgroupDSTNoteApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    public class Bit4idPathgroupDSTNoteApiTests
    {
        private Bit4idPathgroupDSTNoteApi instance;

        /// <summary>
        /// Setup before each unit test
        /// </summary>
        [SetUp]
        public void Init()
        {
            instance = new Bit4idPathgroupDSTNoteApi();
        }

        /// <summary>
        /// Clean up after each unit test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {

        }

        /// <summary>
        /// Test an instance of Bit4idPathgroupDSTNoteApi
        /// </summary>
        [Test]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsInstanceOf' Bit4idPathgroupDSTNoteApi
            //Assert.IsInstanceOf(typeof(Bit4idPathgroupDSTNoteApi), instance);
        }

        
        /// <summary>
        /// Test DSTIdNoteGet
        /// </summary>
        [Test]
        public void DSTIdNoteGetTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //Guid id = null;
            //var response = instance.DSTIdNoteGet(id);
            //Assert.IsInstanceOf(typeof(List<DSTNote>), response, "response is List<DSTNote>");
        }
        
        /// <summary>
        /// Test DSTIdNoteNoteIdDelete
        /// </summary>
        [Test]
        public void DSTIdNoteNoteIdDeleteTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //Guid id = null;
            //long noteId = null;
            //instance.DSTIdNoteNoteIdDelete(id, noteId);
            
        }
        
        /// <summary>
        /// Test DSTIdNoteNoteIdPut
        /// </summary>
        [Test]
        public void DSTIdNoteNoteIdPutTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //Guid id = null;
            //long noteId = null;
            //DSTNote dSTNote = null;
            //var response = instance.DSTIdNoteNoteIdPut(id, noteId, dSTNote);
            //Assert.IsInstanceOf(typeof(DSTNote), response, "response is DSTNote");
        }
        
        /// <summary>
        /// Test DSTIdNotePost
        /// </summary>
        [Test]
        public void DSTIdNotePostTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //Guid id = null;
            //InlineObject1 inlineObject1 = null;
            //var response = instance.DSTIdNotePost(id, inlineObject1);
            //Assert.IsInstanceOf(typeof(DSTNote), response, "response is DSTNote");
        }
        
    }

}