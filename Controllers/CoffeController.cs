using CoffeShopAPI.Model;
using CoffeShopAPI.Repository;
using CoffeShopAPI.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoffeShopAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CoffeController : ControllerBase
    {
        private readonly ICoffeService coffeService;

        public CoffeController(ICoffeService coffe)
        {
            coffeService = coffe;
        }
        // GET: api/<CoffeController>
        [HttpGet]
        public async Task<IActionResult> Get()          // This Controller is executing SelectAllMenu method.
        {
            var result = await coffeService.SelectAllMenu();
            return Ok(result);
        }

        // GET api/<CoffeController>/5
        [HttpGet("id/{id}")]
        public async Task<IActionResult> Get(int id)    // This Controller is executing SelectMenuById method.
        {
            var output = await coffeService.SelectMenuById(id);
            return Ok(output);
        }

        // POST api/<CoffeController>
        [HttpPost]
        //public async Task<IActionResult>
        public async Task<IActionResult> Post([FromBody] CoffeModel coffe)       // This Controller is executing AddMenu method.
        {
            var output = await coffeService.AddMenu(coffe);
            return RedirectToAction(nameof(Get));
        }

        // PUT api/<CoffeController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(CoffeModel coffe, int id)          // This controller is executing UpdateMenu method
        {
            var output = await coffeService.UpdateMenu(coffe, id);
            return Ok(output);
        }

        // DELETE api/<CoffeController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var output = await coffeService.DeleteMenu(id);                  // This Controller is executing DeleteMenu method.
            return Ok(output);
        }
    }
}
