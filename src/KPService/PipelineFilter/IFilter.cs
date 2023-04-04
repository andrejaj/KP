using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPService.PipelineFilter
{
    /// <summary>
    /// A filter to be registered in the message processing pipeline
    /// </summary>
    public interface IFilter<T>
    {
        T Execute(T input);
    }
}
