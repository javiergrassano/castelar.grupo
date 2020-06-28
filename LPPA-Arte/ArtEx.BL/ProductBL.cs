using ArtEx.BL.Exceptions;
using ArtEx.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;

namespace ArtEx.BL
{

    public enum ProductOrderBy
    {
        title,
        artist,
        rating,
        quantitySold
    }
    public partial class BusinessContext
    {
        public List<Product> ListProducts(string search = "", int currentPage = 0, int totalPerPage = 0, ProductOrderBy orderBy = ProductOrderBy.title)
        {
            IQueryable<Product> rows = db.Products.Include(x => x.artist);
            if (!string.IsNullOrWhiteSpace(search))
                rows = rows.Where(x => x.title.Contains(search) || x.artist.fullName.Contains(search));

            switch (orderBy)
            {
                case ProductOrderBy.rating:
                    rows = rows.OrderByDescending(x => x.avgStars);
                    break;
                case ProductOrderBy.quantitySold:
                    rows = rows.OrderByDescending(x => x.quantitySold);
                    break;
                default:
                    rows = rows.OrderBy(x => x.title);
                    break;

            }
            if (totalPerPage > 0)
                rows = rows.Skip(totalPerPage * currentPage).Take(totalPerPage);

            List<Product> result = null;
            try
            {
                result = rows.ToList();
            }
            catch(Exception ex)
            {
                result = null;
            }
            return result;
        }

        public Product findProduct(int id)
        {
            return db.Products.Include(x => x.artist).Where(x => x.id == id).FirstOrDefault();
        }

        public void Update(Product model)
        {
            try
            {
                if (!IsValid(model)) throw new Exception("Restricciones de modelo");
                Product modelDB;
                if (model.id <= 0)
                {
                    modelDB = new Product();
                    db.Products.Add(modelDB);
                }
                else
                {
                    modelDB = db.Products.Find(model.id);
                    if (modelDB == null)
                        throw new CrudException("Productos", CrudAction.Find, model.id);
                    db.Entry(modelDB).State = EntityState.Modified;
                }
                modelDB.title = model.title;
                modelDB.image = model.image;
                modelDB.artistId = model.artistId;
                modelDB.description = model.description;
                modelDB.price = model.price;
                Audit(modelDB);
                db.SaveChanges();
                model.id = modelDB.id;
            }
            catch (Exception ex)
            {
                if (model.id <= 0)
                    throw new CrudException("Producto", CrudAction.Create, ex.Message);
                else
                    throw new CrudException("Producto", CrudAction.Update,model.id, ex.Message);
            }
        }

        public bool IsValid(Product model)
        {
            
            return true;
        }

    }

}
