namespace hunchedDog.ContainerConfiguration
{
    public class GetJwtSettings
    {
        private string _jwtKey;
        private string _jwtIssuer;
        private string _jwtAudience;
        public GetJwtSettings(string jwt, string issuer, string audience)
        {
            _jwtKey = jwt;
            _jwtIssuer = issuer;
            _jwtAudience = audience;
        }
        public string[] GetJWT()
        {
            string[] jwtArr = { _jwtKey, _jwtIssuer, _jwtAudience };
            return jwtArr;
        }
    }
}
