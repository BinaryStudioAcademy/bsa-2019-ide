import { Language } from "./../../Enums/language"
import { ProjectType } from "./../../Enums/projectType"
import { CompilerType } from "./../../Enums/compilerType"

export interface ProjectCreateDTO {
    name: string;
    description: string;
    language: Language;
    projectType: ProjectType;
    compilerType: CompilerType;
    countOfSaveBuilds: number;
    countOfBuildAttempts: number;
    color: string;
}
