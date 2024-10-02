public class UserManager
{
    private List<User> _users = new List<User>();

    public bool Register(string username, string password)
    {
        // Check if the username already exists
        if (_users.Any(u => u.Username == username))
        {
            return false; // Registration failed
        }

        // Create a new user and add it to the list
        _users.Add(new User { Username = username, Password = password });
        return true; // Registration successful
    }

    public User Authenticate(string username, string password)
    {
        return _users.FirstOrDefault(u => u.Username == username && u.Password == password);
    }
}
