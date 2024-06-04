import { INationality } from "./inationality";

export interface IPerson extends INationality {
    name: string
    ,lastName: string
    ,birthDate: string //(Validar que sea mayor de edad)
    ,curp: string
    ,ssn: string
    ,phone: string //(Validar formato a 10 dígitos)
    ,phoneValue: number //(Validar formato a 10 dígitos)
}