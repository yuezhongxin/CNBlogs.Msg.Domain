/**
* author:xishuai
**/

using CNBlogs.Msg.Domain.Entity;
using CNBlogs.Msg.ExternalService;
using CNBlogs.Msg.Infrastructure;
using System.Threading.Tasks;
namespace CNBlogs.Msg.Domain.DomainService
{
    /// <summary>
    /// SendMailMessag 领域服务实现-邮件发送
    /// </summary>
    public class SendMailMessageService : ISendMessageService
    {
        public async Task<bool> SendMessage(Message message)
        {
            string title = message.Title;
            title = "[博客园短消息通知]" + title;
            string body = message.Recipient.DisplayName + "，您好！<br/><br/>";
            body += string.Format("<a href=\"{0}\">{1}</a>给您发了短消息：<br/>", "http://home.cnblogs.com/u/" + message.Sender.ID + "/", message.Sender.DisplayName);
            body += "<br/>";
            //body += message.Content.Replace("\n", "<br/>");
            body += message.Content;
            body += "<br/><br/>------------------------------------<br/>";
            body += string.Format("查看短消息：<a href=\"{0}\">{0}</a><br/>", "http://msg.cnblogs.com/msg/item/" + message.ID + "/");
            body += "这是系统自动通知邮件，不要直接回复该邮件。";
            await MailHelper.SendAsyncMail("notify@cnblogs.biz", await UserService.GetEmailByUserId(message.Recipient.ID), title, body);
            return true;
        }
    }
}
