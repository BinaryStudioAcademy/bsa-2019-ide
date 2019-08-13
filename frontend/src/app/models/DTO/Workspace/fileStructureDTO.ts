/* Auto Generated */

import { TreeNodeType } from "./../../Enums/treeNodeType"
import { FileStructureDTO } from "./fileStructureDTO"

export interface FileStructureDTO {
    id: string;
    type: TreeNodeType;
    name: string;
    details: string;
    nestedFiles: FileStructureDTO[];
}
