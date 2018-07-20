module.exports = function () {
    var outputRootPath = process.cwd();
    var config = {
        solutionName: "CBA.Store",
        apiProject: "./CBA.Store.Api/CBA.Store.Api.csproj",
        webProject: "./CBA.Store.Web/CBA.Store.Web.csproj",
        databaseLocation: "./CBA.Store.Database/bin/Release/*.dacpac",
        apiTargetPath: outputRootPath + "/publish/apiroot",
        webTargetPath: outputRootPath + "/publish/wwwroot",
        databaseTarget: outputRootPath + "/release",
        packageTarget: outputRootPath + "/release",
        buildConfiguration: "Release",
        buildToolsVersion: 15.0,
        buildMaxCpuCount: 0,
        buildVerbosity: "minimal",
        buildPlatform: "Any CPU",
        publishPlatform: "AnyCpu",
        runCleanBuilds: false
    };
    return config;
};
