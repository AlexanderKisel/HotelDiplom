namespace Hotel.Context.Contracts.Models
{
    /// <summary>
    /// Бронирование номеров
    /// </summary>
    public class Booking : BaseAuditEntity
    {
        /// <summary>
        /// <see cref="Room"/>
        /// В бронировании указывается комната
        /// </summary>
        public Guid RoomId { get; set; }

        /// <summary>
        /// Комната
        /// </summary>
        public Room? Room { get; set; }

        /// <summary>
        /// <see cref="Worker"/>
        /// В бронировании указывается сотрудник прикрепленный к этой комнате
        /// </summary>
        public Guid WorkerId { get; set; }

        /// <summary>
        /// Сотрудник
        /// </summary>
        public Worker? Worker { get; set; }

        /// <summary>
        /// <see cref="Person"/>
        /// В бронировании указывается человек, совершающий бронь
        /// </summary>
        public Guid PersonId { get; set; }

        /// <summary>
        /// Персона(Клиент)
        /// </summary>
        public Person? Person { get; set; }

        /// <summary>
        /// Дата бронирования
        /// </summary>
        public DateOnly DateReg { get; set; }

        /// <summary>
        /// Дата начала проживания(заезд)
        /// </summary>
        public DateOnly DateStart { get; set; }
        
        /// <summary>
        /// Дата окончания проживания(съезд)
        /// </summary>
        public DateOnly DateEnd { get; set; }
    }
}
