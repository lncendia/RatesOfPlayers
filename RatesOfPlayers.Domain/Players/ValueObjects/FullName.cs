namespace RatesOfPlayers.Domain.Players.ValueObjects;

public class FullName
{
    /// <summary>
    /// Имя.
    /// </summary>
    public required string FirstName { get; set; }
    
    /// <summary>
    /// Фамилия.
    /// </summary>
    public string? SecondName { get; set; }
    
    /// <summary>
    /// Отчество.
    /// </summary>
    public string? ThirdName { get; set; }

    
    /// <summary>
    /// Краткая форма имени.
    /// </summary>
    public string ShortForm()
    {
        string result;
        
        if (SecondName != null)
            result = $"{SecondName} {FirstName[0]}.";
        else
            result = $"{FirstName}";
        
        if (ThirdName != null)
            result = $"{result} {ThirdName[0]}.";
        
        return result;
    }
}