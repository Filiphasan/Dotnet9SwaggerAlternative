namespace Api.Models;

public class JwtSettingModel
{
    public const string Section = "JwtSettings";
    
    public required string Key { get; set; }
}