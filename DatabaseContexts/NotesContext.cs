using EditorSQL.Models;
using EditorSQL.Tools.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EditorSQL.DatabaseContexts
{
    public class NotesContext : DataBaseContext
    {
        public DbSet<Note> Notes { get; }
        public NotesContext(string connectionString) : base(connectionString) { }
    }
}