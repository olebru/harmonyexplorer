module.exports = function (grunt) {
    grunt.initConfig({
        // get the configuration info from package.json
        pkg: grunt.file.readJSON('package.json'),
        // create a clean task to remove production resource files under wwwroot
        clean: ["wwwroot/css/*"],
        // PostCSS - Tailwindcss and Autoprefixer
        postcss: {
            options: {
                map: true, // inline sourcemaps
                processors: [
                    require('tailwindcss')(),
                    require('autoprefixer') // add vendor prefixes
                ]
            },
            dist: {
                expand: true,
                cwd: 'Styles/',
                src: ['*.css'],
                dest: 'wwwroot/css/',
                ext: '.css'
            }
        }
    });
    // Load Grunt Plugins
    grunt.loadNpmTasks("grunt-contrib-clean");
    grunt.loadNpmTasks("grunt-postcss");
};