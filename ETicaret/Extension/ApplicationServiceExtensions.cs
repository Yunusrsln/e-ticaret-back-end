using API.Core.Interfaces;
using API.Infrastructure.Data;
using API.Infrastructure.Implements;
using API.Infrastructure.Services;

namespace ETicaret.Extension
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<TokenService, TokenService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<PaymentService, PaymentService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
          services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));
            return services;
        }
    }
}
