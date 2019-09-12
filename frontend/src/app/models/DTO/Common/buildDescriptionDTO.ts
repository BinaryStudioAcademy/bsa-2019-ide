/* Auto Generated */

import { BuildStatus } from "./../../Enums/buildStatus"

export interface BuildDescriptionDTO {
    buildMessage: string;
    buildStarted: Date;
    buildFinished?: Date;
    buildStatus: BuildStatus;
    projectName: string;
    userName: string;
    uriForArtifactsDownload: string;
}
