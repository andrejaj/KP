using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("HelperTest")]
namespace KPService.Helper
{
    internal static class ConvertEnum<T>
    {
        public static T ToConvert(string value) => (T)System.Enum.Parse(typeof(T), value, ignoreCase: true);
    }
}
