export interface ProjectStructure {
    Id: string;
    NestedFiles: PSFileNode[];
}

export interface PSFileNode {
    Id: string;
    Type: PSNodeTypeEnum;
    Name: string;
    Details: string;
    NestedFiles: PSFileNode[];
}

export enum PSNodeTypeEnum {
    Folder = 0,
    File = 1
}
