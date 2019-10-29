using System;
using Jirnal.Core.JiraTypes;

namespace Jirnal.Win.ViewModels
{
    public class CommentVm
    {
        public Author Author { get; set; }
        public string Body { get; set; }
        public Author UpdateAuthor { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}