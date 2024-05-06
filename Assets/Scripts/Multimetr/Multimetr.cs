using CustomEventBus;
using CustomEventBus.Signals;
using System;
using UnityEngine;

public class Multimetr : MonoBehaviour, IService, CustomEventBus.IDisposable
{
    public Regulator CurRegulator;

    public float Power = 400f;
    public float Resistance = 1000f;
    public float Current ;
    public float DCV;
    public float ACV = 0.01f;

    private EventBus eventBus;

    public void Initialization()
    {
        //CurRegulator = GetComponent<Regulator>();
        eventBus = ServiceLocator.Current.Get<EventBus>();
        eventBus.Subscribe<ChangedStateSignal>(SendSignalToUpdateUI);
    }

    void Update()
    {
        Current = Mathf.Sqrt(Power/Resistance);
        DCV = Mathf.Sqrt(Power * Resistance);
        ACV = 0.01f;

        Current = (float)Math.Round(Current, 2);
        DCV = (float)Math.Round(DCV, 2);
    }

    /// <summary>
    /// Send value to uiManager to update UI
    /// </summary>
    private void SendSignalToUpdateUI(ChangedStateSignal signal)
    {
        switch (CurRegulator.curState)
        {
            case RegulaturState.turnOff:
                eventBus?.Invoke(new UpdateScreenSignal(0));
                break;
            case RegulaturState.resistance:
                eventBus?.Invoke(new UpdateScreenSignal(Resistance));
                eventBus?.Invoke(new UpdateResistanceSignal(Resistance));

                break;
            case RegulaturState.current:
                eventBus?.Invoke(new UpdateScreenSignal(Current));
                eventBus?.Invoke(new UpdateCurrentSignal(Current));

                break;
            case RegulaturState.DCV:
                eventBus?.Invoke(new UpdateScreenSignal(DCV));
                eventBus?.Invoke(new UpdateDCVSignal(DCV));
                break;
            case RegulaturState.ACV:
                eventBus?.Invoke(new UpdateScreenSignal(ACV));
                eventBus?.Invoke(new UpdateACVSignal(ACV));
                break;
        }

    }

    public void Dispose()
    {
        eventBus.Unsubscribe<ChangedStateSignal>(SendSignalToUpdateUI);

    }
}
