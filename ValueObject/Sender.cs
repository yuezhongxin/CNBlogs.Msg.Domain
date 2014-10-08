namespace CNBlogs.Msg.Domain.ValueObject
{
    public class Sender : Contact
    {
        public Sender(int id, string displayName)
            : base(id, displayName)
        {
        }
    }
}
