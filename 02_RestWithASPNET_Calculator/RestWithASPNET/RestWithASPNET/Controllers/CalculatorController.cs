using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNET.Controllers;

    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
   

        private readonly ILogger<CalculatorController> _logger;
        private bool isNumber;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if(isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }
        [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
        public IActionResult Subtraction(string firstNumber, string secondNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }
    [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
    public IActionResult Multiplication(string firstNumber, string secondNumber)
    {
        if (isNumeric(firstNumber) && isNumeric(secondNumber))
        {
            var sum = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
            return Ok(sum.ToString());
        }
        return BadRequest("Invalid Input");
    }

    [HttpGet("mean/{firstNumber}/{secondNumber}")]
    public IActionResult Mean(string firstNumber, string secondNumber)
    {
        if (isNumeric(firstNumber) && isNumeric(secondNumber))
        {
            var sum = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber))/2;
            return Ok(sum.ToString());
        }
        return BadRequest("Invalid Input");
    }


    [HttpGet("division/{firstNumber}/{secondNumber}")]
    public IActionResult Division(string firstNumber, string secondNumber)
    {
        if (isNumeric(firstNumber) && isNumeric(secondNumber))
        {
            var sum = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
            return Ok(sum.ToString());
        }
        return BadRequest("Invalid Input");
    }

    [HttpGet("square-root/{firstNumber}")]
    public IActionResult SquareRoot(string firstNumber)
    {
        if (isNumeric(firstNumber))
        {
            var SquareRoot = Math.Sqrt((double)ConvertToDecimal(firstNumber));
            return Ok(SquareRoot.ToString());
        }
        return BadRequest("Invalid Input");
    }

   


    private bool isNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(
                strNumber, 
                System.Globalization.NumberStyles.Any, 
                System.Globalization.NumberFormatInfo.InvariantInfo, 
                out number);
            return isNumber;
        
        }


        private decimal ConvertToDecimal(string strNumber)
        {

            decimal decimalValue;
            if(decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }

   }
