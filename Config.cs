namespace ValksMinecraftHelper;

using System.Text.Json;

public class Config
{
    public string MinecraftFolder { get; set; } = "";
    public string MinecraftExe { get; set; } = "";

    // The dependencies folder is where all the mods were temporarily moved to. These are the
    // mods you want to try to rule out.
    public string DependenciesFolder { get; set; } = "";

    public static void Save()
    {
        string config_data = JsonSerializer.Serialize(Form1.Config, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        string exe_directory = AppContext.BaseDirectory;
        string config_file_path = $@"{exe_directory}\config.json";

        File.WriteAllText(config_file_path, config_data);
    }

    public static Config Get()
    {
        string exe_directory = AppContext.BaseDirectory;
        string config_file_path = $@"{exe_directory}\config.json";

        Config config;

        if (File.Exists(config_file_path))
        {
            string text = File.ReadAllText(config_file_path);
            config = JsonSerializer.Deserialize<Config>(text);
        }
        else
        {
            config = new Config();

            string config_data = JsonSerializer.Serialize(config, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(config_file_path, config_data);
        }

        return config;
    }
}
