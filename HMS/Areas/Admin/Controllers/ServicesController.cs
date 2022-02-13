using HMS.Data.DTOs.HospitalServiceModule;
using HMS.Data.Models;
using HMS.Data.Services.HospitalServiceModule;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServicesController : Controller
    {
        private readonly IHospitalService  hospitalService;

        private readonly UserManager<AppUser> userManager;
        public ServicesController(UserManager<AppUser> userManager, IHospitalService hospitalService)
        {
            this.hospitalService = hospitalService;

            this.userManager = userManager;
        }


        public ActionResult Index()
        {

            return View();
        }


        public async Task<ActionResult> GetServices()
        {
            var services = await hospitalService.GetAll();

            return Json(new { data = services });

        }
        public async Task<ActionResult> Create(HospitalServiceDTO hospitalServiceDTO)
        {
            try
            {

                var user = await userManager.FindByEmailAsync(User.Identity.Name);

                hospitalServiceDTO.CreatedBy = user.Id;

                var results = await hospitalService.Create(hospitalServiceDTO);

                if (results != null)
                {
                    return Json(new { success = true, responseText = "Service has been successfully created" });
                }
                else
                {
                    return Json(new { success = false, responseText = "Service has been  not been saved" });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }
        public async Task<ActionResult> Update(HospitalServiceDTO hospitalServiceDTO)
        {
            try
            {
                var results = await hospitalService.Update(hospitalServiceDTO);

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
                var data = await hospitalService.GetById(Id);

                if (data != null)
                {
                    HospitalServiceDTO file = new HospitalServiceDTO
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
                var results = await hospitalService.Delete(Id);

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
