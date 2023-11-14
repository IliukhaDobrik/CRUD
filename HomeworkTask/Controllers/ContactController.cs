using DataLayer;
using DataLayer.Entities;
using HomeworkTask.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeworkTask.Controllers;

public class ContactController : Controller
{
    private readonly MyDbContext _context;

    public ContactController(MyDbContext context)
    {
        _context = context;
    }

    // GET: Contact/Index
    public async Task<IActionResult> Index()
    {
        return View(await _context.Contacts.AsNoTracking().ToListAsync());
    }
    
    // GET: Contact/Delete/Guid
    public async Task<IActionResult> Delete(Guid contactId)
    {
        var contact = await _context.Contacts.FindAsync(contactId);
        _context.Contacts.Remove(contact);
        await _context.SaveChangesAsync();
        
        return RedirectToAction("Index");
    }

    // GET: Contact/CreateOrEdit/{Guid?}
    [HttpGet]
    public async Task<IActionResult> CreateOrEdit(Guid? contactId = null)
    {
        if (contactId is null)
        {
            return View(new Contact());
        }

        var contact = await _context.Contacts.FindAsync(contactId);
        return View(contact);
    }
    
    // POST: Contact/CreateOrEdit
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateOrEdit(Contact contactModel)
    {
        if (ModelState.IsValid)
        {
            if (contactModel.ContactId == Guid.Empty)
            {
                await _context.Contacts.AddAsync(contactModel);
                await _context.SaveChangesAsync();
            }
            else
            {
                _context.Contacts.Update(contactModel);
                await _context.SaveChangesAsync();
            }

            return Json(new
            {
                isValid = true,
                html = RenderHelper.RenderRazorViewToString(this, "_ViewAll",
                    await _context.Contacts.ToListAsync())
            });
        }
        
        return Json(new
        {
            isValid = false, 
            html = RenderHelper.RenderRazorViewToString(this, "CreateOrEdit", contactModel)
        });
    }
}