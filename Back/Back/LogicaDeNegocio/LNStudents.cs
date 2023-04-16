using AccesoDatos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio
{
  public class LNStudents
  {

    private readonly ApplicationDbContext _context;

    public LNStudents(ApplicationDbContext context)
    {
      this._context = context;
    }

    public async Task AddStudent(Students students)
    {
      try
      {
        _context.Students.Add(students);
        await _context.SaveChangesAsync();
      }
      catch (Exception error)
      {
        throw error;
      }
    }


    public async Task<List<Students>> GetAllStudents()
    {
      try
      {
        return await _context.Students.ToListAsync();
      }
      catch (Exception error)
      {
        throw error;
      }
    }

    public async Task<Students> GetStudent(int idStudent)
    {
      try
      {
        Students students = new Students();
        students = _context.Students.Where(x => x.Id == idStudent).FirstOrDefault();

        return students;
      }
      catch (Exception error)
      {
        throw error;
      }
    }

    public async Task DeleteStudent(Students student)
    {
      try
      {
        _context.Students.Remove(student);
        await _context.SaveChangesAsync();
      }
      catch (Exception error)
      {
        throw error;
      }
    }

    public async Task PutStudent(Students studentAnt,Students studentEdit)
    {
      try
      {
        studentAnt.Nombre = studentEdit.Nombre;
        studentAnt.Apellido = studentEdit.Apellido;
        studentAnt.Curso = studentEdit.Curso;
        studentAnt.Edad = studentEdit.Edad;
        //_context.Add(studentAnt);
        await _context.SaveChangesAsync();
      }
      catch (Exception error)
      {
        throw error;
      }
    }

  }
}
