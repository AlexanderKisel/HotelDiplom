using System.Net.Mail;
using System.Net;
using Hotel.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Api.Controllers
{
    public class FeedbackController : Controller
    {
        [HttpPost]
        public IActionResult SendFeedback(FeedbackModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Отправка email
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("alekskisel5250@gmail.com");
                    mail.To.Add(new MailAddress("alekskisel5250@gmail.com"));
                    mail.Subject = "Новое сообщение с формы обратной связи";
                    mail.Body = $"Имя: {model.Name}\nEmail: {model.Email}\nСообщение: {model.Message}";
                    mail.IsBodyHtml = false;

                    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                    smtp.Credentials = new NetworkCredential("alekskisel5250@gmail.com", "xFwxCsoRH5sV");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);

                    // Возвращаем JSON-ответ, если все прошло успешно
                    return Json(new { success = true, message = "Ваш отзыв успешно отправлен!" });
                }
                catch (Exception ex)
                {
                    // Логгирование ошибки
                    Console.WriteLine(ex.Message);
                    // Возвращаем JSON-ответ с ошибками
                    return Json(new { success = false, errors = new { general = new[] { "Произошла ошибка при отправке сообщения. Пожалуйста, попробуйте еще раз." } } });
                }
            }
            else
            {
                // Возвращаем JSON-ответ с ошибками, если модель недействительна
                var errors = ModelState.Where(x => x.Value.Errors.Count > 0)
                                      .ToDictionary(x => x.Key, x => x.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return Json(new { success = false, errors = errors });
            }
        }
    }
}