using IntelSync.Domain.Models;
using IntelSync.Domain.Services;

namespace BatchProcessorTests;

[TestFixture]
public class SimpleTokenValidatorTests
{
    [Test]
    public void Validate_ShouldReturnFalse_WhenTokenIsNull()
    {
        var job = new SyncJob
        {
            User = new CrmUser { Token = null }
        };

        var validator = new SimpleTokenValidator();
        var result = validator.Validate(job, out var error);

        Assert.That(result, Is.False);
        Assert.That(error, Is.EqualTo("Missing CRM token."));
    }

    [Test]
    public void Validate_ShouldReturnTrue_WhenTokenIsPresent()
    {
        var job = new SyncJob
        {
            User = new CrmUser { Token = "valid" }
        };

        var validator = new SimpleTokenValidator();
        var result = validator.Validate(job, out var error);

        Assert.That(result, Is.True);
        Assert.That(error, Is.Empty);
    }
}
