using AutoMapper;
using IDE.Common.ModelsDTO.DTO.Common;
using IDE.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IDE.BLL.MappingProfiles
{
    public class NotificationProfile: Profile
    {
        public NotificationProfile()
        {
            CreateMap<Notification, NotificationDTO>();
            CreateMap<NotificationDTO, Notification>();
        }
    }
}
