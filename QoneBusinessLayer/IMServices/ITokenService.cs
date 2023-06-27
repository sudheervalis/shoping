using DataAxisLayer.Models;
using QoneModel;
using QoneRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QoneBusinessLayer.IMServices
{
    public interface ITokenService
    {
        Task<Tuple<string, string>> GenerateTokensAsync(int userId);
        Task<MValidateRefreshTokenResponse> ValidateRefreshTokenAsync(MRefreshTokenRequest refreshTokenRequest);
        Task<bool> RemoveRefreshTokenAsync(Muser user);
    }
}
