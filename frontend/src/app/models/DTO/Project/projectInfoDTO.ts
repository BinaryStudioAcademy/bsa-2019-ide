/* Auto Generated */

import { Language } from "./../../Enums/language"
import { ProjectType } from "./../../Enums/projectType"
import { CompilerType } from "./../../Enums/compilerType"
import { AccessModifier } from "./../../Enums/accessModifier"
import { EditorSettingDTO } from "./../Common/editorSettingDTO"
import { GitCredentialDTO } from "./../Common/gitCredentialDTO"

export interface ProjectInfoDTO {
    id: number;
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
    editorProjectSettings: EditorSettingDTO;
    authorId: number;
    authorName: string;
    gitCredential: GitCredentialDTO;
    color: string;
    amountOfMembers: number;
}
