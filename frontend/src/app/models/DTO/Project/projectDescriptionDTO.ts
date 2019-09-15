/* Auto Generated */

import { Language } from "./../../Enums/language"
import { ProjectType } from "./../../Enums/projectType"
import { BuildStatus } from "./../../Enums/buildStatus"

export interface ProjectDescriptionDTO {
    id: number;
    title: string;
    description: string;
    language: Language;
    projectType: ProjectType;
    creator: string;
    creatorId: number;
    created: Date;
    favourite: boolean;
    buildStatus?: BuildStatus;
    lastBuild?: Date;
    color: string;
    isPublic: boolean;
    amountOfMembers: number;
}
