using AutoMapper;
using Ecommerce.BLL.Models;
using Ecommerce.DAL.Database;
using Ecommerce.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BLL
{
    public class DomainProfile:Profile
    {
        public DomainProfile()
        {
            CreateMap<product, ProductVM>();
            CreateMap<ProductVM, product>();

            CreateMap<Order, OrderVM>();
            CreateMap<OrderVM, Order>();

            CreateMap<Customer, CustomerVM>();
            CreateMap<CustomerVM, Customer>();

            CreateMap<OrderProduct, OrderProductVM>();
            CreateMap<OrderProductVM, OrderProduct>();

            CreateMap<City, CityVm>();
            CreateMap<CityVm, City>();

            CreateMap<Country, CountryVM>();
            CreateMap<CountryVM, Country>();

            CreateMap<District, DistrictVM>();
            CreateMap<DistrictVM, District>();

            CreateMap<Supplier, SupplierVM>();
            CreateMap<SupplierVM, Supplier>();
        }
    }
}
