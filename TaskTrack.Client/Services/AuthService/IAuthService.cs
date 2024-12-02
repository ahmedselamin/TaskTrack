﻿namespace TaskTrack.Client.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>> Register(UserRegisterDTO request);
        Task<ServiceResponse<string>> Login(UserLoginDTO request);
        Task<bool> IsAuthenticated();
    }
}
