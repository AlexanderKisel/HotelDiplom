namespace Hotel.ModelsRequest.Room
{
    public class EditRoomRequest :CreateRoomRequest
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
    }
}
