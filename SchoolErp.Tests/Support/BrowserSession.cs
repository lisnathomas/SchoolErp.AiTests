using Microsoft.Playwright;

namespace SchoolErp.Tests.Support;

/// <summary>
/// The browser tab for the current scenario. Reqnroll creates one per scenario and
/// gives the same instance to the hooks and step classes ("context injection").
/// </summary>
public sealed class BrowserSession
{
    public IBrowserContext Context { get; set; } = null!;
    public IPage Page { get; set; } = null!;

    /// <summary>The caption currently shown at the bottom of the page.</summary>
    public string CurrentCaption { get; set; } = "";
}
