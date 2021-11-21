using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FHIRValidatorAPI.Models
{
    public class ValidateResult
    {
        public bool status { get; set; }
        public string data { get; set; }
    }
}
