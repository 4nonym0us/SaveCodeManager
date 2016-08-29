namespace SaveCodeManager.Gui.ViewModels
{
    public interface ISettingsViewModel
    {
        int RefreshInterval { get; set; }

        string War3Path { get; set; }
    }
}