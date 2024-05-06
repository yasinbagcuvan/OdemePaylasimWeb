using DTOs;
using Entities;
using EserKepenk.DAL.Repositories.Concrete;
using EserKepenk.DAL.Services.Abstract;
using EserKepenk.BLL.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EserKepenk.DAL.Services.Concrete
{
    public class CategoryService : Service<Category, CategoryDto>
    {
        public CategoryService(CategoryRepo categoryRepo) : base(categoryRepo)
        {
            base._profile = new ProductProfile();
        }
    }
}
