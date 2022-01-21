using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoleSwip.Models.School
{
    [Table("school")]
    public class School
    {

        [Column("IDSCHOOL")]
        public int SchoolID { get; set; }

        [Column("ADRESSE")]
        public string AdresseID { get; set; }

        [Column("MASTER")]
        public string MasterID { get; set; }

        [Column("NOM")]
        public string Nom { get; set; }

        [Column("SIGLE")]
        public string Sigle { get; set; }

        [Column("CLASSEMENT")]
        public int Classement { get; set; }

        [Column("PORTEOUVERTE")]
        public string PorteOuverte { get; set; }

    }
}
