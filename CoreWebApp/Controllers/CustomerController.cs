using CoreWebApp.Core.Common;
using CoreWebApp.Model.Customer;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoreWebApp.Controllers
{
    public class CustomerController : BaseController
    {
        /// <summary>
        /// Indexes the specified m.
        /// </summary>
        /// <param name="m">The m.</param>
        /// <returns></returns>
        public IActionResult Index(string m)
        {
            ViewBag.Message = m;
            return View();
        }

        /// <summary>
        /// Registers the specified customer model.
        /// </summary>
        /// <param name="customerModel">The customer model.</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(CustomerViewModel customerModel)
        {
            var response = await PostServiceAsync(Constants.apiUrl + "/CustomerApi" + "/register-customer", GetContent(customerModel));
            var model = await response.Content.ReadAsAsync<ResponseModel>();
            return RedirectToAction("Index", "Customer", new { m = model.Messsage });
        }
    }
}
