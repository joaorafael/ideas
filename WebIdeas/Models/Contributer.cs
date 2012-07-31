namespace WebIdeas.Models
{
    public class Contributer
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }

        public virtual bool Equals(Contributer other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.Id == Id && Equals(other.Name, Name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Contributer)) return false;
            return Equals((Contributer) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Id*397) ^ (Name != null ? Name.GetHashCode() : 0);
            }
        }
    }
}