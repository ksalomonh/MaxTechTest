using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalTestKSApp_BE_BL.Interfaces.Repositories;
using TechnicalTestKSApp_BE_BL.Models;
using TechnicalTestKSApp_BE_DA.Interfaces;

namespace TechnicalTestKSApp_BE_BL.Repositories
{
    public class BeneficiaryRepository : IBeneficiaryRepository
    {
        private readonly IDbContext _dbService;
        private DynamicParameters _parameters;
        public BeneficiaryRepository(IDbContext dbService)
        {
            _dbService = dbService;
        }

        public async Task<int> Delete(int id)
        {
            _parameters = new();
            _parameters.Add("BeneficiaryId", id);
            int result = await _dbService.ExecuteAsync<object>(_parameters, "dbo.SPDeleteBeneficiary");
            return result;
        }

        public async Task<IEnumerable<Beneficiary>> Get(int id)
        {
            _parameters = new();
            _parameters.Add("BeneficiaryId", id);
            IEnumerable<Beneficiary> Beneficiarys = await _dbService.RunProcedureListAsync<Beneficiary, object>(_parameters, "dbo.SPGetBeneficiary");
            return Beneficiarys;
        }

        public async Task<IEnumerable<Beneficiary>> GetAll(int employeeId)
        {
            _parameters = new();
            _parameters.Add("EmployeeId", employeeId);
            IEnumerable<Beneficiary> Beneficiarys = await _dbService.RunProcedureListAsync<Beneficiary, object>(_parameters, "dbo.SPGetAllBeneficiaries");
            return Beneficiarys;
        }

        public async Task<Beneficiary> Insert(Beneficiary Beneficiary)
        {
            try
            {
                _parameters = new();
                _parameters.Add("@EmployeeId", Beneficiary.EmployeeId);
                _parameters.Add("@NationalityId", Beneficiary.NationalityId);
                _parameters.Add("@Name", Beneficiary.Name);
                _parameters.Add("@LastName", Beneficiary.LastName);
                _parameters.Add("@BirthDate", Beneficiary.BirthDate);
                _parameters.Add("@Curp", Beneficiary.Curp);
                _parameters.Add("@Ssn", Beneficiary.Ssn);
                _parameters.Add("@Phone", Beneficiary.Phone);
                _parameters.Add("@ParticipationPercentage", Beneficiary.ParticipationPercentage);
                Beneficiary.BeneficiaryId = await _dbService.ExecuteAsync<object>(_parameters, "dbo.SPAddBeneficiary");
                return Beneficiary;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<Beneficiary> Update(Beneficiary Beneficiary)
        {
            _parameters = new();
            _parameters.Add("@BeneficiaryId", Beneficiary.BeneficiaryId);
            _parameters.Add("@NationalityId", Beneficiary.NationalityId);            
            _parameters.Add("@Name", Beneficiary.Name);
            _parameters.Add("@LastName", Beneficiary.LastName);
            _parameters.Add("@BirthDate", Beneficiary.BirthDate);
            _parameters.Add("@Curp", Beneficiary.Curp);
            _parameters.Add("@Ssn", Beneficiary.Ssn);
            _parameters.Add("@Phone", Beneficiary.Phone);
            _parameters.Add("@ParticipationPercentage", Beneficiary.ParticipationPercentage);
            Beneficiary.BeneficiaryId = await _dbService.ExecuteAsync<object>(_parameters, "dbo.SPEditBeneficiary");
            return Beneficiary;
        }
    }
}
