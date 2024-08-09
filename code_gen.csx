#!/usr/bin/env dotnet-script
// If you have any questions about this file, check out https://github.com/StateSmith/tutorial-2
#r "nuget: StateSmith, 0.11.2-alpha"

using StateSmith.Common;
using StateSmith.Input.Expansions;
using StateSmith.Output.UserConfig;
using StateSmith.Runner;

// here we generate code for C, C#, and JavaScript
new SmRunner(diagramPath: "LightSm.plantuml", new CRenderConfig(), outputDirectory: "c", transpilerId: TranspilerId.C99).Run();
new SmRunner(diagramPath: "LightSm.plantuml", new CSharpRenderConfig(), outputDirectory: "c#", transpilerId: TranspilerId.CSharp).Run();
new SmRunner(diagramPath: "LightSm.plantuml", new JavaScriptRenderConfig(), outputDirectory: "js", transpilerId: TranspilerId.JavaScript).Run();


public class CRenderConfig : IRenderConfigC
{
    string IRenderConfig.AutoExpandedVars => """
        int count;
        """;

    // This include allows the generated state machine to call Light.h functions.
    // Only the C example has a test harness right now.
    string IRenderConfigC.CFileIncludes => """
        #include "Light.h" // so we can call functions
        """;
}

public class CSharpRenderConfig : IRenderConfigCSharp
{
    string IRenderConfig.AutoExpandedVars => """
        int count;
        """;
}

public class JavaScriptRenderConfig : IRenderConfigJavaScript
{
    string IRenderConfig.AutoExpandedVars => """
        count: 0,
        """;
}
