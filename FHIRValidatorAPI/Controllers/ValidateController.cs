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

namespace FHIRValidatorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidateController : ControllerBase
    {
        [HttpPost]
        public ValidateResult Post([FromBody]ValidateInput value) 
        {
            ValidateResult validateResult = new ValidateResult();
            validateResult.status = false;
            validateResult.data = "";
            try
            {
                var validator = new Validator(MyValidateSetting.validationSettings);
                var jsonReader = (new FhirJsonParser()).Parse<Resource>(value.resourceJson);
                var validation = validator.Validate(jsonReader, value.profile);
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