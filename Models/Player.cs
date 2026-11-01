namespace wt_lab6_6minimalapi_lyashuk.Models;

public class Player
{
    public int Id { get; set; }
    public string Nickname { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public int Rating { get; set; }
    public bool IsActive { get; set; }
}