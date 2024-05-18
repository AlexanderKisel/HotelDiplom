namespace Hotel.ModelsRequest.Person
{
    public class EditPersonRequest : CreatePersonRequest
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
    }
}
