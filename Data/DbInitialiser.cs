using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Models;

namespace WebStore.Data
{
    public static class DbInitialiser
    {
        public static void Initialise(WebStoreDbContext context)
        {
            context.Database.EnsureCreated();


            var suppliers = new Supplier[]
{
            new Supplier{SupplierId=1, Name="02" },

            new Supplier{SupplierId=2, Name="UNIDAYS" },

            new Supplier{SupplierId=3, Name="Student Beans" },

            new Supplier{SupplierId=4, Name="Totem" },

            new Supplier{SupplierId=5, Name="EE" },

            new Supplier{SupplierId=6, Name="GiffGaff" },

            new Supplier{SupplierId=7, Name="VOXI" },

            new Supplier{SupplierId=8, Name="LycaMobile" },

            new Supplier{SupplierId=9, Name="EnchroEx" },

            new Supplier{SupplierId=10, Name="Vodafone" },

};


            foreach (Supplier s in suppliers)
            {
                context.Suppliers.Add(s);
            }
            context.SaveChanges();

            var brands = new Brand[]
            {
            new Brand{BrandId=1, Name="Apple", Description=""},

            new Brand{BrandId=2, Name="Samsung", Description=""},

            new Brand{BrandId=3, Name="Huawei", Description=""},

            new Brand{BrandId=4, Name="Enchro", Description=""},

            new Brand{BrandId=5, Name="Google", }
            };
            foreach (Brand b in brands)
            {
                context.Brands.Add(b);
            }
            context.SaveChanges();

            //Look for any phones.
            if (context.Phones.Any())
            {
                return;   // DB has been seeded
            }

            var phones = new Phone[]
                {
            new Phone{BrandId=1,SupplierId=2, Title="iPhone 14", Price=1000},

            new Phone{BrandId=1,SupplierId=2, Title="iPhone 14 MAX", Price=1500},

            new Phone{BrandId=1,SupplierId=3, Title="iPhone 12 Pro", Price=1200},

            new Phone{BrandId=2,SupplierId=4, Title="Galaxy S22", Price=1100},

            new Phone{BrandId=2,SupplierId=1, Title="Galaxy Fold", Price=1350},

            new Phone{BrandId=5,SupplierId=5, Title="Pixel 6", Price=850},

            new Phone{BrandId=1,SupplierId=3, Title="iPod Touch X", Price=750},

            new Phone{BrandId=5,SupplierId=10, Title="Pixel 5", Price=700},

            new Phone{BrandId=1,SupplierId=6, Title="iPhone XS MAX", Price=800},

            new Phone{BrandId=4,SupplierId=9, Title="Black", Price=900},

            new Phone{BrandId=4,SupplierId=9, Title="Black DXE", Price=1200},

            new Phone{BrandId=4,SupplierId=8, Title="Black LTD [Lyca]", Price=1000},

            new Phone{BrandId=5,SupplierId=7, Title="Pixel 5 Lite", Price=600},

            new Phone{BrandId=5,SupplierId=10, Title="Pixel 6 Pro", Price=1000},

            new Phone{BrandId=2,SupplierId=3, Title="Galaxy Note 20", Price=1350},

            new Phone{BrandId=3,SupplierId=6, Title="P50", Price=500},

            new Phone{BrandId=3,SupplierId=10, Title="P50 Pro", Price=650},

            new Phone{BrandId=3,SupplierId=8, Title="Mate 4", Price=600},

            new Phone{BrandId=3,SupplierId=4, Title="P60 Pocket", Price=800}
            };

            foreach (Phone p in phones)
            {
                context.Phones.Add(p);
            }
            context.SaveChanges();

            


        }
    }
}
