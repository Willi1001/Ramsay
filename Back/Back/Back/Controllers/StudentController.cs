using AccesoDatos.Models;
using AutoMapper;
using Back.DTOs;
using LogicaDeNegocio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Controllers
{
  [ApiController]
  [Route("api/Student")]
  public class StudentController : Controller
  {
    private readonly ApplicationDbContext _context;
    private readonly LNStudents _lNStudents;
    private readonly IMapper _mapper;

    public StudentController(ApplicationDbContext context, LNStudents lNStudents, IMapper mapper)
    {
      this._context = context;
      this._lNStudents = lNStudents;
      this._mapper = mapper;
    }


    [HttpGet("GetAllStudents")]
    public async Task<ActionResult<List<Students>>> GetAllStudents()
    {
      try
      {
        List<Students> students = await _lNStudents.GetAllStudents();
        return Ok(students);
      }
      catch (Exception error)
      {
        return BadRequest(error.Message);
      }
    }

    [HttpGet("GetStudent")]
    public async Task<ActionResult<Students>> GetStudent(int idStudent)
    {
      try
      {
        Students student = await _lNStudents.GetStudent(idStudent);
        return Ok(student);
      }
      catch (Exception error)
      {
        return BadRequest(error.Message);
      }
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] StudentsSaveDTO students)
    {
      try
      {
        var objStudent= _mapper.Map<Students>(students);
        await _lNStudents.AddStudent(objStudent);
        return Ok();
      }
      catch (Exception error)
      {
        return BadRequest(error.Message);
      }
    }

    [HttpDelete]
    public async Task<ActionResult> Delete(int idStudent)
    {
      try
      {
        Students objStudent = await _lNStudents.GetStudent(idStudent);
        await _lNStudents.DeleteStudent(objStudent);
        return Ok();
      }
      catch (Exception error)
      {
        return BadRequest(error.Message);
      }
    }

    [HttpPut]
    public async Task<ActionResult> Put([FromBody] StudentsDTO students)
    {
      try
      {
        var objStudent = _mapper.Map<Students>(students);
        Students student = await _lNStudents.GetStudent(objStudent.Id);
        await _lNStudents.PutStudent(student,objStudent);
        return Ok();
      }
      catch (Exception error)
      {
        return BadRequest(error.Message);
      }
    }

  }
}
