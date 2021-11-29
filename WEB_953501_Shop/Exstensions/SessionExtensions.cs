using Microsoft.AspNetCore.Http;
using System.Text.Json;
using System;

namespace WEB_953501_Shop.Extensions
{
    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T item)
        {
            var serializedItem = JsonSerializer.Serialize(item);
            //var serializedItem = item.serialize();
            session.SetString(key, serializedItem);
        }
        public static T Get<T>(this ISession session, string key) where T : new()
        {
            var item = session.GetString(key);
            return item == null
            ? new T()
            : JsonSerializer.Deserialize<T>(item);
        }
    }
}