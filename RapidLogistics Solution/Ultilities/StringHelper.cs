
namespace Ultilities
{
    public class StringHelper
    {
        public static bool AreEqual(string a, string b)
        {
            if (string.IsNullOrEmpty(a))
            {
                return string.IsNullOrEmpty(b);
            }
            else
            {
                return string.Equals(a, b);
            }
        }

    }
}
