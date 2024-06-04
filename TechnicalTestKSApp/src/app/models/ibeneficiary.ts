import { IPerson } from "./iperson";

export interface IBeneficiary extends IPerson {
    beneficiaryId: number
    ,employeeId: number
    ,participationPercentage: number
    ,IsDeleted: boolean
    ,indexId: number
}   