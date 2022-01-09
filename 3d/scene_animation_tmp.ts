import { Document, NodeIO } from '@gltf-transform/core';
import { sequence } from '@gltf-transform/functions';
import * as process from 'process';
import * as glob from 'glob';

const io = new NodeIO();
const document = new Document();

const meshPathMask = process.argv[2];
const meshPaths = glob.sync(meshPathMask);
console.log(meshPaths);

for (const path of meshPaths) {
	  document.merge(io.read(path));
}

const root = document.getRoot();
const mainScene = root.listScenes()[0];

for (const scene of root.listScenes()) {
  if (scene === mainScene) continue;

  for (const child of scene.listChildren()) {
    scene.addChild(child);
    // If conditions are met, append child to `mainScene`. 
    // Doing so will automatically detach it from the
    // previous scene.
  }
  
  scene.dispose();

  };


  const account = async () => {
  	await document.transform(
		 sequence()
	  );

  };

io.write('foo.gltf', document);
