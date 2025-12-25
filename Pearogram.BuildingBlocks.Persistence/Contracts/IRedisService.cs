namespace Pearogram.BuildingBlocks.Persistence.Contracts;

public interface IRedisService
{
    Task<bool> AddInvalidatedTokenAsync(string token, TimeSpan expiry);
    Task<bool> IsTokenInvalidatedAsync(string token);
    Task<string> StoreOTPAsync(string email, string otp, TimeSpan expiry = default);
    Task<bool> VerifyOTPAsync(string email, string otp);
    Task RemoveOTPAsync(string email);
}
