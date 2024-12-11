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
    public sealed class SeatRepository : ISeat
    {
        private readonly BoletoContext _boletoContext;
        private readonly ILogger<SeatRepository> _logger;

        public SeatRepository(BoletoContext boletoContext,
                              ILogger<SeatRepository> logger)
        {
            _boletoContext = boletoContext;
            _logger = logger;
        }

        public async Task<bool> Exists(Expression<Func<Seat, bool>> filter)
        {
            return await _boletoContext.Asiento.AnyAsync(filter);
        }

        public async Task<OperationResult<List<SeatModel>>> GetAll()
        {
            OperationResult<List<SeatModel>> operationResult = new OperationResult<List<SeatModel>>();

            try
            {
                var seats = await _boletoContext.Asiento
                                        .OrderByDescending(s => s.Id)
                                        .Select(s => new SeatModel()
                                        {
                                            IdAsiento = s.Id,
                                            IdBus = s.IdBus,
                                            NumeroPiso = s.NumeroPiso,
                                            NumeroAsiento = s.NumeroAsiento
                                        }).ToListAsync();

                operationResult.Result = seats;
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Ocurrió un error obteniendo los asientos.";
                _logger.LogError(operationResult.Message, ex.ToString());
            }
            return operationResult;
        }

        public async Task<OperationResult<List<SeatModel>>> GetAll(Expression<Func<Seat, bool>> filter)
        {
            OperationResult<List<SeatModel>> operationResult = new OperationResult<List<SeatModel>>();

            try
            {
                var seats = await _boletoContext.Asiento
                                        .Where(filter)
                                        .Select(s => new SeatModel()
                                        {
                                            IdAsiento = s.Id,
                                            IdBus = s.IdBus,
                                            NumeroPiso = s.NumeroPiso,
                                            NumeroAsiento = s.NumeroAsiento
                                        }).ToListAsync();

                operationResult.Result = seats;
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Ocurrió un error obteniendo los asientos.";
                _logger.LogError(operationResult.Message, ex.ToString());
            }
            return operationResult;
        }

        public async Task<OperationResult<SeatModel>> GetEntityBy(int Id)
        {
            OperationResult<SeatModel> operationResult = new OperationResult<SeatModel>();

            try
            {
                if (Id <= 0)
                {
                    operationResult.Success = false;
                    operationResult.Message = "El id del asiento es inválido";
                    return operationResult;
                }

                var seat = await _boletoContext.Asiento.FindAsync(Id);

                if (seat is null)
                {
                    operationResult.Success = false;
                    operationResult.Message = "El asiento no se encuentra registrado.";
                    return operationResult;
                }

                operationResult.Result = new SeatModel()
                {
                    IdAsiento = seat.Id,
                    IdBus = seat.IdBus,
                    NumeroPiso = seat.NumeroPiso,
                    NumeroAsiento = seat.NumeroAsiento
                };
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Ocurrió un error obteniendo el asiento.";
                _logger.LogError(operationResult.Message, ex.ToString());
            }

            return operationResult;
        }

        public Task<List<OperationResult<SeatModel>>> GetSeat(int idSeat)
        {
            throw new NotImplementedException();
        }

        public async Task<OperationResult<SeatModel>> Remove(Seat entity)
        {
            OperationResult<SeatModel> operationResult = new OperationResult<SeatModel>();
            try
            {
                if (entity is null)
                {
                    operationResult.Message = "La entidad asiento no puede ser nula";
                    operationResult.Success = false;
                    return operationResult;
                }

                var seat = await _boletoContext.Asiento.FindAsync(entity.Id);

                if (seat is null)
                {
                    operationResult.Message = "El asiento no se encuentra registrado.";
                    operationResult.Success = false;
                    return operationResult;
                }

                _boletoContext.Asiento.Remove(seat);
                await _boletoContext.SaveChangesAsync();

                operationResult.Message = "El asiento fue eliminado correctamente.";
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Ocurrió un error eliminando el asiento.";
                _logger.LogError(operationResult.Message, ex.ToString());
            }
            return operationResult;
        }

        public async Task<OperationResult<SeatModel>> Save(Seat entity)
        {
            OperationResult<SeatModel> operationResult = new OperationResult<SeatModel>();
            try
            {
                if (entity is null)
                {
                    operationResult.Message = "La entidad asiento no puede ser nula";
                    operationResult.Success = false;
                    return operationResult;
                }

                _boletoContext.Asiento.Add(entity);
                await _boletoContext.SaveChangesAsync();

                operationResult.Message = "El asiento fue agregado correctamente.";
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Ocurrió un error guardando el asiento.";
                _logger.LogError(operationResult.Message, ex.ToString());
            }
            return operationResult;
        }

        public async Task<OperationResult<SeatModel>> Update(Seat entity)
        {
            OperationResult<SeatModel> operationResult = new OperationResult<SeatModel>();

            try
            {
                if (entity is null)
                {
                    operationResult.Message = "La entidad asiento no puede ser nula";
                    operationResult.Success = false;
                    return operationResult;
                }

                var seat = await _boletoContext.Asiento.FindAsync(entity.Id);

                if (seat is null)
                {
                    operationResult.Message = "El asiento no se encuentra registrado.";
                    operationResult.Success = false;
                    return operationResult;
                }

                seat.IdBus = entity.IdBus;
                seat.NumeroPiso = entity.NumeroPiso;
                seat.NumeroAsiento = entity.NumeroAsiento;

                _boletoContext.Asiento.Update(seat);
                await _boletoContext.SaveChangesAsync();

                operationResult.Message = "El asiento fue actualizado correctamente.";

                operationResult.Result = new SeatModel()
                {
                    IdAsiento = seat.Id,
                    IdBus = seat.IdBus,
                    NumeroPiso = seat.NumeroPiso,
                    NumeroAsiento = seat.NumeroAsiento
                };
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Ocurrió un error actualizando el asiento.";
                _logger.LogError(operationResult.Message, ex.ToString());
            }
            return operationResult;
        }
    }
}
