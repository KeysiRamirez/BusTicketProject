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
    public sealed class UserRepository : IUser
    {
        private readonly BoletoContext _boletoContext;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(BoletoContext boletoContext,
                              ILogger<UserRepository> logger)
        {
            _boletoContext = boletoContext;
            _logger = logger;
        }

        public async Task<bool> Exists(Expression<Func<User, bool>> filter)
        {
            return await _boletoContext.Usuario.AnyAsync(filter);
        }

        public async Task<OperationResult<List<UserModel>>> GetAll()
        {
            OperationResult<List<UserModel>> operationResult = new OperationResult<List<UserModel>>();

            try
            {
                var users = await _boletoContext.Usuario
                                        .OrderByDescending(u => u.Id)
                                        .Select(u => new UserModel()
                                        {
                                            IdUsuario = u.Id,
                                            Nombres = u.Nombres,
                                            Apellidos = u.Apellidos,
                                            Correo = u.Correo,
                                            Clave = u.Clave,
                                            TipoUsuario = u.TipoUsuario
                                        }).ToListAsync();

                operationResult.Result = users;
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Ocurrió un error obteniendo los usuarios.";
                _logger.LogError(operationResult.Message, ex.ToString());
            }
            return operationResult;
        }

        public async Task<OperationResult<List<UserModel>>> GetAll(Expression<Func<User, bool>> filter)
        {
            OperationResult<List<UserModel>> operationResult = new OperationResult<List<UserModel>>();

            try
            {
                var users = await _boletoContext.Usuario
                                        .Where(filter)
                                        .Select(u => new UserModel()
                                        {
                                            IdUsuario = u.Id,
                                            Nombres = u.Nombres,
                                            Apellidos = u.Apellidos,
                                            Correo = u.Correo,
                                            Clave = u.Clave,
                                            TipoUsuario = u.TipoUsuario
                                        }).ToListAsync();

                operationResult.Result = users;
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Ocurrió un error obteniendo los usuarios.";
                _logger.LogError(operationResult.Message, ex.ToString());
            }
            return operationResult;
        }

        public async Task<OperationResult<UserModel>> GetEntityBy(int Id)
        {
            OperationResult<UserModel> operationResult = new OperationResult<UserModel>();

            try
            {
                if (Id <= 0)
                {
                    operationResult.Success = false;
                    operationResult.Message = "El id del usuario es inválido";
                    return operationResult;
                }

                var user = await _boletoContext.Usuario.FindAsync(Id);

                if (user is null)
                {
                    operationResult.Success = false;
                    operationResult.Message = "El usuario no se encuentra registrado.";
                    return operationResult;
                }

                operationResult.Result = new UserModel()
                {
                    IdUsuario = user.Id,
                    Nombres = user.Nombres,
                    Apellidos = user.Apellidos,
                    Correo = user.Correo,
                    Clave = user.Clave,
                    TipoUsuario = user.TipoUsuario
                };
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Ocurrió un error obteniendo el usuario.";
                _logger.LogError(operationResult.Message, ex.ToString());
            }

            return operationResult;
        }

        public Task<List<OperationResult<UserModel>>> GetUser(int idUser)
        {
            throw new NotImplementedException();
        }

        public async Task<OperationResult<UserModel>> Remove(User entity)
        {
            OperationResult<UserModel> operationResult = new OperationResult<UserModel>();
            try
            {
                if (entity is null)
                {
                    operationResult.Message = "La entidad de usuario no puede ser nula";
                    operationResult.Success = false;
                    return operationResult;
                }

                var user = await _boletoContext.Usuario.FindAsync(entity.Id);

                if (user is null)
                {
                    operationResult.Message = "El usuario no se encuentra registrado.";
                    operationResult.Success = false;
                    return operationResult;
                }

                _boletoContext.Usuario.Remove(user);
                await _boletoContext.SaveChangesAsync();

                operationResult.Message = "El usuario fue eliminado correctamente.";
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Ocurrió un error eliminando el usuario.";
                _logger.LogError(operationResult.Message, ex.ToString());
            }
            return operationResult;
        }

        public async Task<OperationResult<UserModel>> Save(User entity)
        {
            OperationResult<UserModel> operationResult = new OperationResult<UserModel>();
            try
            {
                if (entity is null)
                {
                    operationResult.Message = "La entidad de usuario no puede ser nula";
                    operationResult.Success = false;
                    return operationResult;
                }

                _boletoContext.Usuario.Add(entity);
                await _boletoContext.SaveChangesAsync();

                operationResult.Message = "El usuario fue agregado correctamente.";
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Ocurrió un error guardando el usuario.";
                _logger.LogError(operationResult.Message, ex.ToString());
            }
            return operationResult;
        }

        public async Task<OperationResult<UserModel>> Update(User entity)
        {
            OperationResult<UserModel> operationResult = new OperationResult<UserModel>();

            try
            {
                if (entity is null)
                {
                    operationResult.Message = "La entidad de usuario no puede ser nula";
                    operationResult.Success = false;
                    return operationResult;
                }

                var user = await _boletoContext.Usuario.FindAsync(entity.Id);

                if (user is null)
                {
                    operationResult.Message = "El usuario no se encuentra registrado.";
                    operationResult.Success = false;
                    return operationResult;
                }

                user.Nombres = entity.Nombres;
                user.Apellidos = entity.Apellidos;
                user.Correo = entity.Correo;
                user.Clave = entity.Clave;
                user.TipoUsuario = entity.TipoUsuario;

                _boletoContext.Usuario.Update(user);
                await _boletoContext.SaveChangesAsync();

                operationResult.Message = "El usuario fue actualizado correctamente.";

                operationResult.Result = new UserModel()
                {
                    IdUsuario = user.Id,
                    Nombres = user.Nombres,
                    Apellidos = user.Apellidos,
                    Correo = user.Correo,
                    Clave = user.Clave,
                    TipoUsuario = user.TipoUsuario
                };
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Ocurrió un error actualizando el usuario.";
                _logger.LogError(operationResult.Message, ex.ToString());
            }
            return operationResult;
        }
    }
}
