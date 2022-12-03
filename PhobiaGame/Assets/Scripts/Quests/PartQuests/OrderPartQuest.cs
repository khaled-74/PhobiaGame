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
        [SerializeField] private GameObject highlightPoint;
        [SerializeField] private Transform pointShowHighlight;
        [SerializeField] private GameObject coffeObject;

        public bool IsStartedQuest;
        public Order SelectedOrder;
        public UnityEvent<bool> OnOrderSelect;

        private void Start()
        {
            coffeObject.SetActive(false);
        }

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

        public void Choose(int index)
        {
            if (IsFinished)
                return;

            if (index == 0)
            {
                IsFinished = true;
                OnOrderSelect?.Invoke(SelectedOrder == Order.CaramelMacchiato);
                CheckDebug(SelectedOrder == Order.CaramelMacchiato);
            }
            else if (index == 1)
            {
                IsFinished = true;
                OnOrderSelect?.Invoke(SelectedOrder == Order.FlatWhite);
                CheckDebug(SelectedOrder == Order.FlatWhite);
            }
            else if (index == 2)
            {
                IsFinished = true;
                OnOrderSelect?.Invoke(SelectedOrder == Order.CappuccinoSingleShot);
                CheckDebug(SelectedOrder == Order.CappuccinoSingleShot);
            }
            coffeObject.SetActive(true);
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
            OnStartQuest?.Invoke();
            highlightPoint.SetActive(true);
            highlightPoint.transform.position = pointShowHighlight.position;
            IsStartedQuest = true;
            while (!IsFinished)
                yield return null;
            OnEndQuest?.Invoke();
        }
    }
}