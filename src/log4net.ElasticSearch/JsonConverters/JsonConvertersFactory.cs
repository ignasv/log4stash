﻿using System;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace log4net.ElasticSearch.JsonConverters
{
    interface ICustomJsonConverter
    {
         // todo: add description
    }

    class JsonConvertersFactory
    {
        public static JsonConverter[] GetCustomConverters()
        {
            var converters = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.Namespace != null
                            && typeof(ICustomJsonConverter).IsAssignableFrom(t))
                .Select(Activator.CreateInstance).OfType<JsonConverter>();
            return converters.ToArray();
        }
    }
}
