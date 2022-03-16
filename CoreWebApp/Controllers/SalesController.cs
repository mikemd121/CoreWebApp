using CoreWebApp.Core.Common;
using CoreWebApp.Data.BaseOperation;
using CoreWebApp.Data.EntityModels;
using CoreWebApp.Model.Customer;
using CoreWebApp.Model.SalesViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoreWebApp.Controllers
{
    public class SalesController : BaseController
    {
        /// <summary>
        /// The context
        /// </summary>
        private CoreWebAppDbContext _context;
        public SalesController(CoreWebAppDbContext context)
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
            var model = new SalesViewModel
            {
                customerList = await SetListAsync<CustomerId>(Constants.apiUrl + "/customerapi" + "/customer-ids", "Id", "Name"),
                propertyList= await SetListAsync<CustomerId>(Constants.apiUrl + "/customerapi" + "/customer-ids", "Id", "Name")
            };
            ViewBag.Message = m;
            return View(model);
        }

        /// <summary>
        /// Gets the property by customer identifier.
        /// </summary>
        /// <param name="CustomerId">The customer identifier.</param>
        /// <returns></returns>
        public async Task<JsonResult> GetPropertyByCustomerId(int CustomerId)
        {   
            var response = await GetServiceAsync(Constants.apiUrl + "/propertyapi" + $"/get-propertybycustomerid?CustomerId={CustomerId}");
            var data = await response.Content.ReadAsAsync<List<Property>>();
            data.Insert(0, new Property { PropertyId = 0, PropertyName = "Select" });
            return Json(new SelectList(data, "PropertyId", "PropertyName"));
        }


        /// <summary>
        /// Sells the property.
        /// </summary>
        /// <param name="salesModel">The sales model.</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SellProperty(SalesModel salesModel)
        {
            var response = await PostServiceAsync(Constants.apiUrl + "/salesapi" + "/sell-property", GetContent(salesModel));
            var model = await response.Content.ReadAsAsync<ResponseModel>();
            return RedirectToAction("Index", "Sales", new { m = model.Messsage });
        }
    }
}
