using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IDE.BLL.Interfaces;
using IDE.Common.ModelsDTO.DTO.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IDE.API.Controllers
{
    [Route("[controller]")]
    [Authorize]
    [ApiController]
    public class EditorSettingsController : ControllerBase
    {
        private readonly IEditorSettingService _editorSetiingsService;
        private readonly IMapper _mapper;

        public EditorSettingsController(IEditorSettingService editorSettingService,
            IMapper mapper)
        {
            _editorSetiingsService = editorSettingService;
            _mapper = mapper;
        }

        [HttpPut]
        public async Task<ActionResult<EditorSettingDTO>> Update(EditorSettingDTO editorSettingDTO)
        {
            return Ok(await _editorSetiingsService.UpdateEditorSetting(editorSettingDTO));
        }

        [HttpPut("{userId}")]
        public async Task<ActionResult<EditorSettingDTO>> UpdateAllUserProject(EditorSettingDTO editorSettingDTO, int userId)
        {
            return Ok(await _editorSetiingsService.UpdateAllProject(editorSettingDTO, userId));
        }

    }
}