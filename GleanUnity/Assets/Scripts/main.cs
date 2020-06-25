using Mozilla.Glean;
using Mozilla.Glean.Private;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Mozilla.Glean.Glean;

public class main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Redirect third party library logs to Unity panel.
        SystemConsoleRedirector.Redirect();

        Console.WriteLine("Begin Glean test.");

        GleanInstance.Initialize(
               applicationId: "org.mycompany.glean.tests",
               applicationVersion: "0.1",
               uploadEnabled: true,
               configuration: new Configuration(),
               dataDir: "data"
               );

        // Create a custom ping.
        var ping = new PingType<NoReasonCodes>(
            name: "custom",
            includeClientId: true,
            sendIfEmpty: false,
            reasonCodes: null
        );

        // Init launch ping.
        var metric = new StringMetricType(
            category: "hello_world",
            disabled: false,
            lifetime: Lifetime.Application,
            name: "test",
            sendInPings: new string[] { "custom" }
        );

        metric.Set("my_data");

        ping.Submit();

        Console.WriteLine("End of Glean test.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
