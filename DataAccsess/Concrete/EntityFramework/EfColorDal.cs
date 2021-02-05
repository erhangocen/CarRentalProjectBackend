using DataAccsess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccsess.Concrete.EntityFramework
{
    public class EfColorDal : IColorDal
    {
        public void Add(Color entity)
        {
            using (CarsDBContext context = new CarsDBContext())
            {
                var addColor = context.Entry(entity);
                addColor.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Color entity)
        {
            using (CarsDBContext context = new CarsDBContext())
            {
                var deleteColor = context.Entry(entity);
                deleteColor.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            using (CarsDBContext context = new CarsDBContext())
            {
                return context.Set<Color>().SingleOrDefault(filter);
            }
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using (CarsDBContext context = new CarsDBContext())
            {
                return filter == null
                     ? context.Set<Color>().ToList()
                     : context.Set<Color>().Where(filter).ToList();
            }
        }

        public void Update(Color entity)
        {
            using (CarsDBContext context = new CarsDBContext())
            {
                var updateColor = context.Entry(entity);
                updateColor.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
