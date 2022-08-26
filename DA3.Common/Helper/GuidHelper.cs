namespace DA3.Common.Helper
{
    public static class GuidHelper
    {
        public static bool IsGuildNullOrEmpty(this Guid guid)
        {
            return guid == Guid.Empty;
        }
    }
}
