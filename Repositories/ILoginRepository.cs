using PetFinder.DTO.login;

namespace PetFinder.Repositories;

public interface ILoginRepository
{
   Task<LoginResponse> GenerateJwtToken(string userName);
}
