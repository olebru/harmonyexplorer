Rebuilding css with tailwind (not included in build pipeline due to compability with Azure static webpage job)

Remove extension from:
  package.json.removeExtForTailwindBuild 
  gulpefile.js.removeExtForTailwindBuild

npm install gulp-cli -g
npm install
gulp css
