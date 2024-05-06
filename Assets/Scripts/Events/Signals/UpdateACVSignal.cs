namespace CustomEventBus.Signals
{
    /// <summary>
    /// Signal about changed value
    /// </summary>
    public class UpdateACVSignal
    {
        public readonly float Value;

        public UpdateACVSignal(float value)
        {
            Value = value;
        }
    }
}