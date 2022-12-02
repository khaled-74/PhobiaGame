using System.Collections;
using Quests;
using UnityEngine;
using UnityEngine.AI;

namespace AI
{
    public class AIController : MonoBehaviour
    {
        private Quest _selectedTask;
        
        private void Start()
        {
            StartCoroutine(WaitToSeat());
        }

        private IEnumerator WaitToSeat()
        {
            yield return new WaitForSeconds(5f);
        }

        public void SelectTask(Quest selectedTask)
        {
            _selectedTask = selectedTask;
        }
    }
}