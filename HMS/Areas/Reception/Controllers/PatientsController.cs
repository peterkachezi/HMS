using HMS.Data.DTOs.PatientService;
using HMS.Data.Models;
using HMS.Data.Services.CountyModule;
using HMS.Data.Services.PatientService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace HMS.Areas.Reception.Controllers
{
    [Area("Reception")]
    public class PatientsController : Controller
    {
        private readonly IPatientService patientService;

        private readonly ICountyService countyService;

        private UserManager<AppUser> userManager;
        public PatientsController(ICountyService countyService, UserManager<AppUser> userManager, IPatientService patientService)
        {
            this.patientService = patientService;

            this.userManager = userManager;

            this.countyService = countyService;
        }
        public async Task<IActionResult> IndexAsync()
        {
            try
            {
                ViewBag.Counties = await countyService.GetAll();

                return View();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }


        public async Task<IActionResult> GetPatients()
        {
            try
            {
                var patients = (await patientService.GetAll()).OrderBy(x => x.CreateDate).ToList();

                return Json(new { data = patients });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<IActionResult> Create(PatientDTO patientDTO)
        {
            try
            {
                var list = await patientService.GetAll();

                bool exist = list.Any(cus => cus.IdNumber == patientDTO.IdNumber);

                if (exist == true)
                {
                    return Json(new { success = false, responseText = "The record already exists" });

                }

                var user = await userManager.FindByEmailAsync(User.Identity.Name);

                patientDTO.CreatedBy = user.Id;

                var result = await patientService.Create(patientDTO);

                if (result != null)
                {

                    return Json(new { success = true, responseText = "Patient has been successfully registered" });
                }
                else
                {
                    return Json(new { success = false, responseText = "Unable to register patient" });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }
        public async Task<IActionResult> Update(PatientDTO patientDTO)
        {
            try
            {
                var results = await patientService.Update(patientDTO);

                if (results != null)

                {
                    return Json(new { success = true, responseText = "Record  has been  successfully updated!" });
                }

                else
                {
                    return Json(new { success = false, responseText = "Failed to update the record!" });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }

        }
        public async Task<IActionResult> GetById(Guid Id)
        {
            try
            {
                var data = await patientService.GetById(Id);

                if (data != null)
                {
                    PatientDTO file = new PatientDTO
                    {
                        Id = data.Id,

                        VisitCode = data.VisitCode,

                        FirstName = data.FirstName,

                        LastName = data.LastName,

                        IdNumber = data.IdNumber,

                        PhoneNumber = data.PhoneNumber,

                        Gender = data.Gender,

                        CreateDate = data.CreateDate,

                        CreatedBy = data.CreatedBy,

                        Town = data.Town,

                        CountyId = data.CountyId,

                    };

                    return Json(new { data = file });
                }

                return Json(new { data = false });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }

        }
        public async Task<IActionResult> Delete(Guid Id)
        {
            try
            {
                var results = await patientService.Delete(Id);

                if (results == true)
                {
                    return Json(new { success = true, responseText = "Record  has been  successfully Deleted!" });
                }
                else
                {
                    return Json(new { success = false, responseText = "Failed to Delete because the file is in use with other records!" });
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
