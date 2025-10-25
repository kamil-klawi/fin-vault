using System.Security.Cryptography;

namespace IdentityService.Application.Services.VerificationCode
{
    public class VerificationCode : IVerificationCode
    {
        public string GenerateOtp()
        {
            byte[] bytes = new byte[4];
            RandomNumberGenerator.Fill(bytes);
            uint code = BitConverter.ToUInt32(bytes, 0) % 1_000_000;
            return code.ToString("D6");
        }
    }
}
