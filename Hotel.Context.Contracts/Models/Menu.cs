using Hotel.Context.Contracts.Enums;

namespace Hotel.Context.Contracts.Models
{
    /// <summary>
    /// Меню
    /// </summary>
    public class Menu : BaseAuditEntity
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
        public TypeEat TypeEat { get; set; } = TypeEat.None;

    }
}
