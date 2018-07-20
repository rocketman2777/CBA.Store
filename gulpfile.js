var gulp = require("gulp");
var msbuild = require("gulp-msbuild");
var debug = require("gulp-debug");
var del = require('del');
var path = require("path");
var runSequence = require("run-sequence");
var nugetRestore = require('gulp-nuget-restore');
var zip = require('gulp-zip');
var yargs = require("yargs").argv;

var config = require("./gulp-config.js")();
//config = require("./gulp-config-local.js")();
module.exports.config = config;

gulp.task("default", function (callback) {
    config.runCleanBuilds = true;
    return runSequence(
      "01-Nuget-Restore",
      "02-Build-Solution",
      "04-Publish-API",
      "05-Publish-Web",
      "06-Package-Api",
      "07-Package-Web",
      "08-Publish-Database",
      callback);
});

gulp.task("01-Nuget-Restore", function (callback) {
    var solution = "./" + config.solutionName + ".sln";
    return gulp.src(solution).pipe(nugetRestore());
});

gulp.task("02-Build-Solution", function () {
    var targets = ["Build"];
    if (config.runCleanBuilds) {
        targets = ["Clean", "Build"];
    }

    var solution = "./" + config.solutionName + ".sln";
    return gulp.src(solution)
        .pipe(msbuild({
            targets: targets,
            configuration: config.buildConfiguration,
            logCommand: false,
            verbosity: config.buildVerbosity,
            stdout: true,
            errorOnFail: true,
            maxcpucount: config.buildMaxCpuCount,
            nodeReuse: false,
            toolsVersion: config.buildToolsVersion,
            properties: {
                Platform: config.buildPlatform
            }
        }));
});

gulp.task("04-Publish-API", function () {
    var targets = ["Build"];

    return gulp.src(config.apiProject)
        .pipe(debug({ title: "Publishing project:" }))
        .pipe(msbuild({
            targets: targets,
            configuration: config.buildConfiguration,
            logCommand: false,
            verbosity: config.buildVerbosity,
            stdout: true,
            errorOnFail: true,
            maxcpucount: config.buildMaxCpuCount,
            nodeReuse: false,
            toolsVersion: config.buildToolsVersion,
            properties: {
                Platform: config.publishPlatform,
                DeployOnBuild: "true",
                DeployDefaultTarget: "WebPublish",
                WebPublishMethod: "FileSystem",
                DeleteExistingFiles: "false",
                publishUrl: config.apiTargetPath,
                BuildProjectReferences: false,
                _FindDependencies: "false"
            }
        }));
});

gulp.task("05-Publish-Web", function () {
    var targets = ["Build"];

    return gulp.src(config.webProject)
        .pipe(debug({ title: "Publishing project:" }))
        .pipe(msbuild({
            targets: targets,
            configuration: config.buildConfiguration,
            logCommand: false,
            verbosity: config.buildVerbosity,
            stdout: true,
            errorOnFail: true,
            maxcpucount: config.buildMaxCpuCount,
            nodeReuse: false,
            toolsVersion: config.buildToolsVersion,
            properties: {
                Platform: config.publishPlatform,
                DeployOnBuild: "true",
                DeployDefaultTarget: "WebPublish",
                WebPublishMethod: "FileSystem",
                DeleteExistingFiles: "false",
                publishUrl: config.webTargetPath,
                BuildProjectReferences: false,
                _FindDependencies: "false"
            }
        }));
});

gulp.task("06-Package-Api", function () {
    gulp.src(config.apiTargetPath + "/**/*")
        .pipe(zip('apiroot.zip'))
        .pipe(gulp.dest(config.packageTarget))
});

gulp.task("07-Package-Web", function () {
    gulp.src(config.webTargetPath + "/**/*")
        .pipe(zip('webroot.zip'))
        .pipe(gulp.dest(config.packageTarget))
});

gulp.task("08-Publish-Database", function () {
    gulp.src(config.databaseLocation)
        .pipe(gulp.dest(config.databaseTarget));
});

