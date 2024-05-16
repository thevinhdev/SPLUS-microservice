﻿namespace SPLUS.Customer.Api.Models
{
    public class ResRegister : ResGenerateToken
    {

        public ResRegister(ResGenerateToken tokenData) : base(tokenData.AccessToken, tokenData.RefreshToken, tokenData.ExpirationDate)
        {
        }
    }
}
