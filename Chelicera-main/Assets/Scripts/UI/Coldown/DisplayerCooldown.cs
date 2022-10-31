using Assets.Scripts.Attacks_And_Abilities.Attacks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayerCooldown : MonoBehaviour
{
    [SerializeField] private Ability _ability;
    [SerializeField] private Image _coldownImage;
    [SerializeField] private TMP_Text _coldownTextCounter;


    private void Update()
    {
        UpdateTimer();
    }
    private void UpdateTimer()
    {
        if (_ability.DecreaserTime.CoolDown <= 0)
        {
            _coldownTextCounter.text = "";
            return;
        }
        if (_ability.DecreaserTime.CoolDown > _ability.CurrentMaxColdown) {
            return;
        }
        _coldownImage.fillAmount = _ability.DecreaserTime.CoolDown / _ability.CurrentMaxColdown;
        _coldownTextCounter.text = ("" + Mathf.Round(_ability.DecreaserTime.CoolDown));
    }
}
