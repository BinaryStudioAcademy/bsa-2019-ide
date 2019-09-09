/* Auto Generated */

import { TreeNodeType } from "./../../Enums/treeNodeType"
import { FileStructureDTO } from "./fileStructureDTO"

export interface FileStructureDTO {
    id: string;
    type: TreeNodeType;
    isOpened: boolean;
    name: string;
    size: number;
    details: string;
    nestedFiles: FileStructureDTO[];
}
