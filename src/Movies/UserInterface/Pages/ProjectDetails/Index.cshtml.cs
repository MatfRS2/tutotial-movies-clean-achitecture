using Movies.Domain.PripremaContext.PaketAggregate;
using Movies.Domain.PripremaContext.PaketAggregate.Specifications;
using Movies.SharedKernel.Repositories;
using Movies.Web.ApiModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Movies.Domain.PripremaContext.FilmAggregate;

namespace Movies.Web.Pages.PaketDetails;

public class IndexModel : PageModel
{
  private readonly IRepository<Paket> _repository;

  [BindProperty(SupportsGet = true)]
  public int PaketId { get; set; }

  public string Message { get; set; } = "";

  public PaketDTO? Paket { get; set; }

  public IndexModel(IRepository<Paket> repository)
  {
    _repository = repository;
  }

  public async Task OnGetAsync()
  {
    var paketSpec = new PaketSaFilmovimaPoPaketIdSpec(PaketId);
    var paket = await _repository.FirstOrDefaultAsync(paketSpec);
    if (paket == null)
    {
      Message = "No paket found.";

      return;
    }

    Paket = new PaketDTO
    (
        id: paket.Id,
        naziv: paket.Naziv,
        opis: paket.Opis,
        filmovi: new List<FilmDTO>() { new FilmDTO() }
        //.Select(item => FilmDTO.FromFilm(item))
        .ToList()
    );
  }
}
