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

        private Colegiodb2Context _Colegiodb2Context;


        public DALGenericoImpl(Colegiodb2Context Colegiodb2Context)
        {
            _Colegiodb2Context = Colegiodb2Context;
        }

        public bool Add(TEntity entity)
        {
            try
            {
                _Colegiodb2Context.Add(entity);
                return true;
            }
            catch(Exception) 
            {

                return false;
            }


        }

        public TEntity Get(int id)
        {
            return _Colegiodb2Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _Colegiodb2Context.Set<TEntity>().ToList();
        }

        public bool Remove(TEntity entity)
        {
            try
            {
                _Colegiodb2Context.Set<TEntity>().Attach(entity);
                _Colegiodb2Context.Set<TEntity>().Remove(entity);
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
                _Colegiodb2Context.Entry(entity).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
