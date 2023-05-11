using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Windows.Input;
using ReactiveUI;

namespace MusicStore.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {
        ShowDialog = new Interaction<MusicStoreViewModel, AlbumViewModel>();

        BuyMusicCommand = ReactiveCommand.Create( async () =>
        {
            var store = new MusicStoreViewModel();
            var result = await ShowDialog.Handle(store);
        });
    }

    public ICommand BuyMusicCommand { get; }
    public Interaction<MusicStoreViewModel,AlbumViewModel> ShowDialog { get; }
}