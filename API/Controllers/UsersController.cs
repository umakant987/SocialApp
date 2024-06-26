﻿using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[Authorize]
public class UsersController : BaseApiController
{
    private readonly DataContext _context;

    public UsersController(DataContext context)
    {
        _context = context;
    }

    // // Synchronous Code
    // [HttpGet] //  /api/users
    // public ActionResult<IEnumerable<AppUser>> GetUsers()
    // {
    //     var users = _context.Users.ToList();

    //     return users;  // It implicitly returns as Ok(users); because of IEnumerable<AppUser>
    // }

    // Asynchronous Code
    [AllowAnonymous]
    [HttpGet] //  /api/users
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var users = await _context.Users.ToListAsync();

        return users;  // It implicitly returns as Ok(users); because of IEnumerable<AppUser>
    }

    [HttpGet("{id}")]  //  /api/users/2
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
        return await _context.Users.FindAsync(id);
    }
}
