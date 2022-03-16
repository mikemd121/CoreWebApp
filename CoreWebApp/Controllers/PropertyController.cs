using CoreWebApp.Core.Common;
using CoreWebApp.Data.BaseOperation;
using CoreWebApp.Model.Customer;
using CoreWebApp.Model.Property;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoreWebApp.Controllers.APIControllers
{
    public class PropertyController : BaseController
    {
        /// <summary>
        /// The context
        /// </summary>
        private CoreWebAppDbContext _context;
        public PropertyController(CoreWebAppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Indexes the specified m.
        /// </summary>
        /// <param name="m">The m.</param>
        /// <returns></returns>
        public async Task<IActionResult> Index(string m)
        {
            var model = new PropertyViewModel { customerList = await SetListAsync<CustomerId>(Constants.apiUrl + "/customerapi" + "/customer-ids", "Id", "Name") };
            ViewBag.Message = m;
            return View(model);
        }

        /// <summary>
        /// Adds the property.
        /// </summary>
        /// <param name="propertyModel">The property model.</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProperty(PropertyViewModel propertyModel)
        {
            var response = await PostServiceAsync(Constants.apiUrl+ "/propertyapi" + "/register-property", GetContent(propertyModel));
            var model = await response.Content.ReadAsAsync<ResponseModel>();
            return RedirectToAction("Index", "Property", new { m = model.Messsage });
        }
    }
}
