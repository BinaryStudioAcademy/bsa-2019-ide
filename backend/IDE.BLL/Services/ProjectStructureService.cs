using IDE.Common.ModelsDTO.DTO.Workspace;
using IDE.DAL.Interfaces;
using IDE.DAL.Entities.NoSql;
using AutoMapper;
using System.Threading.Tasks;
using IDE.BLL.ExceptionsCustom;

namespace IDE.BLL.Services
{
    public class ProjectStructureService
    {
        private readonly IProjectStructureRepository _projectStructureRepository;
        private readonly IMapper _mapper;

        public ProjectStructureService(
            IProjectStructureRepository projectStructureRepository,
            IMapper mapper)
        {
            _projectStructureRepository = projectStructureRepository;
            _mapper = mapper;
        }

        public async Task<ProjectStructureDTO> GetByIdAsync(string id)
        {
            var projectStructure = await _projectStructureRepository.GetByIdAsync(id);
            if (projectStructure == null)
            {
                throw new NotFoundException(nameof(File), id);
            }

            var projectStructureDto = _mapper.Map<ProjectStructureDTO>(projectStructure);

            return projectStructureDto;
        }

        public async Task UpdateAsync(ProjectStructureDTO projectStructureDTO)
        {
            var currentProjectStructureDto = await GetByIdAsync(projectStructureDTO.Id);
            currentProjectStructureDto.NestedFiles = projectStructureDTO.NestedFiles;

            var projectStructureUpdate = _mapper.Map<ProjectStructure>(currentProjectStructureDto);
            await _projectStructureRepository.UpdateAsync(projectStructureUpdate);
        }

        public async Task<ProjectStructureDTO> CreateAsync(ProjectStructureDTO projectStructureDto)
        {
            var projectStructureCreate = _mapper.Map<ProjectStructure>(projectStructureDto);
            var createdProjectStructure = await _projectStructureRepository.CreateAsync(projectStructureCreate);

            return await GetByIdAsync(createdProjectStructure.Id);
        }

    }
}
