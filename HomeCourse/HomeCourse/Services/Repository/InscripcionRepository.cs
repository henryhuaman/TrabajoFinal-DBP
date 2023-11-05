﻿using HomeCourse.Models;
using HomeCourse.Services.Interface;

namespace HomeCourse.Services.Repository
{
    public class InscripcionRepository : IInscripcion
    {
        private BDWeb bd = new BDWeb();

        public void Add(List<Inscripcion> listinsc)
        {
            foreach (var insc in listinsc)
            {
                try
                {
                    bd.Add(insc);
                    bd.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public void Delete(string id)
        {
            bd.Remove(id);
        }

        public IEnumerable<Inscripcion> GetAllInscripciones()
        {
            return bd.Inscripcions;
        }

        public string getIDCorrelativo()
        {
            var cod = "";
            var lista = GetAllInscripciones();

            if (lista.Any())
            {
                var numero = lista.Select(t => int.Parse(new String(t.Id.Where(char.IsDigit).ToArray()))).Max();

                if (numero.ToString().Length == 1)
                {
                    cod = "IN00" + (numero+1);
                }
                else if (numero.ToString().Length == 2)
                {
                    cod = "IN0" + (numero + 1);
                }
                else if (numero.ToString().Length == 3)
                {
                    cod = "IN" + (numero + 1);
                }
                else
                {
                    return cod;
                }
                Console.WriteLine(cod);
                return cod;
            }
            else
            {
                cod = "IN001"; 
                return cod;
            }
        }

        public IEnumerable<Inscripcion> GetInscripcion(string id)
        {
            throw new NotImplementedException();
        }

        public List<Relacion> getRelacion(string id)
        {
            var result = (from inscripcion in bd.Inscripcions
                          join curso in bd.Cursos on inscripcion.CursoId equals curso.Id
                          join profesor in bd.Profesors on curso.ProfesorId equals profesor.Id
                          where inscripcion.UsuarioId == id
                          select new Relacion
                          {
                              ID = inscripcion.Id,
                              NOMBRE = curso.Nombre,
                              PROFESOR = profesor.Nombre,
                              CATEGORIA = curso.Categoria
                          }).ToList();
            return result;
        }
    }
}