using System.Collections.Generic;

namespace WebIdeas.Models
{
    public class HomeIndexViewModel : ITags, IContributers, IIdeas, ILastIdea
    {
        public List<Tag> Tags { get; set; }
        public List<Contributer> Contributers { get; set; }
        public List<Idea> Ideas { get; set; }
        public Idea LastIdea { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(HomeIndexViewModel)) return false;
            return Equals((HomeIndexViewModel)obj);
        }

        public bool Equals(HomeIndexViewModel other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            if (!ListHelpers.TestEqualList<Tag>(Tags, other.Tags))
            {
                return false;
            }
            if (!ListHelpers.TestEqualList<Contributer>(Contributers, other.Contributers))
            {
                return false;
            }
            if (!ListHelpers.TestEqualList<Idea>(Ideas, other.Ideas))
            {
                return false;
            }
            if (LastIdea == null)
            {
                return other.LastIdea == null;
            }
            return LastIdea.Equals(other.LastIdea);
        }

        public override int GetHashCode()
        {
            return (Tags != null ? Tags.GetHashCode() : 0);
        }

    }
}