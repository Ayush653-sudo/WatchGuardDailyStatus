using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Tooth_Booth_API.Enum
{

    public enum PaymentType
    {
        [EnumMember(Value = "UPI")]
        UPI,
        [EnumMember(Value = "Cash")]
        Cash
    };
}
