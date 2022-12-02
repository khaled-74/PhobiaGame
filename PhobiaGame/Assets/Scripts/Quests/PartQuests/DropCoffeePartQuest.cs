using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Quests.PartQuests
{
    public class DropCoffeePartQuest : Quest
    {
        [SerializeField] private Transform player;
        [SerializeField] private Transform pointDrop;
        [SerializeField] private float distanceCheck;

        public UnityEvent OnDropCoffee;

        public override IEnumerator Progress()
        {
            float distance = Vector3.Distance(player.position, pointDrop.position);
            while (distance > distanceCheck)
            {
                distance = Vector3.Distance(player.position, pointDrop.position);
                Debug.DrawLine(player.position, pointDrop.position, Color.red);
                yield return null;
            }
            
            OnDropCoffee?.Invoke();
            IsFinished = true;
        }

        private void OnDrawGizmos()
        {
            if (pointDrop)
                Gizmos.DrawWireSphere(pointDrop.position, distanceCheck);
        }
    }
}