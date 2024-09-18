

namespace PromotionEngine.Application.Shared.Dto;

public class BaseResponse
{
    [JsonIgnore]
    public bool Success { get; set; } = true;

    [JsonIgnore]
    public Exception? Exception { get; set; }
}
