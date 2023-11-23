using HomeCourse.Models;
using HomeCourse.Services.Interface;
using System.Net;

namespace HomeCourse.Services.Repository
{
    public class ProfesorRepository : IProfesor
    {
        BdWeb bd = new BdWeb();

        public void actualizar(Profesor profe)
        {
            var objAModificado = (from tcliente in bd.Profesors
                                  where tcliente.Id == profe.Id
                                  select tcliente).FirstOrDefault();
            if (objAModificado != null)
            {
                objAModificado.Id = profe.Id;
                objAModificado.Telefono = profe.Telefono;
                objAModificado.Nombre = profe.Nombre;
                objAModificado.Correo = profe.Correo;
                objAModificado.Descripcion = profe.Descripcion;
                objAModificado.Contraseña = profe.Contraseña;
                objAModificado.Dni = profe.Dni;

                bd.SaveChanges();
            }
        }

        public void addNew(Profesor nuevo)
        {
            try
            {
                bd.Profesors.Add(nuevo);
                bd.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void deleteProfesorDataById(string id)
        {
            var obj = (from tablaProfe in bd.Profesors where tablaProfe.Id == id select tablaProfe).Single();
            List<Curso> cursosToRemove = (from tablaCurso in bd.Cursos where tablaCurso.ProfesorId == id select tablaCurso).ToList();
            List<Inscripcion> inscripcionesToRemove = new List<Inscripcion>();

            foreach (Curso item in cursosToRemove)
            {
                inscripcionesToRemove.AddRange(
                    (from tableInscrip in bd.Inscripcions where tableInscrip.CursoId == item.Id select tableInscrip).ToList()
                );
            }
            bd.Inscripcions.RemoveRange(inscripcionesToRemove);
            bd.SaveChanges();
            bd.Cursos.RemoveRange(cursosToRemove);
            bd.SaveChanges();
            bd.Profesors.Remove(obj);
            bd.SaveChanges();
        }


        public IEnumerable<Profesor> GetAllProfesores()
        {
            return bd.Profesors;
        }

        public Profesor getProfesorbyCod(string cod)
        {
            return (from matching in bd.Profesors where matching.Id == cod select matching).Single();
        }

        public Profesor getProfesorbyCorreo(string correo)
        {
            return (from matched in bd.Profesors where matched.Correo == correo select matched).Single();
        }

        public Profesor getProfesorbyDNI(string dni)
        {
            return (from matching in bd.Profesors where matching.Dni == dni select matching).Single();
        }

        public Profesor getProfesorbyID(string id)
        {
            return (from matching in bd.Profesors where matching.Id == id select matching).Single();
        }

        public Profesor getProfesorbyName(string name)
        {
            return (from matching in bd.Profesors where matching.Nombre == name select matching).Single();
        }

        public bool passwordMatchvyEmail(string correo, string password)
        {
            var matchingProfesor = (from profesor in bd.Profesors where profesor.Correo == correo && profesor.Contraseña == password select profesor).Any();

            return matchingProfesor;
        }

        public bool ProfesorExistsbyCorreo(string correo)
        {
            var exists = bd.Profesors.Any(profesor => profesor.Correo == correo);
            return exists;
        }
    }
}
