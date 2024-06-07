using System.ComponentModel;

namespace Hotel.Api.Models.Enums
{
    /// <summary>
    /// Виды комнат
    /// </summary>
    public enum TypeRoomsApi
    {
        /// <summary>
        /// Не определено
        /// </summary>
        None,

        /// <summary>
        /// VIP - команта
        /// </summary>
        VIP,

        /// <summary>
        /// Комфорт
        /// </summary>
        Comfort,

        /// <summary>
        /// Эконом
        /// </summary>
        Economy
    }
}
