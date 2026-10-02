namespace SchoolErp.Tests.Support;

/// <summary>
/// The demo accounts the School ERP seeder creates (see the School ERP README).
/// They exist only in local development databases.
/// </summary>
public static class DemoUsers
{
    public static string Password =>
        TestSettings.DemoPassword;

    public static string EmailFor(string role) => role.Trim().ToLowerInvariant() switch
    {
        "admin" => "admin@example.com",
        "teacher" => "teacher@example.com",
        "student" => "student@example.com",
        "parent" => "parent@example.com",
        _ => throw new ArgumentException($"Unknown role '{role}'. Use admin, teacher, student or parent.")
    };

    /// <summary>Where each role lands after a successful login (from routes/web.php).</summary>
    public static string DashboardPathFor(string role) => role.Trim().ToLowerInvariant() switch
    {
        "admin" => "/admin/dashboard",
        "teacher" => "/teacher/dashboard",
        "student" => "/student/dashboard",
        "parent" => "/parent/dashboard",
        _ => throw new ArgumentException($"Unknown role '{role}'. Use admin, teacher, student or parent.")
    };
}
