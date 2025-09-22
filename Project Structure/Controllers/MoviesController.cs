using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project_Structure.Models;

namespace Project_Structure.Controllers
{
    public class MoviesController : Controller
    {
        //[FromServices] // That like Create from Constructor
        //public IConfiguration Configuration { get; set; }

        #region Routing and Action Return Type
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
        public IActionResult GetMovie(int id, [FromServices] Movie movie)
        {

            if (id == 0)
                //return new BadRequestResult();
                return BadRequest();

            if (id == 100)
                //return new NotFoundResult();
                return NotFound();


            ContentResult result = new ContentResult();
            result.Content = $"<h1>Movie with Id: {id}</h1>";
            result.Content += $"<h1>{movie.ToString()} with Id: {id}</h1>";
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

        #endregion

        #region  Model Action Parameters
        [HttpPost] // POST: baseUrl/Movies/CreateMovie/10 
        public IActionResult CreateMovie(int id) // Model => Action Parameters
        {
            return Ok();
        }

        /// 1. Form Data  -> Input

        /// 2. Route Data -> Segment
        /// Get: baseUrl/Movies/GetMovie/10 

        /// 3. Query String -> Query Param
        /// Get: /Movies/GetMovie?id=10

        /// 4. Request header -> Header

        /// 5. Request Body -> 

        [HttpGet]
        // if just i need IConfiguration just in this Action so, instead of make it in ctor and created object for each action contain IConfiguration,
        // so we used [FromServices] attribute to create them just with this action
        public IActionResult CreateMovie([FromServices] IConfiguration configuration)
        {
            return View();
        }


        [HttpGet]
        public IActionResult CreateMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateMovie(Movie movie)
        {
            return Ok();
        }

        #endregion

    }
}
