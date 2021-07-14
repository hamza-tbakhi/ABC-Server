using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.UnitOfWork;

namespace ABC.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ComplaintController : ControllerBase
    {
        private readonly IServiceUnitOfWork _serviceUnitOfWork;
        public ComplaintController(IServiceUnitOfWork serviceUnitOfWork)
        {
            _serviceUnitOfWork = serviceUnitOfWork;
        }

        [HttpPost]
        public IActionResult GetList()
        {
            var result = _serviceUnitOfWork.Complaint.Value.GetList();
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAllItems()
        {
            var result = _serviceUnitOfWork.Complaint.Value.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long Id)
        {
            var result = _serviceUnitOfWork.Complaint.Value.Get(Id);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult EditItem(Complaint entities)
        {
            var result = _serviceUnitOfWork.Complaint.Value.Update(entities);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult EditRange(Complaint[] entities)
        {
            var result = _serviceUnitOfWork.Complaint.Value.UpdateRange(entities);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult PostItem(Complaint entity)
        {
            var result = _serviceUnitOfWork.Complaint.Value.Add(entity);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult PostRange(Complaint[] entities)
        {
            var result = _serviceUnitOfWork.Complaint.Value.AddRange(entities);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveItemById(int id)
        {
            return Ok(_serviceUnitOfWork.Complaint.Value.Remove(new Complaint() { Id = id }));
        }

        [HttpPost]
        public IActionResult RemoveItem(Complaint entity)
        {
            return Ok(_serviceUnitOfWork.Complaint.Value.Remove(entity));
        }

        [HttpPost]
        public IActionResult RemoveRange(Complaint[] entities)
        {
            return Ok(_serviceUnitOfWork.Complaint.Value.RemoveRange(entities));
        }
    }
}
