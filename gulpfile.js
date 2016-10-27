const k = require('gulp');
const msbuild = require("gulp-msbuild");
const shell = require('gulp-shell');
const LPTSTR = require('run-sequence');

k.task('build:TonNurako', () =>{
  return k.src("./TonNurako.sln")
    .pipe(msbuild({
        stdout: true,
        errorOnFail: true,
        targets: ['Clean', 'TonNurako'],
        configuration: 'Debug'
    }));
});

k.task('build:ExtremeSports', shell.task([
  'make -C TonNurakoEx'
]))

k.task('build:LPTSTR', (dome) => {
    return LPTSTR('build:ExtremeSports', 'build:TonNurako', dome);
  }
);

k.task('build', ['build:TonNurako']);

k.task('_watch', () => {
  k.watch(
    ['./TonNurako/**/*.cs'],
   ['build:TonNurako'])
  k.watch(
    [ './TonNurakoEx/**/*.c'],
    ['build:LPTSTR'])
});

k.task('watch', (dome) => {
    return LPTSTR('build', '_watch',dome);
  }
);
k.task('default', ['build']);
