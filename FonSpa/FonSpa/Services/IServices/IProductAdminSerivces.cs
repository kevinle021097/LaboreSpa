﻿using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FonSpa.Services.IServices
{
    public interface IProductAdminSerivces
    {
        List<Product> ListAllByName(string searchString);
        List<ProductCategory> GetProductCategory();
    }
}
