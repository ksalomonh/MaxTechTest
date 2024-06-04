using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalTestKSApp_BE_BL.Interfaces;
using TechnicalTestKSApp_BE_BL.Interfaces.Logics;
using TechnicalTestKSApp_BE_BL.Interfaces.Repositories;
using TechnicalTestKSApp_BE_BL.Models;
using TechnicalTestKSApp_BE_DA.Interfaces;

namespace TechnicalTestKSApp_BE_BL.Logics
{
    public class BeneficiaryBL : IBeneficiaryBL
    {
        private readonly IResponse _response;
        private readonly IBeneficiaryRepository _beneficiaryRepository;
        public BeneficiaryBL(IResponse response, IBeneficiaryRepository beneficiaryRepository)
        {
            _response = response;
            _beneficiaryRepository = beneficiaryRepository;
        }
        public async Task<IResponse> Delete(int id)
        {
            int result = await _beneficiaryRepository.Delete(id);
            await _response.Set(result);
            return _response;
        }

        public async Task<IResponse> Get(int id)
        {
            IEnumerable<Beneficiary> beneficiarys = await _beneficiaryRepository.Get(id);
            _response.Response = beneficiarys;
            return await Task.FromResult(_response);
        }

        public Task<IResponse> Get()
        {
            throw new NotImplementedException();
        }

        public async Task<IResponse> GetAll(int employeeId)
        {
            IEnumerable<Beneficiary> beneficiarys = await _beneficiaryRepository.GetAll(employeeId);
            _response.Response = beneficiarys;
            return await Task.FromResult(_response);
        }

        public async Task<IResponse> Insert(List<Beneficiary> beneficiaries)
        {
            foreach (Beneficiary beneficiary in beneficiaries)
            {
                if (beneficiary.BeneficiaryId == 0 && !beneficiary.IsDeleted)
                    await _beneficiaryRepository.Insert(beneficiary);
                else if (beneficiary.BeneficiaryId > 0 && !beneficiary.IsDeleted)
                    await _beneficiaryRepository.Update(beneficiary);
                else if (beneficiary.BeneficiaryId > 0 && beneficiary.IsDeleted)
                    await _beneficiaryRepository.Delete(beneficiary.BeneficiaryId);
            }

            await _response.Set(1);
            return _response;
        }

        public Task<IResponse> Insert(Beneficiary entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IResponse> Update(Beneficiary beneficiary)
        {
            beneficiary = await _beneficiaryRepository.Update(beneficiary);
            await _response.Set(beneficiary);
            return _response;
        }
    }
}
