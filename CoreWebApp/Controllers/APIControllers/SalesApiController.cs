using CoreWebApp.Business.Interfaces;
using CoreWebApp.Model.SalesViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebApp.Controllers.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesApiController : ControllerBase
    {
        /// <summary>
        /// The sales service
        /// </summary>
        private readonly ISalesService _salesService;

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesApiController"/> class.
        /// </summary>
        /// <param name="salesService">The sales service.</param>
        public SalesApiController(ISalesService salesService)
        {
            _salesService = salesService;
        }

        /// <summary>
        /// Sells the property.
        /// </summary>
        /// <param name="salesModel">The sales model.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("sell-property")]
        public IActionResult SellProperty(SalesModel salesModel)
        {
            var model = _salesService.SellProperty(salesModel);
            return Ok(model);
        }

        /// <summary>
        /// Gets the sales.
        /// </summary>
        /// <returns></returns>
         [Authorize]
        [HttpGet]
        [Route("get-sales")]
        public IActionResult GetSales()
        {
            var model = _salesService.GetSoldPropertyList();
            return Ok(model);
        }

    }
}
