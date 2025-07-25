using Renci.SshNet;

Console.WriteLine("The battle of wits has begun. It ends when you decide and we both boot, and find out who is UD... and who is banned.");

var config = new ReadData();

string host = config.Get("host");
string username = config.Get("username");
string password = config.Get("password");

Console.WriteLine($"Connecting as {host} as {username}");

using var ssh = new SshClient(host, username, password);
ssh.Connect();

var incoming = ssh.RunCommand("ebtables -A INPUT -p arp -j DROP"); // drop incoming ARP requests
Console.WriteLine($"Incoming Command result: {incoming.CommandText}");

var outgoing = ssh.RunCommand("ebtables -A OUTPUT -p arp -j DROP"); // drop outgoing ARP requests
Console.WriteLine($"Outgoing command result: {outgoing.CommandText}");

if (incoming.Error != null | outgoing.Error != null)
{
    if (incoming != null) Console.WriteLine($"Error {incoming.Error}");
    if (outgoing != null) Console.WriteLine($"Error {outgoing.Error}");

    Console.WriteLine("Vanguard won the war...");
}
else Console.WriteLine("Vanguard is no more.");

ssh.Disconnect();
