using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using Commander;
using GalaSoft.MvvmLight;
using PropertyChanged;
using SaveCodeManager.Core.Saves.Tkok;
using SaveCodeManager.Core.Services;
using SaveCodeManager.Gui.Properties;

namespace SaveCodeManager.Gui.ViewModels.Tkok
{
    [ImplementPropertyChanged]
    public class TkokSavesViewModel : ViewModelBase, ITkokSavesViewModel
    {
        private readonly ISaveCodesLoader<ITkokSaveCode> _tkokSavesLoader;

        public TkokSavesViewModel(ISaveCodesLoader<ITkokSaveCode> tkokSavesLoader)
        {
            _tkokSavesLoader = tkokSavesLoader;
            SaveCodes = new ObservableCollection<ITkokSaveCodeViewModel>();
            ShowOnlyTheLatest = true;
            ShowUserNameColumn = true;

            if (IsInDesignMode)
            {
                SaveCodes.Add(new TkokSaveCodeViewModel(
                    "4nonym0us",
                    TkokSaveCode.HeroKind.Ranger,
                    10,
                    10000,
                    20000,
                    "p@$$w0rd",
                    DateTime.Now,
                    "3.3.0f",
                    "12345"));
            }
            else
            {
                RefreshSaveCodes();


                RefreshTimer = new Timer();
                RefreshTimer.Elapsed += async (sender, args) => await RefreshSaveCodes();
                RefreshTimer.Interval = Settings.Default.RefreshInterval;
                RefreshTimer.Start();
            }
        }

        public bool ShowUserNameColumn { get; set; }

        public bool ShowOnlyTheLatest { get; set; }

        public ObservableCollection<ITkokSaveCodeViewModel> SaveCodes { get; set; }

        [OnCommand(nameof(RefreshSaveCodes) + "Command")]
        public async Task RefreshSaveCodes()
        {
            Trace.WriteLine("RefreshingCodes");
            var newCodes =
                (await _tkokSavesLoader.LoadCodesAsync(Settings.Default.War3Path))
                    .OrderByDescending(s => s.CreationTime)
                    .Select(c => new TkokSaveCodeViewModel(c))
                    .ToList();

            if (ShowOnlyTheLatest)
            {
                var finalCodes = new List<TkokSaveCodeViewModel>();
                foreach (TkokSaveCode.HeroKind className in Enum.GetValues(typeof(TkokSaveCode.HeroKind)))
                {
                    var codeForClass = newCodes.FirstOrDefault(s => s.Class == className);
                    if (codeForClass != null) finalCodes.Add(codeForClass);
                }
                newCodes = finalCodes;
            }

            var toBeAdded = newCodes.Except(SaveCodes).ToList();
            var toBeDeleted = SaveCodes.Except(newCodes).ToList();

            //Trace.WriteLine("toBeAdded: " + toBeAdded.Count);
            //Trace.WriteLine("toBeDeleted: " + toBeDeleted.Count);
            foreach (var s in toBeAdded)
            {
                Action<ITkokSaveCodeViewModel> addMethod = SaveCodes.Add;
                await Application.Current.Dispatcher.BeginInvoke(addMethod, s);
            }
            foreach (var s in toBeDeleted)
            {
                Action<ITkokSaveCodeViewModel> removeMethod = code => SaveCodes.Remove(code);
                await Application.Current.Dispatcher.BeginInvoke(removeMethod, s);
            }

            //SaveCodes.ToList().Select(s => s.UserName).Distinct().Count() <= 1;
        }

        public Timer RefreshTimer { get; set; }
    }
}