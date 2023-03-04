﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Refugio.Areas.Admin.Models.Veterinarian
{
    public class Edit
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        [MinLength(4, ErrorMessage = "El nombre de usuario no puede ser menor a 4 caracteres")]
        [MaxLength(50, ErrorMessage = "El nombre de usuario no puede ser mayor a 50 caracteres")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(100, ErrorMessage = "El nombre no puede ser mayor a 100 caracteres")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "El apellido es requerido")]
        [MaxLength(100, ErrorMessage = "El apellido no puede ser mayor a 100 caracteres")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "La dirección es requerida")]
        [MaxLength(50, ErrorMessage = "La dirección no puede ser mayor a 50 caracteres")]
        public string StreetAddress { get; set; }
        [MaxLength(50, ErrorMessage = "La especificación de departamento o descripción no puede ser mayor a 50 caracteres")]
        public string ApartmentNumber { get; set; }
        [Required(ErrorMessage = "La ciudad es requerida")]
        [MaxLength(50, ErrorMessage = "La ciudad no puede ser mayor a 50 caracteres")]
        public string City { get; set; }
        [Required(ErrorMessage = "La provincia es requerida")]
        [MaxLength(50, ErrorMessage = "La provincia no puede ser mayor a 50 caracteres")]
        public string Province { get; set; }
        [Required(ErrorMessage = "El código postal es requerido")]
        [MaxLength(10, ErrorMessage = "El código postal no puede ser mayor a 10 caracteres")]
        public string ZipCode { get; set; }
        [Required(ErrorMessage = "El número de teléfono es requerido")]
        [MaxLength(15, ErrorMessage = "El número de teléfono no puede ser mayor a 15 caracteres")]
        public string PhoneNumberMain { get; set; }
        [MaxLength(15, ErrorMessage = "El número de teléfono no puede ser mayor a 15 caracteres")]
        public string PhoneNumberAditional { get; set; }
        [Required(ErrorMessage = "La especialidad es requerida")]
        public int Speciality { get; set; }
        [Required(ErrorMessage = "Debe especificar si es personal permanente o no")]
        public bool IsPermanent { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        [Range(0, 9999999999999999, ErrorMessage = "El salario debe estar entre 0 y 9999999999999999")]
        public decimal? Salary { get; set; }
        public int? TimeSlot { get; set; }
        [Required(ErrorMessage = "Debe especificar la licencia del profesional")]
        [MaxLength(10, ErrorMessage = "La licencia no puede ser mayor a 10 caracteres")]
        public string ProfessionalLicense { get; set; }
        public string Description { get; set; }
        public SelectList VeterinarianSpeciality { get; set; }
        public byte[] RowVersion { get; set; }
        public bool IsNewUser
        {
            get
            {
                return this.Id == 0;
            }
        }
        public void GetValues(DTO.Veterinarian veterinarian)
        {
            this.Id = veterinarian.Id;
            this.UserName = veterinarian.UserName;
            this.FirstName = veterinarian.FirstName;
            this.LastName = veterinarian.LastName;
            this.StreetAddress = veterinarian.StreetAddress;
            this.ApartmentNumber = veterinarian.ApartmentNumber;
            this.City = veterinarian.City;
            this.ZipCode = veterinarian.ZipCode;
            this.Province = veterinarian.Province;
            this.PhoneNumberMain = veterinarian.PhoneNumberMain;
            this.PhoneNumberAditional = veterinarian.PhoneNumberAditional;
            this.Speciality = veterinarian.Speciality;
            this.IsPermanent = veterinarian.IsPermanent;
            this.Salary = veterinarian.Salary;
            this.TimeSlot = veterinarian.TimeSlot;
            this.ProfessionalLicense = veterinarian.ProfessionalLicense;
            this.Description = veterinarian.ForDescription;
            this.RowVersion = veterinarian.RowVersion;
        }

        public void SetValues(DTO.Veterinarian veterinarian)
        {
            veterinarian.Id = this.Id;
            veterinarian.UserName = this.UserName;
            veterinarian.FirstName = this.FirstName;
            veterinarian.LastName = this.LastName;
            veterinarian.StreetAddress = this.StreetAddress;
            veterinarian.ApartmentNumber = this.ApartmentNumber;
            veterinarian.City = this.City;
            veterinarian.ZipCode = this.ZipCode;
            veterinarian.Province = this.Province;
            veterinarian.PhoneNumberMain = this.PhoneNumberMain;
            veterinarian.PhoneNumberAditional = this.PhoneNumberAditional;
            veterinarian.Speciality = this.Speciality;
            veterinarian.IsPermanent = this.IsPermanent;
            veterinarian.Salary = this.Salary;
            veterinarian.TimeSlot = this.TimeSlot;
            veterinarian.ProfessionalLicense = this.ProfessionalLicense;
            veterinarian.ForDescription = this.Description;
            veterinarian.RowVersion = this.RowVersion;
        }
    }
}
