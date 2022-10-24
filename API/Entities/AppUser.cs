using Microsoft.AspNetCore.Identity;

namespace API.Entities;

public class AppUser : IdentityUser<int>
{

    public DateTime DateOfBirth { get; set; }
    public string? KnownAs { get; set; } = default!;

    public DateTime Created { get; set; } = DateTime.Now;

    public DateTime LastActive { get; set; } = DateTime.Now;

    public string? Gender { get; set; } = default!;
    public string? Introduction { get; set; } = default!;
    public string? LookingFor { get; set; } = default!;
    public string? Interests { get; set; } = default!;
    public string? City { get; set; } = default!;
    public string? Country { get; set; } = default!;
    public ICollection<Photo> Photos { get; set; } = default!;

    public ICollection<UserLike> LikedByUsers { get; private set; }
    public ICollection<UserLike> LikedUsers { get; private set; }

    public ICollection<Message> MessagesSent { get; private set; }
    public ICollection<Message> MessageReceived { get; private set; }

    public ICollection<AppUserRole> UserRoles { get; set; }

    public AppUser()
    {
        LikedByUsers = new HashSet<UserLike>();
        LikedUsers = new HashSet<UserLike>();
        MessagesSent = new HashSet<Message>();
        MessageReceived = new HashSet<Message>();
        UserRoles = new HashSet<AppUserRole>();
    }
}



