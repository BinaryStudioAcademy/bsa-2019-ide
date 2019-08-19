import { Language } from "../../Enums/language"
import { ProjectType } from "../../Enums/projectType"
import { CompilerType } from "../../Enums/compilerType"
import { AccessModifier } from '../../Enums/accessModifier';

export interface ProjectEditDTO {   
    id: number;
    name: string;
    description: string;
    language: Language;
    projectType: ProjectType;
    compilerType: CompilerType;
    countOfSaveBuilds: number;
    countOfBuildAttempts: number;
    accessModifier: AccessModifier;
    color: string;
}
