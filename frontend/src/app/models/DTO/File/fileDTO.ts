/* Auto Generated */

import { UserDTO } from "./../User/userDTO"
import { FileHistoryDTO } from "./fileHistoryDTO"

export interface FileDTO {
    id: string;
    name: string;
    folder: string;
    content: string;
    createdAt: Date;
    projectId: number;
    creatorId: number;
    creator: UserDTO;
    updaterId?: number;
    updater: UserDTO;
    lastFileHistoryId: string;
    lastFileHistory: FileHistoryDTO;
}
