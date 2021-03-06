using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using Jirnal.Core;
using Jirnal.Core.JiraTypes;
using Prism.Commands;
using Tools.ExtensionMethods;
using Tools.UI.WPF;

namespace Jirnal.Win.ViewModels
{
    public class IssueVm : ViewModelBase
    {
        private readonly JirnalCore jirnalCore_;
        private readonly ObservableCollection<CommentVm> comments_ = new ObservableCollection<CommentVm>();
        private DelegateCommand addCommentCmd_;
        private ICommand editProjectCmd_;
        private bool isAddCommentVisible_;
        private ICommand showAddCommentCmd_;
        private ICommand cancelAddCommentCmd_;
        private string commentText_;
        private DelegateCommand<CommentVm> deleteCommentCmd_;


        private IssueVm(JirnalCore jirnalCore)
        {
            jirnalCore_ = jirnalCore;
            Comments = new ListCollectionView(comments_);
            Comments.SortDescriptions.Add(new SortDescription(nameof(Comment.Created), Ascend));
        }
        
        
        public IssueVm(JirnalCore jirnalCore, Issue issue) : this(jirnalCore)
        {
            ProjectName = issue.Fields.Project?.Name;
            Description = issue.Fields.Description;
            Key = issue.Key;
            Updated = issue.Fields.Updated;
            Title = issue.Fields.Summary;
            Assignee = issue.Fields.Assignee?.DisplayName;
            Version = issue.Fields.Versions != null ? string.Join(',', issue.Fields.Versions.Select(v => v.Name)) : "";
            Components = string.Join(',', issue.Fields.Components.Select(c => c.Name));
            Reporter = issue.Fields.Reporter?.DisplayName;
            Resolution = issue.Fields.Resolution?.Name;
            Priority = issue.Fields.Priority?.Name;
            Status = issue.Fields.Status?.Name;
            Sprint = string.Join(",", issue.Fields.Sprints);

            List<string> fields = new List<string>();
            
            foreach (var customField in issue.Fields.CustomFields) {
                fields.Add(jirnalCore.JiraCache.JiraFieldLookup.GetFieldNameFromId(customField.Key));
            }
            
        }

        
        public IssueVm(IssueVm issue) : this(issue.jirnalCore_)
        {
            ProjectName = issue.ProjectName;
            Description = issue.Description;
            Key = issue.Key;
            Updated = issue.Updated;
            Title = issue.Title;
            Assignee = issue.Assignee;
            Version = issue.Version;
            Components = issue.Components;
            Reporter = issue.Reporter;
            Resolution = issue.Resolution;
            Priority = issue.Priority;
            Status = issue.Status;
            Sprint = issue.Sprint;
            Epic = issue.Epic;
            StoryPoints = issue.StoryPoints;
        }

        public event Action CancelComment;

        public string ProjectName { get; }
        public string Description { get; }
        public string Key { get; }
        public DateTime Updated { get; }
        public string Title { get; }
        public string Assignee { get; }
        public string Version { get; }
        public string Components { get; }
        public string Reporter { get; }
        public string Resolution { get; }
        public string Priority { get; }
        public string Status { get; }
        public string Sprint { get; }
        public string Epic { get; }
        public int? StoryPoints { get; }
        public string Labels { get; }
        
        
        public ListCollectionView Comments { get; }
        public string CommentTitle => $"{Key}: {Title}";
        
        
        public bool IsAddCommentVisible
        {
            get => isAddCommentVisible_;
            set => SetValue(ref isAddCommentVisible_, value, nameof(IsAddCommentVisible));
        }

        
        public string CommentText
        {
            get => commentText_;
            set {
                SetValue(ref commentText_, value, nameof(CommentText));
                SubmitComment.RaiseCanExecuteChanged();
            }
        }


        public ICommand ShowAddCommentCmd => CommandHelper(ref showAddCommentCmd_, () => { IsAddCommentVisible = true; });
        
        
        public ICommand EditProjectCmd => CommandHelper(ref editProjectCmd_, () => { });
        
        
        public DelegateCommand SubmitComment => CommandHelper(ref addCommentCmd_, 
            async () => {
                if (await jirnalCore_.JiraProxy.AddComment(CommentText, Key)) {
                    ResetComment_();
                    await GetComments();
                }
            }, 
            () => !CommentText.IsNullOrWhitespace());

        
        public ICommand DeleteCommentCmd => CommandHelper(ref deleteCommentCmd_, async (comment) => {
            if (await jirnalCore_.JiraProxy.DeleteComment(Key, comment.Id))
                await GetComments();
        });


        public ICommand CancelCommentCmd => CommandHelper(ref cancelAddCommentCmd_, ResetComment_);


        private void ResetComment_()
        {
            IsAddCommentVisible = false;
            CommentText = null;
            CancelComment?.Invoke();
        }
        
        
        internal async Task GetComments()
        {
            var comments = await jirnalCore_.JiraProxy.GetComments(Key);
            var ids = new HashSet<long>(comments.CommentList.Select(c => c.Id));
            foreach (var comment in comments.CommentList) {
                var commentVm = new CommentVm(comment);
                foreach(var item in comments_)
                    if(item.Created == comment.Created && item.Updated > comment.Updated)
                        
                comments_.Add(commentVm);
            }
        }
        
    }
}