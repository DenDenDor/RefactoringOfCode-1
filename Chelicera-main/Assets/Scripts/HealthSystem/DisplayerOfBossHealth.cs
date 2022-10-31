using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DisplayerOfBossHealth : BasicHealthSystem
{
    //[SerializeField] private BasicHealthSystem _bossHP;
    [SerializeField] private Slider _slider;

    private void Awake()
    {
        SetMaxValue();
        OnApplyDamage += SetCurrentValue;
    }
    private void SetMaxValue() 
    {
        _slider.maxValue = MaxHealth; 
    }

    private void SetCurrentValue() 
    {
        _slider.value = Health;
    }
    protected override void Die() 
    {
        SceneManager.LoadScene(0);
    }
    private void OnDisable() 
    {
         OnApplyDamage -= SetCurrentValue;
    }
}
