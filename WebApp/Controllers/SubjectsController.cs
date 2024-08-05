using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Hosting;
using WebApp.Areas.Identity.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class SubjectsController : Controller
    {
        private readonly WebAppDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public SubjectsController(WebAppDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Subjects
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
            var subjects = from t in _context.Subject
                         select t;
            /*select from the subject table */
            if (!String.IsNullOrEmpty(searchString))
            /*this is searching for the department name containing
             * whatever name the user enters */
            {
                subjects = subjects.Where(s => s.SubjectName.Contains(searchString));

            }
            switch (sortOrder)
            /*this is sorting, the department name is sort in descending order*/
            {
                case "name_desc":
                    subjects = subjects.OrderByDescending(t => t.SubjectName);
                    break;

                /*the default sort order is te order where I havecreated the departments in and
                 * it is not descending or ascending*/
                default:
                    subjects = subjects.OrderBy(s => s.SubjectName);
                    break;
            }
            /*the maximum department displayed on 1 page will be 4*/
            int pageSize = 4;
            return View(await PaginatedList<Subject>.CreateAsync(subjects.AsNoTracking(), pageNumber ?? 1, pageSize));
            return View(subjects.ToList());

            return _context.Subject != null ?
                        View(await _context.Subject.ToListAsync()) :
                        Problem("Entity set 'WebAppDbContext.Subject'  is null.");
        }

        // GET: Subjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Subject == null)
            {
                return NotFound();
            }

            var subject = await _context.Subject
                .FirstOrDefaultAsync(m => m.SubjectID == id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        // GET: Subjects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Subjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubjectID,SubjectName,ImageFile")] Subject subject)
        {
            if (!ModelState.IsValid)
            {
                /*the uploaded images will be saved in the wwwroot- image folder*/
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(subject.ImageFile.FileName);
                string extension = Path.GetExtension(subject.ImageFile.FileName);
                subject.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssffff") + extension;
                string path = Path.Combine(wwwRootPath + "/images", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await subject.ImageFile.CopyToAsync(fileStream);
                }

                _context.Add(subject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(subject);
        }

        // GET: Subjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Subject == null)
            {
                return NotFound();
            }

            var subject = await _context.Subject.FindAsync(id);
            if (subject == null)
            {
                return NotFound();
            }
            return View(subject);
        }

        // POST: Subjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SubjectID,SubjectName")] Subject subject)
        {
            if (id != subject.SubjectID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubjectExists(subject.SubjectID))
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
            return View(subject);
        }

        // GET: Subjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Subject == null)
            {
                return NotFound();
            }

            var subject = await _context.Subject
                .FirstOrDefaultAsync(m => m.SubjectID == id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        // POST: Subjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Subject == null)
            {
                return Problem("Entity set 'WebAppDbContext.Subject'  is null.");
            }
            var subject = await _context.Subject.FindAsync(id);
            if (subject != null)
            {
                _context.Subject.Remove(subject);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubjectExists(int id)
        {
            return (_context.Subject?.Any(e => e.SubjectID == id)).GetValueOrDefault();
        }
    }
}
