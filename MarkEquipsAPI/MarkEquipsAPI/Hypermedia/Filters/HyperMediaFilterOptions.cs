using MarkEquipsAPI.Hypermedia.Abstract;
using System.Collections.Generic;

namespace MarkEquipsAPI.Hypermedia.Filters
{
    public class HyperMediaFilterOptions
    {
        public List<IResponseEnricher> ContentResponseEnricherList { get; set; } = new List<IResponseEnricher>();
    }
}
