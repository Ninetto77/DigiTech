using CustomEventBus;
using CustomEventBus.Signals;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour, IService, IDisposable
{
    public const string RESISTANT_TEXT = "Ω: ";
    public const string CURRENT_TEXT = "A: ";
    public const string DCV_TEXT = "DCV: ";
    public const string ACV_TEXT = "ACV: ";

    [Header("Text on the multymetr")]
    [SerializeField] private TextMeshProUGUI screenText;

    [Header("Text In Canvas")]
    [SerializeField] private TextMeshProUGUI resisctanceText;
    [SerializeField] private TextMeshProUGUI currentText;
    [SerializeField] private TextMeshProUGUI DCVText;
    [SerializeField] private TextMeshProUGUI ACVText;

    private EventBus _eventBus;

    public void Initialization()
    {
        InitEventBus();
        CleanAllText();
        screenText.text = "0";
    }

    private void InitEventBus()
    {
        _eventBus = ServiceLocator.Current.Get<EventBus>();
        _eventBus.Subscribe<UpdateScreenSignal>(UpdateScreen);

        _eventBus.Subscribe<UpdateResistanceSignal>(UpdateResistanceScreen);
        _eventBus.Subscribe<UpdateCurrentSignal>(UpdateCurrentScreen);
        _eventBus.Subscribe<UpdateDCVSignal>(UpdateDCVScreen);
        _eventBus.Subscribe<UpdateACVSignal>(UpdateACVScreen);
    }

    /// <summary>
    /// update screen in multimeter
    /// </summary>
    /// <param name="signal"></param>
    private void UpdateScreen(UpdateScreenSignal signal)
    {
        CleanAllText();
        float val = signal.Value;
        screenText.text = val.ToString();
    }

    /// <summary>
    /// update resistance TextMeshPro
    /// </summary>
    /// <param name="signal"></param>
    private void UpdateResistanceScreen(UpdateResistanceSignal signal)
    {
        float val = signal.Value;
        resisctanceText.text = RESISTANT_TEXT + val.ToString();
    }

    /// <summary>
    /// update current TextMeshPro
    /// </summary>
    /// <param name="signal"></param>
    private void UpdateCurrentScreen(UpdateCurrentSignal signal)
    {
        float val = signal.Value;
        currentText.text = CURRENT_TEXT + val.ToString();
    }

    /// <summary>
    /// update DCV TextMeshPro
    /// </summary>
    /// <param name="signal"></param>
    private void UpdateDCVScreen(UpdateDCVSignal signal)
    {
        float val = signal.Value;
        DCVText.text = DCV_TEXT + val.ToString();
    }

    /// <summary>
    /// update ACV TextMeshPro
    /// </summary>
    /// <param name="signal"></param>
    private void UpdateACVScreen(UpdateACVSignal signal)
    {
        float val = signal.Value;
        ACVText.text = ACV_TEXT + val.ToString();
    }

    private void CleanAllText()
    {
        resisctanceText.text = RESISTANT_TEXT + "0";
        currentText.text = CURRENT_TEXT + "0";
        DCVText.text = DCV_TEXT + "0";
        ACVText.text = ACV_TEXT + "0";
    }

    public void Dispose()
    {
        _eventBus.Unsubscribe<UpdateScreenSignal>(UpdateScreen);

        _eventBus.Unsubscribe<UpdateResistanceSignal>(UpdateResistanceScreen);
        _eventBus.Unsubscribe<UpdateCurrentSignal>(UpdateCurrentScreen);
        _eventBus.Unsubscribe<UpdateDCVSignal>(UpdateDCVScreen);
        _eventBus.Unsubscribe<UpdateACVSignal>(UpdateACVScreen);
    }
}

