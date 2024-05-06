﻿using Entities;
using EserKepenk.DAL.Context;
using EserKepenk.DAL.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EserKepenk.DAL.Repositories.Concrete
{
    public class CategoryRepo : Repo<Category>
    {
        public CategoryRepo(EserKepenkDbContext dbContext):base(dbContext) 
        { }
    }
}