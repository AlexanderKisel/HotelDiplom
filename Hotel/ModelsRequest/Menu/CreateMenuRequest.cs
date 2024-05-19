using Hotel.Api.Models.Enums;

namespace Hotel.ModelsRequest.Menu
{
    public class CreateMenuRequest
    {
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Цена
        /// </summary>
        public string Price { get; set; } = string.Empty;

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Вид блюда
        /// </summary>
        public TypeEatApi TypeEat { get; set; }
    }
}
