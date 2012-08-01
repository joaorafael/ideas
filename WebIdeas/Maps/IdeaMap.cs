using System;
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
            Map(x => x.Date).Not.Nullable().Default("getDate()").Not.Insert().Not.Update().Generated.Always();
            References(x => x.Contributer).Cascade.All();
            References(x => x.Tag).Cascade.All();
        }
    }
}
