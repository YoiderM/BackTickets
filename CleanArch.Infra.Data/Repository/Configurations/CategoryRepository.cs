using Application.Core.Exceptions;
using CleanArch.Infra.Data.Context;
using Core.Models.configuration;
using Domain.Interfaces.Configurations;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Data.Repository.Configurations
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly U27ApplicationDBContext _ctx;
        public CategoryRepository(U27ApplicationDBContext ctx)
        {
            _ctx = ctx;
        }

        public IQueryable<Category> Get()
        {
            return _ctx.Categories;
        }

        public Category Post(Category category)
        {
            _ctx.Categories.Add(category);

            try
            {
                _ctx.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new NotFoundException("Category", $"La categoría no fue insertada{ ex.Message }");
            }

            return category;
        }

        public Category Put(Category category)
        {
            _ctx.Entry(category).State = EntityState.Modified;

            try
            {
                _ctx.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new NotFoundException("Category", $"La categoría no fue modificada{ ex.Message }");
            }

            return category;
        }

        public Category Activate(Category category)
        {
            category.Status = true;
            _ctx.Entry(category).State = EntityState.Modified;

            try
            {
                _ctx.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new NotFoundException("Category", $"La categoría no fue modificada{ ex.Message }");
            }

            return category;
        }

        public async Task<Category> Deactivate(Category category)
        {
            category.Status = false;
            _ctx.Entry(category).State = EntityState.Modified;

            try
            {
                await _ctx.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new NotFoundException("Category", $"La categoría no fue modificada,{ ex.Message }");
            }

            return category;
        }

        public bool Delete(Category category)
        {
            _ctx.Remove(category);

            try
            {
                _ctx.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new NotFoundException("Category", $"La categoría no fue eliminada { ex.Message }");
            }

            return true;
        }

    }
}
