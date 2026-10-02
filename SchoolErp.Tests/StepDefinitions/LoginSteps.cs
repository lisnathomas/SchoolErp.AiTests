using System.Text.RegularExpressions;
using Reqnroll;
using SchoolErp.Tests.Pages;
using SchoolErp.Tests.Support;
using static Microsoft.Playwright.Assertions;

namespace SchoolErp.Tests.StepDefinitions;

/// <summary>
/// Step definitions: the C# code behind each line of the .feature file.
/// The AI bot reads the text in the [Given]/[When]/[Then] attributes and is only
/// allowed to use these phrases, so every feature file it writes can run.
/// {string} means "any text in double quotes" and becomes a method parameter.
/// </summary>
[Binding]
public sealed class LoginSteps
{
    private readonly BrowserSession _session;

    public LoginSteps(BrowserSession session) => _session = session;

    private LoginPage LoginPage => new(_session.Page);

    [Given("I am on the login page")]
    public async Task GivenIAmOnTheLoginPage() =>
        await LoginPage.OpenAsync();

    [When("I log in as the {string} demo user")]
    public async Task WhenILogInAsTheDemoUser(string role) =>
        await LoginPage.LoginAsync(DemoUsers.EmailFor(role), DemoUsers.Password);

    [When("I log in with email {string} and password {string}")]
    public async Task WhenILogInWithEmailAndPassword(string email, string password) =>
        await LoginPage.LoginAsync(email, password);

    [Then("I should land on the {string} dashboard")]
    public async Task ThenIShouldLandOnTheDashboard(string role)
    {
        var path = DemoUsers.DashboardPathFor(role);
        await Expect(_session.Page).ToHaveURLAsync(new Regex(Regex.Escape(path) + "$"));
    }

    [Then("I should stay on the login page")]
    public async Task ThenIShouldStayOnTheLoginPage() =>
        await Expect(_session.Page).ToHaveURLAsync(new Regex("/login$"));

    [Then("I should see the error {string}")]
    public async Task ThenIShouldSeeTheError(string message)
    {
        var error = LoginPage.ErrorMessage(message);
        await Expect(error).ToBeVisibleAsync();
        await Highlight.CheckedElementAsync(error); // outline it in the video
    }
}
