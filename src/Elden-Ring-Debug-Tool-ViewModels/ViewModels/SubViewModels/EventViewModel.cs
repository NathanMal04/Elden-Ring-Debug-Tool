namespace Elden_Ring_Debug_Tool_ViewModels.ViewModels.SubViewModels
{
    /// <summary>
    /// [Reconstructed] A single watched event flag shown in the Misc tab's watch-list DataGrid and
    /// persisted to Resources/WatchList.txt as JSON. Referenced by MiscViewViewModel but never
    /// committed (the event-watch feature postdates the public v0.8.6.2 build, so there is no
    /// authoritative original). Properties match the DataGrid columns (EventId, Bits, Description,
    /// Value). The live-refresh that writes <see cref="Value"/> in MiscViewViewModel.UpdateViewModel
    /// is commented out upstream, so this currently acts as a data holder.
    /// </summary>
    public class EventViewModel : ViewModelBase
    {
        private uint _eventId;
        public uint EventId
        {
            get => _eventId;
            set => SetField(ref _eventId, value);
        }

        private uint _bits = 1;
        public uint Bits
        {
            get => _bits;
            set => SetField(ref _bits, value);
        }

        private string _description = string.Empty;
        public string Description
        {
            get => _description;
            set => SetField(ref _description, value);
        }

        private uint _value;
        public uint Value
        {
            get => _value;
            set => SetField(ref _value, value);
        }

        public EventViewModel()
        {
        }

        public EventViewModel(EventWatch watch)
        {
            EventId = watch.EventId;
            Bits = watch.Bits;
            Description = watch.Description;
        }
    }
}
