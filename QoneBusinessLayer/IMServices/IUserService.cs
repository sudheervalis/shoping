using QoneModel;
using QoneRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QoneBusinessLayer.IMServices
{
    public interface IUserService
    {
        Task<MTokenResponse> LoginAsync(MLoginRequest loginRequest);
        Task<MSignupResponse> SignupAsync(MSignupRequest signupRequest);
        Task<MLogoutResponse> LogoutAsync(int userId);
        Task<UserResponse> GetInfoAsync(int userId);

    }
}
