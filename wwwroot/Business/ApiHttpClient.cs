﻿using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using Difi.Sjalvdeklaration.Shared;
using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Extensions;
using Difi.Sjalvdeklaration.wwwroot.Business.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Difi.Sjalvdeklaration.wwwroot.Business
{
    public class ApiHttpClient : IApiHttpClient
    {
        private readonly IConfiguration configuration;
        private readonly IHttpContextAccessor httpContextAccessor;

        private readonly HttpClient httpClient;

        public ApiHttpClient(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            this.configuration = configuration;
            this.httpContextAccessor = httpContextAccessor;
            httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<ApiResult<T>> Get<T>(string url)
        {
            AddUserGuid();

            httpClient.DefaultRequestHeaders.Remove("Authorization");

            var responseMessage = await httpClient.GetAsync(configuration["ApiBaseUrl"] + url);

            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception(responseMessage.Content.ToString());
            }

            var responseData = responseMessage.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<ApiResult<T>>(responseData);
        }

        public async Task<T> Post<T>(string url, object jsonObject)
        {
            AddUserGuid();

            httpClient.DefaultRequestHeaders.Remove("Authorization");

            var responseMessage = await httpClient.PostAsync(configuration["ApiBaseUrl"] + url, jsonObject.AsJsonStringContent());

            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception(responseMessage.Content.ToString());
            }

            var responseData = responseMessage.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<T>(responseData);
        }

        public async Task<T> PostWithAuthorization<T>(string url, string authorizationType, string authorizationKey, StringContent stringContent)
        {
            httpClient.DefaultRequestHeaders.Remove("UserGuid");
            httpClient.DefaultRequestHeaders.Remove("Authorization");

            AddAuthorization(authorizationType, authorizationKey);

            var responseMessage = await httpClient.PostAsync(configuration["IdPorten:BaseUrl"] + url, stringContent);

            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception(responseMessage.Content.ToString());
            }

            var responseData = responseMessage.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<T>(responseData);
        }

        private void AddAuthorization(string authorizationType, string authorizationKey)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", $"{authorizationType} {authorizationKey}");
        }

        private void AddUserGuid()
        {
            var userId = Guid.Empty;
            var claims = httpContextAccessor.HttpContext?.User?.Claims.FirstOrDefault(x => x.Type == ClaimTypes.PrimarySid);

            if (claims != null)
            {
                userId = Guid.Parse(claims.Value);
            }

            httpClient.DefaultRequestHeaders.Remove("UserGuid");
            httpClient.DefaultRequestHeaders.Add("UserGuid", userId.ToString());
        }
    }
}