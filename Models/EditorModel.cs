using System.Collections.Generic;

namespace EditorSQL.Models
{
    public class EditorModel
    {
        public string DatabaseText { get; set; } = "unchanged";
        public List<Note> Notes { get; set; }
    }
}