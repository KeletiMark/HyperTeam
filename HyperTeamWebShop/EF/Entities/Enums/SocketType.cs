using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace HyperTeamWebShop.EF.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SocketType
    {
        AM3,
        AM4,
        FM2,
        LGA1050,
        LGA1051
    }
}
