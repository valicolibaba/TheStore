using AutoMapper;
using Store.Domain.CustomerManagement;
using Store.Service.OrderService.Data;
using Store.Service.ProductService.Data;

namespace Store.Service.AutoMapperProfiles
{
    public class GeneralAutoMapperProfile : Profile
    {
        public GeneralAutoMapperProfile()
        {
            CreateMap<Customer, CustomerService.Data.Customer>().ReverseMap();
            CreateMap<Product, Domain.ProductManagement.Product>().ReverseMap();
            CreateMap<Order, Domain.OrderManagement.Order>().ReverseMap();
            CreateMap<Cart, Domain.CartManagement.Cart>().ReverseMap();
        }
    }
}