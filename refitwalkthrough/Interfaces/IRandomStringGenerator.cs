using Refit;
using refitwalkthrough.DTOs;

namespace refitwalkthrough.Interfaces;

public interface IRandomStringGenerator
{
    [Get("/api?len={RandomStringLength}&count={NumberOfRandomStrings}")]
    Task<GeneratedNumbersDTO> GetRandomStrings([AliasAs("RandomStringLength")] int length, [AliasAs("NumberOfRandomStrings")] int number);

}