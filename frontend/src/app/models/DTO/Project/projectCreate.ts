import { Language } from 'src/app/models/Enums/Language'
import { ProjectType } from 'src/app/models/Enums/projectType'
import { CompilerType } from 'src/app/models/Enums/compilerType'

export interface ProjectCreate {
    name: string;
    description: string;
    authorId: number;
    language: Language;
    projectType: ProjectType;
    compilerType: CompilerType;
    countOfSaveBuilds: number;
    countOfBuildAttempts: number;
}
