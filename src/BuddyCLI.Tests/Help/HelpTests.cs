using BuddyCLI.Core;
using BuddyCLI.Tests.Tools;

namespace BuddyCLI.Tests.Help;

class HelpTests: TestTemplate
{
    [Test, Ignore("Not yet implemented")]
    public void ImplicitHelp()
    {
        var app = new App.App(new ArgumentParser([]), new TestsDisplayFactory(VirtualConsole));
        var exitCode = app.Process();
        Assert.Multiple(() =>
        {
            Assert.That(VirtualConsole.Messages, Is.EqualTo((List<MessageData>)[
                        new MessageData("bdyctl 1.0.0.0v - Community command line interface client to buddy.works", ConsoleColor.White)
                    ]), "Output message is invalid");
            Assert.That(exitCode, Is.EqualTo(ExitCode.CommandNotFound));
        });
    }
}