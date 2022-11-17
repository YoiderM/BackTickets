using Application.Common.Response;
using Application.Cqrs.Novelties.Commands;
using Application.Cqrs.Novelties.Queries;
using Application.DTOs.Mekano;
using Application.DTOs.Novelties;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Novelties
{
    public interface INoveltiesService
    {
        Task<ApiResponse<List<TB_ASISTENCIA_MARCADORESDto>>> GetUsers(GetUsersNoveltiesQuery request, CancellationToken cancellationToken);
        Task<ApiResponse<List<ConfigurationNoveltiesDto>>> GetConfigurationNovelties(int Without, CancellationToken cancellationToken);
        Task<ApiResponse<TB_ASISTENCIA_MARCADORESDto>> PutStatusNoveltyPerson(PutStatusNoveltyPersonCommand request, CancellationToken cancellationToken);
        Task<ApiResponse<List<MekanoUserDto>>> GetMekanoUsers(int ConstCenterId, CancellationToken cancellationToken);
        Task<ApiResponse<NoveltyEntryDto>> PostAnticipatedNovelties (PostAnticipatedNoveltyCommand request, CancellationToken cancellationToken);
        Task<ApiResponse<List<NoveltiesOrderByTypeNoveltyDto>>> GetAnticipatedNovelties(getAnticipatedNoveltiesQuery request, CancellationToken cancellationToken);
        Task<ApiResponse<List<NoveltyEntryQueryDto>>> getAnticipatedNoveltiesQuery(getNoveltiesQuery request, CancellationToken cancellationToken);
        Task<ApiResponse<NoveltyEntryDto>> PutStatusAprobationNovelty (PutAnticipatedNoveltyCommand request, CancellationToken cancellationToken);
    }
}
