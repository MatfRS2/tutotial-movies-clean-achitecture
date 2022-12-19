using Movies.Domain.PripremaContext.PaketAggregate;
using Movies.Domain.PripremaContext.PaketAggregate.Specifications;
using Movies.SharedKernel.Repositories;
using Movies.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Movies.Web.Controllers;

[Route("[controller]")]
public class PaketController : Controller
{
  private readonly IRepository<Paket> _paketRepository;

  public PaketController(IRepository<Paket> paketRepository)
  {
    _paketRepository = paketRepository;
  }

  // GET paket/{paketId?}
  [HttpGet("{paketId:int}")]
  public async Task<IActionResult> Index(int paketId = 1)
  {
    var spec = new PaketSaFilmovimaPoPaketIdSpec(paketId);
    var paket = await _paketRepository.FirstOrDefaultAsync(spec);
    if (paket == null)
    {
      return NotFound();
    }

    var dto = new PaketViewModel
    {
      Id = paket.Id,
      Naziv = paket.Naziv,
      Opis = paket.Opis,
      DatumFormiranja = paket.DatumFormiranja
      //Filmovi = paket.Filmovi
      //              .Select(item => FilmViewModel.FromFilm(item))
      //              .ToList()
    };
    return View(dto);
  }
}
