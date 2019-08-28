/* Auto Generated */

import { UserDTO } from "./../User/userDTO"

export interface FileUpdateDTO {
    id: string;
    name: string;
    content: string;
    folder: string;
    isOpen: boolean;
    updaterId?: number;
    updater: UserDTO;
}
