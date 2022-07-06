﻿using Microsoft.EntityFrameworkCore;
using VShop.ProductApi.Context;
using VShop.ProductApi.Models;

namespace VShop.ProductApi.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            var result = await _context.Categories.ToListAsync();
            return result;
        }
        public async Task<IEnumerable<Category>> GetCategoriesProducts()
        {
            return await _context.Categories.Include(c => c.Products).ToListAsync();
        }

        public async Task<Category> FindById(int id)
        {
            return await _context.Categories.Where(c => c.CategoryId == id).FirstOrDefaultAsync();
        }

        public async Task<Category> Create(Category category)
        {
           _context.Categories.Add(category);
           await _context.SaveChangesAsync();
           return category;
        }
        public async Task<Category> Update(Category category)
        {
            _context.Entry(category).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> Delete(int id)
        {
            var category = await FindById(id);
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return category;
        }

    }
}
