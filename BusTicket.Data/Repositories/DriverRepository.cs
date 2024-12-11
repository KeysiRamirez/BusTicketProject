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
    public sealed class DriverRepository : IDriver
    {
        private readonly BoletoContext _boletoContext;
        private readonly ILogger<DriverRepository> _logger;

        public DriverRepository(BoletoContext boletoContext,
                                 ILogger<DriverRepository> logger)
        {
            _boletoContext = boletoContext;
            _logger = logger;
        }

        public async Task<bool> Exists(Expression<Func<Driver, bool>> filter)
        {
            return await _boletoContext.Conductor.AnyAsync(filter);
        }

        public async Task<OperationResult<List<DriverModel>>> GetAll()
        {
            OperationResult<List<DriverModel>> operationResult = new OperationResult<List<DriverModel>>();

            try
            {
                var Conductor = await _boletoContext.Conductor
                                         .Where(d => d.Estatus == true)
                                         .OrderByDescending(d => d.FechaModificacion)
                                         .Select(d => new DriverModel()
                                         {
                                             ConductorId = d.Id,
                                             Telefono = d.Telefono,
                                             NumeroLicencia = d.NumeroLicencia,
                                             FechaContratacion = d.FechaContratacion,
                                         }).ToListAsync();

                operationResult.Result = Conductor;
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Ocurrió un error obteniendo los conductores.";
                _logger.LogError(operationResult.Message, ex.ToString());
            }
            return operationResult;
        }

        public async Task<OperationResult<List<DriverModel>>> GetAll(Expression<Func<Driver, bool>> filter)
        {
            OperationResult<List<DriverModel>> operationResult = new OperationResult<List<DriverModel>>();

            try
            {
                var Conductor = await _boletoContext.Conductor
                                         .Where(filter)
                                         .Select(d => new DriverModel()
                                         {
                                             ConductorId = d.Id,
                                             Telefono = d.Telefono,
                                             NumeroLicencia = d.NumeroLicencia,
                                             FechaContratacion = d.FechaContratacion
                                         }).ToListAsync();

                operationResult.Result = Conductor;
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Ocurrió un error obteniendo los conductores.";
                _logger.LogError(operationResult.Message, ex.ToString());
            }
            return operationResult;
        }

        public Task<List<OperationResult<DriverModel>>> GetDriver(int idDriver)
        {
            throw new NotImplementedException();
        }

        public async Task<OperationResult<DriverModel>> GetEntityBy(int Id)
        {
            OperationResult<DriverModel> operationResult = new OperationResult<DriverModel>();

            try
            {
                if (Id <= 0)
                {
                    operationResult.Success = false;
                    operationResult.Message = "El id del conductor es inválido";
                    return operationResult;
                }

                var driver = await _boletoContext.Conductor.FindAsync(Id);

                if (driver is null)
                {
                    operationResult.Success = false;
                    operationResult.Message = "El conductor no se encuentra registrado.";
                    return operationResult;
                }

                operationResult.Result = new DriverModel()
                {
                    ConductorId = driver.Id,
                    Telefono = driver.Telefono,
                    NumeroLicencia = driver.NumeroLicencia,
                    FechaContratacion = driver.FechaContratacion
                };
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Ocurrió un error obteniendo el conductor.";
                _logger.LogError(operationResult.Message, ex.ToString());
            }

            return operationResult;
        }

        public async Task<OperationResult<DriverModel>> Remove(Driver entity)
        {
            OperationResult<DriverModel> operationResult = new OperationResult<DriverModel>();
            try
            {
                if (entity is null)
                {
                    operationResult.Message = "La entidad conductor no puede ser nula";
                    operationResult.Success = false;
                    return operationResult;
                }

                var driver = await _boletoContext.Conductor.FindAsync(entity.Id);

                if (driver is null)
                {
                    operationResult.Message = "El conductor no se encuentra registrado.";
                    operationResult.Success = false;
                    return operationResult;
                }

                driver.Estatus = entity.Estatus;
                driver.FechaModificacion = entity.FechaModificacion;
                driver.UsuarioModificacion = entity.UsuarioModificacion;

                _boletoContext.Conductor.Update(driver);
                await _boletoContext.SaveChangesAsync();

                operationResult.Message = $"El conductor {entity.NumeroLicencia} fue desactivado correctamente.";
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Ocurrió un error removiendo el conductor.";
                _logger.LogError(operationResult.Message, ex.ToString());
            }
            return operationResult;
        }

        public async Task<OperationResult<DriverModel>> Save(Driver entity)
        {
            OperationResult<DriverModel> operationResult = new OperationResult<DriverModel>();
            try
            {
                if (entity is null)
                {
                    operationResult.Message = "La entidad conductor no puede ser nula";
                    operationResult.Success = false;
                    return operationResult;
                }

                if (string.IsNullOrWhiteSpace(entity.NumeroLicencia))
                {
                    operationResult.Message = "El número de licencia es requerido.";
                    operationResult.Success = false;
                    return operationResult;
                }

                _boletoContext.Conductor.Add(entity);
                await _boletoContext.SaveChangesAsync();

                operationResult.Message = $"El conductor {entity.NumeroLicencia} fue agregado correctamente.";
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Ocurrió un error guardando el conductor.";
                _logger.LogError(operationResult.Message, ex.ToString());
            }
            return operationResult;
        }

        public async Task<OperationResult<DriverModel>> Update(Driver entity)
        {
            OperationResult<DriverModel> operationResult = new OperationResult<DriverModel>();

            try
            {
                if (entity is null)
                {
                    operationResult.Message = "La entidad conductor no puede ser nula";
                    operationResult.Success = false;
                    return operationResult;
                }

                var driver = await _boletoContext.Conductor.FindAsync(entity.Id);

                if (driver is null)
                {
                    operationResult.Message = "El conductor no se encuentra registrado.";
                    operationResult.Success = false;
                    return operationResult;
                }

                driver.Telefono = entity.Telefono;
                driver.NumeroLicencia = entity.NumeroLicencia;
                driver.FechaContratacion = entity.FechaContratacion;
                driver.FechaModificacion = entity.FechaModificacion;
                driver.UsuarioModificacion = entity.UsuarioModificacion;

                _boletoContext.Conductor.Update(driver);
                await _boletoContext.SaveChangesAsync();

                operationResult.Message = $"El conductor {entity.NumeroLicencia} fue actualizado correctamente.";

                operationResult.Result = new DriverModel()
                {
                    ConductorId = driver.Id,
                    Telefono = driver.Telefono,
                    NumeroLicencia = driver.NumeroLicencia,
                    FechaContratacion = driver.FechaContratacion
                };
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Ocurrió un error actualizando el conductor.";
                _logger.LogError(operationResult.Message, ex.ToString());
            }
            return operationResult;
        }
    }
}
