using DataAxisLayer.Models;
using Microsoft.EntityFrameworkCore;
using QoneBusinessLayer.IMServices;
using QoneBusinessLayer.Ticket;
using QoneModel;
using QoneRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QoneBusinessLayer.MService
{
    public class TokenService : ITokenService
    {
        private readonly RaoneContext tasksDbContext;

    public TokenService(RaoneContext tasksDbContext)
    {
        this.tasksDbContext = tasksDbContext;
    }

    public async Task<Tuple<string, string>> GenerateTokensAsync(int userId)
    {
        var accessToken = await TokenHelper.GenerateAccessToken(userId);
        var refreshToken = await TokenHelper.GenerateRefreshToken();

        var userRecord = await tasksDbContext.Musers.Include(o => o.MrefreshTokens).FirstOrDefaultAsync(e => e.Id == userId);

        if (userRecord == null)
        {
            return null;
        }

        var salt = PasswordHelper.GetSecureSalt();

        var refreshTokenHashed = PasswordHelper.HashUsingPbkdf2(refreshToken, salt);

        if (userRecord.MrefreshTokens != null && userRecord.MrefreshTokens.Any())
        {
            await RemoveRefreshTokenAsync(userRecord);

        }
        userRecord.MrefreshTokens?.Add(new MrefreshToken
        {
            ExpiryDate = DateTime.UtcNow.AddMinutes(5),
            Ts = DateTime.Now,
            UserId = userId,
            TokenHash = refreshTokenHashed,
            TokenSalt = Convert.ToBase64String(salt)

        });

        await tasksDbContext.SaveChangesAsync();

        var token = new Tuple<string, string>(accessToken, refreshToken);

        return token;
    }

    public async Task<bool> RemoveRefreshTokenAsync(Muser user)
    {
        var userRecord = await tasksDbContext.Musers.Include(o => o.MrefreshTokens).FirstOrDefaultAsync(e => e.Id == user.Id);

        if (userRecord == null)
        {
            return false;
        }

        if (userRecord.MrefreshTokens != null && userRecord.MrefreshTokens.Any())
        {
            var currentRefreshToken = userRecord.MrefreshTokens.First();

            tasksDbContext.MrefreshTokens.Remove(currentRefreshToken);
        }
        return false;
    }

        

        public async Task<MValidateRefreshTokenResponse> ValidateRefreshTokenAsync(MRefreshTokenRequest refreshTokenRequest)
    {
        var refreshToken = await tasksDbContext.MrefreshTokens.FirstOrDefaultAsync(o => o.UserId == refreshTokenRequest.UserId);

        var response = new MValidateRefreshTokenResponse();
        if (refreshToken == null)
        {
            response.Success = false;
            response.Error = "Invalid session or user is already logged out";
            response.ErrorCode = "invalid_grant";
            return response;
        }

        var refreshTokenToValidateHash = PasswordHelper.HashUsingPbkdf2(refreshTokenRequest.RefreshToken, Convert.FromBase64String(refreshToken.TokenSalt));

        if (refreshToken.TokenHash != refreshTokenToValidateHash)
        {
            response.Success = false;
            response.Error = "Invalid refresh token";
            response.ErrorCode = "invalid_grant";
            return response;
        }

        if (refreshToken.ExpiryDate < DateTime.Now)
        {
            response.Success = false;
            response.Error = "Refresh token has expired";
            response.ErrorCode = "invalid_grant";
            return response;
        }

        response.Success = true;
        response.UserId = refreshToken.UserId;

        return response;
    }

       
    }
}