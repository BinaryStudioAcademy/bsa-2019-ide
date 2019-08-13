/* Auto Generated */

import { TreeNodeType } from "./../../Enums/treeNodeType"
import { FileDTO } from "./../File/fileDTO"

export interface FileDTO {
    id: string;
    type: TreeNodeType;
    name: string;
    details: string;
    nestedFiles: FileDTO[];
}
