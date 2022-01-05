"use strict";
exports.__esModule = true;
var core_1 = require("@gltf-transform/core");
var process = require("process");
var glob = require("glob");
var io = new core_1.NodeIO();
var document = new core_1.Document();
var meshPathMask = process.argv[2];
var meshPaths = glob.sync(meshPathMask);
console.log(meshPaths);
for (var _i = 0, meshPaths_1 = meshPaths; _i < meshPaths_1.length; _i++) {
    var path = meshPaths_1[_i];
    document.merge(io.read(path));
}
var root = document.getRoot();
var mainScene = root.listScenes()[0];
for (var _a = 0, _b = root.listScenes(); _a < _b.length; _a++) {
    var scene = _b[_a];
    if (scene === mainScene)
        continue;
    for (var _c = 0, _d = scene.listChildren(); _c < _d.length; _c++) {
        var child = _d[_c];
        scene.addChild(child);
        // If conditions are met, append child to `mainScene`. 
        // Doing so will automatically detach it from the
        // previous scene.
    }
    scene.dispose();
}
io.write('foo.gltf', document);
