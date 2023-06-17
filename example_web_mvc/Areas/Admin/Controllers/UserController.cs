using example.Models;
using example.Models.ViewModel;
using example.Utility;
using example_web_mvc.DataAccess.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace example_web_mvc.Areas.Admin.Controllers
{
    [Area("Admin")]

    // cũng có thể cho từng hàm nhỏ 
    [Authorize(Roles = SD.Role_Admin)]

    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;

        private readonly UserManager<IdentityUser> _userManager;
        public UserController(ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;

        }
        public IActionResult Index()
        {



            return View();
        }

        public IActionResult RoleManagment(string userId)
        {

            string RoleId = _db.UserRoles.FirstOrDefault(u => u.UserId == userId).RoleId;
            RoleManagmentVM RoleVM = new RoleManagmentVM()
            {
                ApplicationUser = _db.ApplicationUsers.Include(u => u.Company).FirstOrDefault(u => u.Id == userId),
                RoleList = _db.Roles.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Name,
                }),
                CompanyList = _db.Companies.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),

            };
            RoleVM.ApplicationUser.Role = _db.Roles.FirstOrDefault(u => u.Id == RoleId).Name;

            return View(RoleVM);
        }
        [HttpPost]

        public IActionResult RoleManagment(RoleManagmentVM roleManagmentVM)
        {

            string RoleId = _db.UserRoles.FirstOrDefault(u => u.UserId == roleManagmentVM.ApplicationUser.Id).RoleId;
            string oldRole = _db.Roles.FirstOrDefault(u => u.Id == RoleId).Name;
            if (!(roleManagmentVM.ApplicationUser.Role == oldRole))
            {
                ApplicationUser application = _db.ApplicationUsers.FirstOrDefault(u => u.Id == roleManagmentVM.ApplicationUser.Id);
                if (roleManagmentVM.ApplicationUser.Role == SD.Role_Company)
                {
                    application.CompanyId = roleManagmentVM.ApplicationUser.CompanyId;
                }
                if (oldRole == SD.Role_Company)
                {
                    application.CompanyId = null;
                }
                _db.SaveChanges();

                // xoa role cũ 
                _userManager.RemoveFromRoleAsync(application, oldRole).GetAwaiter().GetResult();

                // thêm role mới
                _userManager.AddToRoleAsync(application, roleManagmentVM.ApplicationUser.Role).GetAwaiter().GetResult();

            }



            return RedirectToAction("Index");
        }



        #region API CALLS

        // https://localhost:7139/admin/company/getall
        [HttpGet]
        public IActionResult GetAll()
        {
            List<ApplicationUser> objUserList = _db.ApplicationUsers.Include(u => u.Company).ToList();
            var userRoles = _db.UserRoles.ToList();
            var roles = _db.Roles.ToList();
            foreach (var user in objUserList)
            {
                var roleId = userRoles.FirstOrDefault(u => u.UserId == user.Id).RoleId;
                user.Role = roles.FirstOrDefault(u => u.Id == roleId).Name;
                if (user.Company == null)
                {
                    user.Company = new Company()
                    {
                        Name = ""
                    };
                }
            }

            return Json(new
            {
                data = objUserList
            });

        }


        //[HttpPost]
        //public IActionResult LockUnLock([FromBody] string id)
        //{
        //    var objformDb = _db.ApplicationUsers.FirstOrDefault(u => u.Id == id);
        //    if (objformDb == null)
        //    {
        //        return Json(new { success = false, message = "Error while   Lock UnLock" });
        //    }
        //    if (objformDb.LockoutEnd != null && objformDb.LockoutEnd > DateTime.Now)
        //    {
        //        objformDb.LockoutEnd = DateTime.Now;
        //    }
        //    else
        //    {
        //        objformDb.LockoutEnd = DateTime.Now.AddYears(1000);

        //    }
        //    _db.SaveChanges();
        //    return Json(new { success = true, message = "Operation   successful" });


        //}

        public IActionResult LockUnLock([FromBody] string id)
        {
            var objformDb = _db.ApplicationUsers.FirstOrDefault(u => u.Id == id);
            if (objformDb == null)
            {
                return Json(new { success = false, message = "Error while Lock/Unlock" });
            }

            if (objformDb.LockoutEnd != null && objformDb.LockoutEnd > DateTime.Now)
            {
                objformDb.LockoutEnd = DateTime.Now;
                _db.SaveChanges();
                return Json(new { success = true, message = "Lock successful" });
            }
            else
            {
                objformDb.LockoutEnd = DateTime.Now.AddYears(1000);
                _db.SaveChanges();
                return Json(new { success = true, message = "Unlock successful" });
            }
        }


        #endregion

    }

}
