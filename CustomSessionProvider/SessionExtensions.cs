using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_WebApp.CustomSessionProvider
{
    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            // Serialoize the CLR Object in the JSON format
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T Get<T>(this ISession session, string key)
        {
            // read the JSON string
            var value = session.GetString(key);
            // DeSerialize the JSON string into CLR Object
            return value == null ? default(T) :
                JsonConvert.DeserializeObject<T>(value);
        }
    }
}
