using UnityEngine;
using CustomEventBus;
using System.Collections.Generic;

public class ServicesLocator_Main : MonoBehaviour
{
    [Header("Servises")]
    [SerializeField] private EventBus _eventBus;
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private Multimetr _multimetr;


    private void Awake()
    {
        Initialization();
    }

    private List<IDisposable> _disposables = new List<IDisposable>();
    public void Initialization()
    { 
        _eventBus = new EventBus();

        RegisterServices();
        Init();
    }

    private void Init()
    {
        _multimetr.Initialization();
        _uiManager.Initialization();
    }

    private void RegisterServices()
    {
        ServiceLocator.Initialization();
        ServiceLocator.Current.Register(_eventBus);
        ServiceLocator.Current.Register(_multimetr);
        ServiceLocator.Current.Register(_uiManager);
    }

    private void OnDestroy()
    {
        foreach (var disposable in _disposables)
        {
            disposable.Dispose();
        }
    }
}
