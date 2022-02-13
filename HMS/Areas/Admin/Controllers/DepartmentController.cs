using HMS.Data.Models;
using HMS.Data.Services.DepartmentModule;
using Manager.Data.DTOs.DepartmentModule;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;


namespace HMS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService  departmentService;

        private readonly UserManager<AppUser>   userManager;
        public DepartmentController(UserManager<AppUser> userManager,IDepartmentService departmentService)
        {
            this.departmentService = departmentService;

            this.userManager = userManager;
        }


        public ActionResult Index()
        {        

            return View();
        }


        public async Task<ActionResult> GetDepartments()
        {
            var departments = await departmentService.GetAll();

            return Json(new { data = departments });

        }
        public async Task<ActionResult> Create(DepartmentDTO departmentDTO)
        {
            try
            {

                var user = await userManager.FindByEmailAsync(User.Identity.Name);

                departmentDTO.CreatedBy = user.Id;

                var results = await departmentService.Create(departmentDTO);

                if (results != null)
                {
                    return Json(new { success = true, responseText = "Department has been successfully created" });
                }
                else
                {
                    return Json(new { success = false, responseText = "Department has been  not been saved" });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }
        public async Task<ActionResult> Update(DepartmentDTO departmentDTO)
        {
            try
            {
                var results = await departmentService.Update(departmentDTO);

                if (results != null)
                {
                    return Json(new { success = true, responseText = "The record updated successfully" });
                }
                else
                {
                    return Json(new { success = false, responseText = "The record has not been updated" });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }
        public async Task<ActionResult> GetById(Guid Id)
        {
            try
            {
                var data = await departmentService.GetById(Id);

                if (data != null)
                {
                    DepartmentDTO file = new DepartmentDTO
                    {
                        Id = data.Id,

                        Name = data.Name,

                        CreateDate = data.CreateDate,

                        CreatedBy = data.CreatedBy,

                    };

                    return Json(new { data = file });
                }
                else
                {
                    return Json(new { data = false });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<ActionResult> Delete(Guid Id)
        {
            try
            {
                var results = await departmentService.Delete(Id);

                if (results == true)
                {
                    return Json(new { success = true, responseText = "Record deleted successfully " });
                }
                else
                {
                    return Json(new { success = false, responseText = "Record has not been deleted ,it could be in use by other records" });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }
    }
}