﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Areas.Identity.Data;
using WebApp.Models;
using PagedList;
using Microsoft.CodeAnalysis.Options;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.Controllers
{
    public class StaffsController : Controller
    {
        private readonly WebAppDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

       public StaffsController(WebAppDbContext context,IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Staffs
        public async Task<IActionResult> Index(string sortOrder,string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
             /*this is for paging. if a search is done, the page will reset to the number 1*/
            if (searchString != null)   
               
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;
            /*select from the staff table*/
            var staffs = from t in _context.Staff
                           select t;
            if (!String.IsNullOrEmpty(searchString))    
                /*this is searching for the first and last name containing
                 * whatever name the user enters */
            {
                staffs = staffs.Where(s => s.LastName.Contains(searchString)
                                       || s.FirstName.Contains(searchString));
            }
            switch (sortOrder)
                /*this is sorting. the last name is sort in descending order*/
            {
                case "name_desc":
                    staffs = staffs.OrderByDescending(t => t.LastName);
                    break;
              /*the default sort order is the order where I created them in, 
               the default is not in a descending and not ascending order*/
                default:
                    staffs = staffs.OrderBy(s => s.LastName);
                    break;
            }
            /*4 will be the maximum number of staffs on 1 page*/
            int pageSize = 4;
            
            return View(await PaginatedList<Staff>.CreateAsync(staffs.AsNoTracking(), pageNumber ?? 1, pageSize));
            return View(staffs.ToList());

            return _context.Staff != null ?
                        View(await _context.Staff.ToListAsync()) :
                        Problem("Entity set 'WebAppDbContext.Staff'  is null.");
        }

        // GET: Staffs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Staff == null)
            {
                return NotFound();
            }

            var staff = await _context.Staff
                .FirstOrDefaultAsync(m => m.StaffID == id);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        // GET: Staffs/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Staffs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StaffID,FirstName,MidName,LastName,Email,PhoneNumber,ImageFile")] Staff staff)
        {
            if (!ModelState.IsValid)
            {
                /*the uploaded images will be saved in the wwwroot- image folder*/
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(staff.ImageFile.FileName);
                string extension = Path.GetExtension(staff.ImageFile.FileName);
                staff.ImageName=fileName = fileName + DateTime.Now.ToString("yymmssffff") + extension;
                string path = Path.Combine(wwwRootPath + "/images", fileName);
                using (var fileStream = new FileStream(path,FileMode.Create))
                {
                    await staff.ImageFile.CopyToAsync(fileStream);
                }

                _context.Add(staff);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index
                    ));
            }
            return View(staff);
        }

        // GET: Staffs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Staff == null)
            {
                return NotFound();
            }

            var staff = await _context.Staff.FindAsync(id);
            if (staff == null)
            {
                return NotFound();
            }
            return View(staff);
        }

        // POST: Staffs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StaffID,FirstName,MidName,LastName,Email,PhoneNumber")] Staff staff)
        {
            if (id != staff.StaffID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staff);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffExists(staff.StaffID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(staff);
        }

        // GET: Staffs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Staff == null)
            {
                return NotFound();
            }

            var staff = await _context.Staff
                .FirstOrDefaultAsync(m => m.StaffID == id);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        // POST: Staffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Staff == null)
            {
                return Problem("Entity set 'WebAppDbContext.Staff'  is null.");
            }
            var staff = await _context.Staff.FindAsync(id);
            if (staff != null)
            {
                _context.Staff.Remove(staff);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StaffExists(int id)
        {
            return (_context.Staff?.Any(e => e.StaffID == id)).GetValueOrDefault();
        }
    }
}
