namespace Hotel.ModelsRequest.Worker
{
    public class EditWorkerRequest : CreateWorkerRequest
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
    }
}
