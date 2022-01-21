using System;
using System.Collections.Generic;
using System.Linq;
using EcoleSwip.DAL;
using EcoleSwip.DTO.School;
using Microsoft.Extensions.Logging;

namespace EcoleSwip.Services
{
    public class SchoolService
    {
        private readonly ILogger<SchoolService> _logger;
        private SchoolContext _context { get; set; }

        public SchoolService(ILogger<SchoolService> logger, SchoolContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IEnumerable<SchoolReadDto> FindByName(string sigle)
        {
            int valStar = sigle.IndexOf('*');
            if(valStar > 0)
            {
                sigle = sigle.Substring(0, valStar);
            }

            var dbSchool = _context.DbSchools.ToList();

            var innerJoinQuery =
                from school in dbSchool
                where school.Sigle.Contains(sigle)
                select new {school};

            var TotalResult = innerJoinQuery.ToList();

            var schoolReadDtos = new List<SchoolReadDto>();

            TotalResult.ForEach(e =>
            {
                var schoolReadDto = new SchoolReadDto
                {
                    schoolID = e.school.SchoolID,
                    adresseID = e.school.AdresseID,
                    masterID = e.school.MasterID,
                    nom = e.school.Nom,
                    sigle = e.school.Sigle,
                    classement = e.school.Classement,
                    porteOuverte = e.school.PorteOuverte,
                };

                schoolReadDtos.Add(schoolReadDto);
            });



             return schoolReadDtos;

            
        }
    }
}
