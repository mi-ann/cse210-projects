public class UserManager
{
    private List<User> _users = new List<User>();
    private const string UserFile = "users.txt";

    public UserManager()
    {
        LoadUsers(); // Load users from file when UserManager is created
    }

    public bool Register(string username, string password)
    {
        if (_users.Any(u => u.Username == username))
        {
            return false; // Username already exists
        }
        _users.Add(new User { Username = username, Password = password });
        SaveUsers(); // Save updated user list
        return true;
    }

    public User Authenticate(string username, string password)
    {
        return _users.FirstOrDefault(u => u.Username == username && u.Password == password);
    }

    private void SaveUsers()
    {
        using (StreamWriter writer = new StreamWriter(UserFile))
        {
            foreach (User user in _users)
            {
                writer.WriteLine($"{user.Username},{user.Password}");
            }
        }
    }

    private void LoadUsers()
    {
        if (File.Exists(UserFile))
        {
            string[] lines = File.ReadAllLines(UserFile);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 2)
                {
                    _users.Add(new User { Username = parts[0], Password = parts[1] });
                }
            }
        }
    }
}