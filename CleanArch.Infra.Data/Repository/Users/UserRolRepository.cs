using Application.Core.Exceptions;
using CleanArch.Infra.Data.Context;
using Domain.Interfaces.User;
using Domain.Models.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infra.Data.Repository.Users
{
    public class UserRolRepository : IUserRolRepository
    {
        private U27ApplicationDBContext _ctx;

        public UserRolRepository(U27ApplicationDBContext ctx)
        {
            _ctx = ctx;
        }

        public IQueryable<UserRol> Get()
        {
            return _ctx.UserRols;
        }


        public UserRol Post(UserRol userRol)
        {

            try
            {
                _ctx.UserRols.Add(userRol);
                _ctx.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new NotFoundException("ScheduledAppointment", "El usuario rol no fue insertado");
            }

            return userRol;
        }


        public UserRol Put(UserRol userRol)
        {

            try
            {
                _ctx.Entry(userRol).State = EntityState.Modified;
                _ctx.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new NotFoundException("UserRol", "El usuario rol no fue encontrado");
            }

            return userRol;
        }

        public List<UserRol> PostRange(List<UserRol> userRol)
        {


            try
            {
                _ctx.UserRols.AddRange(userRol);
                _ctx.SaveChanges();
                return userRol;
            }
            catch (Exception)
            {

                throw new BadRequestException("No se ha podido agregar los usuarios roles");
            }
        }


        public bool Delete(UserRol userRol)
        {

            try
            {
                _ctx.Remove(userRol);
                _ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw new NotFoundException("User", "El usuario rol no fue eliminado");
            }

            return true;
        }

        public bool DeleteRange(List<UserRol> userRol)
        {

            try
            {
                _ctx.RemoveRange(userRol);
                _ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw new NotFoundException("User", "El usuario rol no fue eliminado");
            }

            return true;
        }

    }
}
