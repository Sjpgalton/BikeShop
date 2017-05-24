/// <binding AfterBuild='styles' />
var gulp = require('gulp');
    sass = require('gulp-sass');

//style paths
var sassFiles = 'Content/site.scss',
    cssDest = 'Content';


gulp.task('styles', function() {
    gulp.src(sassFiles)
        .pipe(sass().on('error', sass.logError))
        .pipe(gulp.dest(cssDest));
});

gulp.task('watch', function() {
    gulp.watch(sassFiles,['styles']);
});