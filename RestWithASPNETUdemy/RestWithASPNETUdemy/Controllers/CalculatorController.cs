using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNETUdemy.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculatorController : ControllerBase
{

    private readonly ILogger<CalculatorController> _logger;

    public CalculatorController(ILogger<CalculatorController> logger)
    {
        _logger = logger;
    }

    [HttpGet("Sum/")]
    public IActionResult Sum(string firstNumber, string secondNumber)
    {

        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
            return Ok(sum.ToString());
        }

        return BadRequest("Invalid Input");
    }

    [HttpGet("Multiplication/")]
    public IActionResult Multiplication(string firstNumber, string secondNumber)
    {

        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
            return Ok(sum.ToString());
        }

        return BadRequest("Invalid Input");
    }

    [HttpGet("Division/")]
    public IActionResult Division(string firstNumber, string secondNumber)
    {

        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
            return Ok(sum.ToString());
        }

        return BadRequest("Invalid Input");
    }

    [HttpGet("Media/")]
    public IActionResult Media(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
            var average = sum / 2; 
            return Ok(average.ToString());
        }

        return BadRequest("Invalid Input");
    }

    [HttpGet("Raizquadrada/")]
    public IActionResult RaizQuadrada(string number)
    {
        if (IsNumeric(number))
        {
            var inputNumber = ConvertToDecimal(number);
            if (inputNumber >= 0) 
            {
                var squareRoot = Math.Sqrt((double)inputNumber);
                return Ok(squareRoot.ToString());
            }
            else
            {
                return BadRequest("Número negativo. Não é possível calcular a raiz quadrada de um número negativo.");
            }
        }

        return BadRequest("Entrada inválida");
    }

    private bool IsNumeric(string strNumber)
    {
        double number;
        bool isNumber = double.TryParse
            (strNumber, System.Globalization.NumberStyles.Any, 
            System.Globalization.NumberFormatInfo.InvariantInfo, out number);

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
