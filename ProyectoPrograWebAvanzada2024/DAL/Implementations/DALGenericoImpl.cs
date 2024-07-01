using DAL.Interfaces;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class DALGenericoImpl<TEntity> : IDALGenerico<TEntity> where TEntity : class
    {

        private ColegiodbContext _ColegiodbContext;


        public DALGenericoImpl(ColegiodbContext ColegiodbContext)
        {
            _ColegiodbContext = ColegiodbContext;
        }

        public bool Add(TEntity entity)
        {
            try
            {
                _ColegiodbContext.Add(entity);
                return true;
            }
            catch(Exception) 
            {

                return false;
            }


        }

        public TEntity Get(int id)
        {
            return _ColegiodbContext.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _ColegiodbContext.Set<TEntity>().ToList();
        }

        public bool Remove(TEntity entity)
        {
            try
            {
                _ColegiodbContext.Set<TEntity>().Attach(entity);
                _ColegiodbContext.Set<TEntity>().Remove(entity);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Update(TEntity entity)
        {
            try
            {
                _ColegiodbContext.Entry(entity).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
