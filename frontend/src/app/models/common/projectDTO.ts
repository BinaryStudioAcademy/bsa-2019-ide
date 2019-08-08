/* Auto Generated */

import { UserDTO } from "./../User/userDTO";
import { GitCredentialDTO } from "./gitCredentialDTO";
import { ImageDTO } from "./../Image/imageDTO";

export interface ProjectDTO {
    name: string;
    description: string;
    createdAt: Date;
    projectLink: string;
    countOfSaveBuilds: number;
    countOfBuildAttempts: number;
    language: any;
    projectType: any;
    compilerType: any;
    accessModifier: any;
    author: UserDTO;
    gitCredential: GitCredentialDTO;
    logo: ImageDTO;
    builds: any[];
}
