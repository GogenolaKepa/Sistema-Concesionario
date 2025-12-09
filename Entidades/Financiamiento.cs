using System;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class Financiamiento
    {
        private int financiamientoId;
        private string nombreFinanciamiento;
        private int cantidadCuotas;
        private decimal interes;
        private string terminosYCondicionesFinanciamiento;

        [Key]
        public int FinanciamientoId
        {
            get => financiamientoId;
            set => financiamientoId = value;
        }

        public string NombreFinanciamiento
        {
            get => nombreFinanciamiento;
            set => nombreFinanciamiento = !string.IsNullOrWhiteSpace(value)
                ? value
                : throw new ArgumentException("El nombre del financiamiento no puede estar vacío.");
        }

        public int CantidadCuotas
        {
            get => cantidadCuotas;
            set => cantidadCuotas = value > 0
                ? value
                : throw new ArgumentException("La cantidad de cuotas debe ser mayor a 0.");
        }

        public decimal Interes
        {
            get => interes;
            set => interes = value >= 0
                ? value
                : throw new ArgumentException("El interés no puede ser negativo.");
        }

        public string TerminosYCondicionesFinanciamiento
        {
            get => terminosYCondicionesFinanciamiento;
            set => terminosYCondicionesFinanciamiento = !string.IsNullOrWhiteSpace(value)
                ? value
                : throw new ArgumentException("Los términos y condiciones no pueden estar vacíos.");
        }
        public string ObtenerDescripcion()
        {
            return $"{NombreFinanciamiento} - {CantidadCuotas} cuotas al {Interes}%";
        }
    }
}
