using FluentNHibernate.Mapping;
using WebIdeas.Models;

namespace WebIdeas.Maps
{
    public class TagMap : ClassMap<Tag>
    {
        public TagMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
        }
    }
}