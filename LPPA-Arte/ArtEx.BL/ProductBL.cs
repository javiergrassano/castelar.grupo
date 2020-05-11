using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtEx.BL.Exceptions;
using ArtEx.EF;

namespace ArtEx.BL
{
    
    public enum ProductOrderBy
    {
        title,
        artist,
        rating
    }
    public partial class BusinessContext
    {   
        public List<Product> ListProducts(string search, int currentPage = 0,int totalPerPage = 0, ProductOrderBy orderBy = ProductOrderBy.title)
        {
            IQueryable<Product> rows = db.Products.Include(x => x.artist);
            if (!string.IsNullOrWhiteSpace(search))
                rows = rows.Where(x => x.title.Contains(search) || x.artist.fullName.Contains(search));

            switch (orderBy)
            {
                default: rows = rows.OrderBy(x => x.title);
                    break;
            }
            if (totalPerPage > 0)
                rows = rows.Skip(totalPerPage * currentPage).Take(totalPerPage);
            return rows.ToList();
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
                    db.Products.Add(model);
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
            return Validate(model).Count == 0;
        }

        public List<InvalidRow> Validate(Product model)
        {
            List<InvalidRow> invalidRows = new List<InvalidRow>();
            if (string.IsNullOrEmpty(model.title)) invalidRows.Add(new InvalidRow("Product", "title", model.id, "Valor requerido"));
            if (string.IsNullOrEmpty(model.description)) invalidRows.Add(new InvalidRow("Product", "description", model.id, "Valor requerido"));
            if (model.artistId > 0) invalidRows.Add(new InvalidRow("Product", "artistId", model.id, "No se encontro un artista"));
            if (model.price > 0) invalidRows.Add(new InvalidRow("Product", "price", model.id, "El precio tiene que ser mayor a 0"));
            return invalidRows;
        }
    }

}
