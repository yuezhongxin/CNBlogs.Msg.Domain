/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

namespace CNBlogsMsg.Domain.ValueObject
{
    public class Sender : Contact
    {
        public Sender(int id, string displayName)
            : base(id, displayName)
        {
        }
    }
}
