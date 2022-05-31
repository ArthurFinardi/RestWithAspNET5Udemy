using System.Collections.Generic;

namespace RestWithAspNET5Udemy.Hypermedia.Abstract
{
    public interface ISupportsHyperMedia
    {
        List<HyperMediaLink> Links { get; set; }
    }
}
