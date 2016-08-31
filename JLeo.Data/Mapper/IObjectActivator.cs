using System.Collections.Generic;
using System.Data;
namespace JLeo.Data.Mapper
{
    public interface IObjectActivator
    {
        IList<T> CreateInstance<T>(IDataReader reader) where T : class, new();
    }
}
