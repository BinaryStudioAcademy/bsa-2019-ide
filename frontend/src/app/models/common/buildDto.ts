/* Auto Generated */

import { ProjectDTO } from "./projectDTO"
import { UserDTO } from "./../User/userDTO"

export interface BuildDto {
    id: number;
    buildMessage: string;
    buildStarted: Date;
    buildFinished?: Date;
    buildStatus: any;
    project: ProjectDTO;
    user: UserDTO;
}
