using HMS.Data.DTOs.AppointmentModule;
using HMS.Data.Models;
using HMS.Data.Services.AppointmentModule;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMS.Areas.Reception.Controllers
{
    [Area("Reception")]
    public class AppointmentsController : Controller
    {

        private readonly IAppointmentService appointmentService;
        private readonly UserManager<AppUser> userManager;
        public AppointmentsController(UserManager<AppUser> userManager,IAppointmentService appointmentService)
        {
            this.appointmentService = appointmentService;
            this.userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var appointments = await appointmentService.GetAll();

            return View(appointments);
        }

        public IActionResult Create()
        {


            return View();
        }

        public async Task<ActionResult> CreateAppointment(AppointmentDTO  appointmentDTO)
        {
            try
            {

                var user = await userManager.FindByEmailAsync(User.Identity.Name);

                appointmentDTO.CreatedBy = user.Id;

                var results = await appointmentService.Create(appointmentDTO);

                if (results != null)
                {
                    return Json(new { success = true, responseText = "Appointment has been successfully created" });
                }
                else
                {
                    return Json(new { success = false, responseText = "Appointment has been  not been saved" });
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
