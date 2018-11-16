using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Qcet.Models;

namespace Qcet.Controllers {
  /// <summary>User info endpoint controller.</summary>
  [Route("api/[controller]")]
  [ApiController]
  public class UsersController : ControllerBase {
    private readonly QcetContext _ctx;

    /// <summary>Constructor.</summary>
    public UsersController(QcetContext ctx) {
      _ctx = ctx;
    }

    /// <summary>Retrieves a list of all users.</summary>
    [HttpGet]
    public ActionResult<IEnumerable<User>> Get() {
      return _ctx.Users;
    }

    /// <summary>Retrieves data of a specific user.</summary>
    [HttpGet("{id}")]
    public ActionResult<User> Get(int id) {
      var user = _ctx.Users.Find(id);
      if(user == null) {
        return NotFound();
      }
      return user;
    }

    /// <summary>Adds a new user.</summary>
    [HttpPost]
    public void Post([FromBody] User user) {
      _ctx.Users.Add(user);
      _ctx.SaveChanges();
    }

    /// <summary>Updates a specific user.</summary>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] User userUpdate) {
      var user = _ctx.Users.Find(id);
      if(user == null) {
        return NotFound();
      }

      user.FirstName = userUpdate.FirstName;
      user.FamilyName = userUpdate.FamilyName;
      user.Nick = userUpdate.Nick;
      user.City = userUpdate.City;

      _ctx.Users.Update(user);
      _ctx.SaveChanges();
      return NoContent();
    }

    /// <summary>Deletes a specific user.</summary>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id) {
      var user = _ctx.Users.Find(id);
      if(user == null) {
        return NotFound();
      }

      _ctx.Users.Remove(user);
      return NoContent();
    }
  }
}
