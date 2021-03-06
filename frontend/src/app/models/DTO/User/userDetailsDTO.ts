﻿/* Auto Generated */

import { EditorSettingDTO } from "./../Common/editorSettingDTO"

export interface UserDetailsDTO {
    id: number;
    firstName: string;
    lastName: string;
    nickName: string;
    email: string;
    gitHubUrl: string;
    birthday: Date;
    registeredAt: Date;
    lastActive: Date;
    url: string;
    editorSettingsId?: number;
    editorSettings: EditorSettingDTO;
}
