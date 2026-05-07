using Microsoft.AspNetCore.Mvc;
using DockerDemoApp.Data;
using DockerDemoApp.Models;

namespace DockerDemoApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly AppDbContext _context;

        // Constructor Dependency Injection
        public WeatherForecastController(AppDbContext context)
        {
            _context = context;
        }

        // Sample Weather API
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild",
            "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        // GET: api/weatherforecast
        [HttpGet]
        public IEnumerable<WeatherForecast> GetWeather()
        {
            return Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast(
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    Summaries[Random.Shared.Next(Summaries.Length)]
                ));
        }

        // POST: api/weatherforecast/add
        [HttpPost("add")]
        public IActionResult AddItem(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();

            return Ok(new
            {
                Message = "Item added successfully",
                Data = item
            });
        }

        // GET: api/weatherforecast/items
        [HttpGet("items")]
        public IActionResult GetItems()
        {
            var items = _context.Items.ToList();

            return Ok(items);
        }

        // DELETE: api/weatherforecast/delete/1
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteItem(int id)
        {
            var item = _context.Items.Find(id);

            if (item == null)
            {
                return NotFound("Item not found");
            }

            _context.Items.Remove(item);
            _context.SaveChanges();

            return Ok("Item deleted successfully");
        }
    }

    // Weather model
    public record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
    {
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}