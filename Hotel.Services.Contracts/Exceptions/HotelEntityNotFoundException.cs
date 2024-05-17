namespace Hotel.Services.Contracts.Exceptions
{
    public class HotelEntityNotFoundException<TEntity> : HotelNotFoundException
    {
        public HotelEntityNotFoundException(Guid id)
            : base($"Сущность {typeof(TEntity)} c id = {id} не найдена.")
        {
        }
    }
}
