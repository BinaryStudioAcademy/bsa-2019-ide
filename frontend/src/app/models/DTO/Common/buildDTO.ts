/* Auto Generated */

import { BuildStatus } from "./../../Enums/buildStatus"
import { ProjectDTO } from "./projectDTO"
import { UserDTO } from "./../User/userDTO"

export interface BuildDTO {
    buildMessage: string;
    buildStarted: Date;
    buildFinished?: Date;
    buildStatus: BuildStatus;
    project: ProjectDTO;
    user: UserDTO;
}
