using BuddyCLI.Core;
using BuddyCLI.Core.Displays;

namespace BuddyCLI.Tests.Tools;

class TestsDisplayFactory(VirtualConsole console): DisplayToolFactory
{
    public override IDisplayManager CreateDisplayManager() => new TestDisplayManager(console);
    public override ILogger CreateLogger(ArgumentParser parser, object scope) => new TestLogger(parser, scope, console);
}