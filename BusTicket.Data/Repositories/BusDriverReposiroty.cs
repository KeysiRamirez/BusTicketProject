using BusTicket.Data.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using BusTicket.Data.Entities;
using BusTicket.Data.Models;
using BusTicket.Data.Base;
using BusTicket.Data.Context;
using System.Linq;

namespace BusTicket.Data.Repositories
{
    public sealed class BusDriverRepository : IBusDriver
    {
        private readonly BoletoContext _boletoContext;
        private readonly ILogger<BusDriverRepository> _logger;

        public BusDriverRepository(BoletoContext boletoContext, ILogger<BusDriverRepository> logger)
        {
            _boletoContext = boletoContext;
            _logger = logger;
        }

        public async Task<OperationResult<List<BusDriverModel>>> GetAll()
        {
            OperationResult<List<BusDriverModel>> operationResult = new OperationResult<List<BusDriverModel>>();

            try
            {
                var busDrivers = await _boletoContext.ConductorBus
                                            .Where(cd => cd.ConductorID != null)
                                            .Select(cd => new BusDriverModel()
                                            {
                                                ConductorBusID = cd.Id,
                                                ConductorID = cd.ConductorID,
                                                BusId = cd.BusId,
                                                FechaAsignacion = cd.FechaAsignacion,
                                            }).ToListAsync();

                operationResult.Result = busDrivers;
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Ocurrió un error obteniendo los conductores de buses.";
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
                                            .Select(cd => new BusDriverModel()
                                            {
                                                ConductorBusID = cd.Id,
                                                ConductorID = cd.ConductorID,
                                                BusId = cd.BusId,
                                                FechaAsignacion = cd.FechaAsignacion,
                                            }).ToListAsync();

                operationResult.Result = busDrivers;
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Ocurrió un error obteniendo los conductores de buses.";
                _logger.LogError(operationResult.Message, ex.ToString());
            }
            return operationResult;
        }


        public async Task<OperationResult<BusDriverModel>> GetEntityBy(int Id)
        {
            OperationResult<BusDriverModel> operationResult = new OperationResult<BusDriverModel>();

            try
            {
                if (Id <= 0)
                {
                    operationResult.Success = false;
                    operationResult.Message = "El id del conductor es inválido";
                    return operationResult;
                }

                var busDriver = await _boletoContext.ConductorBus.FindAsync(Id);

                if (busDriver is null)
                {
                    operationResult.Success = false;
                    operationResult.Message = "El conductor de bus no se encuentra registrado.";
                    return operationResult;
                }

                operationResult.Result = new BusDriverModel()
                {
                    ConductorBusID = busDriver.Id,
                    ConductorID = busDriver.ConductorID,
                    BusId = busDriver.BusId,
                    FechaAsignacion = busDriver.FechaAsignacion,
                };
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Ocurrió un error obteniendo el conductor de bus.";
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
                    operationResult.Message = "La entidad conductor de bus no puede ser nula";
                    operationResult.Success = false;
                    return operationResult;
                }

                var busDriver = await _boletoContext.ConductorBus.FindAsync(entity.Id);

                if (busDriver is null)
                {
                    operationResult.Message = "El conductor de bus no se encuentra registrado.";
                    operationResult.Success = false;
                    return operationResult;
                }

                busDriver.Estatus = false;  
                busDriver.FechaModificacion = DateTime.Now;
                busDriver.UsuarioModificacion = entity.UsuarioModificacion;

                _boletoContext.ConductorBus.Update(busDriver);
                await _boletoContext.SaveChangesAsync();

                operationResult.Message = $"El conductor de bus {entity.ConductorID} fue desactivado correctamente.";
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Ocurrió un error removiendo el conductor de bus.";
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
                    operationResult.Message = "La entidad conductor de bus no puede ser nula";
                    operationResult.Success = false;
                    return operationResult;
                }

                if (entity.ConductorID <= 0 || entity.BusId <= 0)
                {
                    operationResult.Message = "El conductor y el bus son requeridos.";
                    operationResult.Success = false;
                    return operationResult;
                }

                _boletoContext.ConductorBus.Add(entity);
                await _boletoContext.SaveChangesAsync();

                operationResult.Message = $"El conductor de bus {entity.ConductorID} fue asignado correctamente.";
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Ocurrió un error guardando el conductor de bus.";
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
                    operationResult.Message = "La entidad conductor de bus no puede ser nula";
                    operationResult.Success = false;
                    return operationResult;
                }

                var busDriver = await _boletoContext.ConductorBus.FindAsync(entity.Id);

                if (busDriver is null)
                {
                    operationResult.Message = "El conductor de bus no se encuentra registrado.";
                    operationResult.Success = false;
                    return operationResult;
                }

                busDriver.ConductorID = entity.ConductorID;
                busDriver.BusId = entity.BusId;
                busDriver.FechaAsignacion = entity.FechaAsignacion;
                busDriver.FechaModificacion = DateTime.Now;
                busDriver.UsuarioModificacion = entity.UsuarioModificacion;

                _boletoContext.ConductorBus.Update(busDriver);
                await _boletoContext.SaveChangesAsync();

                operationResult.Message = $"El conductor de bus {entity.ConductorID} fue actualizado correctamente.";

                operationResult.Result = new BusDriverModel()
                {
                    ConductorBusID = busDriver.Id,
                    ConductorID = busDriver.ConductorID,
                    BusId = busDriver.BusId,
                    FechaAsignacion = busDriver.FechaAsignacion,
                };
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Ocurrió un error actualizando el conductor de bus.";
                _logger.LogError(operationResult.Message, ex.ToString());
            }
            return operationResult;
        }
    }
}