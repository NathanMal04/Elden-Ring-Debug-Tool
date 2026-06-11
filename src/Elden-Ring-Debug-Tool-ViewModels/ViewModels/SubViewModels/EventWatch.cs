namespace Elden_Ring_Debug_Tool_ViewModels.ViewModels.SubViewModels
{
    /// <summary>
    /// [Reconstructed] Backing model for the Misc tab's "add event watch" form. Referenced by
    /// MiscViewViewModel but never committed to the repo (the event-watch feature postdates the
    /// public v0.8.6.2 build, so there is no authoritative original to recover). Holds the inputs
    /// used to create an <see cref="EventViewModel"/> watch entry.
    /// </summary>
    public class EventWatch
    {
        public uint EventId { get; set; }
        public uint Bits { get; set; } = 1;
        public string Description { get; set; } = string.Empty;

        public EventWatch(uint eventId)
        {
            EventId = eventId;
        }
    }
}
