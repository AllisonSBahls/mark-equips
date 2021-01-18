using System.Collections.Generic;

namespace MarkEquipsAPI.Hypermedia.Abstract
{
    public interface ISupportsHyperMedia
    {
        List<HyperMediaLink> Links { get; set; }
    }
}
