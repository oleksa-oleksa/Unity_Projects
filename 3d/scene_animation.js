"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var __generator = (this && this.__generator) || function (thisArg, body) {
    var _ = { label: 0, sent: function() { if (t[0] & 1) throw t[1]; return t[1]; }, trys: [], ops: [] }, f, y, t, g;
    return g = { next: verb(0), "throw": verb(1), "return": verb(2) }, typeof Symbol === "function" && (g[Symbol.iterator] = function() { return this; }), g;
    function verb(n) { return function (v) { return step([n, v]); }; }
    function step(op) {
        if (f) throw new TypeError("Generator is already executing.");
        while (_) try {
            if (f = 1, y && (t = op[0] & 2 ? y["return"] : op[0] ? y["throw"] || ((t = y["return"]) && t.call(y), 0) : y.next) && !(t = t.call(y, op[1])).done) return t;
            if (y = 0, t) op = [op[0] & 2, t.value];
            switch (op[0]) {
                case 0: case 1: t = op; break;
                case 4: _.label++; return { value: op[1], done: false };
                case 5: _.label++; y = op[1]; op = [0]; continue;
                case 7: op = _.ops.pop(); _.trys.pop(); continue;
                default:
                    if (!(t = _.trys, t = t.length > 0 && t[t.length - 1]) && (op[0] === 6 || op[0] === 2)) { _ = 0; continue; }
                    if (op[0] === 3 && (!t || (op[1] > t[0] && op[1] < t[3]))) { _.label = op[1]; break; }
                    if (op[0] === 6 && _.label < t[1]) { _.label = t[1]; t = op; break; }
                    if (t && _.label < t[2]) { _.label = t[2]; _.ops.push(op); break; }
                    if (t[2]) _.ops.pop();
                    _.trys.pop(); continue;
            }
            op = body.call(thisArg, _);
        } catch (e) { op = [6, e]; y = 0; } finally { f = t = 0; }
        if (op[0] & 5) throw op[1]; return { value: op[0] ? op[1] : void 0, done: true };
    }
};
exports.__esModule = true;
var core_1 = require("@gltf-transform/core");
var functions_1 = require("@gltf-transform/functions");
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
;
var account = function () { return __awaiter(void 0, void 0, void 0, function () {
    return __generator(this, function (_a) {
        switch (_a.label) {
            case 0: return [4 /*yield*/, document.transform((0, functions_1.sequence)({ pattern: "josh" }))];
            case 1:
                _a.sent();
                return [2 /*return*/];
        }
    });
}); };
io.write('seq01/seq01.gltf', document);
