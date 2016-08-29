namespace SaveCodeManager.Gui.ViewModels.Interfaces
{
    /// <summary>
    /// This interface must be implemented by all view models of save codes to identify them by convention.
    /// </summary>
    public interface ISaveCodeViewModel
    {
        void CopyPasswordToClipboard();
    }
}