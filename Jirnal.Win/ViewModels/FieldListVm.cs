using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Data;
using GongSolutions.Wpf.DragDrop;
using Jirnal.Core;
using Jirnal.Core.JiraTypes;
using Tools.UI.WPF;

namespace Jirnal.Win.ViewModels
{
    public class FieldListVm : ViewModelBase, IDropTarget
    {
        private readonly JirnalCore core_;
        private bool isVisible_;


        public FieldListVm(JirnalCore core, IList fields, int id) 
        {
            core_ = core;
            Id = id;
            Fields = new ListCollectionView(fields) {Filter = FieldFilter_};
        }
        
        
        public ListCollectionView Fields { get; }
        public int Id { get; }


        public bool IsVisible
        {
            get => isVisible_;
            set => SetValue(ref isVisible_, value, nameof(IsVisible));
        }

        
        void IDropTarget.DragOver(IDropInfo dropInfo)
        {
            dropInfo.DropTargetAdorner = DropTargetAdorners.Insert;
            dropInfo.Effects = DragDropEffects.Move;
        }
	
        
        void IDropTarget.Drop(IDropInfo dropInfo) 
        {
            if (!(dropInfo.Data is FieldDefinitionVm field)
                || !(dropInfo.DragInfo.SourceCollection is ListCollectionView sourceCollection)
                || !(dropInfo.TargetCollection is ListCollectionView targetCollection)) 
                return;
        
            field.DisplayColumn = Id;
            var index = dropInfo.InsertIndex;
            if (ReferenceEquals(sourceCollection, targetCollection)) {
                // Adjust index for removed item
                index = Math.Max(0, index - 1);
            }
            field.Rank = index;
            sourceCollection.Refresh();
            targetCollection.Refresh();
        }

        
        private bool FieldFilter_(object obj)
        {
            if (!(obj is FieldDefinitionVm field))
                return false;
            return field.DisplayColumn == Id;
        }
    }
}