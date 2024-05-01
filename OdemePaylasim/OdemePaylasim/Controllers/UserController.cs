using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OdemePaylasim.Data;
using OdemePaylasim.Data.Entities;
using OdemePaylasim.Models;

namespace OdemePaylasim.Controllers
{
    public class UserController : Controller
    {
        private readonly OdemeDbContext _db;
        private int _row = 1;
        public UserController(OdemeDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
           return View(GetUsersViewModel());
        }
        
        public IActionResult CreateUser()
        {
            UserAddViewModel model = new UserAddViewModel();
            return PartialView("_CreateUser",model);
        }

        [HttpPost]
        public IActionResult SaveUser(UserAddViewModel model)
        {
            User user = new User();
            user.UserName = model.UserName;
            user.IsActive = model.IsActive;
            user.PaidMoney = model.PaidMoney;
            user.CreatedDate = DateTime.Now;
            _db.Add(user);
            int result = _db.SaveChanges();

            ResponseViewModel response = new ResponseViewModel();

            if (result > 0)
            {
                response.IsSuccess = true;
                response.Record = user;
            }
            else
            {
                response.IsSuccess = false;
                response.Error = "Bir hata oluştu.";
            }

            return Json(response);
        }

        public IActionResult DeleteUserModel(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var people = _db.Users.FirstOrDefault(x => x.Id == id);
            people.IsActive = false;

            if(people == null) 
            {
                return NotFound();
            }
            return View(people);
        }

        public List<UserEditViewModel> GetUsersViewModel()
        {
            List<UserEditViewModel> userEditViewModels = new List<UserEditViewModel>();
            var list = _db.Users.ToList();
            foreach (User user in list)
            {
                UserEditViewModel model = new UserEditViewModel();
                model.UserName = user.UserName;
                model.PaidMoney = user.PaidMoney;
                model.Id = user.Id;
                model.RowId=_row++;
                userEditViewModels.Add(model);
            }
            return userEditViewModels.ToList();
        }
        public List<User> GetUsers()
        {
          
            return  _db.Users.Where(x => x.IsActive == true).ToList();
       
        }

        public IActionResult UserList()
        {
            List<UserEditViewModel> list = new List<UserEditViewModel>();
            List<User> users = GetUsers();
            foreach (User user in users)
            {
                UserEditViewModel viewModel = new UserEditViewModel();
                viewModel.UserName = user.UserName;
                viewModel.PaidMoney = user.PaidMoney;
                viewModel.RowId = _row;
                list.Add(viewModel);
                _row++;
            }

            return PartialView("_UserList", list);
        }

        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user =  GetUsers().FirstOrDefault(x => x.Id == id);

          
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        public IActionResult Edit(int id, UserEditViewModel newModel)
        {

                User oldModel = _db.Users.Single(o => o.Id == id);
				newModel.UserName = oldModel.UserName;
				newModel.PaidMoney = oldModel.PaidMoney;


                return View(newModel);


        }
    }
}
