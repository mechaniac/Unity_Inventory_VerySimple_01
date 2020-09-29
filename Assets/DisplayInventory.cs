using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DisplayInventory : MonoBehaviour
{
    public InventoryObject inventory;

    public int X_Space_betweenItems;
    public int Y_Space_betweenItems;
    public int numberOfColumns;
    Dictionary<InventorySlot, Image> itemsDisplayed = new Dictionary<InventorySlot, Image>();
    void Start()
    {
        CreateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            if (itemsDisplayed.ContainsKey(inventory.Container[i]))
            {
                itemsDisplayed[inventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
                //.Log($"Have: {inventory.Container[i].item.type}");
            }
            else
            {
                AddImage(i);

                Debug.Log($"Add: {inventory.Container[i].item.type}");
            }
        }
    }

    public void CreateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
        }
    }

    void AddImage(int i)
    {
        var img = Instantiate(inventory.Container[i].item.imagePrefab, Vector3.zero, Quaternion.identity, transform);
        img.GetComponent<RectTransform>().localPosition = GetPosition(i);
        img.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
        itemsDisplayed.Add(inventory.Container[i], img);
    }

    public Vector3 GetPosition(int i)
    {
        return new Vector3(X_Space_betweenItems * (i % numberOfColumns), (Y_Space_betweenItems * (i / numberOfColumns)), 0f);
    }
}
