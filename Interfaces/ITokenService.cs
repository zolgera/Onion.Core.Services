using System;
using System.Threading.Tasks;
using core.Interfaces.Query;
using Core.Data.Entitys.Security;

namespace Core.Services.Interfaces
{
    public interface ITokenService
    {
        Task DeleteToken(Guid id);
        Task<Token> GetToken(Guid id);
        Task<Token> GetToken(string code);
        Task<Token> GetToken(string clientId, string refreshToken);
        Task<IQueryResult<Token>> GetTokens();
        Task InsertToken(Token token);
        Task UpdateToken(Token token);
    }
}