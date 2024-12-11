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
    public sealed class TripInfoRepository : ITripInfo
    {
        private readonly BoletoContext _boletoContext;
        private readonly ILogger<TripInfoRepository> _logger;

        public TripInfoRepository(BoletoContext boletoContext,
                                  ILogger<TripInfoRepository> logger)
        {
            _boletoContext = boletoContext;
            _logger = logger;
        }

        public async Task<bool> Exists(Expression<Func<TripInfo, bool>> filter)
        {
            return await _boletoContext.Reserva.AnyAsync(filter);
        }

        public async Task<OperationResult<List<TripInfoModel>>> GetAll()
        {
            OperationResult<List<TripInfoModel>> operationResult = new OperationResult<List<TripInfoModel>>();

            try
            {
                var tripInfo = await _boletoContext.Reserva
                                        .OrderByDescending(t => t.Id)
                                        .Select(t => new TripInfoModel()
                                        {
                                            IdReserva = t.Id,
                                            IdViaje = t.IdViaje,
                                            IdPasajero = t.IdPasajero,
                                            AsientosReservados = t.AsientosReservados,
                                            MontoTotal = t.MontoTotal
                                        }).ToListAsync();

                operationResult.Result = tripInfo;
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Ocurrió un error obteniendo la información del viaje.";
                _logger.LogError(operationResult.Message, ex.ToString());
            }
            return operationResult;
        }

        public async Task<OperationResult<List<TripInfoModel>>> GetAll(Expression<Func<TripInfo, bool>> filter)
        {
            OperationResult<List<TripInfoModel>> operationResult = new OperationResult<List<TripInfoModel>>();

            try
            {
                var tripInfo = await _boletoContext.Reserva
                                        .Where(filter)
                                        .Select(t => new TripInfoModel()
                                        {
                                            IdReserva = t.Id,
                                            IdViaje = t.IdViaje,
                                            IdPasajero = t.IdPasajero,
                                            AsientosReservados = t.AsientosReservados,
                                            MontoTotal = t.MontoTotal
                                        }).ToListAsync();

                operationResult.Result = tripInfo;
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Ocurrió un error obteniendo la información del viaje.";
                _logger.LogError(operationResult.Message, ex.ToString());
            }
            return operationResult;
        }

        public async Task<OperationResult<TripInfoModel>> GetEntityBy(int Id)
        {
            OperationResult<TripInfoModel> operationResult = new OperationResult<TripInfoModel>();

            try
            {
                if (Id <= 0)
                {
                    operationResult.Success = false;
                    operationResult.Message = "El id de reserva es inválido";
                    return operationResult;
                }

                var tripInfo = await _boletoContext.Reserva.FindAsync(Id);

                if (tripInfo is null)
                {
                    operationResult.Success = false;
                    operationResult.Message = "La reserva no se encuentra registrada.";
                    return operationResult;
                }

                operationResult.Result = new TripInfoModel()
                {
                    IdReserva = tripInfo.Id,
                    IdViaje = tripInfo.IdViaje,
                    IdPasajero = tripInfo.IdPasajero,
                    AsientosReservados = tripInfo.AsientosReservados,
                    MontoTotal = tripInfo.MontoTotal
                };
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Ocurrió un error obteniendo la información de la reserva.";
                _logger.LogError(operationResult.Message, ex.ToString());
            }

            return operationResult;
        }

        public Task<List<OperationResult<TripInfoModel>>> GetTripInfo(int idTripInfo)
        {
            throw new NotImplementedException();
        }

        public async Task<OperationResult<TripInfoModel>> Remove(TripInfo entity)
        {
            OperationResult<TripInfoModel> operationResult = new OperationResult<TripInfoModel>();
            try
            {
                if (entity is null)
                {
                    operationResult.Message = "La entidad de reserva no puede ser nula";
                    operationResult.Success = false;
                    return operationResult;
                }

                var tripInfo = await _boletoContext.Reserva.FindAsync(entity.Id);

                if (tripInfo is null)
                {
                    operationResult.Message = "La reserva no se encuentra registrada.";
                    operationResult.Success = false;
                    return operationResult;
                }

                _boletoContext.Reserva.Remove(tripInfo);
                await _boletoContext.SaveChangesAsync();

                operationResult.Message = "La reserva fue eliminada correctamente.";
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Ocurrió un error eliminando la reserva.";
                _logger.LogError(operationResult.Message, ex.ToString());
            }
            return operationResult;
        }

        public async Task<OperationResult<TripInfoModel>> Save(TripInfo entity)
        {
            OperationResult<TripInfoModel> operationResult = new OperationResult<TripInfoModel>();
            try
            {
                if (entity is null)
                {
                    operationResult.Message = "La entidad de reserva no puede ser nula";
                    operationResult.Success = false;
                    return operationResult;
                }

                _boletoContext.Reserva.Add(entity);
                await _boletoContext.SaveChangesAsync();

                operationResult.Message = "La reserva fue agregada correctamente.";
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Ocurrió un error guardando la reserva.";
                _logger.LogError(operationResult.Message, ex.ToString());
            }
            return operationResult;
        }

        public async Task<OperationResult<TripInfoModel>> Update(TripInfo entity)
        {
            OperationResult<TripInfoModel> operationResult = new OperationResult<TripInfoModel>();

            try
            {
                if (entity is null)
                {
                    operationResult.Message = "La entidad de reserva no puede ser nula";
                    operationResult.Success = false;
                    return operationResult;
                }

                var tripInfo = await _boletoContext.Reserva.FindAsync(entity.Id);

                if (tripInfo is null)
                {
                    operationResult.Message = "La reserva no se encuentra registrada.";
                    operationResult.Success = false;
                    return operationResult;
                }

                tripInfo.IdViaje = entity.IdViaje;
                tripInfo.IdPasajero = entity.IdPasajero;
                tripInfo.AsientosReservados = entity.AsientosReservados;
                tripInfo.MontoTotal = entity.MontoTotal;

                _boletoContext.Reserva.Update(tripInfo);
                await _boletoContext.SaveChangesAsync();

                operationResult.Message = "La reserva fue actualizada correctamente.";

                operationResult.Result = new TripInfoModel()
                {
                    IdReserva = tripInfo.Id,
                    IdViaje = tripInfo.IdViaje,
                    IdPasajero = tripInfo.IdPasajero,
                    AsientosReservados = tripInfo.AsientosReservados,
                    MontoTotal = tripInfo.MontoTotal
                };
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Ocurrió un error actualizando la reserva.";
                _logger.LogError(operationResult.Message, ex.ToString());
            }
            return operationResult;
        }
    }
}
