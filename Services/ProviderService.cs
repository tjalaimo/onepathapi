using Microsoft.EntityFrameworkCore;
using onepathapi.Data;
using onepathapi.Models;
using onepathapi.DTOs;

namespace onepathapi.Services
{
    public interface IProviderService
    {
        Task<BaseProviderDTO> GetProvider(int providerId);
        Task<(List<BaseProviderDTO>, int)> GetProviders(PaginationRequest request);        
    }

    public class ProviderService : IProviderService
    {

        private readonly ApplicationDbContext _context;

        public ProviderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<BaseProviderDTO> GetProvider(int providerId)
        {
            Provider provider = await _context.Providers
                .Include(p => p.User)
                .Where(p => p.ProviderId == providerId)
                .FirstAsync();

            return new BaseProviderDTO(provider);
        }

        public async Task<(List<BaseProviderDTO>, int)> GetProviders(PaginationRequest request)
        {            
            var query = _context.Providers.AsQueryable();

            // If searchTerm is provided, apply the filters
            if (!string.IsNullOrEmpty(request.SearchTerm))
            {
                query = query.Where(p => 
                    p.FirstName.Contains(request.SearchTerm) ||
                    p.LastName.Contains(request.SearchTerm) ||
                    p.Specialty.ToString().Contains(request.SearchTerm) ||
                    p.Email.Contains(request.SearchTerm) ||
                    p.Phone.Contains(request.SearchTerm) ||
                    p.Address.Contains(request.SearchTerm) ||
                    p.Gender.Contains(request.SearchTerm) ||
                    p.Identifier.Contains(request.SearchTerm)                  
                );
            }

            // Apply pagination
            var totalProviders = await query.CountAsync();
            var providers = await query
                .Include(p => p.User)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

            return (providers.Select(p => new BaseProviderDTO(p)).ToList(), totalProviders);
        }
    }
}
