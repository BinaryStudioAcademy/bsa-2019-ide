/* Auto Generated */

import { Language } from "./../../Enums/language"
import { ProjectType } from "./../../Enums/projectType"
import { CompilerType } from "./../../Enums/compilerType"
import { AccessModifier } from "./../../Enums/accessModifier"
import { UserDTO } from "./../User/userDTO"
import { GitCredentialDTO } from "./gitCredentialDTO"
import { ImageDTO } from "./../Image/imageDTO"
import { BuildDTO } from "./buildDTO"

export interface ProjectDTO {
    name: string;
    description: string;
    createdAt: Date;
    projectLink: string;
    countOfSaveBuilds: number;
    countOfBuildAttempts: number;
    language: Language;
    projectType: ProjectType;
    compilerType: CompilerType;
    accessModifier: AccessModifier;
    author: UserDTO;
    gitCredential: GitCredentialDTO;
    logo: ImageDTO;
    builds: BuildDTO[];
}
