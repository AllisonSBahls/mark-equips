using System.Collections.Generic;

namespace MarkEquipsAPI.Hypermedia.Abstract
{
    public interface ISupportHyperMedia
    {
        List<HyperMediaLink> Links { get; set; }
    }
}
