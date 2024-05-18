﻿namespace Hotel.Api.Models
{
    public class BookingResponse
    {
        public Guid Id { get; set; }
        /// <summary>
        /// <see cref="RoomRequestModel"/>
        /// </summary>
        public string NumberRoom { get; set; }
        /// <summary>
        /// <see cref="RoomRequestModel"/>
        /// </summary>
        public string PriceRoom { get; set; }
        /// <summary>
        /// <see cref="WorkerRequestModel"/>
        /// </summary>
        public string FIOWorker { get; set; }
        /// <summary>
        /// <see cref="PersonRequestModel"/>
        /// </summary>
        public string FIOPerson { get; set; }
        /// <summary>
        /// Дата бронирования
        /// </summary>
        public DateOnly DateReg { get; set; }
        /// <summary>
        /// Дата начала
        /// </summary>
        public DateOnly DateStart { get; set; }
        /// <summary>
        /// Дата окончания
        /// </summary>
        public DateOnly DateEnd { get; set; }
    }
}
