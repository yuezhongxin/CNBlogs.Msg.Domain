namespace CNBlogs.Msg.Domain.ValueObject
{
    public class Recipient : Contact
    {
        public Recipient(int id, string displayName)
            : base(id, displayName)
        {
        }
    }
}
