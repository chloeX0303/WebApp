using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Areas.Identity.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly WebAppDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public DepartmentsController(WebAppDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Departments
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
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
            /*select from the department table*/
            var departments = from t in _context.Department
                           select t;
            if (!String.IsNullOrEmpty(searchString))
                /*this is searching for the department name containing
                 * whatever name the user enters */
            {
                departments = departments.Where(s => s.DepartmentName.Contains(searchString));

            }
            switch (sortOrder)
                /*this is sorting, the department name is sort in descending order*/
            {
                case "name_desc":
                    departments = departments.OrderByDescending(t => t.DepartmentName);
                    break;
                    /*the default sort order is te order where I havecreated the departments in and
                     * it is not descending or ascending*/
                default:
                    departments = departments.OrderBy(s => s.DepartmentName);
                    break;
            }
            /*the maximum department displayed on 1 page will be 4*/
            int pageSize = 4;
            return View(await PaginatedList<Department>.CreateAsync(departments.AsNoTracking(), pageNumber ?? 1, pageSize));
            return View(departments.ToList());
            return _context.Department != null ?
                        View(await _context.Department.ToListAsync()) :
                        Problem("Entity set 'WebAppDbContext.Department'  is null.");
        }

        // GET: Departments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Department == null)
            {
                return NotFound();
            }

            var department = await _context.Department
                .FirstOrDefaultAsync(m => m.DepartmentID == id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // GET: Departments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DepartmentID,DepartmentName,ImageFile")] Department department)
        {
            if (!ModelState.IsValid)
            {
                /*the uploaded images will be saved in the wwwroot- image folder*/
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(department.ImageFile.FileName);
                string extension = Path.GetExtension(department.ImageFile.FileName);
                department.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssffff") + extension;
                string path = Path.Combine(wwwRootPath + "/images", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await department.ImageFile.CopyToAsync(fileStream);
                }

                _context.Add(department);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        // GET: Departments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Department == null)
            {
                return NotFound();
            }

            var department = await _context.Department.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DepartmentID,DepartmentName")] Department department)
        {
            if (id != department.DepartmentID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(department);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentExists(department.DepartmentID))
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
            return View(department);
        }

        // GET: Departments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Department == null)
            {
                return NotFound();
            }

            var department = await _context.Department
                .FirstOrDefaultAsync(m => m.DepartmentID == id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Department == null)
            {
                return Problem("Entity set 'WebAppDbContext.Department'  is null.");
            }
            var department = await _context.Department.FindAsync(id);
            if (department != null)
            {
                _context.Department.Remove(department);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentExists(int id)
        {
            return (_context.Department?.Any(e => e.DepartmentID == id)).GetValueOrDefault();
        }
    }
}
