namespace SaveCodeManager.Gui.ViewModels.Interfaces
{
    public interface IMainWindowViewModel
    {
        string AppVerion { get; }

        string StatusBarText { get; set; }

        void OnWindowLoaded();
    }
}