using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Jirnal.Core;
using Tools.UI.WPF;

namespace Jirnal.Win.ViewModels
{
    public class IssueFieldManagerVm : ViewModelBase
    {
        private ObservableCollection<FieldDefinitionVm> fields_ = new ObservableCollection<FieldDefinitionVm>();
        private readonly JirnalCore core_;
        private string visibleColumns_;
        private ICommand applyColumnLayoutCmd_;


        public IssueFieldManagerVm(JirnalCore core)
        {
            core_ = core;

            foreach (var field in core_.JiraCache.JiraFieldLookup)
                fields_.Add(new FieldDefinitionVm(field));

            Fields = new FieldListVm(core_, fields_, 0);
            Fields.Fields.SortDescriptions.Add(new SortDescription(nameof(FieldDefinitionVm.Name), Ascend));
            ColumnOne = new FieldListVm(core_, fields_, 1);
            ColumnTwo = new FieldListVm(core_, fields_, 2);
            ColumnThree = new FieldListVm(core_, fields_, 3);
            ColumnFour = new FieldListVm(core_, fields_, 4);
            ColumnLayout = new Collection<string> {"One Column", "Two Column", "Three Column", "Four Column"};
            VisibleColumns = ColumnLayout.First();
        }
        

        public FieldListVm Fields { get; }
        public FieldListVm ColumnOne { get; }
        public FieldListVm ColumnTwo { get; }
        public FieldListVm ColumnThree { get; }
        public FieldListVm ColumnFour { get; }
        public ICollection<string> ColumnLayout { get; } 

        
        public string VisibleColumns
        {
            get => visibleColumns_;
            set {
                visibleColumns_ = value;
                var count =  ColumnLayout.TakeWhile(layout => layout != value).Count() + 1;
                SetColumnVisibility_(count);
                RemoveFieldsFromHiddenColumns_(count);
            }
        }

        public ICommand ApplyColumnAssignmentCmd => CommandHelper(ref applyColumnLayoutCmd_, ApplyColumnLayout);


        private void RemoveFieldsFromHiddenColumns_(in int value)
        {
            if (value < 2) {
                MoveFields_(ColumnTwo, value);
            }
            
            if (value < 3) {
                MoveFields_(ColumnThree, value);
                ColumnThree.Fields.Refresh();
            }
            
            if (value < 4) {
                MoveFields_(ColumnFour, value);
                ColumnThree.Fields.Refresh();
                ColumnFour.Fields.Refresh();
            }
            
            ColumnTwo.Fields.Refresh();
            ColumnOne.Fields.Refresh();
            Fields.Fields.Refresh();
        }
        
        
        private void MoveFields_(FieldListVm column, in int value)
        {
            foreach (var field in fields_.Where(field => field.DisplayColumn == column.Id))
                field.DisplayColumn = value;
        }


        private void SetColumnVisibility_(in int value)
        {
            ColumnFour.IsVisible = value > 3;
            ColumnThree.IsVisible = value > 2;
            ColumnTwo.IsVisible = value > 1;
        }
        
        
        private void ApplyColumnLayout()
        {
            core_.SaveColumnLayout(fields_.Select(f => f.BuildFieldDefinition()));
        }

    }
}