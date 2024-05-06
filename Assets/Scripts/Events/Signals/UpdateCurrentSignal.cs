namespace CustomEventBus.Signals
{
    /// <summary>
    /// Signal about changed value
    /// </summary>
    public class UpdateCurrentSignal
    {
        public readonly float Value;

        public UpdateCurrentSignal(float value)
        {
            Value = value;
        }
    }
}