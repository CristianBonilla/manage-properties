namespace RealEstate.Properties.API
{
    struct CommonValues
    {
        public const string Bearer = nameof(Bearer);
        public const string PropertiesConnection = nameof(PropertiesConnection);
        public const string AllowOrigins = nameof(AllowOrigins);

        private static string ToCamelCase(string source) => char.ToLowerInvariant(source[0]) + source[1..];
    }
}
