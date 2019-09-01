/* Auto Generated */

import { NotificationStatus } from "./../../Enums/notificationStatus"
import { NotificationType } from "./../../Enums/notificationType"

export interface NotificationDTO {
    id: number;
    status: NotificationStatus;
    type: NotificationType;
    dateTime: Date;
    message: string;
    isRead: boolean;
    projectId?: number;
    metadata: string;
}
