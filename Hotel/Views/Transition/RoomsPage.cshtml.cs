using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RoomsPage
{
    public class RoomsPageModel : PageModel
    {
        public string GetData()
        {
            // Вызов контроллера и получение данных
            // Пример: 
            // var result = yourController.YourMethod();
            // return result;

            return "Данные, полученные из контроллера";
        }
    }
}