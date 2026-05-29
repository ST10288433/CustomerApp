/// <summary>
/// Handles CRUD operations for customer management.
/// Implements filtering, sorting, and paging for the customer list.
/// </summary>

using CustomerApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerApp.Controllers;

public class CustomerController : Controller
{
    private readonly CustomerAppDbContext _context;
    private const int PageSize = 10;

    public CustomerController(CustomerAppDbContext context) => _context = context;

    public async Task<IActionResult> Index(
        string? nameFilter, string? vatFilter,
        string sortColumn = "Name", string sortDirection = "ASC", int page = 1)
    {
        var q = _context.Customers.AsQueryable();

        // name filtering
        if (!string.IsNullOrWhiteSpace(nameFilter))
            q = q.Where(c => c.Name.Contains(nameFilter));
        
        // VAT filtering and handling null values
        if (!string.IsNullOrWhiteSpace(vatFilter))
            q = q.Where(c => c.Vatnumber != null && c.Vatnumber.Contains(vatFilter));

        int total = await q.CountAsync(); // gets total count before paging for view model

        // sorting applied based on column and direction
        q = (sortColumn, sortDirection) switch {
            ("Name",               "DESC") => q.OrderByDescending(c => c.Name),
            ("Address",            "ASC")  => q.OrderBy(c => c.Address),
            ("Address",            "DESC") => q.OrderByDescending(c => c.Address),
            ("TelephoneNumber",    "ASC")  => q.OrderBy(c => c.TelephoneNumber),
            ("TelephoneNumber",    "DESC") => q.OrderByDescending(c => c.TelephoneNumber),
            ("ContactPersonName",  "ASC")  => q.OrderBy(c => c.ContactPersonName),
            ("ContactPersonName",  "DESC") => q.OrderByDescending(c => c.ContactPersonName),
            ("ContactPersonEmail", "ASC")  => q.OrderBy(c => c.ContactPersonEmail),
            ("ContactPersonEmail", "DESC") => q.OrderByDescending(c => c.ContactPersonEmail),
            ("VATNumber",          "ASC")  => q.OrderBy(c => c.Vatnumber),
            ("VATNumber",          "DESC") => q.OrderByDescending(c => c.Vatnumber),
            _ => q.OrderBy(c => c.Name) // default sort by Name ASC
        };

        // applies paging - skip records from previous pages, takes page size
        var customers = await q
            .Skip((page - 1) * PageSize)
            .Take(PageSize)
            .ToListAsync();

        return View(new CustomerListViewModel {
            Customers     = customers,
            NameFilter    = nameFilter,
            VATFilter     = vatFilter,
            SortColumn    = sortColumn,
            SortDirection = sortDirection,
            CurrentPage   = page,
            PageSize      = PageSize,
            TotalCount    = total
        });
    }

    // displays customer creation form
    public IActionResult Create() => View(new Customer());

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Customer customer)
    {
        if (!ModelState.IsValid) return View(customer);
        
        // sets audit timestamps (UTC for consistency across time zones)
        customer.CreatedAt = customer.UpdatedAt = DateTime.UtcNow;
        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();
        
        // uses TempData for one-time notification after redirect
        TempData["Success"] = $"Customer '{customer.Name}' created.";
        return RedirectToAction(nameof(Index));
    }

    // displays the customer edit form
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();
        var c = await _context.Customers.FindAsync(id);
        return c == null ? NotFound() : View(c);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Customer customer)
    {
        if (id != customer.Id) return NotFound();
        if (!ModelState.IsValid) return View(customer);

        var existing = await _context.Customers.FindAsync(id);
        if (existing == null) return NotFound();

        // explicitly updates only allowed properties
        existing.Name               = customer.Name;
        existing.Address            = customer.Address;
        existing.TelephoneNumber    = customer.TelephoneNumber;
        existing.ContactPersonName  = customer.ContactPersonName;
        existing.ContactPersonEmail = customer.ContactPersonEmail;
        existing.Vatnumber          = customer.Vatnumber;
        existing.UpdatedAt          = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        TempData["Success"] = $"Customer '{customer.Name}' updated.";
        return RedirectToAction(nameof(Index));
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var c = await _context.Customers.FindAsync(id);
        if (c != null) { _context.Customers.Remove(c); await _context.SaveChangesAsync(); }
        TempData["Success"] = "Customer deleted.";
        return RedirectToAction(nameof(Index));
    }
}

/// REFERENCES:
/// Microsoft Docs (2026). Pagination, sorting, and filtering in ASP.NET Core. [online] Available at: https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/sort-filter-page [Accessed 29 May 2026].
/// 
/// Microsoft (2026). C# 8.0 Switch Expressions. [online] Available at: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/switch-expression [Accessed 29 May 2026].
/// 
/// Microsoft (2026). EF Core Pagination. [online] Available at: https://docs.microsoft.com/en-us/ef/core/querying/pagination [Accessed 29 May 2026].
/// 
/// Wikipedia (2025). Post-Redirect-Get Pattern. [online] Available at: https://en.wikipedia.org/wiki/Post/Redirect/Get [Accessed 29 May 2026].
/// 
/// Microsoft (2026). Best practices for DateTime in .NET. [online] Available at: https://docs.microsoft.com/en-us/dotnet/standard/datetime/choosing-between-datetime [Accessed 29 May 2026].
/// 
/// Microsoft (2026). TempData in ASP.NET Core. [online] Available at: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/app-state [Accessed 29 May 2026].
/// 
/// Microsoft (2026). Over-posting Attack. [online] Available at: https://docs.microsoft.com/en-us/aspnet/core/mvc/models/overposting [Accessed 29 May 2026].
/// 
/// Mozilla (2026). HTTP Methods. [online] Available at: https://developer.mozilla.org/en-US/docs/Web/HTTP/Methods [Accessed 29 May 2026].