namespace IDE.BLL.Helpers
{
    public static class TextExtension
    {
        public static string Capitalize(this string str)
        {
            return char.ToUpper(str[0]) + str.Substring(1);
        }
    }
}
