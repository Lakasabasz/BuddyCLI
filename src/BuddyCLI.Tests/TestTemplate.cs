using BuddyCLI.Tests.Tools;
using Serilog;

namespace BuddyCLI.Tests;

class TestTemplate
{
    private readonly ILogger _logger;
    protected VirtualConsole VirtualConsole;
    
    public TestTemplate()
    {
        _logger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();
    }
    
    [OneTimeSetUp]
    public void GlobalSetUp()
    {
    }

    [SetUp]
    public void RunBeforeAllTests()
    {
        _logger.Information("Start: {testName}", TestContext.CurrentContext.Test.FullName);
        VirtualConsole = new();
    }

    [TearDown]
    public void RunAfterAllTests()
    {
        _logger.Information("End: {testName} => {status}", TestContext.CurrentContext.Test.FullName, TestContext.CurrentContext.Result.Outcome);
    }

    [OneTimeTearDown]
    public void GlobalTearDown()
    {
        ((IDisposable)_logger).Dispose();
    }
}