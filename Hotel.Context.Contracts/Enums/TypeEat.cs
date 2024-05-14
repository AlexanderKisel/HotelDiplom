using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Context.Contracts.Enums
{
    /// <summary>
    /// Вид еды
    /// </summary>
    public enum TypeEat
    {
        /// <summary>
        /// Неопределено
        /// </summary>
        None,

        /// <summary>
        /// Завтрак
        /// </summary>
        Breakfast,

        /// <summary>
        /// Обед
        /// </summary>
        Lunch,

        /// <summary>
        /// Полдник
        /// </summary>
        AfternoonSnack,

        /// <summary>
        /// Ужин
        /// </summary>
        Supper
    }
}
