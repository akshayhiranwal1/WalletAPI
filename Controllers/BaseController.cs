using WalletAPI.Services.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Linq;

namespace WalletAPI.Controllers
{
    /// <summary>
    /// Base api controller all api controllers should inherit from this controller
    /// </summary>
    /// <typeparam name="TViewModel">Type of the view model</typeparam>
    //[Route("api/v{version:apiVersion}/[controller]")]
    [Route("api/[controller]")]
    public class BaseController<TViewModel> : Controller where TViewModel : class
    {
        private IGenericService<TViewModel> GenericService { get; set; }

        /// <summary>
        /// TODO: Pass base validation service and common CRUD operation in the base controller
        /// </summary>
        public BaseController(IGenericService<TViewModel> genericService)
        {
            GenericService = genericService;
        }

        /// <summary>
        /// Gets all the entities
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return new OkObjectResult(await GenericService.GetAll());
        }

        /// <summary>
        /// Gets all the entities
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetByAny/{value}")]
        public async Task<IActionResult> GetByAny([FromRoute][Required]int value)
        {
            return new OkObjectResult(await GenericService.GetByAny(value));
        }

        /// <summary>
        /// Gets teh paged result for the entity requested
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("GetPaged")]
        public async Task<IActionResult> Get([FromQuery, Required]int page, [FromQuery, Required]int pageSize)
        {
            return new OkObjectResult(await GenericService.GetAll(page, pageSize));
        }

        /// <summary>
        /// Gets the entity by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute][Required]int id)
        {
            return new ObjectResult(await GenericService.GetById(id));
        }

        /// <summary>
        /// Inserts the entity
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody]TViewModel model)
        {
            var entity = GenericService.Create(model);
            return new OkObjectResult(entity);
        }

        /// <summary>
        /// Updates the entity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute]int id, [FromBody]TViewModel model)
        {
            GenericService.Update(id, model);
            return new OkResult();
        }

        /// <summary>
        /// Deletes the entity
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute]int id)
        {
            GenericService.Delete(id);
            return new OkResult();
        }

    }
}