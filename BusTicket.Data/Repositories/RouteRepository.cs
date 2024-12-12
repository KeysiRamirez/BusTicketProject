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
    public sealed class RouteRepository : IRoute
    {
        private readonly BoletoContext _boletoContext;
        private readonly ILogger<RouteRepository> _logger;

        public RouteRepository(BoletoContext boletoContext, ILogger<RouteRepository> logger)
        {
            _boletoContext = boletoContext;
            _logger = logger;
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

                if (routes == null || routes.Count == 0)
                {
                    operationResult.Message = "No se encontraron rutas.";
                    operationResult.Success = true;  // Éxito pero sin datos.
                }
                else
                {
                    operationResult.Result = routes;
                    operationResult.Message = "Rutas obtenidas correctamente.";
                    operationResult.Success = true;
                }
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
            var operationResult = new OperationResult<List<RouteModel>>();

            try
            {
                var routes = await _boletoContext.Ruta
                    .Where(filter)
                    .Select(rt => new RouteModel
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
                operationResult.Message = "Error al obtener las rutas.";
                _logger.LogError(operationResult.Message, ex);
            }

            return operationResult;
        }

            public async Task<OperationResult<RouteModel>> GetEntityBy(int Id)
            {
            var operationResult = new OperationResult<RouteModel>();

            try
            {
                if (Id <= 0)
                {
                    operationResult.Success = false;
                    operationResult.Message = "ID de ruta inválido.";
                    return operationResult;
                }

                var route = await _boletoContext.Ruta.FindAsync(Id);

                if (route == null)
                {
                    operationResult.Success = false;
                    operationResult.Message = "Ruta no encontrada.";
                    return operationResult;
                }

                operationResult.Result = new RouteModel
                {
                    IdRuta = route.Id,
                    PickUpLocation = route.PickUpLocation,
                    Destination = route.Destination
                };
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Error al obtener la ruta.";
                _logger.LogError(operationResult.Message, ex);
            }

            return operationResult;
        }

        public async Task<OperationResult<RouteModel>> Remove(Route entity)
        {
            var operationResult = new OperationResult<RouteModel>();

            try
            {
                if (entity == null)
                {
                    operationResult.Success = false;
                    operationResult.Message = "La ruta no puede ser nula.";
                    return operationResult;
                }

                var route = await _boletoContext.Ruta.FindAsync(entity.Id);

                if (route == null)
                {
                    operationResult.Success = false;
                    operationResult.Message = "Ruta no encontrada.";
                    return operationResult;
                }

                _boletoContext.Ruta.Remove(route);
                await _boletoContext.SaveChangesAsync();

                operationResult.Message = "Ruta eliminada correctamente.";
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Error al eliminar la ruta.";
                _logger.LogError(operationResult.Message, ex);
            }

            return operationResult;
        }

        public async Task<OperationResult<RouteModel>> Save(Route entity)
        {
            var operationResult = new OperationResult<RouteModel>();

            try
            {
                if (entity == null)
                {
                    operationResult.Success = false;
                    operationResult.Message = "La ruta no puede ser nula.";
                    return operationResult;
                }

                _boletoContext.Ruta.Add(entity);
                await _boletoContext.SaveChangesAsync();

                operationResult.Message = "Ruta guardada correctamente.";
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Error al guardar la ruta.";
                _logger.LogError(operationResult.Message, ex);
            }

            return operationResult;
        }

        public async Task<OperationResult<RouteModel>> Update(Route entity)
        {
            var operationResult = new OperationResult<RouteModel>();

            try
            {
                if (entity == null)
                {
                    operationResult.Success = false;
                    operationResult.Message = "La ruta no puede ser nula.";
                    return operationResult;
                }

                var route = await _boletoContext.Ruta.FindAsync(entity.Id);

                if (route == null)
                {
                    operationResult.Success = false;
                    operationResult.Message = "Ruta no encontrada.";
                    return operationResult;
                }

                route.PickUpLocation = entity.PickUpLocation;
                route.Destination = entity.Destination;

                _boletoContext.Ruta.Update(route);
                await _boletoContext.SaveChangesAsync();

                operationResult.Message = "Ruta actualizada correctamente.";
                operationResult.Result = new RouteModel
                {
                    IdRuta = route.Id,
                    PickUpLocation = route.PickUpLocation,
                    Destination = route.Destination
                };
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Error al actualizar la ruta.";
                _logger.LogError(operationResult.Message, ex);
            }

            return operationResult;
        }
    }
}
