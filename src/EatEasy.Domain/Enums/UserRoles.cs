namespace EatEasy.Domain.Enums
{
    public static class UserRoles
    {
        public const string ADMIN = "Admin";
        public const string SELLER = "Seller";
        public const string CLIENT = "Client";

        public static string[] ROLES = { ADMIN, SELLER, CLIENT };
    }
}
