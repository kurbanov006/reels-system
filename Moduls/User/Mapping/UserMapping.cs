public static class UserMapping
{
    public static User ToCreate(this CreateUserInfo user)
    {
        return new User()
        {
            FirstName = user.BaseUserInfo.FirstName,
            LastName = user.BaseUserInfo.LastName,
            UserName = user.BaseUserInfo.UserName,
            Email = user.BaseUserInfo.Email,
            Password = user.BaseUserInfo.Password,
            Age = user.BaseUserInfo.Age,
            IsAdmin = user.BaseUserInfo.IsAdmin
        };
    }

    public static User ToUpdate(this User userUpdate, UpdateUserInfo user)
    {
        userUpdate.FirstName = user.BaseUserInfo.FirstName;
        userUpdate.LastName = user.BaseUserInfo.LastName;
        userUpdate.UserName = user.BaseUserInfo.UserName;
        userUpdate.Email = user.BaseUserInfo.Email;
        userUpdate.Password = user.BaseUserInfo.Password;
        userUpdate.Age = user.BaseUserInfo.Age;
        userUpdate.IsAdmin = user.BaseUserInfo.IsAdmin;
        userUpdate.UpdatedAt = DateTime.UtcNow;
        return userUpdate;
    }

    public static ReadUserInfo ToRead(this User user)
    {
        return new ReadUserInfo()
        {
            Id = user.Id,
            CreatedAt = user.CreatedAt,
            BaseUserInfo = new BaseUserInfo()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Age = user.Age,
                Email = user.Email,
                Password = user.Password,
                IsAdmin = user.IsAdmin
            }
        };
    }

    public static User ToDelete(this User user)
    {
        user.IsDeleted = true;
        user.DeletedAt = DateTime.UtcNow;
        return user;
    }
}