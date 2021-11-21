using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FHIRValidatorAPI.Models
{
    public class ValidateInput
    {
        public string resourceJson { get; set; }
        public string[] profile { get; set; }
    }
}
