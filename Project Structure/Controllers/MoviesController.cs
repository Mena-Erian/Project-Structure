using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project_Structure.Models;

namespace Project_Structure.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IConfiguration _configuration;
        public MoviesController(IConfiguration configuration) // Ask CLR for Creating Object from Class implement interface IConfiguration
        {
            _configuration = configuration;
        }

        // Action //==>Any public Non-Static Object Member Method inside Controller

        [HttpGet] // GET: baseUrl/Movies/GetMovie/{id}?name=
        public string Index()
        {
            return "All Movies";
        }
        // GET: baseUrl/Movies/GetMovie/{id}
        public IActionResult GetMovie(int id)
        {

            if (id == 0)
                //return new BadRequestResult();
                return BadRequest();

            if (id == 100)
                //return new NotFoundResult();
                return NotFound();


            ContentResult result = new ContentResult();
            result.Content = $"<h1>Movie with Id: {id}</h1>";
            result.ContentType = "text/html";
            //result.ContentType = "object/pdf";
            //result.StatusCode = 200;



            /// try
            /// {
            ///     string str = null;
            ///     var number = str.Length;
            /// }
            /// catch (System.Exception ex)
            /// {
            ///     result.Content = ex.Message;
            /// 	result.ContentType = "text/html";
            /// 	result.StatusCode = 200;
            /// }
            return result;
        }

        public IActionResult Hamda()
        {
            /// //RedirectResult redirectResult = new RedirectResult("https://www.google.com");
            /// //RedirectResult redirectResult = new RedirectResult(_configuration["GoogleUrl"] ?? string.Empty);
            /// //RedirectResult redirectResult = new RedirectResult($"{_configuration["BaseUrl"]}/Movies/GetMovie/11");
            /// 
            /// //RedirectToActionResult redirectResult = new RedirectToActionResult(nameof(GetMovie), "Movies", new { id = 54 });
            /// 
            /// RedirectToRouteResult result = new RedirectToRouteResult("default", null);
            /// 
            /// return result;

            return Redirect(_configuration["GoogleUrl"] ?? string.Empty);
            //return RedirectToAction(nameof(GetMovie), "Movies", new { id = 54 });
#warning not work //return RedirectToRoute("default", null); 
        }


        // baseUrl/Movies/GetMovie/{id}
        //                       Model
        /// public string GetMovie(/*[FromRoute]*/ int id, string name)
        /// {
        ///     Console.WriteLine(id);
        ///     return $"Movie {name} with Id: {id}";
        /// }
        /// [Authorize(Roles = "VIP")]
        /// [HttpGet]
        /// //[AcceptVerbs("GET","POST")]
        /// public ViewResult CreateMovie()
        /// {
        ///     return new ViewResult();
        /// }
        /// [HttpPost]
        /// //[ActionName("ConfirmCreateMovie")]
        /// public OkResult CreateMovie(Movie mode)
        /// {
        ///     return new OkResult();
        /// }



    }
}
