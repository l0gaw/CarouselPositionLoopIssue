using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input; 

namespace CarouselPositionLoopIssue;

public partial class MainPage : ContentPage
{ 
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new MainPageViewModel();
    } 
}

public partial class MainPageViewModel : ObservableObject
{
    [ObservableProperty]
    ObservableCollection<string> items;

    [ObservableProperty]
    int position;

    [ObservableProperty]
    bool loop;

    public MainPageViewModel()
    {
        Items = new ObservableCollection<string>
        {
            "1","2","3","4"
        };
    }

    [RelayCommand]
    async Task ReloadItems()
    {
        var currentPosition = Position;
        Items = new ObservableCollection<string>
        {
            "1","2","3","4"
        };
        await Task.Delay(300);
        Position = currentPosition;
    }

    [RelayCommand]
    void EnableDisableLoop()
    {
        Loop = !Loop; 
        Application.Current.MainPage.DisplayAlert("Loop Enabled", Loop.ToString(), "OK");
    }
}


