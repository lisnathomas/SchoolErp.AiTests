# US-001: Log in to School ERP

Tags: @ui

As a School ERP user (admin, teacher, student or parent),
I want to sign in with my email and password,
so that I can reach the dashboard for my role.

## Acceptance criteria

1. An admin who signs in with valid details lands on the admin dashboard.
2. A teacher who signs in with valid details lands on the teacher dashboard.
3. A student who signs in with valid details lands on the student dashboard.
4. A parent who signs in with valid details lands on the parent dashboard.
5. A wrong password keeps the user on the login page and shows "These credentials do not match our records."
6. An email that is not registered keeps the user on the login page and shows the same message.
7. Submitting the form with both fields empty shows "The email field is required." and "The password field is required."

## Test data

Demo accounts created by the School ERP seeder (password for all: `password`):
admin@example.com, teacher@example.com, student@example.com, parent@example.com
