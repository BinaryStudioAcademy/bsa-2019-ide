/* Auto Generated */

import { BuildStatus } from "./../../Enums/buildStatus"

export interface ProjectDescriptionDTO {
    id: number;
    title: string;
    creator: string;
    photoLink: string;
    created: Date;
    favourite: boolean;
    buildStatus?: BuildStatus;
    lastBuild?: Date;
    color: string;
}
