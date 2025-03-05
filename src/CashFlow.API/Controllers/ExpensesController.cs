using CashFlow.API.Filters;
using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Exceptions.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;


namespace CashFlow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        [HttpPost("register")]
        [ProducesResponseType(typeof(ResponseRegisterExpanseJson), StatusCodes.Status201Created)]
        public IActionResult Register([FromBody]RequestExpenseJson request)
        {
            var response = new RegisterExpensesUseCase().Execute(request);
        
            return Created(string.Empty, response);
        }
    }
}
