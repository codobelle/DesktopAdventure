using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class User  {

    public List<UserData> users;

    [Serializable]
    public struct UserData
    {
        public string name;
        public int age;
        public int activity;
        public int height;
        public int weight;
    }
}
