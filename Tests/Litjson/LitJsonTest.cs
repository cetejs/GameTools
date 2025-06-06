using System.Collections.Generic;
using UnityEngine;
using LitJson;
using NUnit.Framework;

public class LitJsonTest
{
    public class TestData
    {
        public int a;
        public float b;
        public string c;
        public List<int> d;
        public Dictionary<int, string> e;
        public Vector3 f;
        [JsonIgnore]
        public int g;
    }

    [Test]
    public void Test()
    {
        TestData data = new TestData()
        {
            a = 1,
            b = 2.1f,
            c = "3",
            d = new List<int>()
            {
                1, 2, 3
            },
            e = new Dictionary<int, string>()
            {
                { 1, "1" },
                { 2, "2" },
                { 3, "3" },
            },
            f = new Vector3(1, 2, 3),
            g = 100
        };

        string json = JsonMapper.ToJson(data);
        Debug.Log(json);
        TestData newData = JsonMapper.ToObject<TestData>(json);
        Debug.Log( $"{newData.a} {newData.b} {newData.c} {string.Join(",", newData.d)} " +
                   $"{string.Join(",", newData.e.Keys)} {string.Join(",", newData.e.Values)} {newData.f} {newData.g}");
    }
}