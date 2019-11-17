using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using Jirnal.Core.JiraTypes;
using Tools;


namespace Jirnal.Core
{
    public class JiraFieldLookup : IEnumerable<FieldDefinition>
    {
        private readonly ReaderWriterLockSlim lock_ = new ReaderWriterLockSlim();
        private readonly IDictionary<string, FieldDefinition> customFieldsByName_ = new Dictionary<string, FieldDefinition>();
        private readonly IDictionary<string, FieldDefinition> customFieldsById_ = new Dictionary<string, FieldDefinition>();
        private readonly ICollection<FieldDefinition> fields_ = new Collection<FieldDefinition>();


        public void AddFields(FieldDefinition[] fieldCollection)
        {
            if (fieldCollection == null)
                return;

            using var locker = new AutoWriteLock(lock_);
            foreach (var field in fieldCollection) {
                fields_.Add(field);
                customFieldsById_.Add(field.Id, field);
                customFieldsByName_.Add(field.Name, field);
            }
        }

        public string GetFieldNameFromId(string id)
        {
            using var locker = new AutoReadLock(lock_);
            if (!customFieldsById_.TryGetValue(id, out var field) || field == null)
                throw new KeyNotFoundException(id);
            return field.Name;
        }
        
        
        public string GetFieldIdFromName(string name)
        {
            using var locker = new AutoReadLock(lock_);
            if (!customFieldsByName_.TryGetValue(name, out var field) || field == null)
                throw new KeyNotFoundException(name);
            return field.Name;
        }
        

        public IEnumerator<FieldDefinition> GetEnumerator() => fields_.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}