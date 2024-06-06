using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using URLShortener.Bussiness;
using URLShortener.Bussiness.Interfaces;

namespace URLShortener.Presentation.Controllers;

public class UrlController:Controller
{
    private readonly IUrlService _urlService;
    
    public UrlController(IUrlService urlService)
    {
        _urlService = urlService ?? throw new ArgumentNullException(nameof(urlService));
    }
    
    public IActionResult Index()
    {
        // var pathToAngularApp = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "js", "client", "browser",  "index.html");
        // return PhysicalFile(pathToAngularApp, "text/html");
        return View();
    }
    [Route("/{path}")]
    public IActionResult Go(string path)
    {
        if (path == null || path == string.Empty || !Regex.IsMatch(path, "^[a-zA-Z0-9]*$"))
            return BadRequest();

        var id = _urlService.Decode(path);
        var origin = _urlService.GetById(id);
        if (origin == null)
            return NotFound();

        return Redirect(origin.FullUrl);
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _urlService.GetAll();
        if (!User.IsInRole(Constants.Admin))
            result = result.Where(x => x.CreatedBy.Equals(User.Identity.Name));

        return Ok(result);
    }
    [HttpGet]
    public IActionResult Info(int id)
    {
        var result = _urlService.GetById(id);
        if (!User.IsInRole(Constants.Admin) && !User.Identity.Name.Equals(result.CreatedBy))
        {
            return Unauthorized();
        }

        return View(result);
    }
}