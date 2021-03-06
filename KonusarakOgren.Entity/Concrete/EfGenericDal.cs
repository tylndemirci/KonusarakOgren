﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using KonusarakOgren.Entity.Abstract;
using Microsoft.EntityFrameworkCore;

namespace KonusarakOgren.Entity.Concrete
{
    public class EfGenericDal<T> : IGenericDal<T> where T : class
    {
        private readonly KonusarakOgrenContext _context;

        public EfGenericDal(KonusarakOgrenContext context)
        {
            _context = context;
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public IQueryable<T> GetBy(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public T Create(T entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            return entity;
        }

        public void CreateGroup(List<T> entities)
        {
            foreach (var entity in entities)
            {
                _context.Entry(entity).State = EntityState.Added;
            }
        }


        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}