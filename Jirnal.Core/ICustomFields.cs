using System.Collections.Generic;

namespace Jirnal.Core
{
    public interface ICustomFields
    {
        IDictionary<string, object> CustomFields { get; }
    }
}