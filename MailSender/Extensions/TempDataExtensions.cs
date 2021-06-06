﻿using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;

namespace MailSender.Extensions
{
    public static class TempDataExtensions
    {
        public static void Put<T>(this ITempDataDictionary tempData, string key, T value) where T : class
        {
            tempData[key] = JsonConvert.SerializeObject(value);
        }

        public static T Get<T>(this ITempDataDictionary tempData, string key) where T : class
        {
            object objectFromData;
            tempData.TryGetValue(key, out objectFromData);
            return objectFromData == null ? null : JsonConvert.DeserializeObject<T>((string)objectFromData);
        }
    }
}
