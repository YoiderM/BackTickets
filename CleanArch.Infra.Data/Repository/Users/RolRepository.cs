using Application.Core.Exceptions;
using CleanArch.Infra.Data.Context;
using Domain.Interfaces.User;
using Domain.Models.Rol;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infra.Data.Repository.Users
{
    public class RolRepository : IRolRepository
    {
        private U27ApplicationDBContext _ctx;

        public RolRepository(U27ApplicationDBContext ctx)
        {
            _ctx = ctx;
        }

        public IQueryable<Rol> Get()
        {
            return _ctx.Rols;
        }


        public Rol Post(Rol rol)
        {

            try
            {
                _ctx.Rols.Add(rol);
                _ctx.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new NotFoundException("Rol", "El rol no fue insertado");
            }

            return rol;
        }

        public Rol Put(Rol rol)
        {

            try
            {
                _ctx.Entry(rol).State = EntityState.Modified;
                _ctx.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new NotFoundException("Rol", "El rol no fue encontrado");
            }

            return rol;
        }

        public List<Rol> PostRange(List<Rol> rol)
        {


            try
            {
                _ctx.Rols.AddRange(rol);
                _ctx.SaveChanges();
                return rol;
            }
            catch (Exception)
            {

                throw new BadRequestException("No se ha podido agregar los roles");
            }
        }


        public bool Delete(Rol rol)
        {

            try
            {
                _ctx.Remove(rol);
                _ctx.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new NotFoundException("Rol", "El rol no fue eliminado");
            }

            return true;
        }

        public Rol PutStatusActivateRolById(Rol rol)
        {
            try
            {
                rol.Status = true;
                _ctx.Entry(rol).State = EntityState.Modified;
                _ctx.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new NotFoundException("Rol", "El rol no fue modificado, " + ex.Message);
            }

            return rol;
        }

        public Rol PutStatusDeactivateRolById(Rol rol)
        {

            try
            {
                rol.Status = false;
                _ctx.Entry(rol).State = EntityState.Modified;
                _ctx.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new NotFoundException("Rol", "El rol no fue modificado");
            }

            return rol;
        }
    }
}
