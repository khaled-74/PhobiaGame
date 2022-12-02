using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Quests.PartQuests
{
    public enum Order
    {
        CaramelMacchiato,
        FlatWhite,
        CappuccinoSingleShot
    }
    
    public class OrderPartQuest : Quest
    {
        public bool IsStartedQuest;
        public Order SelectedOrder;
        public UnityEvent<bool> OnOrderSelect;

        private void Update()
        {
            if (IsFinished || !IsStartedQuest)
                return;
            if (Input.GetKeyDown(KeyCode.H))
            {
                IsFinished = true;
                OnOrderSelect?.Invoke(SelectedOrder == Order.CaramelMacchiato);
                CheckDebug(SelectedOrder == Order.CaramelMacchiato);
            }
            else if (Input.GetKeyDown(KeyCode.J))
            {
                IsFinished = true;
                OnOrderSelect?.Invoke(SelectedOrder == Order.FlatWhite);
                CheckDebug(SelectedOrder == Order.FlatWhite);
            }
            else if (Input.GetKeyDown(KeyCode.K))
            {
                IsFinished = true;
                OnOrderSelect?.Invoke(SelectedOrder == Order.CappuccinoSingleShot);
                CheckDebug(SelectedOrder == Order.CappuccinoSingleShot);
            }
        }

        private void CheckDebug(bool value)
        {
            if (value)
                DebugRight();
            else
                DebugWrong();
        } 
        
        private void DebugWrong() => Debug.Log("Wrong Order");
        private void DebugRight() => Debug.Log("Right Order");

        public override IEnumerator Progress()
        {
            IsStartedQuest = true;
            yield break;
        }
    }
}