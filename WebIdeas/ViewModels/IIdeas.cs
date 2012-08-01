using System.Collections.Generic;
using WebIdeas.Models;

namespace WebIdeas.ViewModels
{
    public interface IIdeas
    {
        List<Idea> Ideas { get; }
    }
}