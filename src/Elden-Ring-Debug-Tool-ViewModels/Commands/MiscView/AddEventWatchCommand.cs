using Elden_Ring_Debug_Tool_ViewModels.ViewModels;
using Elden_Ring_Debug_Tool_ViewModels.ViewModels.SubViewModels;

namespace Elden_Ring_Debug_Tool_ViewModels.Commands
{
    /// <summary>
    /// [Reconstructed] Adds the event flag described by the Misc tab's form (passed as the
    /// EventWatch command parameter) to the watch list. Never committed upstream; the event-watch
    /// feature postdates the public v0.8.6.2 build.
    /// </summary>
    public class AddEventWatchCommand : CommandBase
    {
        private MiscViewViewModel _miscViewViewModel { get; }

        public AddEventWatchCommand(MiscViewViewModel miscViewViewModel)
        {
            _miscViewViewModel = miscViewViewModel;
        }

        public override void Execute(object? parameter)
        {
            if (parameter is not EventWatch watch)
                return;

            _miscViewViewModel.EventWatchList.Add(new EventViewModel(watch));
        }
    }
}
