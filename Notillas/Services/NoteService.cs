using System.Text.Json;
using Notillas.Models;

namespace Notillas.Services;

public class NoteService
{
    private readonly string _storagePath = Path.Combine(FileSystem.AppDataDirectory, "notes.json");

    public async Task<IList<Note>> LoadAsync()
    {
        if (!File.Exists(_storagePath))
        {
            return new List<Note>();
        }

        await using var stream = File.OpenRead(_storagePath);
        var notes = await JsonSerializer.DeserializeAsync<List<Note>>(stream);
        return notes ?? new List<Note>();
    }

    public async Task SaveAsync(IEnumerable<Note> notes)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(_storagePath)!);
        await using var stream = File.Create(_storagePath);
        await JsonSerializer.SerializeAsync(stream, notes.OrderByDescending(n => n.UpdatedAt));
    }
}
