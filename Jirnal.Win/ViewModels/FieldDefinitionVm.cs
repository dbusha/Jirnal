using System.Diagnostics;
using Jirnal.Core.JiraTypes;
using Tools.UI.WPF;

namespace Jirnal.Win.ViewModels
{
    [DebuggerDisplay("{Name} - {DisplayColumn}")]
    public class FieldDefinitionVm : ViewModelBase
    {
        private int rank_;
        private int displayColumn_;

        public FieldDefinitionVm(FieldDefinition field, int column = 0, int rank = 0)
        {
            Name = field.Name;
            DisplayColumn = column;
            Rank = rank;
        }
        
        
        public string Name { get; }
        public object Value { get; }


        public int DisplayColumn
        {
            get => displayColumn_;
            set => SetValue(ref displayColumn_, value, nameof(DisplayColumn));
        }


        public int Rank
        {
            get => rank_;
            set => SetValue(ref rank_, value, nameof(Rank));
        }

        public FieldDefinition BuildFieldDefinition()
        {
            return new FieldDefinition(Name, DisplayColumn, Rank);
        }
    }
}