using Microsoft.AspNetCore.Identity;

namespace MusicCatalog.Models;

public class AppUser : IdentityUser
{
    public List<Vote> Votes { get; } = new();
}