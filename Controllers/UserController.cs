using Microsoft.AspNetCore.Mvc;

namespace MongoCRUD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly MongoDbService mongoDbService;

        public UserController(IConfiguration configuration)
        {
            mongoDbService = new MongoDbService(configuration);
        }

        [HttpPost]
        public async Task Create(User user) => await mongoDbService.Create(user);

        [HttpGet]
        public async Task<User> Read(string id) => await mongoDbService.Read(id);
        [HttpPatch]
        public async Task Update(User user) => await mongoDbService.Update(user);
        [HttpDelete]
        public async Task Delete(string id) => await mongoDbService.Delete(id);
    }
}