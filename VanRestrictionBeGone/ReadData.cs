class ReadData
{
    public Dictionary<string, string> Settings = new();

    public ReadData()
    {
        string exePath = AppDomain.CurrentDomain.BaseDirectory;
        string configPath = Path.Combine(exePath, "config.ini");

        foreach (var line in File.ReadLines(configPath))
        {
            if (string.IsNullOrEmpty(line) || line.TrimStart().StartsWith("#")) continue;

            var parts = line.Split('=');
            if (parts.Length == 2)
            {
                Settings[parts[0].Trim()] = parts[1].Trim();
            }
        }
    }

    public string Get(string key)
    {
        return Settings.TryGetValue(key, out var value) ? value : null;
    }
}