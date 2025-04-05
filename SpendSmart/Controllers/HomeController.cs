using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SpendSmart.Models;

namespace SpendSmart.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly SpendSmartDbContext _context;
    public HomeController(ILogger<HomeController> logger, SpendSmartDbContext context)
    {
        _logger = logger;
        _context = context;
    }


    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Expenses()
    {
        var Allexpenses = _context.Expenses.ToList();

        var total = 0m;
        foreach (var expense in Allexpenses)
        {
            total += expense.Value;
        }
        ViewBag.Total = total;
        return View(Allexpenses);
    }

    public IActionResult CreateEditExpense(int? id)
    {
        if (id != null)
        {
            var expense = _context.Expenses.SingleOrDefault(expense => expense.Id == id);
            return View(expense);
        }
        return View();
    }

    public IActionResult DeleteExpense(int id)
    {

        var expense = _context.Expenses.SingleOrDefault(expense => expense.Id == id);
        _context.Expenses.Remove(expense);
        _context.SaveChanges();
        return RedirectToAction("Expenses");
    }

    public IActionResult CreateEditExpenseForm(Expense expense)
    {
        if (expense.Id == 0)
        {
            _context.Expenses.Add(expense);

        }
        else
        {
            _context.Expenses.Update(expense);
        }
        _context.SaveChanges();
        return RedirectToAction("Expenses");
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
