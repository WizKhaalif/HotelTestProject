using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using HotelAdministrationSystem.Domain.Abstractions;
using HotelAdministrationSystem.Domain.Services;

namespace HotelAdministrationSystem.Domain.Entities
{
    public static class DomainExtensions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection collection)
        {
            collection.AddScoped<IRoomServise, RoomService>();
            collection.AddScoped<IClientServise, ClientService>();
            return collection;
        }
    }
}
