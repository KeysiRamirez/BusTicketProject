using BusTicket.Data.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using BusTicket.Data.Entities;
using BusTicket.Data.Models;
using BusTicket.Data.Base;
using BusTicket.Data.Context.Configuration;

namespace BusTicket.Data.Repositories
{
    public sealed class TripRepository : ITrip
    {
        private readonly BoletoContext _boletoContext;
        private readonly ILogger<TripRepository> _logger;

        public TripRepository(BoletoContext boletoContext,
                              ILogger<TripRepository> logger)
        {
            _boletoContext = boletoContext;
            _logger = logger;
        }

        public async Task<bool> Exists(Expression<Func<Trip, bool>> filter)
        {
            return await _boletoContext.Viaje.AnyAsync(filter);
        }

        public async Task<OperationResult<List<TripModel>>> GetAll()
        {
            OperationResult<List<TripModel>> operationResult = new OperationResult<List<TripModel>>();

            try
            {
                var trips = await _boletoContext.Viaje
                                        .OrderByDescending(t => t.Id)
                                        .Select(t => new TripModel()
                                        {
                                            IdViaje = t.Id,
                                            IdBus = t.IdBus,
                                            IdRuta = t.IdRuta,
                                            FechaSalida = t.FechaSalida,
                                            HoraSalida = t.HoraSalida,
                                            FechaLlegada = t.FechaLlegada,
                                            HoraLlegada = t.HoraLlegada,
                                            Precio = t.Precio,
                                            TotalAsientos = t.TotalAsientos,
                                            AsientosReservados = t.AsientosReservados,
                                            AsientoDisponibles = t.AsientoDisponibles,
                                            Completo = t.Completo
                                        }).ToListAsync();

                operationResult.Result = trips;
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Ocurrió un error obteniendo la información de los viajes.";
                _logger.LogError(operationResult.Message, ex.ToString());
            }
            return operationResult;
        }

        public async Task<OperationResult<List<TripModel>>> GetAll(Expression<Func<Trip, bool>> filter)
        {
            OperationResult<List<TripModel>> operationResult = new OperationResult<List<TripModel>>();

            try
            {
                var trips = await _boletoContext.Viaje
                                        .Where(filter)
                                        .Select(t => new TripModel()
                                        {
                                            IdViaje = t.Id,
                                            IdBus = t.IdBus,
                                            IdRuta = t.IdRuta,
                                            FechaSalida = t.FechaSalida,
                                            HoraSalida = t.HoraSalida,
                                            FechaLlegada = t.FechaLlegada,
                                            HoraLlegada = t.HoraLlegada,
                                            Precio = t.Precio,
                                            TotalAsientos = t.TotalAsientos,
                                            AsientosReservados = t.AsientosReservados,
                                            AsientoDisponibles = t.AsientoDisponibles,
                                            Completo = t.Completo
                                        }).ToListAsync();

                operationResult.Result = trips;
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Ocurrió un error obteniendo la información de los viajes.";
                _logger.LogError(operationResult.Message, ex.ToString());
            }
            return operationResult;
        }

        public async Task<OperationResult<TripModel>> GetEntityBy(int Id)
        {
            OperationResult<TripModel> operationResult = new OperationResult<TripModel>();

            try
            {
                if (Id <= 0)
                {
                    operationResult.Success = false;
                    operationResult.Message = "El id del viaje es inválido";
                    return operationResult;
                }

                var trip = await _boletoContext.Viaje.FindAsync(Id);

                if (trip is null)
                {
                    operationResult.Success = false;
                    operationResult.Message = "El viaje no se encuentra registrado.";
                    return operationResult;
                }

                operationResult.Result = new TripModel()
                {
                    IdViaje = trip.Id,
                    IdBus = trip.IdBus,
                    IdRuta = trip.IdRuta,
                    FechaSalida = trip.FechaSalida,
                    HoraSalida = trip.HoraSalida,
                    FechaLlegada = trip.FechaLlegada,
                    HoraLlegada = trip.HoraLlegada,
                    Precio = trip.Precio,
                    TotalAsientos = trip.TotalAsientos,
                    AsientosReservados = trip.AsientosReservados,
                    AsientoDisponibles = trip.AsientoDisponibles,
                    Completo = trip.Completo
                };
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Ocurrió un error obteniendo la información del viaje.";
                _logger.LogError(operationResult.Message, ex.ToString());
            }

            return operationResult;
        }

