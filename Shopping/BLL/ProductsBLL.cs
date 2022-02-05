using Microsoft.EntityFrameworkCore;
using Shopping.DAL;
using Shopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Shopping.BLL
{
    public class ProductsBLL
    {
        public static bool Guardar(Products Products)
        {
            if (!Existe(Products.id))// si no existe se inserta
                return Insertar(Products);
            else
                return Modificar(Products);
        }

        private static bool Insertar(Products Products)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                //establesco el id en cero por entityframework automaticamente me establece el campo autoincrements
                Products.id = 0;
                contexto.products.Add(Products);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Modificar(Products Products)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(Products).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var aux = contexto.products.Find(id);
                if (aux != null)
                {
                    contexto.products.Remove(aux);//remueve la informacion de la entidad relacionada
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static Products Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Products Products;

            try
            {
                Products = contexto.products.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Products;
        }

        public static List<Products> GetList(Expression<Func<Products, bool>> Products)
        {
            List<Products> lista = new List<Products>();
            Contexto db = new Contexto();

            try
            {
                lista = db.products.Where(Products).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }

            return lista;
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.products.Any(p => p.id == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }
    }
}
