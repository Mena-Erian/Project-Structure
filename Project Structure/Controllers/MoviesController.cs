using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project_Structure.Models;

namespace Project_Structure.Controllers
{
    public class MoviesController : Controller
    {
        // Action //==>Any public Non-Static Object Member Method inside Controller

        [HttpGet] // GET: baseUrl/Movies/GetMovie/{id}?name=
        public string Index()
        {
            return "All Movies";
        }


        // baseUrl/Movies/GetMovie/{id}
        //                       Model
        public string GetMovie(/*[FromRoute]*/ int id, string name)
        {
            Console.WriteLine(id);
            return $"Movie {name} with Id: {id}";
        }
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
