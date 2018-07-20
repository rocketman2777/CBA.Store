module.exports = function () {
    var outputRootPath = "C:\\Websites\\CBA";
    var config = {
        solutionName: "CBA.Store",
        apiProject: "./CBA.Store.Api/CBA.Store.Api.csproj",
        webProject: "./CBA.Store.Web/CBA.Store.Web.csproj",
        apiTargetPath: outputRootPath + "\\apiroot",
        webTargetPath: outputRootPath + "\\wwwroot",
        databaseTarget: outputRootPath + "/release/database",
        packageTarget: outputRootPath + "/release",
        buildConfiguration: "Debug",
        buildToolsVersion: 15.0,
        buildMaxCpuCount: 0,
        buildVerbosity: "minimal",
        buildPlatform: "Any CPU",
        publishPlatform: "AnyCpu",
        runCleanBuilds: false
    };
    return config;
    return config;
};