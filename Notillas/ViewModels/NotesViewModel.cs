using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Notillas.Models;
using Notillas.Services;

namespace Notillas.ViewModels;

public partial class NotesViewModel : ObservableObject
{
    private readonly NoteService _noteService;

    [ObservableProperty]
    private string titleInput = string.Empty;

    [ObservableProperty]
    private string contentInput = string.Empty;

    [ObservableProperty]
    private Note? selectedNote;

    public ObservableCollection<Note> Notes { get; } = new();

    public NotesViewModel(NoteService noteService)
    {
        _noteService = noteService;
    }

    [RelayCommand]
    public async Task LoadAsync()
    {
        var notes = await _noteService.LoadAsync();
        Notes.Clear();
        foreach (var note in notes.OrderByDescending(n => n.UpdatedAt))
        {
            Notes.Add(note);
        }
    }

    [RelayCommand]
    public async Task SaveNoteAsync()
    {
        var normalizedTitle = TitleInput.Trim();
        var normalizedContent = ContentInput.Trim();

        if (string.IsNullOrWhiteSpace(normalizedTitle) && string.IsNullOrWhiteSpace(normalizedContent))
        {
            return;
        }

        if (SelectedNote is null)
        {
            var newNote = new Note
            {
                Title = string.IsNullOrWhiteSpace(normalizedTitle) ? "Sin título" : normalizedTitle,
                Content = normalizedContent,
                UpdatedAt = DateTime.Now
            };
            Notes.Insert(0, newNote);
        }
        else
        {
            SelectedNote.Title = string.IsNullOrWhiteSpace(normalizedTitle) ? "Sin título" : normalizedTitle;
            SelectedNote.Content = normalizedContent;
            SelectedNote.UpdatedAt = DateTime.Now;

            var current = SelectedNote;
            Notes.Remove(current);
            Notes.Insert(0, current);
        }

        await _noteService.SaveAsync(Notes);
        ClearInputs();
    }

    [RelayCommand]
    public void Select(Note note)
    {
        SelectedNote = note;
        TitleInput = note.Title;
        ContentInput = note.Content;
    }

    [RelayCommand]
    public async Task DeleteAsync(Note note)
    {
        Notes.Remove(note);
        await _noteService.SaveAsync(Notes);

        if (SelectedNote?.Id == note.Id)
        {
            ClearInputs();
        }
    }

    [RelayCommand]
    public void ClearInputs()
    {
        SelectedNote = null;
        TitleInput = string.Empty;
        ContentInput = string.Empty;
    }
}
