using System;
using Jirnal.Core.JiraTypes;

namespace Jirnal.Win.ViewModels
{
    public class CommentVm
    {
        public CommentVm(Comment comment)
        {
            Id = comment.Id;
            Author = comment.Author;
            Body = comment.Body;
            UpdateAuthor = comment.UpdateAuthor;
            Created = comment.Created;
            Updated = comment.Updated;
        }

        public long Id { get; }
        public Author Author { get; }
        public string Body { get; set; }
        public Author UpdateAuthor { get; }
        public DateTime Created { get; }
        public DateTime? Updated { get; }

        
        public string DisplayDate 
        {
            get {
                var date = Updated ?? Created;
                return date.Date == DateTime.Today ? date.ToString("h:mm tt zz") : date.ToString("yyyy-MM-dd h:mm tt");
            }
        }
}
}