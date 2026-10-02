using Microsoft.Playwright;

namespace SchoolErp.Tests.Pages;

/// <summary>
/// Page Object for the School ERP login page.
/// Selectors come from resources/views/vendor/adminlte/auth/login.blade.php
/// in the School ERP repo. If the page changes, only this file needs updating.
/// </summary>
public sealed class LoginPage
{
    private readonly IPage _page;

    public LoginPage(IPage page) => _page = page;

    private ILocator EmailInput => _page.Locator("input[name='email']");
    private ILocator PasswordInput => _page.Locator("input[name='password']");
    private ILocator SignInButton => _page.Locator("form button[type='submit']");

    /// <summary>A validation or login error shown under a field, matched by its text.</summary>
    public ILocator ErrorMessage(string text) =>
        _page.Locator(".invalid-feedback", new PageLocatorOptions { HasText = text });

    public async Task OpenAsync() => await _page.GotoAsync("/login");

    public async Task LoginAsync(string email, string password)
    {
        await EmailInput.FillAsync(email);
        await PasswordInput.FillAsync(password);
        await SignInButton.ClickAsync();
    }
}
