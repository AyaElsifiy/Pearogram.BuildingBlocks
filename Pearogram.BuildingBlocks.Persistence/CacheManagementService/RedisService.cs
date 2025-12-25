using Pearogram.BuildingBlocks.Persistence.Contracts;
using StackExchange.Redis;

namespace Pearogram.BuildingBlocks.Persistence.CacheManagementService;

public class RedisService : IRedisService
{
    private readonly IDatabase _redisDb;

    public RedisService(IConnectionMultiplexer redis)
    {
        _redisDb = redis.GetDatabase();
    }

    public async Task<bool> AddInvalidatedTokenAsync(string token, TimeSpan expiry)
    {
        return await _redisDb.StringSetAsync(token, "invalid", expiry);
    }

    public async Task<bool> IsTokenInvalidatedAsync(string token)
    {
        var value = await _redisDb.StringGetAsync(token);
        return value.HasValue && value == "invalid";
    }
    public async Task<string> StoreOTPAsync(string email, string otp, TimeSpan expiry = default)
    {
        if (expiry == default)
            expiry = TimeSpan.FromMinutes(5);

        await _redisDb.StringSetAsync(email, otp, expiry);
        return otp;
    }

    //public async Task<bool> VerifyOTPAsync(string email, string otp)
    //{
    //    try
    //    {
    //        var storedOTP = await _redisDb.StringGetAsync(email);
    //        return storedOTP == otp;

    //    }
    //    catch (Exception ex)
    //    {
    //        throw;
    //    }

    //}

    public async Task<bool> VerifyOTPAsync(string email, string otp)
    {
        var storedOTP = await _redisDb.StringGetAsync(email);

        if (storedOTP.IsNullOrEmpty)
            return false;

        if (storedOTP != otp)
            return false;

        // OTP صحيح → احذفه عشان ميستخدمش تاني
        await _redisDb.KeyDeleteAsync(email);

        return true;
    }

    public async System.Threading.Tasks.Task RemoveOTPAsync(string email)
    => await _redisDb.KeyDeleteAsync(email);
}
