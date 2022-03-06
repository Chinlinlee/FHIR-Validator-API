using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FHIRValidatorAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Hl7.Fhir.Validation;
using Hl7.Fhir.Serialization;
using Hl7.Fhir.Model;
using Hl7.Fhir.Specification.Source;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace FHIRValidatorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidateController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly Validator _validator;
        public ValidateController(ILogger<ValidateController> logger) 
        {
            _logger = logger;
            _validator = new Validator(MyValidateSetting.validationSettings);
        }
        [HttpPost]
        public ValidateResult Post([FromBody]ValidateInput value) 
        {
            ValidateResult validateResult = new ValidateResult();
            validateResult.status = false;
            validateResult.data = "";
            try
            {
                var jsonReader = (new FhirJsonParser()).Parse<Resource>(value.resourceJson);
                var validation = this._validator.Validate(jsonReader, value.profile);
                validateResult.status = true;
                validateResult.data = validation.ToJson();
            }
            catch (Exception e) 
            {
                validateResult.status = false;
                validateResult.data = e.StackTrace;
            }
            return validateResult;
        }
        

    }
}