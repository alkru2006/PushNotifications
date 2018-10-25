using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PushNotifications.Models;

namespace PushNotifications.Controllers
{
    public class MsgController : Controller
    {
        // GET: Msg
        [HttpGet]
        [Route("")]
        public IActionResult Msg()
        {
            Message msg = Message.GetMessage();
            return View(msg);
        }

        // POST: Msg/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Message message)
        {
            try
            {
                var msg = Message.GetMessage();
                msg.Msg = message.Msg;
                msg.PushMessage();                

                return RedirectToAction(nameof(Msg));
            }
            catch
            {
                return View();
            }
        }
    }
}