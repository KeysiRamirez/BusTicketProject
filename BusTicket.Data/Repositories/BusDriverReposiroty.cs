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
    public sealed class BusDriverRepository : IBusDriver
    {
        private readonly BoletoContext _boletoContext;
        private readonly ILogger<BusDriverRepository> _logger;

        public BusDriverRepository(BoletoContext boletoContext,
                                     ILogger<BusDriverRepository> logger)
        {
            _boletoContext = boletoContext;
            _logger = logger;
        }

        public async Task<bool> Exists(Expression<Func<BusDriver, bool>> filter)
        {
            return await _boletoContext.ConductorBus.AnyAsync(filter);
        }

        public async Task<OperationResult<List<BusDriverModel>>> GetAll()
        {
            OperationResult<List<BusDriverModel>> operationResult = new OperationResult<List<BusDriverModel>>();

            try
            {
                var busDrivers = await _boletoContext.ConductorBus
                                          .OrderByDescending(bd => bd.FechaAsignacion)
                                          .Select(bd => new BusDriverModel()
                                          {
                                              ConductorBusID = bd.Id,
                                              ConductorID = bd.ConductorID,
                                              BusId = bd.BusId,
                                              FechaAsignacion = bd.FechaAsignacion
                                          }).ToListAsync();

                operationResult.Result = busDrivers;
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Ocurrió un error obteniendo las asignaciones de conductores a buses.";
                _logger.LogError(operationResult.Message, ex.ToString());
            }
            return operationResult;
        }

        public async Task<OperationResult<List<BusDriverModel>>> GetAll(Expression<Func<BusDriver, bool>> filter)
        {
            OperationResult<List<BusDriverModel>> operationResult = new OperationResult<List<BusDriverModel>>();

            try
            {
                var busDrivers = await _boletoContext.ConductorBus
                                          .Where(filter)
                                          .Select(bd => new BusDriverModel()
                                          {
                                              ConductorBusID = bd.Id,
                                              ConductorID = bd.ConductorID,
                                              BusId = bd.BusId,
                                              FechaAsignacion = bd.FechaAsignacion
                                          }).ToListAsync();

                operationResult.Result = busDrivers;
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Ocurrió un error obteniendo las asignaciones de conductores a buses.";
                _logger.LogError(operationResult.Message, ex.ToString());
            }
            return operationResult;
        }

        public Task<List<OperationResult<BusDriverModel>>> GetBusDriver(int idBusDriver)
        {
            throw new NotImplementedException();
        }

        public async Task<OperationResult<BusDriverModel>> GetEntityBy(int Id)
        {
            OperationResult<BusDriverModel> operationResult = new OperationResult<BusDriverModel>();

            try
            {
                if (Id <= 0)
                {
                    operationResult.Success = false;
                    operationResult.Message = "El id de la asignación es inválido";
                    return operationResult;
                }

                var busDriver = await _boletoContext.ConductorBus.FindAsync(Id);

                if (busDriver is null)
                {
                    operationResult.Success = false;
                    operationResult.Message = "La asignación no se encuentra registrada.";
                    return operationResult;
                }

                operationResult.Result = new BusDriverModel()
                {
                    ConductorBusID = busDriver.Id,
                    ConductorID = busDriver.ConductorID,
                    BusId = busDriver.BusId,
                    FechaAsignacion = busDriver.FechaAsignacion
                };
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Ocurrió un error obteniendo la asignación.";
                _logger.LogError(operationResult.Message, ex.ToString());
            }

            return operationResult;
        }

        public async Task<OperationResult<BusDriverModel>> Remove(BusDriver entity)
        {
            OperationResult<BusDriverModel> operationResult = new OperationResult<BusDriverModel>();
            try
            {
                if (entity is null)
                {
                    operationResult.Message = "La entidad asignación no puede ser nula";
                    operationResult.Success = false;
                    return operationResult;
                }

                var busDriver = await _boletoContext.ConductorBus.FindAsync(entity.Id);

                if (busDriver is null)
                {
                    operationResult.Message = "La asignación no se encuentra registrada.";
                    operationResult.Success = false;
                    return operationResult;
                }

                _boletoContext.ConductorBus.Remove(busDriver);
                await _boletoContext.SaveChangesAsync();

                operationResult.Message = "La asignación fue eliminada correctamente.";
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Ocurrió un error eliminando la asignación.";
                _logger.LogError(operationResult.Message, ex.ToString());
            }
            return operationResult;
        }

        public async Task<OperationResult<BusDriverModel>> Save(BusDriver entity)
        {
            OperationResult<BusDriverModel> operationResult = new OperationResult<BusDriverModel>();
            try
            {
                if (entity is null)
                {
                    operationResult.Message = "La entidad asignación no puede ser nula";
                    operationResult.Success = false;
                    return operationResult;
                }

                _boletoContext.ConductorBus.Add(entity);
                await _boletoContext.SaveChangesAsync();

                operationResult.Message = "La asignación fue agregada correctamente.";
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Ocurrió un error guardando la asignación.";
                _logger.LogError(operationResult.Message, ex.ToString());
            }
            return operationResult;
        }

        public async Task<OperationResult<BusDriverModel>> Update(BusDriver entity)
        {
            OperationResult<BusDriverModel> operationResult = new OperationResult<BusDriverModel>();

            try
            {
                if (entity is null)
                {
                    operationResult.Message = "La entidad asignación no puede ser nula";
                    operationResult.Success = false;
                    return operationResult;
                }

                var busDriver = await _boletoContext.ConductorBus.FindAsync(entity.Id);

                if (busDriver is null)
                {
                    operationResult.Message = "La asignación no se encuentra registrada.";
                    operationResult.Success = false;
                    return operationResult;
                }

                busDriver.ConductorID = entity.ConductorID;
                busDriver.BusId = entity.BusId;
                busDriver.FechaAsignacion = entity.FechaAsignacion;

                _boletoContext.ConductorBus.Update(busDriver);
                await _boletoContext.SaveChangesAsync();

                operationResult.Message = "La asignación fue actualizada correctamente.";

                operationResult.Result = new BusDriverModel()
                {
                    ConductorBusID = busDriver.Id,
                    ConductorID = busDriver.ConductorID,
                    BusId = busDriver.BusId,
                    FechaAsignacion = busDriver.FechaAsignacion
                };
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Ocurrió un error actualizando la asignación.";
                _logger.LogError(operationResult.Message, ex.ToString());
            }
            return operationResult;
        }
    }
}
