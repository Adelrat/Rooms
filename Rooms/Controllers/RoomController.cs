using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Rooms.Controllers
{
    public class RoomController : Controller
    {
        DataContext _context;
        public RoomController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Show(int id)
        {
            var room = await _context.Rooms.SingleAsync(x => x.Id == id);
            return View(room);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}