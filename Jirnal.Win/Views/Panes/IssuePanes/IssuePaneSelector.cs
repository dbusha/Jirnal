using System.Windows;
using System.Windows.Controls;
using Jirnal.Win.ViewModels.IssuePanes;

namespace Jirnal.Win.Views.Panes.IssuePanes
{
    public class IssuePaneSelector : DataTemplateSelector
    {
            public DataTemplate SearchIssuesTemplate { get; set; }
            public DataTemplate RecentIssuesTemplate { get; set; }
            public DataTemplate PinnedIssuesTemplate { get; set; }
        
        
            public override DataTemplate SelectTemplate(object item, DependencyObject container)
            {
                if (!(container is FrameworkElement element) || !(item is IssuesPaneBaseVm pane))
                    return null;

                return pane switch
                {
                    SearchIssuesPaneVm _ => SearchIssuesTemplate,
                    RecentIssuesPaneVm _ => RecentIssuesTemplate,
                    PinnedIssuesPaneVm _ => PinnedIssuesTemplate,
                    _ => RecentIssuesTemplate
                };
            }
    }
}