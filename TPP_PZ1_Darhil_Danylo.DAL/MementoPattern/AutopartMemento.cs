using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPP_PZ1_Darhil_Danylo.DAL.Models;

namespace TPP_PZ_Darhil_Danylo.DAL.MementoPattern
{
    public class AutopartMemento
    {
        public int Id { get; set; }

        public string Code { get; set; } = null!;

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public string Description { get; set; } = null!;

        public int Quantity { get; set; }
        public virtual AutoModel AutoModel { get; set; } = null!;

        public virtual ManufacturerBrand ManufacturerBrand { get; set; } = null!;

        public virtual ManufacturerCountry ManufacturerCountry { get; set; } = null!;

        public virtual PartCategory PartCategory { get; set; } = null!;

        public virtual PartType PartType { get; set; } = null!;
        public int SelectedPartCount { get; set; }//additional parametr

        public AutopartMemento(int Id, string Code, string Name, decimal Price, string Description, 
            int Quantity, AutoModel AutoModel, ManufacturerBrand ManufacturerBrand, ManufacturerCountry ManufacturerCountry,
            PartCategory PartCategory, PartType PartType, int SelectedPartCount=0)
        {
            this.Id=Id;
            this.Code=Code;
            this.Name=Name;
            this.Price=Price;
            this.Description=Description;
            this.Quantity=Quantity;
            this.AutoModel=AutoModel;
            this.ManufacturerBrand=ManufacturerBrand;
            this.ManufacturerCountry=ManufacturerCountry;
            this.PartCategory=PartCategory;
            this.PartType=PartType;
            this.SelectedPartCount=SelectedPartCount;
        }
    }
}
