using IDE.Common.ModelsDTO.DTO.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IDE.BLL.Interfaces
{
    public interface IEditorSettingService
    {
        Task<EditorSettingDTO> UpdateEditorSetting(EditorSettingDTO editorSettingstUpdateDTO);
        Task<EditorSettingDTO> GetEditorSettingById(int editorSettingsId);
        Task<EditorSettingDTO> CreateEditorSettings(EditorSettingDTO editorSettinsCreateDto);
        Task<EditorSettingDTO> UpdateAllProject(EditorSettingDTO editorSettingstUpdateDTO, int userId);
    }
}
