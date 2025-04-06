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
                        Consts.Messages.Header, Consts.Padding.NewLine,
                        Consts.Padding.NewLine,
                        ..Consts.Messages.HelpUsage
            ]), "Output message is invalid");
            Assert.That(exitCode, Is.EqualTo(ExitCode.CommandNotFound));
        });
    }
}