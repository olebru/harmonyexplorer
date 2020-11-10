Nice to know...


Needs Node.Js

To rebuild Tailwind site.css... 

npm install gulp-cli -g

package.json ->

    {
  "devDependencies": {
    "gulp": "^4.0.2",
    "gulp-postcss": "^8.0.0",
    "precss": "^4.0.0",
    "tailwindcss": "^1.2.0",
    "autoprefixer": "^9.7.4"
  }
}

gulpfile.js ->

const gulp = require('gulp');

gulp.task('css', () => {
  const postcss = require('gulp-postcss');

  return gulp.src('./Styles/site.css')
    .pipe(postcss([
      require('precss'),
      require('tailwindcss'),
      require('autoprefixer')
    ]))
    .pipe(gulp.dest('./wwwroot/css/'));
});

npm install
gulp css