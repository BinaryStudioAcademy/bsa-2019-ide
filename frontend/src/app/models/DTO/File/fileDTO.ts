/* Auto Generated */

import { UserDTO } from "./../User/userDTO"

export interface FileDTO {
    id: string;
    name: string;
    folder: string;
    content: string;
    projectId: number;
    createdAt: Date;
    creatorId: number;
    creator: UserDTO;
    updatedAt?: Date;
    updaterId?: number;
    updater: UserDTO;
}
