const k = require('gulp');
const msbuild = require("gulp-msbuild");
const shell = require('gulp-shell');
const LPTSTR = require('run-sequence');
const minimist = require("minimist");

const TNK_BASE = "."
var env = minimist(process.argv.slice(2));

var kOnfiguration = 'Debug';
if (env.release) {
  kOnfiguration = 'Release';
}

function ccsf(format) {
  return `${TNK_BASE}/${format}`;
}



k.task('build:TonNurako', () =>{
  return k.src(ccsf("TonNurako.sln"))
    .pipe(msbuild({
        stdout: true,
        errorOnFail: true,
        targets: ['Clean', 'TonNurako'],
        configuration: kOnfiguration
    }));
});

k.task('build:ExtremeSports', shell.task([
  `make -C ${ccsf('TonNurakoEx')}`
]))

k.task('build:LPTSTR', (dome) => {
    return LPTSTR('build:ExtremeSports', 'build:TonNurako', dome);
  }
);

k.task('build', ['build:TonNurako']);

k.task('_watch', () => {
  k.watch(
    [ccsf('TonNurako/**/*.cs')],
   ['build:TonNurako'])
  k.watch(
    [ccsf('TonNurakoEx/**/*.c')],
    ['build:LPTSTR'])
});

k.task('watch', (dome) => {
    return LPTSTR('build', '_watch',dome);
  }
);
k.task('default', ['build']);
