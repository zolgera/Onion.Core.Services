using core.Interfaces.Query;
using Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Core.Repository.Interfaces;
using Core.Data.Entitys.Security;
using Core.Repository.Query;

namespace Core.Services.Security
{
    public class TokenService : ITokenService
    {
        private readonly IRepository<Token> _tokenRepository;

        public TokenService(IRepository<Token> tokenRepository)
        {
            _tokenRepository = tokenRepository;
        }

        public async Task DeleteToken(Guid id)
        {
            Token token = _tokenRepository.Get(id);
            await _tokenRepository.DeleteAsync(token);
        }

        public async Task<Token> GetToken(Guid id)
        {
            return await _tokenRepository.GetAsync(id);
        }

        public async Task<Token> GetToken(string code)
        {
            return await _tokenRepository.GetByCodeAsync(code);
        }
        public async Task<Token> GetToken(string clientId, string refreshToken)
        {
            IEnumerable<Token> tokens = await _tokenRepository.FindAsync(t => t.ClientId == clientId && t.Value == refreshToken);
            return tokens?.SingleOrDefault();
        }
        public async Task<IQueryResult<Token>> GetTokens()
        {
            IEnumerable<Token> tokens = await _tokenRepository.GetAllAsync();
            return new QueryResult<Token>(tokens);
        }

        public async Task InsertToken(Token token)
        {
            await _tokenRepository.InsertAsync(token);
        }

        public async Task UpdateToken(Token token)
        {
            await _tokenRepository.UpdateAsync(token);
        }
    }
}
