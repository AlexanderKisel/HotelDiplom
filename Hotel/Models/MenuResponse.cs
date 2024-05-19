namespace Hotel.Api.Models
{
    /// <summary>
    /// Модель ответа сущности меню
    /// </summary>
    public class MenuResponse
    {
        /// <summary>
        /// идентификатор
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Цена
        /// </summary>
        public string Price { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Тип еды
        /// </summary>
        public string TypeEat { get; set; } = string.Empty;
    }
}
