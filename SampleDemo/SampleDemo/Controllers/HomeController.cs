using Microsoft.AspNetCore.Mvc;
using SampleDemo.Database;
using SampleDemo.Domain;

namespace SampleDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly AppDbContext donarsDbContext;

        public HomeController(AppDbContext donarsDbContext)
        {
            this.donarsDbContext = donarsDbContext;
        }
        [HttpPost]
        public async Task<IActionResult> AddDonar([FromBody] Donar donar)
        {
            
            await donarsDbContext.Donors.AddAsync(donar);
            await donarsDbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
