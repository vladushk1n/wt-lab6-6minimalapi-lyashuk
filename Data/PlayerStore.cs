using wt_lab6_6minimalapi_lyashuk.Models;

namespace wt_lab6_6minimalapi_lyashuk.Data;

public static class PlayerStore
{
    public static List<Player> Players { get; set; } = new()
    {
        new Player { Id = 1, Nickname = "s1mple", Role = "AWPer", Rating = 2850, IsActive = true },
        new Player { Id = 2, Nickname = "ZywOo", Role = "AWPer", Rating = 2840, IsActive = true },
        new Player { Id = 3, Nickname = "b1t", Role = "Rifler", Rating = 2100, IsActive = true },
        new Player { Id = 4, Nickname = "electronic", Role = "Entry Killer", Rating = 2300, IsActive = false },
        new Player { Id = 5, Nickname = "m0NESY", Role = "AWPer", Rating = 2790, IsActive = true }
    };
}