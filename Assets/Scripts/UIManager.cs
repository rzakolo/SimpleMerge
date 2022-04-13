using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Image progressBar;
    [SerializeField] Text levelText;
    [SerializeField] Player player;
    private void Start()
    {
        player.OnExpEarn += ChangeExp;
        player.OnLevelUp += ChangeLevel;
    }

    private void ChangeExp(float value)
    {
        progressBar.fillAmount += value;
    }
    private void ChangeLevel(int value)
    {
        progressBar.fillAmount = 0f;
        levelText.text = value.ToString();
    }
}
