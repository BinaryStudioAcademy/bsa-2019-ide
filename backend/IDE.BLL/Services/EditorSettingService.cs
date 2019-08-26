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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDE.BLL.Services
{
    public class EditorSettingService : IEditorSettingService
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

            await _context.EditorSettings.AddAsync(editorSettins);
            await _context.SaveChangesAsync();
            editorSettinsCreateDto = _mapper.Map<EditorSettingDTO>(editorSettins);

            return editorSettinsCreateDto;
        }

        public async Task<EditorSettingDTO> GetEditorSettingById(int editorSettingsId)
        {
            var editorSettings = await _context.EditorSettings
                .SingleOrDefaultAsync(p => p.Id == editorSettingsId);

            return _mapper.Map<EditorSettingDTO>(editorSettings);
        }

        public async Task<int> CreateInitEditorSettings()
        {
            var neweditorSettings = new EditorSetting
            {
                LineNumbers = "on",
                RoundedSelection = false,
                ScrollBeyondLastLine = false,
                ReadOnly = false,
                FontSize = 20,
                TabSize = 5,
                CursorStyle = "line",
                LineHeight = 20,
                Theme = "vs"
            };

            await _context.EditorSettings.AddAsync(neweditorSettings);
            await _context.SaveChangesAsync();
            return neweditorSettings.Id;

        }

        public async Task<EditorSettingDTO> UpdateAllProject(EditorSettingDTO editorSettingstUpdateDTO, int userId)
        {
            var projects = await _context.Projects
                .Where(pr => pr.AuthorId == userId)
                .Include(x => x.Author)
                .Include(x => x.EditorProjectSettings)
                .ToListAsync();

            var author = await _context.Users
                .FirstOrDefaultAsync(item => item.Id == userId);
            foreach (var project in projects)
            {
                var editorSettings = await _context.EditorSettings
                    .FirstOrDefaultAsync(item => item.Id == project.EditorProjectSettingsId);
                if (editorSettings == null)
                {
                    var neweditorSettings = new EditorSetting
                    {
                        CursorStyle = editorSettingstUpdateDTO.CursorStyle,
                        FontSize = editorSettingstUpdateDTO.FontSize,
                        LineHeight = editorSettingstUpdateDTO.LineHeight,
                        LineNumbers = editorSettingstUpdateDTO.LineNumbers,
                        RoundedSelection = editorSettingstUpdateDTO.RoundedSelection,
                        ScrollBeyondLastLine = editorSettingstUpdateDTO.ScrollBeyondLastLine,
                        TabSize = editorSettingstUpdateDTO.TabSize,
                        Theme = editorSettingstUpdateDTO.Theme,
                        ReadOnly = editorSettingstUpdateDTO.ReadOnly
                    };
                    editorSettings = neweditorSettings;
                    await _context.EditorSettings.AddAsync(editorSettings);
                    await _context.SaveChangesAsync();
                    project.EditorProjectSettingsId = editorSettings.Id;
                    _context.Projects.Update(project);
                    await _context.SaveChangesAsync();
                }
                else if (!HaveTheSameEditorSettings(editorSettingstUpdateDTO, editorSettings))
                {
                    editorSettingstUpdateDTO.Id = editorSettings.Id;
                    await UpdateEditorSetting(editorSettingstUpdateDTO);
                }
            }
            var userEditorSettings = await _context.EditorSettings
                    .FirstOrDefaultAsync(item => item.Id == author.EditorSettingsId);
            editorSettingstUpdateDTO.Id = userEditorSettings.Id;
            await UpdateEditorSetting(editorSettingstUpdateDTO);
            await _context.SaveChangesAsync();
            return editorSettingstUpdateDTO;

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
            targetEditorSetting.TabSize = editorSettingstUpdateDTO.TabSize;
            targetEditorSetting.Theme = editorSettingstUpdateDTO.Theme;
            targetEditorSetting.ReadOnly = editorSettingstUpdateDTO.ReadOnly;

            _context.EditorSettings.Update(targetEditorSetting);
            await _context.SaveChangesAsync();

            return await GetEditorSettingById(targetEditorSetting.Id);
        }

        private bool HaveTheSameEditorSettings(EditorSettingDTO first, EditorSetting second)
        {
            if (first.LineHeight != second.LineHeight ||
                first.LineNumbers != second.LineNumbers ||
                first.RoundedSelection != second.RoundedSelection ||
                first.ScrollBeyondLastLine != second.ScrollBeyondLastLine ||
                first.TabSize != second.TabSize ||
                first.Theme != second.Theme)
            {
                return false;
            }
            return true;
        }
    }
}
