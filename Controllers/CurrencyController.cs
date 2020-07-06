using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkcCurrencyApi.BLL.Application;
using SkcCurrencyApi.BLL.Application.Request;

namespace SkcCurrencyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencySevice _sevice;
        public CurrencyController(ICurrencySevice sevice)
        {
            _sevice = sevice;
        }


        [HttpPost]
        public async Task<IActionResult> CreateCurrency(OperatorRequest request)
        {
            return Ok(_sevice.CreateCurrency(request));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCurrency(OperatorRequest request)
        {
            return Ok(_sevice.DeleteCurrency(request));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCurrency(OperatorRequest request)
        {
            return Ok(_sevice.UpdateCurrency(request));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCurrency()
        {
            return Ok(_sevice.GetALLCurrency());
        }

        public async Task<IActionResult> GetByDate(DateTime exchangeDate)
        {
            return Ok(_sevice.GetByDate(exchangeDate));
        }

    }
}
