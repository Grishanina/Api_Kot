using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_Kot.Models
{
	public class KetModel
	{
		public KetModel(Ket ket)
		{
			ID = (int)ket.ID;
			Name = ket.Name;
			Year = (int)ket.Year;
			Image = ket.Image;
		}

		public int ID { get; set; }
		public string Name { get; set; }
		public int Year { get; set; }
		public string Image { get; set; }
	}
}