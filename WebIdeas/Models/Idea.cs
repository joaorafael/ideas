using System;
using WebIdeas.Helpers;

namespace WebIdeas.Models
{
    public class Idea
    {
        public virtual int Id { get; set; }
        public virtual string Text { get; set; }
        public virtual string Title { get; set; }
        public virtual Tag Tag { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual Contributer Contributer { get; set; }

        public virtual bool Equals(Idea other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.Id == Id && Equals(other.Text, Text) && Equals(other.Title, Title) && Equals(other.Tag, Tag) && DateHelper.EqualsDateToTheMinute(other.Date, Date) && Equals(other.Contributer, Contributer);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Idea)) return false;
            return Equals((Idea) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = Id;
                result = (result*397) ^ (Text != null ? Text.GetHashCode() : 0);
                result = (result*397) ^ (Title != null ? Title.GetHashCode() : 0);
                result = (result*397) ^ (Tag != null ? Tag.GetHashCode() : 0);
                result = (result*397) ^ Date.GetHashCode();
                result = (result*397) ^ (Contributer != null ? Contributer.GetHashCode() : 0);
                return result;
            }
        }
    }
}