using BuddyCLI.Core;
using BuddyCLI.Tests.Tools;

namespace BuddyCLI.Tests.Help;

class HelpTests: TestTemplate
{
    [Test/*, Ignore("Not yet implemented")*/]
    public void ImplicitHelp()
    {
        var app = new App.App(new ArgumentParser([]), new TestsDisplayFactory(VirtualConsole));
        var exitCode = app.Process();
        Assert.Multiple(() =>
        {
            Assert.That(VirtualConsole.Messages, Is.EqualTo((List<MessageData>)[
                        Consts.Messages.Header, Consts.Padding.NewLine,
                        Consts.Padding.NewLine,
                        ..Consts.Messages.HelpUsage,
                        ..Consts.Messages.GeneralUsageCommand,
                        Consts.Padding.NewLine,
                        ..Consts.Messages.HelpCommands,
                        Consts.Padding.Padding2, Consts.Messages.PaddedResource("help", 10), Consts.Messages.PaddedAliases(["?"], 16), Consts.Padding.Padding2
            ]), "Output message is invalid");
            Assert.That(exitCode, Is.EqualTo(ExitCode.CommandNotFound));
        });
    }
}