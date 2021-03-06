﻿using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Threading.Tasks;
using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.Log;
using Difi.Sjalvdeklaration.Shared.Extensions;
using Difi.Sjalvdeklaration.wwwroot.Business.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;

namespace Difi.Sjalvdeklaration.wwwroot.Business
{
    public class ApiHttpClient : IApiHttpClient
    {
        private readonly IConfiguration configuration;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IStringLocalizer<ApiHttpClient> localizer;
        private readonly HttpClient httpClient;

        public ApiHttpClient(IConfiguration configuration, IHttpContextAccessor httpContextAccessor, IStringLocalizer<ApiHttpClient> localizer)
        {
            this.configuration = configuration;
            this.httpContextAccessor = httpContextAccessor;
            this.localizer = localizer;
            httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<ApiResult<T>> Get<T>(string url)
        {
            AddHeaders();

            var responseMessage = await httpClient.GetAsync(configuration["ApiBaseUrl"] + url);

            if (!responseMessage.IsSuccessStatusCode)
            {
                if (responseMessage.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new Exception(localizer["Api URL ({0}) not found!", url]);
                }

                throw new Exception(responseMessage.Content.ToString());
            }

            var responseData = responseMessage.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<ApiResult<T>>(responseData);
        }

        public async Task<T> Post<T>(string url, object jsonObject)
        {
            AddHeaders();

            var responseMessage = await httpClient.PostAsync(configuration["ApiBaseUrl"] + url, jsonObject.AsJsonStringContent());

            if (!responseMessage.IsSuccessStatusCode)
            {
                string text;

                try
                {
                    text = responseMessage.Content.ReadAsStringAsync().Result;
                }
                catch
                {
                    text = responseMessage.ReasonPhrase;
                }

                throw new Exception(text);
            }

            var responseData = responseMessage.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<T>(responseData);
        }

        public async Task<T> PostWithAuthorization<T>(string url, string authorizationType, string authorizationKey, StringContent stringContent)
        {
            httpClient.DefaultRequestHeaders.Remove("UserGuid");
            httpClient.DefaultRequestHeaders.Remove("Lang");
            httpClient.DefaultRequestHeaders.Remove("ApiKey");
            httpClient.DefaultRequestHeaders.Remove("Authorization");

            AddAuthorization(authorizationType, authorizationKey);

            var responseMessage = await httpClient.PostAsync(configuration["IdPorten:BaseUrl"] + url, stringContent);

            if (!responseMessage.IsSuccessStatusCode)
            {
                string text;

                try
                {
                    text = responseMessage.Content.ReadAsStringAsync().Result;
                }
                catch
                {
                    text = responseMessage.ReasonPhrase;
                }

                throw new Exception(text);
            }

            var responseData = responseMessage.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<T>(responseData);
        }

        public async void LogError(Exception exception, object callParameter1 = null, object callParameter2 = null, [CallerMemberName] string callerFunctionName = null, [CallerFilePath] string callerFileName = null)
        {
            AddHeaders();

            var userId = Guid.Empty;
            var claims = httpContextAccessor.HttpContext?.User?.Claims.FirstOrDefault(x => x.Type == ClaimTypes.PrimarySid);

            if (claims != null)
            {
                userId = Guid.Parse(claims.Value);
            }

            var apiResult = new ApiResult
            {
                Exception = exception,
                Succeeded = false
            };

            var logItem = new LogItem(new Stopwatch(), userId, Guid.Empty, apiResult, callParameter1, callParameter2, null, callerFunctionName, callerFileName);

            var responseMessage = await httpClient.PostAsync(configuration["ApiBaseUrl"] + "/api/Log/Add", logItem.AsJsonStringContent());

            if (responseMessage.IsSuccessStatusCode) return;

            string text;

            try
            {
                text = responseMessage.Content.ReadAsStringAsync().Result;
            }
            catch
            {
                text = responseMessage.ReasonPhrase;
            }

            throw new Exception(text);
        }

        private void AddAuthorization(string authorizationType, string authorizationKey)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", $"{authorizationType} {authorizationKey}");
        }

        private void AddHeaders()
        {
            httpClient.DefaultRequestHeaders.Remove("Authorization");

            var userId = Guid.Empty;
            var claims = httpContextAccessor.HttpContext?.User?.Claims.FirstOrDefault(x => x.Type == ClaimTypes.PrimarySid);

            if (claims != null)
            {
                userId = Guid.Parse(claims.Value);
            }

            httpClient.DefaultRequestHeaders.Remove("UserGuid");
            httpClient.DefaultRequestHeaders.Add("UserGuid", userId.ToString());

            httpClient.DefaultRequestHeaders.Remove("Lang");
            httpClient.DefaultRequestHeaders.Add("Lang", CultureInfo.CurrentCulture.Name);

            httpClient.DefaultRequestHeaders.Remove("ApiKey");
            httpClient.DefaultRequestHeaders.Add("ApiKey", configuration["Api:Key"]);
        }
    }
}