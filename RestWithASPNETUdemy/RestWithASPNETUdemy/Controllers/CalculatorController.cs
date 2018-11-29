using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNETUdemy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        // GET api/calculator/sum/5/5
        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var ret = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(ret.ToString());
            }
            return BadRequest("Invalid input");
        }

        // GET api/calculator/subtraction/5/5
        [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
        public IActionResult Subtraction(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var ret = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(ret.ToString());
            }
            return BadRequest("Invalid input");
        }

        // GET api/calculator/multiplication/5/5
        [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplication(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var ret = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(ret.ToString());
            }
            return BadRequest("Invalid input");
        }

        // GET api/calculator/division/5/5
        [HttpGet("division/{firstNumber}/{secondNumber}")]
        public IActionResult Division(string firstNumber, string secondNumber)
        {

            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                if (ConvertToDecimal(secondNumber) != 0)
                {
                    var ret = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                    return Ok(ret.ToString());
                }
            }
            return BadRequest("Invalid input");
        }

        // GET api/calculator/average/5/5
        [HttpGet("average/{firstNumber}/{secondNumber}")]
        public IActionResult Average(string firstNumber, string secondNumber)
        {

            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                    var ret = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber) / 2;
                    return Ok(ret.ToString());
            }
            return BadRequest("Invalid input");
        }


        private decimal ConvertToDecimal(string number)
        {
            decimal decimalValue;
            if (decimal.TryParse(number, out decimalValue))
                return decimalValue;
            return 0;
        }

        private bool IsNumeric(string number)
        {
            double doubleNumber;
            return double.TryParse(number, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out doubleNumber);
        }
    }
}
