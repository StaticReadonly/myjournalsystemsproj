namespace Domain.Entities
{
    public abstract class Entity<T>
    {
        public T Id { get; private set; }

        protected Entity(T id)
        {
            Id = id;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Entity<T> other)
            {
                return false;
            }
            else if (ReferenceEquals(this, other))
            {
                return true;
            }
            else if (EqualityComparer<T>.Default.Equals(Id, default) || EqualityComparer<T>.Default.Equals(other.Id, default))
            {
                return false;
            }

            return EqualityComparer<T>.Default.Equals(Id, other.Id);
        }

        public override int GetHashCode()
        {
            return Id?.GetHashCode() ?? 0;
        }
    }
}
