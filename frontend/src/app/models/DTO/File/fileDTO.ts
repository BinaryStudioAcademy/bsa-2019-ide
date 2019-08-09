/* Auto Generated */

import { FileHistoryDTO } from "./fileHistoryDTO"
import { ProjectDTO } from "./../Common/projectDTO"

export interface FileDTO {
    id: string;
    name: string;
    folder: string;
    content: string;
    createdAt: Date;
    fileHistoryId: number;
    fileHistory: FileHistoryDTO;
    projectId: number;
    project: ProjectDTO;
}
