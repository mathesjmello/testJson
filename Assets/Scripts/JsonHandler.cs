
using System;
using DefaultNamespace;
using UnityEngine;

public class JsonHandler : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey("space"))
        {
            TestGet();
        }
    }

    [ContextMenu("test get")]
    public async void TestGet()
    {
        
        string jsonString = "{\r\n    \"Items\": [\r\n        {\r\n            \"playerId\": \"8484239823\",\r\n            \"playerLoc\": \"Powai\",\r\n            \"playerNick\": \"Random Nick\"\r\n        },\r\n        {\r\n            \"playerId\": \"512343283\",\r\n            \"playerLoc\": \"User2\",\r\n            \"playerNick\": \"Rand Nick 2\"\r\n        }\r\n    ]\r\n}";

        var player = JsonHelper.FromJson<Player>(jsonString);
            
            Debug.Log(player[0].playerLoc);
            Debug.Log(player[1].playerLoc);
        
    }
}
