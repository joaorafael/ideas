using FluentNHibernate.Mapping;
using WebIdeas.Models;

namespace WebIdeas.Maps
{
    public class IdeaMap : ClassMap<Idea>
    {
        public IdeaMap()
        {
            Id(x => x.Id);
            Map(x => x.Text);
        }
    }
}