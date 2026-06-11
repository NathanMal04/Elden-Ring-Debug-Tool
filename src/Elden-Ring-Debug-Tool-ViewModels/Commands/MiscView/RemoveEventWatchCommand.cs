using Elden_Ring_Debug_Tool_ViewModels.ViewModels;
using Elden_Ring_Debug_Tool_ViewModels.ViewModels.SubViewModels;

namespace Elden_Ring_Debug_Tool_ViewModels.Commands
{
    /// <summary>
    /// [Reconstructed] Removes the EventViewModel for a watch-list row (passed as the command
    /// parameter) from the watch list. Never committed upstream; the event-watch feature postdates
    /// the public v0.8.6.2 build.
    /// </summary>
    public class RemoveEventWatchCommand : CommandBase
    {
        private MiscViewViewModel _miscViewViewModel { get; }

        public RemoveEventWatchCommand(MiscViewViewModel miscViewViewModel)
        {
            _miscViewViewModel = miscViewViewModel;
        }

        public override void Execute(object? parameter)
        {
            if (parameter is not EventViewModel eventViewModel)
                return;

            _miscViewViewModel.EventWatchList.Remove(eventViewModel);
        }
    }
}
