using AccesoDatos.Models;
using AutoMapper;
using Back.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Utilidades
{
  public class AutoMapperProfile :Profile
  {
    public AutoMapperProfile()
    {
      CreateMap<StudentsDTO, Students>();
      CreateMap<StudentsSaveDTO, Students>();

    }
  }
}
