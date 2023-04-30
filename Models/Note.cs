using System;

namespace EditorSQL.Models
{
    public class Note
    {
        public int? Id { get; set; }
        public string Content { get; set; }

        public Note()
        {
            Id = 0;
            Content = string.Empty;
        }

        public Note(int id, string content)
        {
            Id = id;
            Content = content;
        }
    }
}