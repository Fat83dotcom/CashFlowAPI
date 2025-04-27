using CashFlow.Application.UseCases.Expenses.Register.Interfaces;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using Microsoft.AspNetCore.Mvc;


namespace CashFlow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        [HttpPost("register")]
        [ProducesResponseType(typeof(ResponseRegisterExpanseJson), StatusCodes.Status201Created)]
        public IActionResult Register([FromBody]RequestExpenseJson request, [FromServices] IRegisterExpensesUseCase useCase)
        {
            var response = useCase.Execute(request);
        
            return Created(string.Empty, response);
        }

        [HttpGet("getExpenses")]
        [ProducesResponseType(typeof(ResposnseGetExpensesJson), StatusCodes.Status200OK)]
        public IActionResult GetExpenses()
        {
            var response = 5;

            return Ok(response);
        }
    }
}
