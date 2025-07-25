using Renci.SshNet;

var config = new ReadData();

string host = config.Get("host");
string username = config.Get("username");
string password = config.Get("password");

Console.WriteLine($"Connecting as {host} as {username}");


