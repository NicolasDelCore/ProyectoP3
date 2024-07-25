using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcosistemasMarinos.LogicaNegocio.ExcepcionesEntidades;
using EcosistemasMarinos.LogicaNegocio.InterfacesEntidades;

namespace LogicaNegocio.ValueObjects
{
    public class Rango
    {
        #region Properties
        //La ballena azul pesa 200.000 KG, este es el valor más grande que esperamos manejar con este value-object, por lo que sólo necesitaremos hasta 6 dígitos antes de la coma, y 2 dígitos flotantes da suficiente presición
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Min { get; private set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Max { get; private set; }
        #endregion
        #region Constructores
        public Rango(decimal min, decimal max)
        {
            Min = min;
            Max = max;
            Validar();
        }

        private Rango() { }
        #endregion
        #region Validacion
        public void Validar()
        {
            if (Min > Max) throw new ObjectValueException("Error en Rango: Se esperan dos números, el segundo mayor o igual al primero.");
            if (Min <= 0 || Max <= 0) throw new ObjectValueException("Error en Rango: Se esperan valores positivos > 0.");
        }
        #endregion
    }
}