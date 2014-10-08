/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

namespace CNBlogsMsg.Domain.ValueObject
{
    public class Recipient : Contact
    {
        public Recipient(int id, string displayName)
            : base(id, displayName)
        {
        }
    }
}
