Rebuilding css with tailwind (not included in build pipeline due to compability with Azure static webpage job)<br>

Remove extension from:<br>

  package.json.removeExtForTailwindBuild <br>

  gulpefile.js.removeExtForTailwindBuild<br>


npm install gulp-cli -g<br>

npm install<br>

gulp css<br>

