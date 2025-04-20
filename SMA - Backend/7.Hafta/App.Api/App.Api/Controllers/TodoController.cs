using App.Api.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private AppDbContext Context { get; set; }

        public TodoController(AppDbContext context)
        {
            Context = context;
        }
    }
}
