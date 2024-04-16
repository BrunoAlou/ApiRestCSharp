using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeniorApi.Data;
using SeniorApi.Models;

namespace SeniorApi.Controllers
{
  [Route("v1/users")]
  [Authorize]
  public class UserController : Controller
  {
    private readonly DataContext _context;

    public UserController(DataContext context)
    {
      _context = context;
    }

    // GET v1/users/list
    [HttpGet("list")]
    public async Task<ActionResult<List<User>>> GetAllUsers()
    {
      var users = await _context.User.ToListAsync();
      return users;
    }

    // POST v1/users/create
    [HttpPost("create")]
    public async Task<ActionResult<User>> CreateUser([FromBody] User model)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      _context.User.Add(model);
      await _context.SaveChangesAsync();
      return model;
    }

    // GET v1/users/list/userCode?code={code}
    [HttpGet("list/userCode")]
    public async Task<ActionResult<List<User>>> GetUserByCode(string code)
    {
      var users = await _context.User.AsNoTracking()
          .Where(x => x.UserCode == code)
          .ToListAsync();

      return users;
    }

    // GET v1/users/list/userUf?Uf={Uf}
    [HttpGet("list/userUf")]
    public async Task<ActionResult<List<User>>> GetUserByUf(string Uf)
    {
      var users = await _context.User.AsNoTracking()
          .Where(x => x.UF == Uf)
          .ToListAsync();

      return users;
    }

    // PUT v1/users/update/{id}
    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateUser(int id, [FromBody] User model)
    {
      if (id != model.Id)
        return BadRequest(new { message = "ID do usuário não corresponde" });

      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      _context.Entry(model).State = EntityState.Modified;
      await _context.SaveChangesAsync();
      return NoContent();
    }

    // DELETE v1/users/delete/{id}
    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
      var user = await _context.User.FindAsync(id);
      if (user == null)
        return NotFound(new { message = "Usuário não encontrado" });

      _context.User.Remove(user);
      await _context.SaveChangesAsync();
      return NoContent();
    }
  }
}
