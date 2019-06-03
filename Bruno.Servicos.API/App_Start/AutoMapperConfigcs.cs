using System.Linq;
using AutoMapper;

namespace Bruno.Servicos.API.App_Start
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            var automapperProfiles = typeof(AutoMapperConfig).Assembly.GetTypes()
                           .Where(type => type.IsSubclassOf(typeof(Profile)));

            Mapper.Initialize(cfg =>
            {
                foreach (var automapperProfile in automapperProfiles)
                {
                    cfg.AddProfile(automapperProfile);
                }
            });
        }
    }
}