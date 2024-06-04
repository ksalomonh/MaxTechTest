using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalTestKSApp_BE_BL.Interfaces;
using TechnicalTestKSApp_BE_BL.Interfaces.Repositories;
using TechnicalTestKSApp_BE_BL.Models;
using TechnicalTestKSApp_BE_DA.Interfaces;

namespace TechnicalTestKSApp_BE_BL.Repositories
{
    public class GeneralInformationRepository : IGeneralInformationRepository
    {
        private readonly IDbContext _dbService;
        public GeneralInformationRepository(IDbContext dbService)
        {
            _dbService = dbService;
        }

        public async Task<IEnumerable<Nationality>> GetNationalities()
        {
            IEnumerable<Nationality> nationalities = await _dbService.RunProcedureListAsync<Nationality, object>(new { }, "dbo.SPGetNationalities");
            return nationalities;
        }
    }
}
