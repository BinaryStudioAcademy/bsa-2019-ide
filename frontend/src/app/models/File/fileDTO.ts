/* Auto Generated */

import { FileHistoryDTO } from "./fileHistoryDTO"
import { ProjectDTO } from "./../Common/projectDTO"

export interface FileDTO {
    name: string;
    folder: string;
    content: string;
    createAt: Date;
    fileHistoryId: number;
    fileHistory: FileHistoryDTO;
    projectId: number;
    project: ProjectDTO;
}
