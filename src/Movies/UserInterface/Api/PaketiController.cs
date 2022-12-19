using Movies.Domain.PripremaContext.PaketAggregate;
using Movies.Domain.PripremaContext.PaketAggregate.Specifications;
using Movies.SharedKernel.Repositories;
using Movies.Web.ApiModels;
using Microsoft.AspNetCore.Mvc;

namespace Movies.Web.Api;

/// <summary>
/// A sample API Controller. Consider using API Endpoints (see Endpoints folder) for a more SOLID approach to building APIs
/// https://github.com/ardalis/ApiEndpoints
/// </summary>
public class PaketiController : BaseApiController
{
  private readonly IRepository<Paket> _repository;

  public PaketiController(IRepository<Paket> repository)
  {
    _repository = repository;
  }

  // GET: api/Paket
  [HttpGet]
  public async Task<IActionResult> List()
  {
    var paketDTOs = (await _repository.ListAsync())
        .Select(paket => new PaketDTO
        (
            id: paket.Id,
            naziv: paket.Naziv,
            opis: paket.Opis
        ))
        .ToList();

    return Ok(paketDTOs);
  }

  // GET: api/Paket
  [HttpGet("{id:int}")]
  public async Task<IActionResult> GetById(int id)
  {
    var paketSpec = new PaketSaFilmovimaPoPaketIdSpec(id);
    var paket = await _repository.FirstOrDefaultAsync(paketSpec);
    if (paket == null)
    {
      return NotFound();
    }

    var result = new PaketDTO
    (
        id: paket.Id,
        naziv: paket.Naziv,
        opis: paket.Opis,
        filmovi: new List<FilmDTO>
        (
        //paket.Items.Select(i => FilmDTO.FromFilm(i)).ToList()
        )
    );

    return Ok(result);
  }

  // POST: api/Paket
  [HttpPost]
  public async Task<IActionResult> Post([FromBody] CreatePaketDTO request)
  {
    var newPaket = new Paket(request.Naziv, request.Opis, request.DatumFormiranja.GetValueOrDefault());

    var createdPaket = await _repository.AddAsync(newPaket);

    var result = new PaketDTO
    (
    id: createdPaket.Id,
    naziv: createdPaket.Naziv,
    opis: createdPaket.Opis
    );
    return Ok(result);
  }

  // PATCH: api/Paket/{paketId}/complete/{itemId}
  [HttpPatch("{paketId:int}/complete/{itemId}")]
  public async Task<IActionResult> Complete(int paketId, int itemId)
  {
    var paketSpec = new PaketSaFilmovimaPoPaketIdSpec(paketId);
    var paket = await _repository.FirstOrDefaultAsync(paketSpec);
    if (paket == null)
      return NotFound("No such paket");

    var toDoItem = paket.Filmovi.FirstOrDefault(item => item.Id == itemId);
    if (toDoItem == null)
      return NotFound("No such item.");

    await _repository.UpdateAsync(paket);

    return Ok();
  }
}
