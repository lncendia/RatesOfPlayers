namespace RatesOfPlayers.Infrastructure.Web.Home.Models;

public class ErrorViewModel
{
    public string? RequestId { get; init; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}