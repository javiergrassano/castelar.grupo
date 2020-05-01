using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtEx.BL.Exceptions
{
    public enum CrudAction
    {
        List,
        Find,
        Create,
        Update,
        Delete
    }

    public class CrudException: Exception
    {
        public CrudException(string tableName, CrudAction action, int? id)
        {
            this.tableName = tableName;
            this.action = action;
            this.recordId = id;
        }

        public CrudException(string tableName, CrudAction action, int id, string message): base(message)
        {
            this.tableName = tableName;
            this.action = action;
            this.recordId = id;
        }

        public CrudException(string tableName, CrudAction action, string message) : base(message)
        {
            this.tableName = tableName;
            this.action = action;
        }

        public string tableName { get; set; }
        public CrudAction action { get; set; }
        public int? recordId { get; set; }

        public override string Message => $"Error CRUD Tabla: {tableName} Accion: {action} {(recordId.HasValue?$"Registro Id:{recordId}":"")}\n" + base.Message;
    }
}
