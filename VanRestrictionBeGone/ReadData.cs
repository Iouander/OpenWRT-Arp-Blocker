class ReadData
{
    public Dictionary<string, string> Settings = new();

    public ReadData()
    {
        foreach (var line in File.ReadLines("settings.txt"))
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