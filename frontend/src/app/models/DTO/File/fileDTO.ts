/* Auto Generated */

import { UserDTO } from "./../User/userDTO"

export interface FileDTO {
    id: string;
    name: string;
    content: string;
    folder: string;
    projectId: number;
    createdAt: Date;
    creatorId: number;
    creator: UserDTO;
    isOpen: boolean;
    updatedAt?: Date;
    updaterId?: number;
    updater: UserDTO;
}
