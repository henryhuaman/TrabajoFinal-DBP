﻿using HomeCourse.Models;
using HomeCourse.Services.Interface;

namespace HomeCourse.Services.Repository
{
    public class CarritoDeComprasRepository : ICarritoDeCompras
    {   
        private List<CarritoDeCompras> _compras = new List<CarritoDeCompras>();
        public void Add(CarritoDeCompras curso)
        {
            _compras.Add(curso);
        }

        public void Delete(CarritoDeCompras id)
        {
            _compras.Remove(id);
        }

        public IEnumerable<CarritoDeCompras> GetAllCarritoDeCompras()
        {
            return _compras ;
        }

        public void Update(CarritoDeCompras curso)
        {
            throw new NotImplementedException();
        }
    }
}