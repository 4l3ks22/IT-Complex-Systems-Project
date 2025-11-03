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
                    .Select(pt => pt.TconstNavigation.Adapt<TitleDto>()))
                .Map(dest => dest.KnownForTitles, src => src.KnownForTitles
                    .Where(kt => kt.TconstNavigation != null)
                    .Select(kt => kt.TconstNavigation.Adapt<TitleDto>()))
                .Map(dest => dest.Professions, src => src.PersonProfessions
                    .Where(pp => pp.Profession != null)
                    .Select(pp => pp.Profession.Profession1))
                .Map(dest => dest.PersonRating, src => src.PersonRating != null
                    ? src.PersonRating.WeightedRating
                    : 0);

            config.NewConfig<Title, TitleDto>()
                .Map(dest => dest, src => src)
                .Map(dest => dest.TitleExtras, src => src.TitleExtra.Adapt<TitleExtraDto>())
                .Map(dest => dest.TitleRating, src => src.Rating.Adapt<RatingDto>())
                .Map(dest => dest.Versions, src => src.Versions.Adapt<List<VersionDto>>());
            
            config.NewConfig<Genre, GenreDto>()
                .Map(dest => dest, src => src);

            config.NewConfig<Episode, EpisodeDto>()
                .Map(dest => dest.SerieName, src => src.ParenttconstNavigation.Primarytitle)
                .Map(dest => dest.Genres, src => src.ParenttconstNavigation.Genres);
            //.Map(dest => dest.TitleUrl, src => $"/api/titles/{src.ParenttconstNavigation.Tconst.Trim()}"); // this one is not necessary now,
                                                                                                            //but works in case we wanted a relative and not absolute titleurl
                                                                                                            //without implementing it in the Episodedcontroller in CreateEpisodeDto method
                                                                                                            
            // config.NewConfig<Version, VersionDto>()
            //     .Map(dest => dest.Isoriginaltitle, src => src.Tconst);
            
            config.NewConfig<KnownForTitle, KnownForTitleDto>()
                .Map(dest => dest.TconstNavigation, src => src.TconstNavigation.Primarytitle);

            config.NewConfig<TitleDto, PersonTitlesDto>()
                .Map(dest => dest.Url, src => src.Url)
                .Map(dest => dest.Title, src => src.Primarytitle);

            config.NewConfig<User, UserCreationDto>()
                .Map(dest => dest.UserName, src => src.Username)
                .Map(dest => dest.Email, src => src.Email)
                .Map(dest => dest.Password, src => src.PasswordHash);
        }
    }
}