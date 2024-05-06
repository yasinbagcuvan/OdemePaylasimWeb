﻿using DTOs;
using Entities;
using EserKepenk.DAL.Repositories.Concrete;
using EserKepenk.DAL.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EserKepenk.DAL.Services.Concrete
{
    public class ProductService : Service<Product, ProductDto>
    {
        public ProductService(ProductRepo productRepo) : base(productRepo)
        {
            //base._profile = new ProductProfile();
        }
    }
}
