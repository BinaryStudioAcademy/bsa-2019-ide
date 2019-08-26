using AutoMapper;
using IDE.BLL.ExceptionsCustom;
using IDE.BLL.Interfaces;
using IDE.Common.ModelsDTO.DTO.Common;
using IDE.Common.ModelsDTO.Enums;
using IDE.DAL.Context;
using IDE.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IDE.BLL.Services
{
    public class EditorSettingService: IEditorSettingService
    {
        private IdeContext _context;
        private readonly ILogger<EditorSettingService> _logger;
        private readonly IMapper _mapper;

        public EditorSettingService(IdeContext context, 
            ILogger<EditorSettingService> logger,
            IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<EditorSettingDTO> CreateEditorSettings(EditorSettingDTO editorSettinsCreateDto)
        {
            var editorSettins = _mapper.Map<EditorSetting>(editorSettinsCreateDto);

            _context.EditorSettings.Add(editorSettins);
            await _context.SaveChangesAsync();
            editorSettinsCreateDto  = _mapper.Map<EditorSettingDTO>(editorSettins);

            return editorSettinsCreateDto;
        }

        public async Task<EditorSettingDTO> GetEditorSettingById(int editorSettingsId)
        {
            var editorSettings = await _context.EditorSettings
                .SingleOrDefaultAsync(p => p.Id == editorSettingsId);

            return _mapper.Map<EditorSettingDTO>(editorSettings);
        }

        public async Task<EditorSettingDTO> UpdateEditorSetting(EditorSettingDTO editorSettingstUpdateDTO)
        {
            var editorSettingstUpdate = _mapper.Map<EditorSetting>(editorSettingstUpdateDTO);
            var targetEditorSetting = await _context.EditorSettings.SingleOrDefaultAsync(p => p.Id == editorSettingstUpdate.Id);

            if (targetEditorSetting == null)
            {
                _logger.LogWarning(LoggingEvents.HaveException, $"update project not found");
                throw new NotFoundException(nameof(targetEditorSetting), editorSettingstUpdate.Id);
            }

            targetEditorSetting.FontSize = editorSettingstUpdateDTO.FontSize;
            targetEditorSetting.CursorStyle = editorSettingstUpdateDTO.CursorStyle;
            targetEditorSetting.LineHeight = editorSettingstUpdateDTO.LineHeight;
            targetEditorSetting.LineNumbers = editorSettingstUpdateDTO.LineNumbers;
            targetEditorSetting.RoundedSelection = editorSettingstUpdateDTO.RoundedSelection;
            targetEditorSetting.TabSize= editorSettingstUpdateDTO.TabSize;
            targetEditorSetting.Theme = editorSettingstUpdateDTO.Theme;
            targetEditorSetting.ReadOnly = editorSettingstUpdateDTO.ReadOnly;

            _context.EditorSettings.Update(targetEditorSetting);
            await _context.SaveChangesAsync();

            return await GetEditorSettingById(targetEditorSetting.Id);
        }
    }
}
