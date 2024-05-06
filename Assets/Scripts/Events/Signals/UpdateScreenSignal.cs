namespace CustomEventBus.Signals
{
    /// <summary>
    /// Signal about changed values
    /// </summary>
    public class UpdateScreenSignal
    {
        public readonly float Value;

        public UpdateScreenSignal(float value)
        {
            Value = value;
        }
    }
}
