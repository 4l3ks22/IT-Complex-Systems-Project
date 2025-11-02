using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Version = EntityFramework.Models.Version;

namespace EntityFramework;

/// <summary>
/// Generated database entities, relations and context using dotnet ef scaffold 
/// </summary>
public class MyDbContext : DbContext
{

    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
    }

    public DbSet<Episode> Episodes { get; set; }

    public DbSet<Genre> Genres { get; set; }

    public DbSet<ParticipatesInTitle> ParticipatesInTitles { get; set; }

    public DbSet<Person> Persons { get; set; }

    public DbSet<PersonProfession> PersonProfessions { get; set; }

    public DbSet<PersonRating> PersonRatings { get; set; }

    public DbSet<Profession> Professions { get; set; }

    public DbSet<Rating> Ratings { get; set; }
    public DbSet<Title> Titles { get; set; }

    public DbSet<TitleExtra> TitleExtras { get; set; }
    public DbSet<TitleGenre> TitleGenres { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<UserBookmark> UserBookmarks { get; set; }

    public DbSet<UserRatingHistory> UserRatingHistories { get; set; }

    public  DbSet<UserSearchHistory> UserSearchHistories { get; set; }

    public DbSet<Version> Versions { get; set; }

    public DbSet<WordIndex> WordIndices { get; set; }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
         
        modelBuilder.Entity<Episode>(entity =>
        {
            entity.HasKey(e => e.Tconst).HasName("pk_tconst_episode");

            entity.ToTable("episodes");

            entity.Property(e => e.Tconst)
                .HasMaxLength(10)
                //.IsFixedLength() //causing a mismatch
                .HasColumnName("tconst");
            entity.Property(e => e.Episodenumber).HasColumnName("episodenumber");
            entity.Property(e => e.Parenttconst)
                .HasMaxLength(10)
                //.IsFixedLength() //causing a mismatch
                .HasColumnName("parenttconst");
            entity.Property(e => e.Seasonnumber).HasColumnName("seasonnumber");

            entity.HasOne(d => d.ParenttconstNavigation).WithMany(p => p.Episodes)
                .HasForeignKey(d => d.Parenttconst)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_tconst_episode");
        });
        


        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.GenreId).HasName("genres_pkey");

            entity.ToTable("genres");

            entity.HasIndex(e => e.GenreName, "genres_genre_key").IsUnique();

            entity.Property(e => e.GenreId).HasColumnName("genre_id");
            entity.Property(e => e.GenreName)
                .HasMaxLength(50)
                .HasColumnName("genre");
        });

        modelBuilder.Entity<ParticipatesInTitle>(entity =>
        {
            entity.HasKey(e => e.ParticipationId).HasName("participates_in_title_pkey");

            entity.ToTable("participates_in_title");

            entity.HasIndex(e => new { e.Tconst, e.Nconst, e.ProfessionId, e.Ordering }, "unique_participation").IsUnique();

            entity.Property(e => e.ParticipationId).HasColumnName("participation_id");
            entity.Property(e => e.Category)
                .HasMaxLength(50)
                .HasColumnName("category");
            entity.Property(e => e.Characters).HasColumnName("characters");
            entity.Property(e => e.Job).HasColumnName("job");
            entity.Property(e => e.Nconst)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("nconst");
            entity.Property(e => e.Ordering).HasColumnName("ordering");
            entity.Property(e => e.ProfessionId).HasColumnName("profession_id");
            entity.Property(e => e.Tconst)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("tconst");

            entity.HasOne(d => d.NconstNavigation).WithMany(p => p.ParticipatesInTitles)
                .HasForeignKey(d => d.Nconst)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_nconst_participates");

            entity.HasOne(d => d.TconstNavigation).WithMany(p => p.ParticipatesInTitles)
                .HasForeignKey(d => d.Tconst)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_tconst_participates");

            entity.HasOne(d => d.PersonProfession).WithMany(p => p.ParticipatesInTitles)
                .HasForeignKey(d => new { d.Nconst, d.ProfessionId })
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_profession_participates");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Nconst).HasName("pk_nconst_namebasics");

            entity.ToTable("persons");

            entity.Property(e => e.Nconst)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("nconst");
            entity.Property(e => e.Birthyear)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("birthyear");
            entity.Property(e => e.Deathyear)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("deathyear");
            entity.Property(e => e.Primaryname)
                .HasMaxLength(256)
                .HasColumnName("primaryname");

            entity.HasMany(d => d.Tconsts).WithMany(p => p.Nconsts)
                .UsingEntity<Dictionary<string, object>>(
                    "KnownForTitle",
                    r => r.HasOne<Title>().WithMany()
                        .HasForeignKey("Tconst")
                        .HasConstraintName("fk_tconst_known_for_title"),
                    l => l.HasOne<Person>().WithMany()
                        .HasForeignKey("Nconst")
                        .HasConstraintName("fk_nconst_known_for_title"),
                    j =>
                    {
                        j.HasKey("Nconst", "Tconst").HasName("pk_nconst_tconst");
                        j.ToTable("known_for_title");
                    });
        });

        modelBuilder.Entity<PersonProfession>(entity =>
        {
            entity.HasKey(e => new { e.Nconst, e.ProfessionId }).HasName("pk_nconst_profession");

            entity.ToTable("person_profession");

            entity.Property(e => e.Nconst)
                .HasMaxLength(20)
                .HasColumnName("nconst");
            entity.Property(e => e.ProfessionId).HasColumnName("profession_id");

            entity.HasOne(d => d.NconstNavigation).WithMany(p => p.PersonProfessions)
                .HasForeignKey(d => d.Nconst)
                .HasConstraintName("fk_nconst_profession");

            entity.HasOne(d => d.Profession).WithMany(p => p.PersonProfessions)
                .HasForeignKey(d => d.ProfessionId)
                .HasConstraintName("fk_profession_id");
        });

        modelBuilder.Entity<PersonRating>(entity =>
        {
            entity.HasKey(e => new { e.Nconst, e.WeightedRating }).HasName("pk_nconst_weighted_rating");

            entity.ToTable("person_ratings");

            entity.HasIndex(e => e.Nconst, "person_ratings_nconst_key").IsUnique();

            entity.Property(e => e.Nconst)
                .HasMaxLength(10)
                .HasColumnName("nconst");
            entity.Property(e => e.WeightedRating).HasColumnName("weighted_rating");

            entity.HasOne(d => d.NconstNavigation).WithOne(p => p.PersonRating)
                .HasForeignKey<PersonRating>(d => d.Nconst)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ratings_nconst");
        });

        modelBuilder.Entity<Profession>(entity =>
        {
            entity.HasKey(e => e.ProfessionId).HasName("professions_pkey");

            entity.ToTable("professions");

            entity.HasIndex(e => e.Profession1, "professions_profession_key").IsUnique();

            entity.Property(e => e.ProfessionId).HasColumnName("profession_id");
            entity.Property(e => e.Profession1)
                .HasMaxLength(50)
                .HasColumnName("profession");
        });

        modelBuilder.Entity<Rating>(entity =>
        {
            entity.HasKey(e => e.Tconst).HasName("pk_tconst_ratings");

            entity.ToTable("ratings");

            entity.Property(e => e.Tconst)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("tconst");
            entity.Property(e => e.Averagerating)
                .HasPrecision(5, 1)
                .HasColumnName("averagerating");
            entity.Property(e => e.Numvotes).HasColumnName("numvotes");

            entity.HasOne(d => d.TconstNavigation).WithOne(p => p.Rating)
                .HasForeignKey<Rating>(d => d.Tconst)
                .HasConstraintName("fk_tconst_ratings");
        });

        modelBuilder.Entity<Title>(entity =>
        {
            entity.HasKey(e => e.Tconst).HasName("pk_tconst_titlebasics");

            entity.ToTable("titles");

            entity.Property(e => e.Tconst)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("tconst");
            entity.Property(e => e.Endyear)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("endyear");
            entity.Property(e => e.Genres)
                .HasMaxLength(256)
                .HasColumnName("genres");
            entity.Property(e => e.Isadult).HasColumnName("isadult");
            entity.Property(e => e.Originaltitle).HasColumnName("originaltitle");
            entity.Property(e => e.Primarytitle).HasColumnName("primarytitle");
            entity.Property(e => e.Runtimeminutes).HasColumnName("runtimeminutes");
            entity.Property(e => e.Startyear)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("startyear");
            entity.Property(e => e.Titletype)
                .HasMaxLength(20)
                .HasColumnName("titletype");
            

        });

        modelBuilder.Entity<TitleGenre>(tg =>
        {
            tg.ToTable("title_genre");

            tg.HasKey(x => new { x.Tconst, x.GenreId })
                .HasName("pk_tconst_genre");

            tg.Property(x => x.Tconst)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("tconst");

            tg.Property(x => x.GenreId)
                .HasColumnName("genre");

            tg.HasOne(x => x.Title)                   // navigation property in TitleGenre
                .WithMany(t => t.TitleGenres)         // collection in Title
                .HasForeignKey(x => x.Tconst)         // foreign key in TitleGenre
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_tconst_genre");

            tg.HasOne(x => x.Genre)                   // navigation property in TitleGenre
                .WithMany(g => g.TitleGenres)         // collection in Genre
                .HasForeignKey(x => x.GenreId)        // foreign key in TitleGenre
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_genre");
        });
        
        modelBuilder.Entity<TitleExtra>(entity =>
        {
            entity
                //.HasNoKey()
                .HasKey(e => e.Tconst).HasName("pk_tconst_extras");
            entity.ToTable("title_extras");

            entity.Property(e => e.Awards).HasColumnName("awards");
            entity.Property(e => e.Plot).HasColumnName("plot");
            entity.Property(e => e.Poster)
                .HasMaxLength(200)
                .HasColumnName("poster");
            entity.Property(e => e.Tconst)
                .HasMaxLength(20)
                .HasColumnName("tconst");

            /*entity.HasOne(d => d.TconstNavigation).WithMany()
                .HasForeignKey(d => d.Tconst)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_tconst_extras");*/ // this was originallly from scaffold model
            
            
            // But the relation is not one to many, but one to one relation with Title
            entity.HasOne(e => e.Title)
                .WithOne(t => t.TitleExtra)
                .HasForeignKey<TitleExtra>(e => e.Tconst)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_titleextra_title");
            
        });
        
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("users_pkey");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "users_email_key").IsUnique();

            entity.HasIndex(e => e.Username, "users_username_key").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("creation_time");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.PasswordHash).HasColumnName("password_hash");
            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .HasColumnName("username");
        });

        modelBuilder.Entity<UserBookmark>(entity =>
        {
            entity.HasKey(e => e.BookmarkId).HasName("user_bookmarks_pkey");

            entity.ToTable("user_bookmarks");

            entity.HasIndex(e => new { e.UserId, e.Nconst }, "unique_user_name").IsUnique();

            entity.HasIndex(e => new { e.UserId, e.Tconst }, "unique_user_title").IsUnique();

            entity.Property(e => e.BookmarkId).HasColumnName("bookmark_id");
            entity.Property(e => e.BookmarkTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("bookmark_time");
            entity.Property(e => e.Nconst)
                .HasMaxLength(20)
                .HasColumnName("nconst");
            entity.Property(e => e.Tconst)
                .HasMaxLength(20)
                .HasColumnName("tconst");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.NconstNavigation).WithMany(p => p.UserBookmarks)
                .HasForeignKey(d => d.Nconst)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("user_bookmarks_nconst_fkey");

            entity.HasOne(d => d.TconstNavigation).WithMany(p => p.UserBookmarks)
                .HasForeignKey(d => d.Tconst)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("user_bookmarks_tconst_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.UserBookmarks)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("user_bookmarks_user_id_fkey");
        });

        modelBuilder.Entity<UserRatingHistory>(entity =>
        {
            entity.HasKey(e => e.RatingId).HasName("user_rating_history_pkey");

            entity.ToTable("user_rating_history");

            entity.Property(e => e.RatingId).HasColumnName("rating_id");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.RatingTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("rating_time");
            entity.Property(e => e.Tconst)
                .HasMaxLength(20)
                .HasColumnName("tconst");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.TconstNavigation).WithMany(p => p.UserRatingHistories)
                .HasForeignKey(d => d.Tconst)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("user_rating_history_tconst_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.UserRatingHistories)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("user_rating_history_user_id_fkey");
        });

        modelBuilder.Entity<UserSearchHistory>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.SearchTime }).HasName("pk_user_id_search_time");

            entity.ToTable("user_search_history");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.SearchTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("search_time");
            entity.Property(e => e.SearchTerm).HasColumnName("search_term");

            entity.HasOne(d => d.User).WithMany(p => p.UserSearchHistories)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("user_search_history_user_id_fkey");
        });

        modelBuilder.Entity<Version>(entity =>
        {
            entity.HasKey(e => new { e.Tconst, e.Ordering }).HasName("pk_title_ordering");

            entity.ToTable("versions");

            entity.Property(e => e.Tconst)
                .HasMaxLength(10)
                //.IsFixedLength()
                .HasColumnName("tconst");
            entity.Property(e => e.Ordering).HasColumnName("ordering");
            entity.Property(e => e.Attributes)
                .HasMaxLength(256)
                .HasColumnName("attributes");
            entity.Property(e => e.Isoriginaltitle).HasColumnName("isoriginaltitle");
            entity.Property(e => e.Language)
                .HasMaxLength(10)
                .HasColumnName("language");
            entity.Property(e => e.Region)
                .HasMaxLength(10)
                .HasColumnName("region");
            entity.Property(e => e.Title).HasColumnName("title");
            entity.Property(e => e.Types)
                .HasMaxLength(256)
                .HasColumnName("types");

            entity.HasOne(d => d.TconstNavigation).WithMany(p => p.Versions)
                .HasForeignKey(d => d.Tconst)
                .HasConstraintName("fk_tconst_akas");
        });

        modelBuilder.Entity<WordIndex>(entity =>
        {
            entity.HasKey(e => new { e.Tconst, e.Word, e.Field }).HasName("pk_tconst_lexeme");

            entity.ToTable("word_index");

            entity.Property(e => e.Tconst)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("tconst");
            entity.Property(e => e.Word).HasColumnName("word");
            entity.Property(e => e.Field)
                .HasMaxLength(1)
                .HasColumnName("field");
            entity.Property(e => e.Lexeme).HasColumnName("lexeme");

            entity.HasOne(d => d.TconstNavigation).WithMany(p => p.WordIndices)
                .HasForeignKey(d => d.Tconst)
                .HasConstraintName("fk_tconst_word_index");
        });
        
    }
}
