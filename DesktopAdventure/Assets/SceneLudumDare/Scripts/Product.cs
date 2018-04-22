using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class Product {

    public Products[] products;

    [Serializable]
    public struct Products
    {
        public string Product;
        public string Quantity;
        public int Calories;
    }
}
