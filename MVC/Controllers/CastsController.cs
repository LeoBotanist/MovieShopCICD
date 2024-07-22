using ApplicationCore.Contract.Services;
using ApplicationCore.Models.ResponseModels;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers;

public class CastsController: Controller
{
    private readonly ICastService _service;

    public CastsController(ICastService castService)
    {
        this._service = castService;
    }

    public IActionResult Index(int id)
    {
        
        CastResponseModel castModel = _service.GetCastById(id);
        foreach (var movie in castModel.Movies)
        {
            Console.WriteLine(movie.Title);
        }
        return View(castModel);
    }
}