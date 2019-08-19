import { AccessModifier } from "./../../Enums/accessModifier"

export interface ProjectUpdateDTO {
    id: number;
    name: string;
    description: string;
    countOfSaveBuilds: number;
    countOfBuildAttempts: number;
    accessModifier: AccessModifier;
    color: string;
}
