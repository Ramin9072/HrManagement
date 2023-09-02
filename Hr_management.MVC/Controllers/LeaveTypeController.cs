using Hr_management.MVC.Contracts.LeaveType;
using Hr_management.MVC.Models.LeaveType;
using Hr_management.MVC.Services.Base;
using Microsoft.AspNetCore.Mvc;

namespace Hr_management.MVC.Controllers
{
    public class LeaveTypeController : Controller
    {

        private readonly ILeaveTypeService _leaveTypeService;

        public LeaveTypeController(ILeaveTypeService leaveTypeService)
        {
            _leaveTypeService = leaveTypeService;
        }

        // GET: LeaveTypeController
        public async Task<ActionResult> Index()
        {
            var leaveTypes = await _leaveTypeService.GetLeaveTypes();
            return View(leaveTypes);
        }

        // GET: LeaveTypeController/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var leaveType = await _leaveTypeService.GetLeaveTypeDetailById(id);
            return View(leaveType);
        }


        // GET: LeaveTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateLeaveTypeVM createLeave)
        {
            try
            {

                var response = await _leaveTypeService.CreateLeaveType(createLeave);
                if (response.Success)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", response.ValidationErrors);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(createLeave);
        }

        // GET: LeaveTypeController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var details = await _leaveTypeService.GetLeaveTypeDetailById(id);
            return View(details);
        }

        // POST: LeaveTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, LeaveTypeVM updateLeaveTypeVM)
        {
            var response = await _leaveTypeService.UpdateLeaveType(updateLeaveTypeVM);
            if (response is not null)
                return RedirectToAction("Index");
            else
                return View(response);

        }

        // GET: LeaveTypeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LeaveTypeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
