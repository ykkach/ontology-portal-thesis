using Microsoft.AspNetCore.Mvc;
using Onto.BLL.Models;
using Onto.BLL.Services.Abstractions;

namespace OntoWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ConceptController : ControllerBase
    {
        private readonly IConceptService _conceptService;

        public ConceptController(IConceptService conceptService)
        {
            _conceptService = conceptService;
        }

        ////GET: /api/concepts/?...=Jon%20Snow&Year=1996
        //[HttpGet]
        //public ActionResult<IEnumerable<Concept>> GetByFilter([FromQuery] FilterSearchModel model)
        //{
        //    var data = _bookService.GetByFilter(model);
        //    return new ActionResult<IEnumerable<BookModel>>(data);
        //}

        ////GET: /api/books/1
        //[HttpGet("{id}")]
        //public async Task<ActionResult<BookModel>> GetById(int id)
        //{
        //    var book = await _bookService.GetByIdAsync(id);
        //    return new ActionResult<BookModel>(book);
        //}

        //POST: /api/concepts/
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] ConceptChildren conceptModel)
        {
            try
            {
                await _conceptService.AddAsync(conceptModel);
                return Ok($"Concept {conceptModel.Uri} successfully added!");
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
                //return BadRequest("Failed to add the book");
            }
        }

        [HttpGet("{uri}")]
        public async Task<IActionResult> GetConcept(string uri)
        {
            Concept concept = await _conceptService.GetConceptByUriAsync(uri);

            if (concept == null)
                return NotFound();

            return Ok(concept);
        }
    }
}
