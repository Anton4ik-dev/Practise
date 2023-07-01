using DataFactories;
using ScriptableObjects;
using Document;
using TMPro;
using UnityEngine;
using Zenject;

public class MainInstaller : MonoInstaller
{
    [SerializeField] private DocumentTemplate _documentTemplate;
    [SerializeField] private DateSO _dateSO;
    [SerializeField] private TextMeshProUGUI _dateClocks;
    [SerializeField] private ScoreChanger _scoreChanger;
    [SerializeField] private RageChanger _rageChanger;

    public override void InstallBindings()
    {
        Container.Bind<QualityFactory>().AsSingle();
        Container.Bind<HeaderFactory>().AsSingle();
        Container.Bind<MarkFactory>().AsSingle();
        Container.Bind<DateFactory>().AsSingle();
        Container.Bind<DataFactory>().AsSingle();

        Container.Bind<DocumentModel>().AsSingle();

        Container.Bind<DocumentTemplate>().FromInstance(_documentTemplate).AsSingle();
        Container.Bind<DateSO>().FromInstance(_dateSO).AsSingle();
        Container.Bind<TextMeshProUGUI>().FromInstance(_dateClocks).AsSingle();
        Container.Bind<ScoreChanger>().FromInstance(_scoreChanger).AsSingle();
        Container.Bind<RageChanger>().FromInstance(_rageChanger).AsSingle();
        Container.Bind<Swiper>().FromInstance(_documentTemplate).AsSingle();
    }
}