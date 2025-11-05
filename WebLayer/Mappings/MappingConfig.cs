using EntityFramework.Models;
using WebLayer.Dtos;
using Mapster;
using Version = EntityFramework.Models.Version;


namespace WebLayer.Mappings
{
    public static class MappingConfig
    {
        public static void Register(TypeAdapterConfig config)
        {

            config.NewConfig<Person, PersonDto>()
                .Map(dest => dest, src => src)
                .Map(dest => dest.Titles, src => src.ParticipatesInTitles
                    .Where(pt => pt.TconstNavigation != null)
                    .Select(pt => pt.Adapt<PersonTitlesDto>())) 
                .Map(dest => dest.Professions, src => src.PersonProfessions
                    .Where(pp => pp.Profession != null)
                    .Select(pp => pp.Profession.Profession1))
                .Map(dest => dest.PersonRating, src => src.PersonRating != null
                    ? src.PersonRating.WeightedRating
                    : 0);
                

            config.NewConfig<Title, TitleDto>()
                .Map(dest => dest, src => src)
                .Map(dest => dest.TitleExtras, src => src.TitleExtra.Adapt<TitleExtraDto>())
                .Map(dest => dest.TitleRating, src => src.Rating.Adapt<RatingDto>());
            
            config.NewConfig<Genre, GenreDto>()
                .Map(dest => dest, src => src);

            config.NewConfig<Episode, EpisodeDto>()
                .Map(dest => dest.SerieName, src => src.ParenttconstNavigation.Primarytitle)
                .Map(dest => dest.Genres, src => src.ParenttconstNavigation.Genres);
            
            config.NewConfig<Title, PersonTitlesDto>()
                .Map(dest => dest.Title, src => src.Primarytitle)
                .Map(dest => dest.Tconst, src => src.Tconst);

            config.NewConfig<ParticipatesInTitle, PersonTitlesDto>()
                .Map(dest => dest.Title, src => src.TconstNavigation.Primarytitle)
                .Map(dest => dest.Tconst, src => src.TconstNavigation.Tconst)
                .Map(dest => dest.Category, src => src.Category);
            
 
            config.NewConfig<User, UserCreationDto>()
                .Map(dest => dest.Username, src => src.Username)
                .Map(dest => dest.Email, src => src.Email)
                .Map(dest => dest.PasswordHash, src => src.PasswordHash);
        }
    }
}