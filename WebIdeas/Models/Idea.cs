namespace WebIdeas.Models
{
    public class Idea
    {
        public virtual int Id { get; set; }
        public virtual string Text { get; set; }

        public virtual bool Equals(Idea other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.Id == Id && Equals(other.Text, Text);
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
                return (Id*397) ^ (Text != null ? Text.GetHashCode() : 0);
            }
        }
    }
}