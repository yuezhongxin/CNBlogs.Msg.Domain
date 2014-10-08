/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

namespace CNBlogsMsg.Domain.ValueObject
{
    public class Contact
    {
        public Contact()
        {
        }

        public Contact(int id, string displayName)
        {
            this.ID = id;
            this.DisplayName = displayName;
        }

        public int ID { get; private set; }
        public string DisplayName { get; private set; }
    }
}
