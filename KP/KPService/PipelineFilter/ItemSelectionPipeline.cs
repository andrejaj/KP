using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPService.PipelineFilter
{
    public class ItemSelectionPipeline : Pipeline<IEnumerable<string>>
    {
        public override IEnumerable<string> Process(IEnumerable<string> input)
        {
            foreach (var filter in filters)
            {
                input = filter.Execute(input);
            }
            return input;
        }
    }
}
