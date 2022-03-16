using CoreWebApp.Business.Interfaces;
using CoreWebApp.Model.Customer;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Web.Http.Description;

namespace CoreWebApp.Controllers.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerApiController : ControllerBase
    {
        /// <summary>
        /// The customer service/
        /// </summary>
        private readonly ICustomerService _customerService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerApiController"/> class.
        /// </summary>
        /// <param name="customerService">The customer service.</param>
        public CustomerApiController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        /// <summary>
        /// Registers the customer.
        /// </summary>
        /// <param name="customerModel">The customer model.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("register-customer")]
        public IActionResult RegisterCustomer(CustomerModel customerModel)
        {
            var model = _customerService.RegisterCustomer(customerModel);
            return Ok(model);

        }

        /// <summary>
        /// Gets the customer ids.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("customer-ids")]
        [ResponseType(typeof(List<CustomerId>))]
        public IActionResult GetCustomerIds()
        {
            var model = _customerService.GetCustomerList();
            if (model == null)
                return BadRequest();
            return Ok(model);

        }

    }
}
