using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Vitals.Core.Entities
{
    public enum Types
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        Height,
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [EnumMember(Value = "HeartRate")]
        HeartRate,
        [EnumMember(Value = "BloodPressure")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        BloodPressure,
        [EnumMember(Value = "Temperature")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        Temperature,
        [EnumMember(Value = "WEIGHT")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        WEIGHT,
        [EnumMember(Value = "BODY_MASS_INDEX")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        BODY_MASS_INDEX
    }
}
