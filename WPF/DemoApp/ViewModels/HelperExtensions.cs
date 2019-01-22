using VVMConnection;

namespace DemoApp.ViewModels
{
    public static class HelperExtensions
    {
        public static bool IsNullOrEmpty(this Notify<string> text)
            => string.IsNullOrEmpty(text.Value);

        public static bool IsNullOrEmpty(this string text)
            => string.IsNullOrEmpty(text);
    }
}
