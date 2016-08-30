using System;
using System.Windows;
using Commander;
using SaveCodeManager.Saves.Tkok;

namespace SaveCodeManager.Gui.ViewModels.Tkok
{
    public class TkokSaveCodeViewModel : TkokSaveCode, ITkokSaveCodeViewModel
    {
        public TkokSaveCodeViewModel(string userName, HeroKind heroKind, int level, int exp, int gold, string password,
            DateTime creationTime, string mapVersion, string fileHash)
            : base(userName, heroKind, level, exp, gold, password, creationTime, mapVersion, fileHash)
        {
        }

        public TkokSaveCodeViewModel(ITkokSaveCode tkokSaveCode)
            : base(
                tkokSaveCode.UserName, tkokSaveCode.Class, tkokSaveCode.Level, tkokSaveCode.Exp, tkokSaveCode.Gold, tkokSaveCode.Password,
                tkokSaveCode.CreationTime, tkokSaveCode.MapVersion, tkokSaveCode.FileHash)
        {
        }

        [OnCommand(nameof(CopyPasswordToClipboard) + "Command")]
        public void CopyPasswordToClipboard()
        {
            Clipboard.SetText("-load " + Password);
        }
    }
}