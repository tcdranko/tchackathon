﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TCRateAndFeedbackServiceClient
{
    public class ModelHttpClient : JsonHttpClient
    {
        public ModelHttpClient(string baseUri) : base(baseUri)
        {

        }

        public async Task<TModel> GetAsync<TModel>(string relativePath, (string key, string value)[] parameters = null) where TModel : class
        {
            var result = await GetAsync(relativePath, parameters);
            return GetTypedResult<TModel>(result);
        }
        
        public async Task<TModel> PostAsync<TModel>(string relativePath, TModel model) where TModel : class
        {
            var serializeObject = JsonConvert.SerializeObject(model);
            var result = await base.PostAsync(relativePath, serializeObject);
            return GetTypedResult<TModel>(result);
        }

        private static TModel GetTypedResult<TModel>(string result) where TModel : class
        {
            try
            {
                var data = JsonConvert.DeserializeObject<TModel>(result);
                return data;
            }
            catch
            {
                return null;
            }
        }
    }
}
