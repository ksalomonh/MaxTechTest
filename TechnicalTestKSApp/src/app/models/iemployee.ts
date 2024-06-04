import { IPerson } from "./iperson";

export interface IEmployee extends IPerson {
    employeeId: number
    ,employeeNumber: string
    ,beneficiariesCount: number
}