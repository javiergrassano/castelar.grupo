using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ArtEx.EF
{
    public abstract class GenericId
	{
		[Key]
		public int id { get; set; }

		public DateTime createdOn { get; set; }

		[MaxLength(50)]
		public string createdBy { get; set; }

		public DateTime changedOn { get; set; }

		[MaxLength(50)]
		public string changedBy { get; set; }

	}

}
