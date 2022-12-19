using Autofac;
using Movies.Domain.PripremaContext.Services;

namespace Movies.Core;

public class DefaultCoreModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterType<ObrisiFilmService>()
        .As<IObrisiFilmService>().InstancePerLifetimeScope();
    builder.RegisterType<PretragaPaketiFilmoviService>()
        .As<IPretragaPaketiFilmoviService>().InstancePerLifetimeScope();
  }
}
