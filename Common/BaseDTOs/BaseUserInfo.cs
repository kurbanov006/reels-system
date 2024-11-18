public readonly record struct BaseUserInfo(
    string UserName,
    string FirstName,
    string LastName,
    string Email,
    string Password,
    int Age,
    bool IsAdmin
);