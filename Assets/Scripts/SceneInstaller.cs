using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] Image progressBar;
    [SerializeField] Text levelText;

    public override void InstallBindings()
    {

        BindUIService();
        BindPlayer();
    }

    private void BindUIService()
    {
        Container.Bind<Image>().FromInstance(progressBar);
        Container.Bind<Text>().FromInstance(levelText);
        Container.BindInterfacesAndSelfTo<UIService>().AsSingle();
    }
    private void BindPlayer()
    {
        Container.Bind<Player>().AsSingle();
    }
}