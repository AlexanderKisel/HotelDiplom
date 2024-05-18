namespace Hotel.ModelsRequest.Menu
{
    public class EditMenuRequest : CreateMenuRequest
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
    }
}
