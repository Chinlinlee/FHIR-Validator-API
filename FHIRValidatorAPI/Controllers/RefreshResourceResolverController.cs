using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FHIRValidatorAPI.Models;
using Hl7.Fhir.Specification.Source;
using Hl7.Fhir.Validation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FHIRValidatorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RefreshResourceResolverController : ControllerBase
    {
        public class RefreshResourceResolverResult 
        {
            public string message { get; set; }
            public bool status { get; set; }
        }
        [HttpPost]
        public RefreshResourceResolverResult Post() 
        {
            RefreshResourceResolverResult result = new RefreshResourceResolverResult();
            try
            {
                MyValidateSetting.validationSettings = null;
                var validationSettings = new ValidationSettings();
                validationSettings.Trace = false;
                validationSettings.ResourceResolver = new CachedResolver(new MultiResolver(
                       new DirectorySource(@"./assets/validationResources", new DirectorySourceSettings() { IncludeSubDirectories = true }), ZipSource.CreateValidationSource()));
                MyValidateSetting.validationSettings = validationSettings;
                result.status = true;
                result.message = "success";
            }
            catch (Exception e) 
            {
                result.status = false;
                result.message = e.StackTrace;
            }
            return result;
        }
    }
}