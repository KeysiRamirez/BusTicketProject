using BusTicket.Data.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using BusTicket.Data.Entities;
using BusTicket.Data.Models;
using BusTicket.Data.Base;
using BusTicket.Data.Context;

namespace BusTicket.Data.Repositories
{
    public sealed class TripInfoDetailsRepository : ITripInfoDetails
    {
        private readonly BoletoContext _boletoContext;
        private readonly ILogger<TripInfoDetailsRepository> _logger;

        public TripInfoDetailsRepository(BoletoContext boletoContext,
                                         ILogger<TripInfoDetailsRepository> logger)
        {
            _boletoContext = boletoContext;
            _logger = logger;
        }

        public async Task<bool> Exists(Expression<Func<TripInfoDetails, bool>> filter)
        {
            return await _boletoContext.ReservaDetalle.AnyAsync(filter);
        }

        public async Task<OperationResult<List<TripInfoDetailsModel>>> GetAll()
        {
            OperationResult<List<TripInfoDetailsModel>> operationResult = new OperationResult<List<TripInfoDetailsModel>>();

            try
            {
                var tripInfoDetails = await _boletoContext.ReservaDetalle
                                        .OrderByDescending(t => t.Id)
                                        .Select(t => new TripInfoDetailsModel()
                                        {
                                            IdReservaDetalle = t.Id,
                                            IdReserva = t.IdReserva,
                                            IdAsiento = t.IdAsiento
                                        }).ToListAsync();

                operationResult.Result = tripInfoDetails;
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Ocurrió un error obteniendo los detalles de los viajes.";
                _logger.LogError(operationResult.Message, ex.ToString());
            }
            return operationResult;
        }

        public async Task<OperationResult<List<TripInfoDetailsModel>>> GetAll(Expression<Func<TripInfoDetails, bool>> filter)
        {
            OperationResult<List<TripInfoDetailsModel>> operationResult = new OperationResult<List<TripInfoDetailsModel>>();

            try
            {
                var tripInfoDetails = await _boletoContext.ReservaDetalle
                                        .Where(filter)
                                        .Select(t => new TripInfoDetailsModel()
                                        {
                                            IdReservaDetalle = t.Id,
                                            IdReserva = t.IdReserva,
                                            IdAsiento = t.IdAsiento
                                        }).ToListAsync();

                operationResult.Result = tripInfoDetails;
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Ocurrió un error obteniendo los detalles de los viajes.";
                _logger.LogError(operationResult.Message, ex.ToString());
            }
            return operationResult;
        }

        public async Task<OperationResult<TripInfoDetailsModel>> GetEntityBy(int Id)
        {
            OperationResult<TripInfoDetailsModel> operationResult = new OperationResult<TripInfoDetailsModel>();

            try
            {
                if (Id <= 0)
                {
                    operationResult.Success = false;
                    operationResult.Message = "El id de los detalles de reserva es inválido";
                    return operationResult;
                }

                var tripInfoDetails = await _boletoContext.ReservaDetalle.FindAsync(Id);

                if (tripInfoDetails is null)
                {
                    operationResult.Success = false;
                    operationResult.Message = "El detalle de reserva no se encuentra registrado.";
                    return operationResult;
                }

                operationResult.Result = new TripInfoDetailsModel()
                {
                    IdReservaDetalle = tripInfoDetails.Id,
                    IdReserva = tripInfoDetails.IdReserva,
                    IdAsiento = tripInfoDetails.IdAsiento
                };
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Ocurrió un error obteniendo el detalle de reserva.";
                _logger.LogError(operationResult.Message, ex.ToString());
            }

            return operationResult;
        }

        public Task<List<OperationResult<TripInfoDetailsModel>>> GetTripInfoDetails(int idTripInfoDetails)
        {
            throw new NotImplementedException();
        }

        public async Task<OperationResult<TripInfoDetailsModel>> Remove(TripInfoDetails entity)
        {
            OperationResult<TripInfoDetailsModel> operationResult = new OperationResult<TripInfoDetailsModel>();
            try
            {
                if (entity is null)
                {
                    operationResult.Message = "La entidad de detalles de reserva no puede ser nula";
                    operationResult.Success = false;
                    return operationResult;
                }

                var tripInfoDetails = await _boletoContext.ReservaDetalle.FindAsync(entity.Id);

                if (tripInfoDetails is null)
                {
                    operationResult.Message = "El detalle de reserva no se encuentra registrado.";
                    operationResult.Success = false;
                    return operationResult;
                }

                _boletoContext.ReservaDetalle.Remove(tripInfoDetails);
                await _boletoContext.SaveChangesAsync();

                operationResult.Message = "El detalle de reserva fue eliminado correctamente.";
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Ocurrió un error eliminando el detalle de reserva.";
                _logger.LogError(operationResult.Message, ex.ToString());
            }
            return operationResult;
        }

        public async Task<OperationResult<TripInfoDetailsModel>> Save(TripInfoDetails entity)
        {
            OperationResult<TripInfoDetailsModel> operationResult = new OperationResult<TripInfoDetailsModel>();
            try
            {
                if (entity is null)
                {
                    operationResult.Message = "La entidad de detalles de reserva no puede ser nula";
                    operationResult.Success = false;
                    return operationResult;
                }

                _boletoContext.ReservaDetalle.Add(entity);
                await _boletoContext.SaveChangesAsync();

                operationResult.Message = "El detalle de reserva fue agregado correctamente.";
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Ocurrió un error guardando el detalle de reserva.";
                _logger.LogError(operationResult.Message, ex.ToString());
            }
            return operationResult;
        }

        public async Task<OperationResult<TripInfoDetailsModel>> Update(TripInfoDetails entity)
        {
            OperationResult<TripInfoDetailsModel> operationResult = new OperationResult<TripInfoDetailsModel>();

            try
            {
                if (entity is null)
                {
                    operationResult.Message = "La entidad de detalles de reserva no puede ser nula";
                    operationResult.Success = false;
                    return operationResult;
                }

                var tripInfoDetails = await _boletoContext.ReservaDetalle.FindAsync(entity.Id);

                if (tripInfoDetails is null)
                {
                    operationResult.Message = "El detalle de reserva no se encuentra registrado.";
                    operationResult.Success = false;
                    return operationResult;
                }

                tripInfoDetails.IdReserva = entity.IdReserva;
                tripInfoDetails.IdAsiento = entity.IdAsiento;

                _boletoContext.ReservaDetalle.Update(tripInfoDetails);
                await _boletoContext.SaveChangesAsync();

                operationResult.Message = "El detalle de reserva fue actualizado correctamente.";

                operationResult.Result = new TripInfoDetailsModel()
                {
                    IdReservaDetalle = tripInfoDetails.Id,
                    IdReserva = tripInfoDetails.IdReserva,
                    IdAsiento = tripInfoDetails.IdAsiento
                };
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Ocurrió un error actualizando el detalle de reserva.";
                _logger.LogError(operationResult.Message, ex.ToString());
            }
            return operationResult;
        }
    }
}
