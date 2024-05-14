using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Context.Contracts.Enums
{
    /// <summary>
    /// Виды комнат
    /// </summary>
    public enum TypeRooms
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
