using Microsoft.Extensions.DependencyInjection;

namespace Hotel.Common
{
    public abstract class Module
    {
        /// <summary>
        /// Создаёт зависимости
        /// </summary>
        public abstract void CreateModule(IServiceCollection service);
    }
}
