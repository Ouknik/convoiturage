using AutoMapper;
using Serveur.DTOs.Reservations;
using Serveur.DTOs.Trips;
using Serveur.Models.Entities;

namespace Serveur.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Trip, TripResponseDto>();
        CreateMap<Reservation, ReservationResponseDto>();
    }
}
