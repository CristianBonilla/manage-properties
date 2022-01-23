namespace RealEstate.Properties.API.Options
{
    class JwtOptions
    {
        public string Secret { get; set; }
        public int ExpiresInDays { get; set; }
    }
}
