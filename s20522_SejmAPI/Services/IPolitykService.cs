namespace s20522_SejmAPI.Services;

using s20522_SejmAPI.DTOs;

public interface IPolitykService
{
    Task<IEnumerable<PolitykGetDto>> GetAllPolitycyAsync();
}