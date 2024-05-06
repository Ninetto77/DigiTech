namespace CustomEventBus.Signals
{
    /// <summary>
    /// Signal about changed value
    /// </summary>
    public class UpdateDCVSignal
    {
        public readonly float Value;

        public UpdateDCVSignal(float value)
        {
            Value = value;
        }
    }
}