        public Task<List<OperationResult<TripModel>>> GetTrip(int idTrip)
        {
            throw new NotImplementedException();
        }

        public async Task<OperationResult<TripModel>> Remove(Trip entity)
        {
            OperationResult<TripModel> operationResult = new OperationResult<TripModel>();
            try
            {
                if (entity is null)
                {
                    operationResult.Message = "La entidad de viaje no puede ser nula";
                    operationResult.Success = false;
                    return operationResult;
                }

                var trip = await _boletoContext.Viaje.FindAsync(entity.Id);

                if (trip is null)
                {
                    operationResult.Message = "El viaje no se encuentra registrado.";
                    operationResult.Success = false;
                    return operationResult;
                }

                _boletoContext.Viaje.Remove(trip);
                await _boletoContext.SaveChangesAsync();

                operationResult.Message = "El viaje fue eliminado correctamente.";
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Ocurrió un error eliminando el viaje.";
                _logger.LogError(operationResult.Message, ex.ToString());
            }
            return operationResult;
        }

        public async Task<OperationResult<TripModel>> Save(Trip entity)
        {
            OperationResult<TripModel> operationResult = new OperationResult<TripModel>();
            try
            {
                if (entity is null)
                {
                    operationResult.Message = "La entidad de viaje no puede ser nula";
                    operationResult.Success = false;
                    return operationResult;
                }

                _boletoContext.Viaje.Add(entity);
                await _boletoContext.SaveChangesAsync();

                operationResult.Message = "El viaje fue agregado correctamente.";
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Ocurrió un error guardando el viaje.";
                _logger.LogError(operationResult.Message, ex.ToString());
            }
            return operationResult;
        }

        public async Task<OperationResult<TripModel>> Update(Trip entity)
        {
            OperationResult<TripModel> operationResult = new OperationResult<TripModel>();

            try
            {
                if (entity is null)
                {
                    operationResult.Message = "La entidad de viaje no puede ser nula";
                    operationResult.Success = false;
                    return operationResult;
                }

                var trip = await _boletoContext.Viaje.FindAsync(entity.Id);

                if (trip is null)
                {
                    operationResult.Message = "El viaje no se encuentra registrado.";
                    operationResult.Success = false;
                    return operationResult;
                }

                trip.IdBus = entity.IdBus;
                trip.IdRuta = entity.IdRuta;
                trip.FechaSalida = entity.FechaSalida;
                trip.HoraSalida = entity.HoraSalida;
                trip.FechaLlegada = entity.FechaLlegada;
                trip.HoraLlegada = entity.HoraLlegada;
                trip.Precio = entity.Precio;
                trip.TotalAsientos = entity.TotalAsientos;
                trip.AsientosReservados = entity.AsientosReservados;
                trip.AsientoDisponibles = entity.AsientoDisponibles;
                trip.Completo = entity.Completo;

                _boletoContext.Viaje.Update(trip);
                await _boletoContext.SaveChangesAsync();

                operationResult.Message = "El viaje fue actualizado correctamente.";

                operationResult.Result = new TripModel()
                {
                    IdViaje = trip.Id,
                    IdBus = trip.IdBus,
                    IdRuta = trip.IdRuta,
                    FechaSalida = trip.FechaSalida,
                    HoraSalida = trip.HoraSalida,
                    FechaLlegada = trip.FechaLlegada,
                    HoraLlegada = trip.HoraLlegada,
                    Precio = trip.Precio,
                    TotalAsientos = trip.TotalAsientos,
                    AsientosReservados = trip.AsientosReservados,
                    AsientoDisponibles = trip.AsientoDisponibles,
                    Completo = trip.Completo
                };
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Ocurrió un error actualizando el viaje.";
                _logger.LogError(operationResult.Message, ex.ToString());
            }
            return operationResult;
        }
    }
}
