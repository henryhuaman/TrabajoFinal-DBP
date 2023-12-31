﻿using HomeCourse.Models;

namespace HomeCourse.Services.Interface
{
    public interface IProfesor
    {
        IEnumerable<Profesor> GetAllProfesores();
        Profesor getProfesorbyCod(string cod);
        Profesor getProfesorbyName(string name);
        Profesor getProfesorbyDNI(string dni);
        Profesor getProfesorbyID(string id);
        Profesor getProfesorbyCorreo(string correo);
        void addNew(Profesor nuevo);
        void actualizar(Profesor profe);
        void deleteProfesorDataById(String id);
        bool ProfesorExistsbyCorreo(string correo);
        bool passwordMatchvyEmail(string correo, string password);
    }
}
