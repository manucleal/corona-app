using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using Dominio.EntidadesNegocio;
using System;

namespace WcfServicioCoronApp
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServicioVacunas" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioVacunas
    {
        [OperationContract]
        IEnumerable<DtoVacunas> GetTodasLasVacunas();
    }

    [DataContract]
    public class DtoVacunas
    {
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public int CantidadDosis { get; set; }
        [DataMember]
        public int LapsoDiasDosis { get; set; }
        [DataMember]
        public int MinEdad { get; set; }
        [DataMember]
        public int MaxEdad { get; set; }
        [DataMember]
        public int EficaciaPrev { get; set; }
        [DataMember]
        public int EficaciaHosp { get; set; }
        [DataMember]
        public int EficaciaCti { get; set; }
        [DataMember]
        public int MinTemp { get; set; }
        [DataMember]
        public int MaxTemp { get; set; }
        [DataMember]
        public int ProduccionAnual { get; set; }
        [DataMember]
        public int FaseClinicaAprob { get; set; }
        [DataMember]
        public bool Emergencia { get; set; }
        [DataMember]
        public string EfectosAdversos { get; set; }
        [DataMember]
        public decimal Precio { get; set; }
        [DataMember]
        public string IdTipo { get; set; }
        [DataMember]
        public ICollection<Laboratorio> ListaLaboratorios { get; set; } = new List<Laboratorio>();
        [DataMember]
        public bool Covax { get; set; }

        internal Vacuna ConvertirHaciaCliente()
        {
            return new Vacuna()
            {
                Nombre = this.Nombre,
                CantidadDosis = this.CantidadDosis,
                LapsoDiasDosis = this.LapsoDiasDosis,
                MinEdad = this.MinEdad,
                MaxEdad = this.MaxEdad,
                EficaciaPrev = this.EficaciaPrev,
                EficaciaHosp = this.EficaciaHosp,
                EficaciaCti = this.EficaciaCti,
                MinTemp = this.MinEdad,
                MaxTemp = this.MaxTemp,
                ProduccionAnual = this.ProduccionAnual,
                FaseClinicaAprob = this.FaseClinicaAprob,
                Emergencia = this.Emergencia,
                EfectosAdversos = this.EfectosAdversos,
                Precio = this.Precio,
                IdTipo = this.IdTipo,
                ListaLaboratorios = this.ListaLaboratorios,
                Covax = this.Covax
            };
        }

        internal void ConvertirDesdeVacuna(Vacuna vacuna)
        {
            Nombre = vacuna.Nombre;
            CantidadDosis = vacuna.CantidadDosis;
            LapsoDiasDosis = vacuna.LapsoDiasDosis;
            MinEdad = vacuna.MinEdad;
            MaxEdad = vacuna.MaxEdad;
            EficaciaPrev = vacuna.EficaciaPrev;
            EficaciaHosp = vacuna.EficaciaHosp;
            EficaciaCti = vacuna.EficaciaCti;
            MinTemp = vacuna.MinEdad;
            MaxTemp = vacuna.MaxTemp;
            ProduccionAnual = vacuna.ProduccionAnual;
            FaseClinicaAprob = vacuna.FaseClinicaAprob;
            Emergencia = vacuna.Emergencia;
            EfectosAdversos = vacuna.EfectosAdversos;
            Precio = vacuna.Precio;
            IdTipo = vacuna.IdTipo;
            ListaLaboratorios = vacuna.ListaLaboratorios;
            Covax = vacuna.Covax;
        }
    }
}
