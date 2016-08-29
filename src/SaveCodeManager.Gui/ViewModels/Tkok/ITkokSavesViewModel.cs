using SaveCodeManager.Gui.ViewModels.Interfaces;

namespace SaveCodeManager.Gui.ViewModels.Tkok
{
    public interface ITkokSavesViewModel : ISavesViewModel<ITkokSaveCodeViewModel>
    {
        bool ShowUserNameColumn { get; set; }

        bool ShowOnlyTheLatest { get; set; }
    }
}