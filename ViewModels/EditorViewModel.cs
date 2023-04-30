using System.Linq;
using EditorSQL.DatabaseContexts;
using EditorSQL.Models;

namespace EditorSQL.ViewModels
{
    public sealed class EditorViewModel : ViewModel
    {
        public string DatabaseDataText
        {
            get => _model.DatabaseText;
            private set
            {
                if (value == _model.DatabaseText) return;
                _model.DatabaseText = value;
                OnPropertyChanged();
            }
        }

        private readonly EditorModel _model;
        private readonly NotesContext _notesContext;

        private const string _CONNECTION_STRING =
            "Server=localhost;Database=notes;Trusted_Connection=True;TrustServerCertificate=True";

        public EditorViewModel()
        {
            _model = new EditorModel();
            _notesContext = new NotesContext(_CONNECTION_STRING);
        }

        ~EditorViewModel()
        {
            _notesContext.Dispose();
        }

        public void PullData()
        {
            _model.Notes = _notesContext.Notes.ToList();

            string newDataText = string.Empty;

            for (int noteIndex = 0; noteIndex < _model.Notes.Count; noteIndex++)
            {
                Note note = _model.Notes[noteIndex];
                newDataText += $"{note.Id}_{note.Content}\n";
            }

            DatabaseDataText = newDataText;
        }

        public void PushData(string data)
        {
            Note newNote = new Note(_model.Notes.Count, data);
            _notesContext.Notes.Add(newNote);
            _notesContext.SaveChanges();
            _model.Notes.Add(newNote);
        }
    }
}