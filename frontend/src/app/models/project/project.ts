import { Language } from '../common/project-language';
import { ProjectType } from '../common/project-type';
import { CompilerType } from '../common/compiler-type';

export interface Project {
    id: number;
    name: string;
    description: string;
    authorId: number;
    language: Language;
    projectType: ProjectType;
    compilerType: CompilerType;
    countOfSaveBuilds: number;
    countOfBuildAttempts: number;
    gitCredentialsId: number;
}
