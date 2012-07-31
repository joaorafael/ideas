using FluentNHibernate.Mapping;
using WebIdeas.Models;

namespace WebIdeas.Maps
{
    public class ContributerMap : ClassMap<Contributer>
    {
        public ContributerMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
        }
    }
}