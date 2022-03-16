using CoreWebApp.Business.Interfaces;
using CoreWebApp.Core.Enums;
using CoreWebApp.Data.EntityModels;
using CoreWebApp.Model.Property;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Web.Http.Description;

namespace CoreWebApp.Controllers.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyApiController : ControllerBase
    {
        /// <summary>
        /// The property service/
        /// </summary>
        private readonly IPropertyService _propertyService;

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyApiController"/> class.
        /// </summary>
        /// <param name="propertyService">The property service.</param>
        public PropertyApiController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        /// <summary>
        /// Registers the property.
        /// </summary>
        /// <param name="propertyModel">The property model.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("register-property")]
        public IActionResult RegisterProperty(PropertyModel propertyModel)
        {
            var model = _propertyService.RegisterProperty(propertyModel);
            return Ok(model);
        }

        /// <summary>
        /// Gets the available property by customer identifier.
        /// </summary>
        /// <param name="CustomerId">The customer identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("get-propertybycustomerid", Name = nameof(ApiRoute.InsertCustomer))]
        [ResponseType(typeof(List<Property>))]
        public IActionResult GetAvailablePropertyByCustomerId(int CustomerId)
        {
            var model = _propertyService.GetAvailablePropertyByCustomerId(CustomerId);

            if (model == null)
                return BadRequest();
            return Ok(model);
        }

    }
}
