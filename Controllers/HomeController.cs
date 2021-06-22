using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;
using WebApplication4.Models.ViewModel;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetMessages()
        {
            OnlineChatEntities chatEntities = new OnlineChatEntities();
            var messages = chatEntities.Messages
                                       .OrderByDescending(x => x.PostDateTime)
                                       .Take(10);
            var result = new LinkedList<object>();
            foreach (var message in messages)
            {
                result.AddLast(new
                {
                    Username = message.Username,
                    PostDateTime = message.PostDateTime.ToString(),
                    MessageBody = message.MessageBody
                });
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddMessage(NewMessageViewModel message)
        {
            Message newMessage = new Message();
            newMessage.Username = message.Username;
            newMessage.MessageBody = message.MessageBody;
            newMessage.PostDateTime = DateTime.Now;

            OnlineChatEntities chatEntities = new OnlineChatEntities();
            chatEntities.Messages.Add(newMessage);
            chatEntities.SaveChanges();
            var result = new { message = "Success" };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}