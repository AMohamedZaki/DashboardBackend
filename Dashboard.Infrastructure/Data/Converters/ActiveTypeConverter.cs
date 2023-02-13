using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Zanobia.Infrastructure.Data.Converters
{
    public class ActiveTypeConverter : ValueConverter<bool, string>
    {
        public ActiveTypeConverter()
      : base(
          coreValue => ToString(coreValue),
          efValue => FromString(efValue))
        {
        }

        private static string ToString(bool type)
        {
            return type switch
            {
                true => "Y",
                false => "N",
                // _ => null
            };
        }

        private static bool FromString(string type)
        {
            return type.ToUpper() switch
            {
                "Y" => true,
                "N" => false,
                // _ => KnowType.Unknown
            };
        }
    }
}
