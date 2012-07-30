using System.Collections.Generic;

namespace WebIdeas.Models
{
    public class HomeIndexViewModel : ITags
    {
        public List<Tag> Tags { get; private set; }

        public HomeIndexViewModel(List<Tag> tags)
        {
            Tags = tags;
        }

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
            if (other.Tags.Count == Tags.Count)
            {
                for (var i = 0; i<other.Tags.Count; i++)
                {
                    Tag otherTag = other.Tags[i];
                    Tag thisTag = Tags[i];

                    if (!(otherTag.Id.Equals(thisTag.Id) &&
                        otherTag.Name.Equals(thisTag.Name)))
                        return false;
                }
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (Tags != null ? Tags.GetHashCode() : 0);
        }

    }
}