using IDE.Common.ModelsDTO.DTO.Workspace;
using IDE.DAL.Interfaces;
using IDE.DAL.Entities.NoSql;
using AutoMapper;
using System.Threading.Tasks;
using IDE.BLL.ExceptionsCustom;
using IDE.BLL.Interfaces;

namespace IDE.BLL.Services
{
    public class ProjectStructureService : IProjectStructureService
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
                throw new NotFoundException(nameof(ProjectStructure), id);
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

        public async Task<ProjectStructureDTO> CreateEmptyAsync(string projectId, string projectName)
        {
            var emptyStructureDTO = new ProjectStructureDTO
            {
                Id = projectId
            };
            var initialFileStructure = new FileStructureDTO()
            {
                Type = 0,
                Details = $"Super important details of file {projectName}",
                Name = projectName
            };
            emptyStructureDTO.NestedFiles.Add(initialFileStructure);

            var emptyStructure = _mapper.Map<ProjectStructure>(emptyStructureDTO);
            var createdProjectStructure = await _projectStructureRepository.CreateAsync(emptyStructure);
            return await GetByIdAsync(createdProjectStructure.Id);
        }

    }
}
