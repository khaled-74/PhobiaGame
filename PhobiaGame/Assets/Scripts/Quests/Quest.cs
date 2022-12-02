using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Quests
{
    public abstract class Quest : MonoBehaviour
    {
        [HideInInspector] public bool IsFinished = false;
        
        public UnityEvent OnStartQuest;
        public UnityEvent OnEndQuest;
        public UnityEvent OnQuestSuccess;
        public UnityEvent OnQuestFailed;
        
        public abstract IEnumerator Progress();
    }
}