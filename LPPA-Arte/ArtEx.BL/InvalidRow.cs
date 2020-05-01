using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtEx.BL
{
    public class InvalidRow
    {
        public InvalidRow(string tableName, string fieldName, int? id)
        {
            this.tableName = tableName;
            this.fieldName = fieldName;
            this.recordId = id;
        }

        public InvalidRow(string tableName, string fieldName, string validText)
        {
            this.tableName = tableName;
            this.fieldName = fieldName;
            this.validText = validText;
        }

        public InvalidRow(string tableName, string fieldName, int id, string validText)
        {
            this.tableName = tableName;
            this.fieldName = fieldName;
            this.recordId = id;
            this.validText = validText;
        }


        public string tableName { get; private set; }
        public string fieldName { get; private set; }
        public int? recordId { get; private set; }
        public string validText { get; private set; }
    }
}
