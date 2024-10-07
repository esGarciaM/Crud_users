using API.Utility;
using BL;
using ENTITIES;
using ENTITIES.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private EntityManager<User> _user;
        public UserController(Context context,WriteContext wContext) { 
            _user = new EntityManager<User>(context, wContext);
        }
        [HttpGet("version")]
        public IActionResult Version()
        {
            return Ok("Version 0.1");
        }
        [HttpPost]
        public async Task<IActionResult> Create(User user) {
            int result = await _user.Add(user);
            var Response = new Message();
            Response.EvaluateInt(result,"Unable to create User");
            return Response.ActionResult();
        }
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            List<User> users = await _user.GetList();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            User? user = await _user.Get(id);
            return Ok(user);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(User user,int id)
        {
            user.Id = id;
            int result = await _user.Update(user);
            var response = new Message();
            response.EvaluateInt(result,"Error on User update");
            return response.ActionResult();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            int result = await _user.Delete(id);
            var Response = new Message();
            Response.EvaluateInt(result,"Error on user Delete");
            return Response.ActionResult();
        }

    }
}
