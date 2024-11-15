namespace Api.Providers;

public class UserDataProvider
{
    private readonly List<User> _users = [];
    
    public List<User> GetUsers() => _users;

    public User GetUser(int id) => _users.First(x => x.Id == id);

    public User AddUser(UserDto user)
    {
        var newUserId = _users.Count + 1;
        var newUser = new User { Id = newUserId, FirstName = user.FirstName, LastName = user.LastName };
        _users.Add(newUser);
        return newUser;
    }
    
    public void RemoveUser(int id) => _users.Remove(_users.First(x => x.Id == id));

    public User UpdateUser(UserDto user, int id)
    {
        var userToUpdate = _users.First(x => x.Id == id);
        userToUpdate.FirstName = user.FirstName;
        userToUpdate.LastName = user.LastName;
        return userToUpdate;
    }
}

public class User
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}

public class UserDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}