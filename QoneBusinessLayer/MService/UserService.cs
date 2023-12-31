﻿using DataAxisLayer.Models;
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
    
        public class UserService : IUserService
        {
            private readonly RaoneContext tasksDbContext;
            private readonly ITokenService tokenService;

            public UserService(RaoneContext tasksDbContext, ITokenService tokenService)
            {
                this.tasksDbContext = tasksDbContext;
                this.tokenService = tokenService;
            }

            public async Task<UserResponse> GetInfoAsync(int userId)
            {
                var user = await tasksDbContext.Musers.FindAsync(userId);

                if (user == null)
                {
                    return new UserResponse
                    {
                        Success = false,
                        Error = "No user found",
                        ErrorCode = "I001"
                    };
                }

                return new UserResponse
                {
                    Success = true,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    CreationDate = user.Ts
                };
            }

            public async Task<MTokenResponse> LoginAsync(MLoginRequest loginRequest)
            {
                var user = tasksDbContext.Musers.SingleOrDefault(user => user.Active && user.Email == loginRequest.Email);

                if (user == null)
                {
                    return new MTokenResponse
                    {
                        Success = false,
                        Error = "Email not found",
                        ErrorCode = "L02"
                    };
                }
            var passwordHash = PasswordHelper.HashUsingPbkdf2(loginRequest.Password, Convert.FromBase64String(user.PasswordSalt));

            if (user.Password != passwordHash)
            {
                return new MTokenResponse
                {
                    Success = false,
                    Error = "Invalid Password",
                    ErrorCode = "L03"
                };
            }

            var token = await System.Threading.Tasks.Task.Run(() => tokenService.GenerateTokensAsync(user.Id));

                return new  MTokenResponse
                {
                    Success = true,
                    AccessToken = token.Item1,
                    RefreshToken = token.Item2,
                    UserId = user.Id,
                    FirstName = user.FirstName
                };
            }

       

        public async Task<MLogoutResponse> LogoutAsync(int userId)
            {
                var refreshToken = await tasksDbContext.MrefreshTokens.FirstOrDefaultAsync(o => o.UserId == userId);

                if (refreshToken == null)
                {
                    return new MLogoutResponse { Success = true };
                }

                tasksDbContext.MrefreshTokens.Remove(refreshToken);

                var saveResponse = await tasksDbContext.SaveChangesAsync();

                if (saveResponse >= 0)
                {
                    return new MLogoutResponse { Success = true };
                }

                return new MLogoutResponse { Success = false, Error = "Unable to logout user", ErrorCode = "L04" };
            }

            public async Task< MSignupResponse> SignupAsync(MSignupRequest signupRequest)
            {
                var existingUser = await tasksDbContext.Musers.SingleOrDefaultAsync(user => user.Email == signupRequest.Email);

                if (existingUser != null)
                {
                    return new MSignupResponse
                    {
                        Success = false,
                        Error = "User already exists with the same email",
                        ErrorCode = "S02"
                    };
                }

                if (signupRequest.Password != signupRequest.ConfirmPassword)
                {
                    return new MSignupResponse
                    {
                        Success = false,
                        Error = "Password and confirm password do not match",
                        ErrorCode = "S03"
                    };
                }

                if (signupRequest.Password.Length <= 7) // This can be more complicated than only length, you can check on alphanumeric and or special characters
                {
                    return new MSignupResponse
                    {
                        Success = false,
                        Error = "Password is weak",
                        ErrorCode = "S04"
                    };
                }

                var salt = PasswordHelper.GetSecureSalt();
                var passwordHash = PasswordHelper.HashUsingPbkdf2(signupRequest.Password, salt);

                var user = new Muser
                {
                    Email = signupRequest.Email,
                    Password = passwordHash,
                    PasswordSalt = Convert.ToBase64String(salt),
                    FirstName = signupRequest.FirstName,
                    LastName = signupRequest.LastName,
                    Ts = signupRequest.Ts,
                    Active = true // You can save is false and send confirmation email to the user, then once the user confirms the email you can make it true
                };

                await tasksDbContext.Musers.AddAsync(user);

                var saveResponse = await tasksDbContext.SaveChangesAsync();

                if (saveResponse >= 0)
                {
                    return new MSignupResponse { Success = true, Email = user.Email };
                }

                return new MSignupResponse
                {
                    Success = false,
                    Error = "Unable to save the user",
                    ErrorCode = "S05"
                };

            }

        

       
    }
    }