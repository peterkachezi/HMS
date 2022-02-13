using HMS.Data.DTOs.DiseaseModule;
using HMS.Data.Models;
using HMS.Data.Services.DiseaseModule;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DiseasesController : Controller
    {
        private readonly IDiseaseService  diseaseService;

        private readonly UserManager<AppUser> userManager;
        public DiseasesController(UserManager<AppUser> userManager, IDiseaseService diseaseService)
        {
            this.diseaseService = diseaseService;

            this.userManager = userManager;
        }


        public ActionResult Index()
        {

            return View();
        }


        public async Task<ActionResult> GetDiseases()
        {
            var services = await diseaseService.GetAll();

            return Json(new { data = services });

        }
        public async Task<ActionResult> Create(DiseaseDTO diseaseDTO)
        {
            try
            {

                var user = await userManager.FindByEmailAsync(User.Identity.Name);

                diseaseDTO.CreatedBy = user.Id;

                var results = await diseaseService.Create(diseaseDTO);

                if (results != null)
                {
                    return Json(new { success = true, responseText = "Disease has been successfully created" });
                }
                else
                {
                    return Json(new { success = false, responseText = "Disease has been  not been saved" });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }
        public async Task<ActionResult> Update(DiseaseDTO diseaseDTO)
        {
            try
            {
                var results = await diseaseService.Update(diseaseDTO);

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
                var data = await diseaseService.GetById(Id);

                if (data != null)
                {
                    DiseaseDTO file = new DiseaseDTO
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
                var results = await diseaseService.Delete(Id);

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
