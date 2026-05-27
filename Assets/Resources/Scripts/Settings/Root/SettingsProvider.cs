using UnityEngine;

public class SettingsProvider : ISettingsProvider
{
    public ApplicationSettings ApplicationSettings { get; }

    public SettingsProvider()
    {
        ApplicationSettings = Resources.Load<ApplicationSettings>("ApplicationSettings");
    }
}
