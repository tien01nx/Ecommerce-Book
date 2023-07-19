using example.DataAccess.Repository.IRepository;
using example.Models;
using example.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace example_web_mvc.Areas.Admin.Controllers
{
    [Area("Admin")]

    // cũng có thể cho từng hàm nhỏ 
    [Authorize(Roles = SD.Role_Admin)]

    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public IActionResult Index()
        {
            List<Company> obj = _unitOfWork.Company.GetAll().ToList();


            return View(obj);
        }

        public IActionResult Upsert(int? id)
        {




            if (id == 0 || id == null)
            {
                // create
              return NotFound();
            }
            else
            {
                // update
                Company companyObj = _unitOfWork.Company.Get(u => u.Id == id);
                return Json(companyObj);
            }

        }



        [HttpPost]
        public IActionResult Upsert([FromBody] Company companyObj)
        {

            if (ModelState.IsValid)
            {

                if (companyObj.Id == 0)
                {
                    // thêm dữ liệu vào database
                    _unitOfWork.Company.Add(companyObj);
                }
                else
                {
                    _unitOfWork.Company.Update(companyObj);
                }

                // lưu dữ liệu khi thêm
                _unitOfWork.Save();

                //TempData["success"] = "Company created successfully";
                return Ok(companyObj);
                //return RedirectToAction("Index");
            }
            else
            { 
                return BadRequest();
            }


        }



        #region API CALLS

        // https://localhost:7139/admin/company/getall
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Company> obj = _unitOfWork.Company.GetAll().ToList();
            return Json(new { data = obj });


        }


        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var companyToBeDelete = _unitOfWork.Company.Get(u => u.Id == id);
            if (companyToBeDelete == null)
            {
                return Json(new { success = false, message = "Error while deleteing" });
            }


            _unitOfWork.Company.Remove(companyToBeDelete);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete  successful" });

        }

        #endregion

    }

}
