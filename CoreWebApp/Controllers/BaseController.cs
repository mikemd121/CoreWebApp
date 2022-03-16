using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CoreWebApp.Controllers
{
    public class BaseController : Microsoft.AspNetCore.Mvc.Controller
    {
        /// <summary>
        /// Gets the method route.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="method">The method.</param>
        /// <param name="routeValues">The route values.</param>
        /// <returns>The method route</returns>
        protected static string GetMethodRoute<T>(MethodInfo method, Dictionary<string, string> routeValues = null) where T : Microsoft.AspNetCore.Mvc.ControllerBase
        {
            if (method.GetType() != typeof(System.Web.Http.IHttpActionResult) && !method.GetCustomAttributes().Any())
                return string.Empty;

            var routeUrl = GetRoutePrefix<T>(routeValues) + "/" +
                   ((System.Web.Http.RouteAttribute[])method.GetCustomAttributes(
                       typeof(System.Web.Http.RouteAttribute))).First().Template;

            if (routeValues == null) return routeUrl;

            var regex = new Regex("{(.*?)}");
            var matches = regex.Matches(routeUrl);
            foreach (var match in matches)
            {
                foreach (var entry in routeValues)
                {
                    if (match.ToString().Contains(entry.Key))
                    {
                        routeUrl = routeUrl.Replace(match.ToString(), entry.Value);
                    }
                }
            }

            return routeUrl;
        }
        /// <summary>
        /// Gets the route prefix.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Route prefix</returns>
        public static string GetRoutePrefix<T>(Dictionary<string, string> routeValues = null) where T : Microsoft.AspNetCore.Mvc.ControllerBase
        {
            var routeUrl = ((System.Web.Http.RoutePrefixAttribute)Attribute.GetCustomAttribute(
                typeof(T), typeof(System.Web.Http.RoutePrefixAttribute))).Prefix;

            if (routeValues == null) return routeUrl;

            var regex = new Regex("{(.*?)}");
            var matches = regex.Matches(routeUrl);
            foreach (var match in matches)
            {
                foreach (var entry in routeValues)
                {
                    if (match.ToString().Contains(entry.Key))
                    {
                        routeUrl = routeUrl.Replace(match.ToString(), entry.Value);
                    }
                }
            }

            return routeUrl;
        }

        /// <summary>
        /// Sets the list asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestUri">The request URI.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public async Task<IEnumerable<SelectListItem>> SetListAsync<T>(string requestUri, string id = "Id",
            string name = "Name")
        {
            var response = await GetServiceAsync(requestUri);
            return !response.IsSuccessStatusCode
                ? null
                : LoadSelectListItems<T>(response,
                    new SelectListItemProperty { Value = id, Text = name });
        }

        /// <summary>
        /// Gets the service asynchronous.
        /// </summary>
        /// <param name="requestUri">The request URI.</param>
        /// <returns>The response.</returns>
        public async Task<HttpResponseMessage> GetServiceAsync(string requestUri)
        {
            var client = new HttpClient();
            return await client.GetAsync(requestUri);
        }

        /// <summary>
        /// Loads the select list items.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="response">The response.</param>
        /// <param name="select">The select.</param>
        /// <returns>List of select items.</returns>
        public static IEnumerable<SelectListItem> LoadSelectListItems<T>(HttpResponseMessage response, SelectListItemProperty select)
        {
            var jsjs = response.Content.ReadAsAsync<IEnumerable<T>>().Result;

            var value = select.Value;
            var text = select.Text;

            var query = from e in jsjs
                        select new
                        {
                            Value = ReadProperty(e, value),
                            Text = ReadProperty(e, text),
                        };


            return query.AsEnumerable()
                   .Select(s => new SelectListItem
                   {
                       Value = s.Value.ToString(),
                       Text = s.Text.ToString()
                   });
        }

        /// <summary>
        /// Reads the property.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>An object</returns>
        public static object ReadProperty(object source, string propertyName)
        {
            return source.GetType().GetProperty(propertyName).GetValue(source, null);
        }

        /// <summary>
        /// Select list item property struct
        /// </summary>
        public struct SelectListItemProperty
        {
            public string Text;
            public string Value;
        }

        /// <summary>
        /// Gets the API methods.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>List of route name and methods pair.</returns>
        protected static List<KeyValuePair<string, MethodInfo>> GetApiMethods<T>()
        {
            var methods = typeof(T).GetMethods();
            return (from method in methods
                    let name =
                        ((System.Web.Http.RouteAttribute[])method.GetCustomAttributes(
                            typeof(System.Web.Http.RouteAttribute))).FirstOrDefault()?.Name
                    select new KeyValuePair<string, MethodInfo>(!string.IsNullOrEmpty(name) ? name : "", method)).ToList();
        }

        /// <summary>
        /// Gets the content.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        protected StringContent GetContent<T>(T model)
        {
            return new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
        }

        /// <summary>
        /// Deletes the service asynchronous.
        /// </summary>
        /// <param name="requestUri">The request URI.</param>
        /// <returns></returns>
        protected async Task<HttpResponseMessage> DeleteServiceAsync(string requestUri)
        {
            /// <summary>
            /// The HTTP client.
            /// </summary>
            var client = new HttpClient();

            return await client.DeleteAsync(requestUri);
        }

        /// <summary>
        /// Puts the service asynchronous.
        /// </summary>
        /// <param name="requestUri">The request URI.</param>
        /// <param name="content">The content.</param>
        /// <returns></returns>
        protected async Task<HttpResponseMessage> PutServiceAsync(string requestUri, HttpContent content)
        {
            var client = new HttpClient();
            return await client.PutAsync(requestUri, content);
        }

        /// <summary>
        /// Posts the service asynchronous.
        /// </summary>
        /// <param name="requestUri">The request URI.</param>
        /// <param name="content">The content.</param>
        /// <returns></returns>
        protected async Task<HttpResponseMessage> PostServiceAsync(string requestUri, HttpContent content)
        {
            var client = new HttpClient();
            return await client.PostAsync(requestUri, content);
        }
    }
}
