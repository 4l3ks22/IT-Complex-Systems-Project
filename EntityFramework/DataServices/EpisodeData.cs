// csharp
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using EntityFramework.Models;
using EntityFramework.Models.Interfaces;

namespace EntityFramework.DataServices;

public class EpisodeData(MyDbContext db) : IEpisodeData
{
   
}