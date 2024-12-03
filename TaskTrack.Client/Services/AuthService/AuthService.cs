﻿namespace TaskTrack.Client.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _http;

        public AuthService(HttpClient http)
        {
            _http = http;
        }

        public async Task<ServiceResponse<int>> Register(UserRegisterDTO request)
        {
            var result = await _http.PostAsJsonAsync("api/Auth/register", request);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<int>>();
        }

        public async Task<ServiceResponse<string>> Login(UserLoginDTO request)
        {
            var result = await _http.PostAsJsonAsync("api/Auth/login", request);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }

        public Task<bool> IsAuthenticated()
        {
            throw new NotImplementedException();
        }
    }
}
