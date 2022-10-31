using UnityEngine;

namespace Assets.Scripts.Attacks_And_Abilities.Attacks
{
    public class Ability : MonoBehaviour
    {
        [SerializeField] private protected float _maxCoolDownTime = 2;
        private DecreaserTime decreaserTime;
        private protected float _cooldown = 0;
        private readonly float _minimumTimeForResetCooldown = 0.01f;
        public float CurrentMaxColdown { get => _maxCoolDownTime; private set => value = _maxCoolDownTime;}
        public DecreaserTime DecreaserTime { get => decreaserTime; private set => decreaserTime = value; }
        private void Awake() 
        {
            DecreaserTime = new DecreaserTime(_minimumTimeForResetCooldown);
        }
         private void OnDestroy() 
         {
           Pause.RemoveEntitie(DecreaserTime);
         }

    }
}
