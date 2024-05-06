namespace CustomEventBus.Signals
{
    /// <summary>
    /// Signal about changed value
    /// </summary>
    public class UpdateResistanceSignal
    {
        public readonly float Value;

        public UpdateResistanceSignal(float value)
        {
            Value = value;
        }
    }
}