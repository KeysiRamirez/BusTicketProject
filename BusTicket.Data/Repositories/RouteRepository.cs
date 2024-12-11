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
    public sealed class RouteRepository : IRoute
    {
        private readonly BoletoContext _boletoContext;
        private readonly ILogger<RouteRepository> _logger;

        public RouteRepository(BoletoContext boletoContext,
                                ILogger<RouteRepository> logger)
        {
            _boletoContext = boletoContext;
            _logger = logger;
        }

        public async Task<bool> Exists(Expression<Func<Route, bool>> filter)
        {
            return await _boletoContext.Ruta.AnyAsync(filter);
        }

        public async Task<OperationResult<List<RouteModel>>> GetAll()
        {
            OperationResult<List<RouteModel>> operationResult = new OperationResult<List<RouteModel>>();

            try
            {
                var routes = await _boletoContext.Ruta
                                        .OrderByDescending(rt => rt.Id)
                                        .Select(rt => new RouteModel()
                                        {
                                            IdRuta = rt.Id,
                                            PickUpLocation = rt.PickUpLocation,
                                            Destination = rt.Destination
                                        }).ToListAsync();

                operationResult.Result = routes;
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Ocurrió un error obteniendo las rutas.";
                _logger.LogError(operationResult.Message, ex.ToString());
            }
            return operationResult;
        }

        public async Task<OperationResult<List<RouteModel>>> GetAll(Expression<Func<Route, bool>> filter)
        {
            OperationResult<List<RouteModel>> operationResult = new OperationResult<List<RouteModel>>();

            try
            {
                var routes = await _boletoContext.Ruta
                                        .Where(filter)
                                        .Select(rt => new RouteModel()
                                        {
                                            IdRuta = rt.Id,
                                            PickUpLocation = rt.PickUpLocation,
                                            Destination = rt.Destination
                                        }).ToListAsync();

                operationResult.Result = routes;
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Ocurrió un error obteniendo las rutas.";
                _logger.LogError(operationResult.Message, ex.ToString());
            }
            return operationResult;
        }

        public Task<List<OperationResult<RouteModel>>> GetBusDriver(int idRoute)
        {
            throw new NotImplementedException();
        }

        public async Task<OperationResult<RouteModel>> GetEntityBy(int Id)
        {
            OperationResult<RouteModel> operationResult = new OperationResult<RouteModel>();

            try
            {
                if (Id <= 0)
                {
                    operationResult.Success = false;
                    operationResult.Message = "El id de la ruta es inválido";
                    return operationResult;
                }

                var route = await _boletoContext.Ruta.FindAsync(Id);

                if (route is null)
                {
                    operationResult.Success = false;
                    operationResult.Message = "La ruta no se encuentra registrada.";
                    return operationResult;
                }

                operationResult.Result = new RouteModel()
                {
                    IdRuta = route.Id,
                    PickUpLocation = route.PickUpLocation,
                    Destination = route.Destination
                };
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Ocurrió un error obteniendo la ruta.";
                _logger.LogError(operationResult.Message, ex.ToString());
            }

            return operationResult;
        }

        public async Task<OperationResult<RouteModel>> Remove(Route entity)
        {
            OperationResult<RouteModel> operationResult = new OperationResult<RouteModel>();
            try
            {
                if (entity is null)
                {
                    operationResult.Message = "La entidad ruta no puede ser nula";
                    operationResult.Success = false;
                    return operationResult;
                }

                var route = await _boletoContext.Ruta.FindAsync(entity.Id);

                if (route is null)
                {
                    operationResult.Message = "La ruta no se encuentra registrada.";
                    operationResult.Success = false;
                    return operationResult;
                }

                _boletoContext.Ruta.Remove(route);
                await _boletoContext.SaveChangesAsync();

                operationResult.Message = "La ruta fue eliminada correctamente.";
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Ocurrió un error eliminando la ruta.";
                _logger.LogError(operationResult.Message, ex.ToString());
            }
            return operationResult;
        }

        public async Task<OperationResult<RouteModel>> Save(Route entity)
        {
            OperationResult<RouteModel> operationResult = new OperationResult<RouteModel>();
            try
            {
                if (entity is null)
                {
                    operationResult.Message = "La entidad ruta no puede ser nula";
                    operationResult.Success = false;
                    return operationResult;
                }

                _boletoContext.Ruta.Add(entity);
                await _boletoContext.SaveChangesAsync();

                operationResult.Message = "La ruta fue agregada correctamente.";
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Ocurrió un error guardando la ruta.";
                _logger.LogError(operationResult.Message, ex.ToString());
            }
            return operationResult;
        }

        public async Task<OperationResult<RouteModel>> Update(Route entity)
        {
            OperationResult<RouteModel> operationResult = new OperationResult<RouteModel>();

            try
            {
                if (entity is null)
                {
                    operationResult.Message = "La entidad ruta no puede ser nula";
                    operationResult.Success = false;
                    return operationResult;
                }

                var route = await _boletoContext.Ruta.FindAsync(entity.Id);

                if (route is null)
                {
                    operationResult.Message = "La ruta no se encuentra registrada.";
                    operationResult.Success = false;
                    return operationResult;
                }

                route.PickUpLocation = entity.PickUpLocation;
                route.Destination = entity.Destination;

                _boletoContext.Ruta.Update(route);
                await _boletoContext.SaveChangesAsync();

                operationResult.Message = "La ruta fue actualizada correctamente.";

                operationResult.Result = new RouteModel()
                {
                    IdRuta = route.Id,
                    PickUpLocation = route.PickUpLocation,
                    Destination = route.Destination
                };
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Ocurrió un error actualizando la ruta.";
                _logger.LogError(operationResult.Message, ex.ToString());
            }
            return operationResult;
        }
    }
}
