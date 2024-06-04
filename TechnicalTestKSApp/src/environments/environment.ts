export const environment = {
    production: false,
    apiUrl: 'https://localhost:44312/',
    endpoints:{
        generalInformation:{
            getNationalities: 'api/general-information/nationalities',
            getDateSelect: 'api/general-information/date-select'
        },
        employee:{
            getAll: 'api/employees/get-all',
            get: 'api/employees/get/{id}',
            add:'api/employees/add',
            update:'api/employees/update',
            delete: 'api/employees/delete/{id}'
        },
        beneficiary:{
            getAll: 'api/beneficiaries/get-all/{id}',
            get: 'api/beneficiaries/get/{id}',
            add:'api/beneficiaries/add',
            update:'api/beneficiaries/update',
            delete: 'api/beneficiaries/delete/{id}'
        }
    }
};