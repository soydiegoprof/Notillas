using Notillas.ViewModels;

namespace Notillas.Views;

public partial class MainPage : ContentPage
{
    private readonly NotesViewModel _viewModel;

    public MainPage(NotesViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (_viewModel.Notes.Count == 0)
        {
            await _viewModel.LoadAsync();
        }
    }
}
