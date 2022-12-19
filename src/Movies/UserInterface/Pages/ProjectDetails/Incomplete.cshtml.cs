using Movies.Domain.PripremaContext.FilmAggregate;
using Movies.Domain.PripremaContext.PaketAggregate;
using Movies.Domain.PripremaContext.PaketAggregate.Specifications;
using Movies.SharedKernel.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Movies.Web.Pages.PaketDetails;

public class IncompleteModel : PageModel
{
  private readonly IRepository<Paket> _repository;

  [BindProperty(SupportsGet = true)]
  public int PaketId { get; set; }

  public List<Film>? Films { get; set; }

  public IncompleteModel(IRepository<Paket> repository)
  {
    _repository = repository;
  }

  public async Task OnGetAsync()
  {
    var paketSpec = new PaketSaFilmovimaPoPaketIdSpec(PaketId);
    var paket = await _repository.FirstOrDefaultAsync(paketSpec);
    if (paket == null)
    {
      return;
    }
    // var spec = new IncompleteItemsSpec();
    //Films = spec.Evaluate(paket.Filmovi).ToList();

    Films = new List<Film>() { new Film("proba", new DateTime(1970,1,1), -1, "proba zanr")};
  }
}
