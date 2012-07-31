using System.Collections.Generic;

namespace WebIdeas.Models
{
    public interface IIdeas
    {
        List<Idea> Ideas { get; }
    }
}