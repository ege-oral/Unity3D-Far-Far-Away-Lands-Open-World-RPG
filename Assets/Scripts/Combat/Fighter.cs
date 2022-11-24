using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using UnityEngine.AI;

namespace RPG.Combat
{
   public class Fighter : MonoBehaviour
    {
        Transform target;
        Mover mover;
        [SerializeField] float stopDistance = 2f;

        private void Start() 
        {
            mover = GetComponent<Mover>();
        }

        private void Update() 
        {
            if(target != null)
            {
                float distance = Vector3.Distance(target.position, transform.position);
                if(distance <= stopDistance)
                {
                    print("Charggg");
                    mover.Stop();
                    target = null;
                }
                else
                {
                    mover.MoveTo(target.position);
                }
            }
        }
        
        public void Attack(CombatTarget combatTarget)
        {
            target = combatTarget.transform;
        }
    }
}
