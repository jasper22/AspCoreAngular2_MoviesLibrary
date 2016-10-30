
// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AspCoreAngular2_MoviesLibrary.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AspCoreAngular2_MoviesLibrary.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;

    /// <summary>
    /// The <c>ItemsController</c>
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Route("api/[controller]")]
    public class ItemsController : Controller
    {
        /// <summary>
        /// GET: api/items
        /// </summary>
        /// <returns>Nothing: this method will raise a HttpNotFound HTTP exception, since we're not supporting this API call.</returns>
        [HttpGet()]
        public IActionResult Get()
        {
            return NotFound(new { Error = "not found" });
        }

        /// <summary>
        /// GET: api/items/{id}
        /// ROUTING TYPE: attribute-based
        /// </summary>
        /// <returns>A Json-serialized object representing a single item. </returns>
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return new JsonResult(GetSampleItems()
                                    .Where(i => i.Id == id)
                                    .FirstOrDefault(),
                                    DefaultJsonSettings);
        }

        /// <summary>
        /// GET: api/items/GetLatest
        /// ROUTING TYPE: attribute-based
        /// </summary>
        /// <returns>An array of a default number of Json-serialized objects representing the last inserted items.</returns>
        [HttpGet("GetLatest")]
        public JsonResult GetLatest()
        {
            return GetLatest(DefaultNumberOfItems);
        }

        /// <summary>
        /// GET: api/items/GetLatest/{n}
        /// ROUTING TYPE: attribute-based
        /// </summary>
        /// <returns>An array of {n} Json-serialized objects representing the last inserted items.</returns>
        [HttpGet("GetLatest/{num}")]
        public JsonResult GetLatest(int num)
        {
            var items = GetSampleItems().OrderByDescending(i => i.CreatedDate).Take(num);
            var zz = new JsonResult(items.ToList(), DefaultJsonSettings);
            return new JsonResult(items.ToList(), DefaultJsonSettings);
        }

        /// <summary>
        /// Gets the most viewed.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetMostViewed")]
        public JsonResult GetMostViewed()
        {
            return GetMostViewed(DefaultNumberOfItems);
        }

        /// <summary>
        /// GET: api/items/GetMostViewed/{n}
        /// ROUTING TYPE: attribute-based
        /// </summary>
        /// <returns>An array of {n} Json-serialized objects representing the items with most user views.</returns>
        [HttpGet("GetMostViewed/{n}")]
        public JsonResult GetMostViewed(int n)
        {
            var items = GetSampleItems().OrderByDescending(i => i.ViewCount).Take(n);
            return new JsonResult(items.ToList(), DefaultJsonSettings);
        }

        [HttpGet("GetRandom")]
        public JsonResult GetRandom()
        {
            return GetRandom(DefaultNumberOfItems);
        }

        /// <summary>
        /// GET: api/items/GetRandom/{n}
        /// ROUTING TYPE: attribute-based
        /// </summary>
        /// <returns>An array of {n} Json-serialized objects representing some randomly-picked items.</returns>
        [HttpGet("GetRandom/{n}")]
        public JsonResult GetRandom(int n)
        {
            var items = GetSampleItems().OrderBy(i => Guid.NewGuid()).Take(n);
            return new JsonResult(items, DefaultJsonSettings);
        }

        /// <summary>
        /// Generate a sample array of source Items to emulate a database (for testing purposes only).
        /// </summary>
        /// <param name="num">The number of items to generate: default is 999</param>
        /// <returns>a defined number of mock items (for testing purpose only)
        /// </returns>
        private IEnumerable<ItemViewModel> GetSampleItems(int num = 999)
        {

            DateTime date = new DateTime(2015, 12, 31).AddDays(-num);

            var arr = Enumerable.Range(0, num).Select(counter => new ItemViewModel
            {
                Id = counter,
                Title = string.Format("Item {0} title", counter),
                Description = string.Format("This is a sample description for item {0}: Lorem ipsum dolor sit amet.", counter),
                CreatedDate = date.AddDays(counter),
                LastModifiedDate = date.AddDays(counter),
                ViewCount = num - counter
            });

            return arr;
        }

        /// <summary>
        /// Returns a suitable JsonSerializerSettings object that can be used to generate the JsonResult return value for this
        /// Controller's methods.
        /// </summary>
        private JsonSerializerSettings DefaultJsonSettings
        {
            get
            {
                return new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented
                };
            }
        }

        /// <summary>
        /// Returns the default number of items to retrieve when using the parameterless overloads of the API methods retrieving item lists.
        /// </summary>
        private int DefaultNumberOfItems
        {
            get
            {
                return 5;
            }
        }

        /// <summary>
        /// Returns the maximum number of items to retrieve when using the API methods retrieving item lists.
        /// </summary>
        private int MaxNumberOfItems
        {
            get
            {
                return 100;
            }
        }


        // GET: api/values
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
